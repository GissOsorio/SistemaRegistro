using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Codificador
{
  public  class ElementoLogin
    {
        public String nombre;
        public String apellido;
        public int validacion;
        public ElementoLogin(String nombre, String apellido, int validacion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.validacion = validacion;
        }
        public ElementoLogin()
        {

        }

        public override string ToString()
        {
            String separador = "\n";
            String valor = "Nombre: " + nombre + separador + "Apellido: " + apellido + separador + "Validacion: " + validacion + separador;
            return valor;
        }
    }

}