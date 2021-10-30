using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : IDataErrorInfo, INotifyPropertyChanged
    {
        private string usr_ApellidoNombre;

        public string Usr_ApellidoNombre
        {
            get { return usr_ApellidoNombre; }
            set
            {
                usr_ApellidoNombre = value;
                Notificador("Usr_ApellidoNombre");
            }
        }
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set
            {
                usr_Id = value;
                Notificador("Usr_Id");
            }
        }
        private string usr_NombreUsuario;

        public string Usr_NombreUsuario
        {
            get { return usr_NombreUsuario; }
            set
            {
                usr_NombreUsuario = value;
                Notificador("Usr_NombreUsuario");
            }
        }
        private string usr_Password;

        public string Usr_Password
        {
            get { return usr_Password; }
            set
            {
                usr_Password = value;
                Notificador("Usr_Password");
            }
        }
        private int rol_Id;

        public int Rol_Id
        {
            get { return rol_Id; }
            set
            {
                rol_Id = value;
                Notificador("Rol_Id");
            }
        }

        private Rol rol;
        public Rol Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
                Notificador("Rol");
            }
        }

        public Usuario() { }
        
        public Usuario(int id, string apnombre, string username, string password)
        {
            usr_Id = id;
            usr_ApellidoNombre = apnombre;
            usr_NombreUsuario = username;
            usr_Password = password;
        }    

        public Usuario(int id, string apnombre, string username, string password, Rol usr_rol)
        {
            usr_Id = id;
            usr_ApellidoNombre = apnombre;
            usr_NombreUsuario = username;
            usr_Password = password;
            rol = usr_rol;
        }
    

        //método notificador
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notificador(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        //validación
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
