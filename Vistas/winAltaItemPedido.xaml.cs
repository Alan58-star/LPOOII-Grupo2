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
            txbNumPedido.Text = pedido.Ped_Id.ToString() ;
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
            Console.WriteLine(TrabajarItemPedido.obtener_item(4, 5));
            
            //Dialogo.IsOpen = true;
        }

        private void btnGuardarCant_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                Articulo art = (Articulo)lvwArticulos.SelectedItems[0];
                item = TrabajarItemPedido.obtener_item(art.Art_Id, ped.Ped_Id);
                if (item.Item_Ped_Id != 0)
                {
                    item.Art_Id = art.Art_Id;
                    item.Ped_Id = ped.Ped_Id;
                    item.Item_Ped_Cantidad = Convert.ToInt32(txtCantidad.Text) + item.Item_Ped_Cantidad;

                    item.Item_Ped_Importe = art.Art_Precio * item.Item_Ped_Cantidad;
                    TrabajarItemPedido.edit_item(item);
                }
                else
                {
                    item.Art_Id = art.Art_Id;
                    item.Ped_Id = ped.Ped_Id;
                    item.Item_Ped_Precio = art.Art_Precio;
                    item.Item_Ped_Cantidad = Convert.ToInt32(txtCantidad.Text);
                    item.Item_Ped_Importe = art.Art_Precio * item.Item_Ped_Cantidad;
                    TrabajarItemPedido.add_item_pedido(item);
                }



                cargarColeccion();
                txtCantidad.Text = "";

                Dialogo.IsOpen = false;
            }
            
        }
        private void btnCancelarCant_Click(object sender, RoutedEventArgs e)
        {
            

            Dialogo.IsOpen = false;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validarCampos()
        {
            Dialogo.IsOpen = false;
            bool valido = true;
            int cantidadArt;
            bool result = txtCantidad.Text.Any(x => !char.IsLetter(x));
            //int cantidadReal = Convert.ToInt32(txtCantidad.Text);
            if (result)
            {
                cantidadArt = Convert.ToInt32(txtCantidad.Text);
            }
            else
            {
                valido = false;
                MessageBox.Show("Debe ingresar una cantidad válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCantidad.Text = "";
                Dialogo.IsOpen = true;
                return valido;
            }
            if (txtCantidad.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar la cantidad del artículo seleccionado que desea añadir.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCantidad.Text = "";
                Dialogo.IsOpen = true;
                return valido;
            }else if (Convert.ToInt32(txtCantidad.Text) <= 0) {
                valido = false;
                MessageBox.Show("No puede ingresar un valor menor a 1.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCantidad.Text = "";
                Dialogo.IsOpen = true;
                return valido;
            }
            return valido;
        }
       


    }
}
