using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Articulo:IDataErrorInfo
    {
        private int art_Id;

        public int Art_Id
        {
            get { return art_Id; }
            set { art_Id = value; }
        }
        private string art_Descrip;

        public string Art_Descrip
        {
            get { return art_Descrip; }
            set { art_Descrip = value; }
        }
        private int fam_Id;

        public int Fam_Id
        {
            get { return fam_Id; }
            set { fam_Id = value; }
        }
        private int um_Id;

        public int Um_Id
        {
            get { return um_Id; }
            set { um_Id = value; }
        }
        private decimal art_Precio;

        public decimal Art_Precio
        {
            get { return art_Precio; }
            set { art_Precio = value; }
        }
        private Boolean art_Manejo_Stock;

        public Boolean Art_Manejo_Stock
        {
            get { return art_Manejo_Stock; }
            set { art_Manejo_Stock = value; }
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
                    case "Art_Id":
                        msg_error = validar_Id();
                        break;
                    case "Art_Descrip":
                        msg_error = validar_Descrip();
                        break;
                    case "Art_Precio":
                        msg_error = validar_Precio();
                        break;
                    //case "Art_Manejo_Stock":
                    //    msg_error = validar_Manejo_Stock();
                    //    break;
                }

                return msg_error;
            }
        }

        private string validar_Id()
        {
            if (Art_Id==0)
            {
                return "El valor del campo Id es obligatorio";
            }
            else if(Art_Id<1)
            {
                return "El valor del ID debe ser mayor o igual a 1";
            }
            return null;
        }

        private string validar_Descrip()
        {
            if (String.IsNullOrEmpty(Art_Descrip)) {
                return "El valor del campo Descripción es obligatorio";
            }
            return null;
        }

        private string validar_Precio()
        {
            if (Art_Precio==0)
            {
                return "El valor del campo Precio  debe ser mayor 0";
            }
            return null;
        }
    }
}
