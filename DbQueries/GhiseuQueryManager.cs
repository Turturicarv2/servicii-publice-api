namespace ServiciiPubliceBackend.DbQueries
{
    public class GhiseuQueryManager
    {
        public string getAllGhiseeQuery = "SELECT * FROM Ghiseu";
        public string addGhiseuQuery = "INSERT INTO Ghiseu " +
                "(Cod, Denumire, Descriere, Icon, Activ) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@Cod, @Denumire, @Descriere, @Icon, @Activ)";
        public string editGhiseuQuery = "UPDATE Ghiseu " +
                "SET Cod = @Cod, " +
                "Denumire = @Denumire, " +
                "Descriere = @Descriere, " +
                "Icon = @Icon " +
                "WHERE Id = @Id";
        public string markGhiseuActiveQuery = "UPDATE Ghiseu " +
                "SET Activ = 1 " +
                "WHERE Id = @Id";
        public string markGhiseuInactiveQuery = "UPDATE Ghiseu " +
                "SET Activ = 0 " +
                "WHERE Id = @Id";
        public string deleteGhiseuQuery = "DELETE FROM Ghiseu " +
                "WHERE Id = @Id";

        public GhiseuQueryManager() { }
    }
}
