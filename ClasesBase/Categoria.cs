using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Categoria
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
    }
}
