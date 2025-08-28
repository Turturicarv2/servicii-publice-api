using FluentMigrator;

namespace ServiciiPubliceBackend.Migrations
{
    [Migration(202508270002)]
    public class CreateGhiseuTable : Migration
    {
        public override void Up()
        {
            Create.Table("Ghiseu")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Cod").AsString(25).NotNullable()
                .WithColumn("Denumire").AsString(50).NotNullable()
                .WithColumn("Descriere").AsString(100).NotNullable()
                .WithColumn("Icon").AsString(100).NotNullable()
                .WithColumn("Activ").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Ghiseu");
        }
    }
}
