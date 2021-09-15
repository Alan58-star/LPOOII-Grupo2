using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private string usr_ApellidoNombre;

        public string Usr_ApellidoNombre
        {
            get { return usr_ApellidoNombre; }
            set { usr_ApellidoNombre = value; }
        }
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }
        private string usr_NombreUsuario;

        public string Usr_NombreUsuario
        {
            get { return usr_NombreUsuario; }
            set { usr_NombreUsuario = value; }
        }
        private string usr_Password;

        public string Usr_Password
        {
            get { return usr_Password; }
            set { usr_Password = value; }
        }
        private int rol_Id;

        public int Rol_Id
        {
            get { return rol_Id; }
            set { rol_Id = value; }
        }
    }
}
