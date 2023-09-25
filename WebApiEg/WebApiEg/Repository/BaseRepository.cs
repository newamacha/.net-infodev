using System.Data;
using System.Data.SqlClient;
using WebApiEg.Helper;

namespace WebApiEg.Repository
{
    public class BaseRepository
    {
        public SqlConnection Connection()
        {
            string connectionString = new Connection().GetConectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;  
        }
    }
}
