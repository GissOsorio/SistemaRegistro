using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Codificador;
namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = 8080;
            TcpListener socketEscucha = new TcpListener(IPAddress.Any, puerto);
            socketEscucha.Start();
            TcpClient cliente = socketEscucha.AcceptTcpClient();
            DecodificadorTexto decodificador = new DecodificadorTexto();
            Elemento elemento = decodificador.Decodificar(cliente.GetStream());

            Empleado EmpleadoR = new Empleado();

            EmpleadoR = buscarEmpleado(elemento);

            CodificadorTexto codificador = new CodificadorTexto();
            ElementoLogin elemento2;
            if (EmpleadoR==null)
            {
                elemento2 = new ElementoLogin(null,null,0);
            }
            else
            {
                elemento2 = new ElementoLogin(EmpleadoR.nombre, EmpleadoR.apellido, 1);
            }
            
            byte[] bytesParaEnviar = codificador.CodificarLogin(elemento2);
            Console.WriteLine("(" + bytesParaEnviar.Length + " bytes): ");
            cliente.GetStream().Write(bytesParaEnviar, 0, bytesParaEnviar.Length);
            cliente.Close();
            socketEscucha.Stop();
            Console.ReadLine();
        }
        public static Empleado buscarEmpleado(Elemento elemento)
        {
            Empleado empleado = new Empleado();
            List<Empleado> lista = new List<Empleado>();
            lista=EmpleadoDAO.obtenerEmpleados();

            foreach (var item in lista)
            {
                if (elemento.user == item.user && elemento.contraseña == item.contraseña)
                {
                    empleado.nombre = item.nombre;
                    empleado.id = item.id;
                    empleado.apellido = item.apellido;
                    empleado.user = item.user;
                    empleado.contraseña = item.contraseña;
                    return empleado;
                }
                else
                {
                    empleado = null;
                }

            }
            return empleado;
        }
    }


}