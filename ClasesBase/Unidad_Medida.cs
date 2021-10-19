using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Unidad_Medida:IDataErrorInfo
    {
        private int um_Id;

        public int Um_Id
        {
            get { return um_Id; }
            set { um_Id = value; }
        }
        private string um_Descrip;

        public string Um_Descrip
        {
            get { return um_Descrip; }
            set { um_Descrip = value; }
        }
        private string um_Abrev;

        public string Um_Abrev
        {
            get { return um_Abrev; }
            set { um_Abrev = value; }
        }

        public Unidad_Medida() { }

        public Unidad_Medida(int umID, string umDescrip, string umAbrev)
        {
            um_Id = umID;
            um_Descrip = umDescrip;
            um_Abrev = umAbrev;
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
                    case "Um_Descrip":
                        msg_error = validar_Descrip();
                        break;
                    case "Um_Abrev":
                        msg_error = validar_Abrev();
                        break;
                }

                return msg_error;
            }
        }

        private string validar_Abrev()
        {
            if (String.IsNullOrEmpty(Um_Abrev))
            {
                return "El valor del campo Abreviacion es obligatorio";
            }
            return null;
        }

        private string validar_Descrip()
        {
            if (String.IsNullOrEmpty(Um_Descrip))
            {
                return "El valor del campo Descripción es obligatorio";
            }
            return null;
        }
    }
}
