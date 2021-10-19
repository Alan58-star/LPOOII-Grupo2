using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class Articulo : IDataErrorInfo, INotifyPropertyChanged
    {
        private int art_Id;
        public int Art_Id
        {
            get { return art_Id; }
            set { 
                art_Id = value;
                Notificador("Art_Id");
            }
        }


        private string art_Descrip;
        public string Art_Descrip
        {
            get { return art_Descrip; }
            set { 
                art_Descrip = value;
                Notificador("Art_Descrip");
            }
        }


        private int fam_Id;
        public int Fam_Id
        {
            get { return fam_Id; }
            set { 
                fam_Id = value;
                
            }
        }


        private int um_Id;
        public int Um_Id
        {
            get { return um_Id; }
            set { 
                um_Id = value;
                Notificador("Um_Id");
            }
        }


        private decimal art_Precio;
        public decimal Art_Precio
        {
            get { return art_Precio; }
            set { 
                art_Precio = value;
                Notificador("Art_Precio");
            }
        }


        private Boolean art_Manejo_Stock;
        public Boolean Art_Manejo_Stock
        {
            get { return art_Manejo_Stock; }
            set { 
                art_Manejo_Stock = value;
                Notificador("Art_Manejo_Stock");
            }
        }




        private Familia familia;
        public Familia Familia
        {
            get { return familia; }
            set
            {
                familia = value;
                Notificador("Familia");
            }
        }

        private Categoria categoria;
        public Categoria Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                Notificador("Categoria");
            }
        }

        private Unidad_Medida unidad_medida;
        public Unidad_Medida Unidad_Medida
        {
            get { return unidad_medida; }
            set
            {
                unidad_medida = value;
                Notificador("Unidad_Medida");
            }
        }

        public Articulo() { }
        public Articulo(int artId, string artDescrip, int famId, int umId, decimal artPrecio, Boolean artManejoStock)
        {
            art_Id = artId;
            art_Descrip = artDescrip;
            fam_Id = famId;
            um_Id = umId;
            art_Precio = artPrecio;
            art_Manejo_Stock = artManejoStock;
        }

        public Articulo(int artId, string artDescrip, int famId, int umId, decimal artPrecio, Boolean artManejoStock, Familia fam, Categoria cat, Unidad_Medida um)
        {
            art_Id = artId;
            art_Descrip = artDescrip;
            fam_Id = famId;
            um_Id = umId;
            art_Precio = artPrecio;
            art_Manejo_Stock = artManejoStock;
            familia = fam;
            categoria = cat;
            unidad_medida = um;
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
            if (Art_Id == 0)
            {
                return "El valor del campo Id es obligatorio";
            }
            else if (Art_Id < 1)
            {
                return "El valor del ID debe ser mayor o igual a 1";
            }
            return null;
        }

        private string validar_Descrip()
        {
            if (String.IsNullOrEmpty(Art_Descrip))
            {
                return "El valor del campo Descripción es obligatorio";
            }
            return null;
        }

        private string validar_Precio()
        {
            if (Art_Precio == 0)
            {
                return "El valor del campo Precio  debe ser mayor 0";
            }
            return null;
        }

        private int cat_Id;

        public int Cat_Id
        {
            get { return cat_Id; }
            set { cat_Id = value; }
        }
    }
}
