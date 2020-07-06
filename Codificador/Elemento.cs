using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Codificador
{
    public class Elemento
    {
        public String user;
        public String contraseña;
        public int operacion;
        public Elemento(String user, String contraseña, int operacion)
        {
            this.user = user;
            this.contraseña = contraseña;
            this.operacion = operacion;
        }

        public override string ToString()
        {
            String separador = "\n";
            String valor = "User: " + user + separador + "Contraseña: " + contraseña + separador + "operacion: " + operacion + separador;
            return valor;
        }
    }


    public interface CodificadorElemento
    {
        byte[] Codificar(Elemento elemento);
    }
    public interface DecodificadorElemento
    {
        Elemento Decodificar(Stream dato);
        Elemento Decodificar(byte[] paquete);
    }
}

