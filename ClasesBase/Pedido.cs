using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Pedido : INotifyPropertyChanged
    {
        private int ped_Id;

        public int Ped_Id
        {
            get { return ped_Id; }
            set { ped_Id = value;
            Notificador("Ped_Id");
            }
        }
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set
            {
                usr_Id = value;
                Notificador("Usr_Id");
            }
        }
        private int mesa_Id;

        public int Mesa_Id
        {
            get { return mesa_Id; }
            set
            {
                mesa_Id = value;
                Notificador("Mesa_Id");
            }
        }
        private int cli_Id;

        public int Cli_Id
        {
            get { return cli_Id; }
            set
            {
                cli_Id = value;
                Notificador("Cli_Id");
            }
        }
        private DateTime ped_Fecha_Emision;

        public DateTime Ped_Fecha_Emision
        {
            get { return ped_Fecha_Emision; }
            set
            {
                ped_Fecha_Emision = value;
                Notificador("Ped_Fecha_Emision");
            }
        }
        private DateTime ped_Fecha_Entrega;

        public DateTime Ped_Fecha_Entrega
        {
            get { return ped_Fecha_Entrega; }
            set
            {
                ped_Fecha_Entrega = value;
                Notificador("Ped_Fecha_Entrega");
            }
        }
        private int ped_Comensales;

        public int Ped_Comensales
        {
            get { return ped_Comensales; }
            set
            {
                ped_Comensales = value;
                Notificador("Ped_Comensales");
            }
        }
        private bool ped_Facturado;

        public bool Ped_Facturado
        {
            get { return ped_Facturado; }
            set
            {
                ped_Facturado = value;
                Notificador("Ped_Facturado");
            }
        }

        private Usuario usuario;
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
                Notificador("Usuario");
            }
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                Notificador("Cliente");
            }
        }

        private Mesa mesa;
        public Mesa Mesa
        {
            get
            {
                return mesa;
            }
            set
            {
                mesa = value;
                Notificador("Mesa");
            }
        }

        public Pedido() { }

        public Pedido(int pedId, DateTime pedFechaEmision, DateTime pedFechaEntrega, int pedComensales, Boolean pedFacturado, int usuId, int mesaId, int cliId)
        {
            ped_Id = pedId;
            ped_Fecha_Emision = pedFechaEmision;
            ped_Fecha_Entrega = pedFechaEntrega;
            ped_Comensales = pedComensales;
            ped_Facturado = pedFacturado;
            usr_Id = usuId;
            mesa_Id = mesaId;
            cli_Id = cliId;
        }

        public Pedido(int pedId, DateTime pedFechaEmision, DateTime pedFechaEntrega, int pedComensales, Boolean pedFacturado, int usuId, int mesaId, int cliId, Usuario usu, Cliente cli, Mesa msa)
        {
            ped_Id = pedId;
            ped_Fecha_Emision = pedFechaEmision;
            ped_Fecha_Entrega = pedFechaEntrega;
            ped_Comensales = pedComensales;
            ped_Facturado = pedFacturado;
            usr_Id = usuId;
            mesa_Id = mesaId;
            cli_Id = cliId;
            usuario = usu;
            cliente = cli;
            mesa = msa;
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
