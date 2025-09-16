namespace ServiciiPubliceBackend.DbQueries
{
    public class UserQueryManager
    {
        public string addUserQuery = "INSERT INTO Users " +
            "(Username, Password, Role) " +
            "VALUES (@Username, @Password, @Role)";
        public string loginUserQuery = "SELECT Role FROM Users " +
            "WHERE Username = @Username AND Password = @Password";
    }
}
