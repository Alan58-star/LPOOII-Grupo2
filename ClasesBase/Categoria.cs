using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Categoria:IDataErrorInfo
    {
        private int cat_Id;

        public int Cat_Id
        {
            get { return cat_Id; }
            set { cat_Id = value; }
        }
        private string cat_Descrip;

        public string Cat_Descrip
        {
            get { return cat_Descrip; }
            set { cat_Descrip = value; }
        }

        public Categoria() { }

        public Categoria(int catID, string catDescrip)
        {
            cat_Id = catID;
            cat_Descrip = catDescrip;
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
                    case "Cat_Id":
                        msg_error = validar_Id();
                        break;
                    case "Cat_Descrip":
                        msg_error = validar_Descrip();
                        break;
                }

                return msg_error;
            }
        }

        private string validar_Id()
        {
            if (Cat_Id == 0)
            {
                return "El valor del campo Id es obligatorio";
            }
            else if (Cat_Id < 1)
            {
                return "El valor del ID debe ser mayor o igual a 1";
            }
            return null;
        }

        private string validar_Descrip()
        {
            if (String.IsNullOrEmpty(Cat_Descrip))
            {
                return "El valor del campo Descripción es obligatorio";
            }
            return null;
        }
    }
}
