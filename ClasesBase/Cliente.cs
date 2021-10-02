using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente:IDataErrorInfo
    {
        private int cli_Id;

        public int Cli_Id
        {
            get { return cli_Id; }
            set { cli_Id = value; }
        }
        private string cli_Apellido;

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value; }
        }
        private string cli_Nombre;

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value; }
        }
        private string cli_Domicilio;

        public string Cli_Domicilio
        {
            get { return cli_Domicilio; }
            set { cli_Domicilio = value; }
        }
        private string cli_Telefono;

        public string Cli_Telefono
        {
            get { return cli_Telefono; }
            set { cli_Telefono = value; }
        }
        private string cli_Email;

        public string Cli_Email
        {
            get { return cli_Email; }
            set { cli_Email = value; }
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
                    case "Cli_Apellido":
                        msg_error = validar_Apellido();
                        break;
                    case "Cli_Nombre":
                        msg_error = validar_Nombre();
                        break;
                    case "Cli_Telefono":
                        msg_error = validar_Telefono();
                        break;
                }

                return msg_error;
            }
        }

        //private string validar_Id()
        //{
        //    if (Cli_Id==null)
        //    {
        //        return "El valor del campo Id es obligatorio";
        //    }
        //    else if(Cli_Id<1)
        //    {
        //        return "El valor del ID debe ser mayor o igual a 1";
        //    }
        //    return null;
        //}

        private string validar_Apellido() 
        {
            if (String.IsNullOrEmpty(Cli_Apellido)) {
                return "El valor del campo Apellido es obligatorio";
            }
            return null;
        }

        private string validar_Nombre()
        {
            if (String.IsNullOrEmpty(Cli_Nombre))
            {
                return "El valor del campo Nombre es obligatorio";
            }
            return null;
        }

        private string validar_Telefono()
        {
            if (String.IsNullOrEmpty(Cli_Telefono))
            {
                return "El valor del campo Telefono es obligatorio";
            }
            return null;
        }
    }
}
