using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Articulo
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
    }
}
