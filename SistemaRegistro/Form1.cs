using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Codificador;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRegistro
{
    public partial class frmLogin : Form
    {
        Empleado emlog = new Empleado();
        public frmLogin()
        {
            InitializeComponent();
        }

      
        public void limpiarCampos()
        {
            txtuser.Clear();
            txtPass.Clear();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            Thread.Sleep(500);
            IPAddress servidor = IPAddress.Parse("127.0.0.1");
            int puerto = 8080;
            IPEndPoint extremo = new IPEndPoint(servidor, puerto);
            TcpClient cliente = new TcpClient();
            cliente.Connect(extremo);
            NetworkStream flujoRed = cliente.GetStream();
            Elemento elemento = new Elemento(txtuser.Text, txtPass.Text, 1);
            CodificadorTexto codificador = new CodificadorTexto();
            byte[] datosCodificados = codificador.Codificar(elemento);
            flujoRed.Write(datosCodificados, 0, datosCodificados.Length);
            DecodificadorTexto decodificador = new DecodificadorTexto();
            ElementoLogin elementoRecibido = decodificador.DecodificarLogin(cliente.GetStream());
            if (elementoRecibido.validacion == 1)
            {
                emlog.nombre = elementoRecibido.nombre;
                emlog.apellido = elementoRecibido.apellido;
                frmJornada n1 = new frmJornada();
                n1.Show();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiarCampos();
                txtuser.Focus();
            }
            flujoRed.Close();
            cliente.Close();
            
        }

    }
}
