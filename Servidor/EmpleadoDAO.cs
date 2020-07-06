using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codificador;
using System.Data.SqlClient;

namespace Servidor
{
    public class EmpleadoDAO
    {
        public static List<Empleado> obtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            SqlConnection con = myDB.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from Empleado", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empleado auxiliar = new Empleado();
                    auxiliar.id = reader.GetInt32(0);
                    auxiliar.nombre = reader.GetString(1);
                    auxiliar.apellido = reader.GetString(2);
                    auxiliar.contraseña = reader.GetString(3);
                    auxiliar.user = reader.GetString(4);
                    empleados.Add(auxiliar);
                }
            }
            return empleados;
        }
    }
}
