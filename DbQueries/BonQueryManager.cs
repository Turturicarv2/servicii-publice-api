namespace ServiciiPubliceBackend.DbQueries
{
    public class BonQueryManager
    {
        public string getAllBonQuery = "SELECT * FROM Bon";
        public string addBonQuery = "INSERT INTO Bon " +
                "(IdGhiseu, Stare, CreatedAt) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@IdGhiseu, @Stare, @CreatedAt)";
        public string markBonInProgressQuery = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";
        public string markBonReceivedQuery = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";
        public string markBonClosedQuery = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";
        public BonQueryManager() { }
    }
}
