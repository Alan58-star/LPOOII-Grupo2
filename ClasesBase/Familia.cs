using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Familia:IDataErrorInfo
    {
        private int fam_Id;

        public int Fam_Id
        {
            get { return fam_Id; }
            set { fam_Id = value; }
        }
        private string fam_Descrip;

        public string Fam_Descrip
        {
            get { return fam_Descrip; }
            set { fam_Descrip = value; }
        }

        public Familia() { }

        public Familia(int famID, string famDescrip)
        {
            fam_Id = famID;
            fam_Descrip = famDescrip;
        }

    
        public string  Error
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
                    //case "Cat_Id":
                    //    msg_error = validar_Id();
                    //    break;
                    case "Fam_Descrip":
                        msg_error = validar_Descrip();
                        break;
                }

                return msg_error;
            }
        }

        private string validar_Descrip()
        {
            if (String.IsNullOrEmpty(Fam_Descrip))
            {
                return "El valor del campo Descripción es obligatorio";
            }
            return null;
        }
    }
}
