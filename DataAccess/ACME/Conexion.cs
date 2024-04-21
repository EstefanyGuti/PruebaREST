using Microsoft.Data.SqlClient;

namespace DataAccess.ACME
{
    public class Conexion
    {
        private readonly string? _cadenaConecion;
        public Conexion()
        {
            string? cadenaConexion;
            cadenaConexion = Environment.GetEnvironmentVariable("SQLServerXE");
            _cadenaConecion = cadenaConexion;
        }
        public SqlConnection Conectar()
        {
            SqlConnection sqlConn;

            sqlConn = new SqlConnection(_cadenaConecion);
            return sqlConn;
        }
    }
}
