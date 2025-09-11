using FluentMigrator;

namespace ServiciiPubliceBackend.Migrations
{
    [Migration(202509110004)]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Role").AsString().NotNullable();

            Alter.Table("Bon")
                .AddColumn("UserId").AsInt32().NotNullable();

            Create.ForeignKey("FK_Users_Bon")
                .FromTable("Bon").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Users_Bon").OnTable("Users");
            Delete.Column("UserId").FromTable("Bon");
            Delete.Table("Users");
        }
    }
}
