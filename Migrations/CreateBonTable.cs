using FluentMigrator;

namespace ServiciiPubliceBackend.Migrations
{
    [Migration(202508270003)]
    public class CreateBonTable : Migration
    {
        public override void Up()
        {
            Create.Table("Bon")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdGhiseu").AsInt32().NotNullable()
                .WithColumn("Stare").AsString(20).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("ModifiedAt").AsDateTime().Nullable();

            Create.ForeignKey("FK_Bon_Ghiseu")
                .FromTable("Bon").ForeignColumn("IdGhiseu")
                .ToTable("Ghiseu").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            Execute.Sql(@"
                ALTER TABLE Bon
                ADD CONSTRAINT CK_Bon_Stare
                CHECK (Stare IN ('in asteptare', 'preluat', 'inchis'));
            ");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Bon_Ghiseu").OnTable("Bon");
            Delete.Table("Bon");
        }
    }
}
