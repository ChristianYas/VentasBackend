

using System.Data.SqlClient;

namespace Ventas.DBConexion
{
    public class Conexion
    {

        public SqlConnection getConnection()
        {

            string server = "RCNGTO058194L\\SQLEXPRESS";
            string bd = "tienda";

            string connectionString = $"Data Source={server};Initial Catalog={bd};Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
