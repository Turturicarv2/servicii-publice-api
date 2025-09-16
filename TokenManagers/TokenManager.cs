using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiciiPubliceBackend.TokenManagers
{
    public class TokenManager : ITokenManager
    {
        private readonly string _jwtSecret;
        public TokenManager(IConfiguration config)
        {
            _jwtSecret = config["ApplicationSettings:JWT_Secret"]!;
        }

        public string GenerateJWTToken(string role)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Iss, "http://localhost:5173"),
                new Claim(JwtRegisteredClaimNames.Aud, "ServiciiPublice")
            };

            var jwtToken = new JwtSecurityToken(
                claims: claim,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_jwtSecret)
                    ),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
