using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codificador
{
    public class Empleado
    {
        public int id;
        public String nombre;
        public String apellido;
        public String user;
        public String contraseña;

        public Empleado()
        {

        }

        private void setID (int id)
        {
            this.id = id;
        }

        public int getID()
        {
            return id;
        }

        private void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return nombre;
        }

        private void setApellido(String apellido)
        {
            this.apellido = apellido;
        }

        public String getApellido()
        {
            return apellido;
        }

        private void setUser(String user)
        {
            this.user = user;
        }

        public String getUser()
        {
            return user;
        }

        private void setContraseña(String contraseña)
        {
            this.contraseña = contraseña;
        }

        public String getContraseña()
        {
            return contraseña;
        }

        public Empleado(int iniId, String iniNombre, String iniApellido, String iniUser,String iniContraseña)
        {
            this.id = iniId;
            this.nombre = iniNombre;
            this.apellido = iniApellido;
            this.user = iniUser;
            this.contraseña = iniContraseña;
        }

        public Empleado( String iniUser, String iniContraseña)
        {
          
            this.user = iniUser;
            this.contraseña = iniContraseña;
        }


    }
}
