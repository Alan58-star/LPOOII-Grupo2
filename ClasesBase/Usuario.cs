using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : IDataErrorInfo
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


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_error = null;

                switch (columnName)
                {
                    //case "Cli_Id":
                    //    msg_error = validar_Id();
                    //    break;
                    case "Usr_ApellidoNombre":
                        msg_error = validar_ApellidoNombre();
                        break;
                    case "Usr_NombreUsuario":
                        msg_error = validar_Usuario();
                        break;
                    case "Usr_Password":
                        msg_error = validar_Contraseña();
                        break;
                }

                return msg_error;
            }
        }

        private string validar_ApellidoNombre()
        {
            if (String.IsNullOrEmpty(Usr_ApellidoNombre))
            {
                return "El valor del campo Apellido y Nombre es obligatorio";
            }
            return null;
        }

        private string validar_Usuario()
        {
            if (String.IsNullOrEmpty(Usr_NombreUsuario))
            {
                return "El valor del campo Usuario es obligatorio";
            }
            return null;
        }

        private string validar_Contraseña()
        {
            if (String.IsNullOrEmpty(Usr_Password))
            {
                return "El valor del campo Contraseña es obligatorio";
            }

            if (Usr_Password.Length < 8)
            {
                return "La contraseña debe tener mínimo 8 caracteres";
            }
            return null;
        }


    }
}
