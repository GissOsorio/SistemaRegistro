using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class myDB
    {

        public static SqlConnection obtenerConexion()
        {
            SqlConnection con = new SqlConnection(@"Data Source=USER;Initial Catalog=Sistema_Registro;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            return con;
        }


    }
}