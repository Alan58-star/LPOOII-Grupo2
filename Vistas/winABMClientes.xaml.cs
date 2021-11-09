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
    /// Interaction logic for winABMClientes.xaml
    /// </summary>
    public partial class winABMClientes : Window
    {

        private CollectionViewSource clientesColeccionFiltrada;

        public winABMClientes()
        {
            InitializeComponent();
            clientesColeccionFiltrada = Resources["VISTA_CLIENTES"] as CollectionViewSource; 
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (clientesColeccionFiltrada != null)
            {
                clientesColeccionFiltrada.Filter += eventVistaClientes_Filter;
            }
        }

        private void eventVistaClientes_Filter(object sender, FilterEventArgs e)
        {
            Cliente cli = e.Item as Cliente;

            if (cli.Cli_Nombre.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btn_NuevoCliente(object sender, RoutedEventArgs e)
        {
            winClientes winC = new winClientes(0);
            winC.Show();
            this.Close();
        }

        private void btn_ModifCliente(object sender, RoutedEventArgs e)
        {
            Cliente cli = (Cliente)lvwClientes.SelectedItem;
            winClientes editCliente = new winClientes(cli.Cli_Id);
            editCliente.Show();
            this.Close();
        }

        private void btn_ElimCliente(object sender, RoutedEventArgs e)
        {
            Cliente cli = (Cliente)lvwClientes.SelectedItem;
            int CliID = cli.Cli_Id;
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarClientes.delete_cliente(CliID);
                MessageBox.Show("Cliente eliminado con éxito", "Cliente Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                //lo siguiente va a actualizar los datos al crear una nueva ventana con la informacion modificada
                winABMClientes winABMC = new winABMClientes();
                winABMC.Show();
                this.Close();
            }
        }
    }
}
