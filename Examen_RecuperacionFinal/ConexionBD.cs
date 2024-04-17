using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_RecuperacionFinal
{
    public class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            string connectionString = "Data Source=LAPTOP-PK2H1RHP;Initial Catalog=BD_RUTASTURISTICAS;Integrated Security=True";
            SqlConnection conexion = new SqlConnection(connectionString);
            return conexion;
        }
    }
}
