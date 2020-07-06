using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace Codificador
{
    public class ConstantesCodificadorTexto
    {
        public static readonly String CODIFICACION_POR_DEFECTO = "ascii";
        public static readonly int LONG_MAX_FLUJO = 1024;
    }

    public class CodificadorTexto : CodificadorElemento
    {
        public Encoding codificador;
        public CodificadorTexto() : this(ConstantesCodificadorTexto.CODIFICACION_POR_DEFECTO)
        {
        }
        public CodificadorTexto(string datos)
        {
            codificador = Encoding.GetEncoding(datos);
        }
        public byte[] Codificar(Elemento elemento)
        {
            String cadenaCodificada = elemento.user + "\n";
            cadenaCodificada = cadenaCodificada + elemento.contraseña + "\n";
            cadenaCodificada = cadenaCodificada + elemento.operacion + "\n";
            if (cadenaCodificada.Length > ConstantesCodificadorTexto.LONG_MAX_FLUJO)
                throw new IOException("Longitud codificada demasiado grande");
            byte[] bufer = codificador.GetBytes(cadenaCodificada);
            return bufer;
        }
        public byte[] CodificarLogin(ElementoLogin elemento)
        {
            String cadenaCodificada = elemento.nombre + "\n";
            cadenaCodificada = cadenaCodificada + elemento.apellido + "\n";
            cadenaCodificada = cadenaCodificada + elemento.validacion + "\n";
            if (cadenaCodificada.Length > ConstantesCodificadorTexto.LONG_MAX_FLUJO)
                throw new IOException("Longitud codificada demasiado grande");
            byte[] bufer = codificador.GetBytes(cadenaCodificada);
            return bufer;
        }
    }
    public class DecodificadorTexto : DecodificadorElemento
    {
        public Encoding decodificador;
        public DecodificadorTexto() : this(ConstantesCodificadorTexto.CODIFICACION_POR_DEFECTO)
        { }
        public DecodificadorTexto(String datoCodificado)
        {
            decodificador = Encoding.GetEncoding(datoCodificado);
        }
        public Elemento Decodificar(Stream flujo)
        {
            String operacion, user, contraseña;
            byte[] separador = decodificador.GetBytes("\n");
            user = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            contraseña = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            operacion = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            return new Elemento(user, contraseña, Int32.Parse(operacion));
        }
        public ElementoLogin DecodificarLogin(Stream flujo)
        {
            String nombre, apellido, validacion;
            byte[] separador = decodificador.GetBytes("\n");
            nombre = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            apellido = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            validacion = decodificador.GetString(Entramar.SiguienteToken(flujo, separador));
            return new ElementoLogin(nombre, apellido, Int32.Parse(validacion));
        }
        public ElementoLogin DecodificarLogin(byte[] paquete)
        {
            Stream cargaUtil = new MemoryStream(paquete, 0, paquete.Length, false);
            return DecodificarLogin(cargaUtil);
        }
        public Elemento Decodificar(byte[] paquete)
        {
            Stream cargaUtil = new MemoryStream(paquete, 0, paquete.Length, false);
            return Decodificar(cargaUtil);
        }
    }


}