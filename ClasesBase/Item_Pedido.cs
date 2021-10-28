using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Item_Pedido : INotifyPropertyChanged
    {
        private int item_Ped_Id;

        public int Item_Ped_Id
        {
            get { return item_Ped_Id; }
            set { 
                item_Ped_Id = value;
                Notificador("Item_Ped_Id");
            }
        }
        private int ped_Id;

        public int Ped_Id
        {
            get { return ped_Id; }
            set { ped_Id = value; Notificador("Ped_Id"); }
        }
        private int art_Id;

        public int Art_Id
        {
            get { return art_Id; }
            set { art_Id = value; Notificador("Art_Id"); }
        }
        private decimal item_Ped_Precio;

        public decimal Item_Ped_Precio
        {
            get { return item_Ped_Precio; }
            set { item_Ped_Precio = value; Notificador("Item_Ped_Precio"); }
        }
        private int item_Ped_Cantidad;

        public int Item_Ped_Cantidad
        {
            get { return item_Ped_Cantidad; }
            set { item_Ped_Cantidad = value; Notificador("Item_Ped_Cantidad"); }
        }
        private decimal item_Ped_Importe;

        public decimal Item_Ped_Importe
        {
            get { return item_Ped_Importe; }
            set { item_Ped_Importe = value; Notificador("Item_Ped_Importe"); }
        }

        private Pedido pedido;
        public Pedido Pedido
        {
            get
            {
                return pedido;
            }
            set
            {
                pedido = value; Notificador("Pedido");
            }
        }

        private Articulo articulo;
        public Articulo Articulo
        {
            get
            {
                return articulo;
            }
            set
            {
                articulo = value; Notificador("Articulo");
            }
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
    }
}
