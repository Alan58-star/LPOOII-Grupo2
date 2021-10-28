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
using System.Collections.ObjectModel;
using System.Data;

using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winAltaItemPedido.xaml
    /// </summary>
    public partial class winAltaItemPedido : Window
    {
        Pedido ped;
        Item_Pedido item = new Item_Pedido();

        ObservableCollection<Item_Pedido> listaItems;
        public winAltaItemPedido()
        {
            InitializeComponent();
        }

        public winAltaItemPedido(Pedido pedido)
        {
            InitializeComponent();
            ped = pedido;
            cargarColeccion();
        }

        private void cargarColeccion()
        {
            listaItems = TrabajarItemPedido.TraerItemsColeccion(ped.Ped_Id);
            lvwitems.ItemsSource = listaItems;
           
        }


        private void moveWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Dialogo.IsOpen = true;
            


        }


        private void lvwArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Articulo art = (Articulo)lvwArticulos.SelectedItems[0];
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {


            Dialogo.IsOpen = true;
        }

        private void btnGuardarCant_Click(object sender, RoutedEventArgs e)
        {
            Articulo art = (Articulo)lvwArticulos.SelectedItems[0];

            item.Art_Id = art.Art_Id;
            item.Ped_Id = ped.Ped_Id;
            item.Item_Ped_Precio = art.Art_Precio;
            item.Item_Ped_Cantidad = Convert.ToInt32(txtCantidad.Text);
            item.Item_Ped_Importe = art.Art_Precio * item.Item_Ped_Cantidad;

            TrabajarItemPedido.add_item_pedido(item);
            
            cargarColeccion();
            
            Dialogo.IsOpen = false;
        }
       


    }
}
