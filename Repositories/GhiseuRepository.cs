using Microsoft.Data.SqlClient;

namespace ServiciiPubliceBackend.Repositories
{
    public class GhiseuRepository
    {
        private readonly SqlConnection _sqlConnection;

        public GhiseuRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
    }
}
