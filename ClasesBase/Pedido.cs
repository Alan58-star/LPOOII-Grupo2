using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Pedido
    {
        private int ped_Id;

        public int Ped_Id
        {
            get { return ped_Id; }
            set { ped_Id = value; }
        }
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }
        private int mesa_Id;

        public int Mesa_Id
        {
            get { return mesa_Id; }
            set { mesa_Id = value; }
        }
        private int cli_Id;

        public int Cli_Id
        {
            get { return cli_Id; }
            set { cli_Id = value; }
        }
        private DateTime ped_Fecha_Emision;

        public DateTime Ped_Fecha_Emision
        {
            get { return ped_Fecha_Emision; }
            set { ped_Fecha_Emision = value; }
        }
        private DateTime ped_Fecha_Entrega;

        public DateTime Ped_Fecha_Entrega
        {
            get { return ped_Fecha_Entrega; }
            set { ped_Fecha_Entrega = value; }
        }
        private int ped_Comesales;

        public int Ped_Comesales
        {
            get { return ped_Comesales; }
            set { ped_Comesales = value; }
        }
        private bool ped_Facturado;

        public bool Ped_Facturado
        {
            get { return ped_Facturado; }
            set { ped_Facturado = value; }
        }
    }
}
