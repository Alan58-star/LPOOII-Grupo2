using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Item_Pedido
    {
        private int item_Ped_Id;

        public int Item_Ped_Id
        {
            get { return item_Ped_Id; }
            set { item_Ped_Id = value; }
        }
        private int ped_Id;

        public int Ped_Id
        {
            get { return ped_Id; }
            set { ped_Id = value; }
        }
        private int art_Id;

        public int Art_Id
        {
            get { return art_Id; }
            set { art_Id = value; }
        }
        private decimal item_Ped_Precio;

        public decimal Item_Ped_Precio
        {
            get { return item_Ped_Precio; }
            set { item_Ped_Precio = value; }
        }
        private int item_Ped_Cantidad;

        public int Item_Ped_Cantidad
        {
            get { return item_Ped_Cantidad; }
            set { item_Ped_Cantidad = value; }
        }
        private decimal item_Ped_Importe;

        public decimal Item_Ped_Importe
        {
            get { return item_Ped_Importe; }
            set { item_Ped_Importe = value; }
        }
    }
}
