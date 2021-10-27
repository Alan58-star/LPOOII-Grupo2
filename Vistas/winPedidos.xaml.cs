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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winPedidos.xaml
    /// </summary>
    public partial class winPedidos : Window
    {
        public winPedidos()
        {
            InitializeComponent();
            Load_ComboMesas();
            Load_ComboCliente();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            winAltaItemPedido winAltaitemPedido = new winAltaItemPedido();
            winAltaitemPedido.Show();

        }

        private void Load_ComboMesas()
        {
            var data2 = (TrabajarMesas.traerMesas() as System.ComponentModel.IListSource).GetList();
            cboMesas.DisplayMemberPath = "mesa_id";
            cboMesas.SelectedValuePath = "mesa_id";
            cboMesas.ItemsSource = data2;

        }
        private void Load_ComboCliente()
        {
            var data2 = (TrabajarClientes.traerClientes() as System.ComponentModel.IListSource).GetList();
            cboCliente.DisplayMemberPath = "cli_apellido";
            cboCliente.SelectedValuePath = "cli_id";
            cboCliente.ItemsSource = data2;

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

        private void btnagregarPed_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Crear Pedido", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Pedido oPedido = new Pedido();
                oPedido.Mesa_Id = Convert.ToInt32(cboMesas.SelectedValue.ToString());
                oPedido.Cli_Id = Convert.ToInt32(cboCliente.SelectedValue.ToString());
                oPedido.Ped_Fecha_Emision = DateTime.Now;
                if (chkFacturado.IsChecked == true) oPedido.Ped_Facturado = true;
                else oPedido.Ped_Facturado = false;

                oPedido.Ped_Fecha_Entrega = Convert.ToDateTime(dpFecha.SelectedDate);
                oPedido.Ped_Comensales = Convert.ToInt32(txtComensal.Text);
                oPedido.Usr_Id = 4;
                Console.WriteLine(oPedido.Ped_Fecha_Entrega);
                TrabajarPedido.add_pedido(oPedido);

                MessageBox.Show("Artículo Guardado con éxito", "Datos Creados", MessageBoxButton.OK, MessageBoxImage.Information);

                txtComensal.Text = "";
                
                chkFacturado.IsChecked = false;

            }
        }

        

     
    }
}
