using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winVistaPreviaPedido.xaml
    /// </summary>
    public partial class winVistaPreviaPedido : Window
    {
        ObservableCollection<Item_Pedido> listaItems;
        Pedido ped;
        public winVistaPreviaPedido()
        {
            InitializeComponent();
        }
        public winVistaPreviaPedido(Pedido pedido)
        {
            InitializeComponent();
            ped = pedido;
            
            cargarDocumento();

        }
        private void cargarDocumento()
        {
            listaItems = TrabajarItemPedido.TraerItemsColeccion(ped.Ped_Id);
            lvwitems.ItemsSource = listaItems;
            txbNumeroPedido.Text = ped.Ped_Id.ToString();
            txbMozo.Text = ped.Usuario.Usr_NombreUsuario;
            txbMesaNumero.Text = ped.Mesa.Mesa_Id.ToString();
            txbFechaEntrega.Text = ped.Ped_Fecha_Emision.ToString();
            decimal total = 0;
            for (int i = 0; i < listaItems.Count();i++ )
            {
                total = total + listaItems[i].Item_Ped_Importe;
            }
            txbTotal.Text = total.ToString();

        }

    }
}
