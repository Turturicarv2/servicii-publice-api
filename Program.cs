using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Loggers;
using ServiciiPubliceBackend.Repositories;
using ServiciiPubliceBackend.TokenManagers;
using ServiciiPubliceBackend.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add serilog services to the container and read config from appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add Hangfire services
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddHangfireServer();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// ADD JWT Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(jwtOptions =>
{
    jwtOptions.RequireHttpsMetadata = false;
    jwtOptions.SaveToken = false;
    jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"]!)
        ),
        ValidateIssuer = true,
        ValidIssuer = "http://localhost:5173",

        ValidateAudience = true,
        ValidAudience = "ServiciiPublice",
        
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IBonRepository, BonRepository>();
builder.Services.AddScoped<IGhiseuRepository, GhiseuRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITokenManager, TokenManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHangfireDashboard();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
