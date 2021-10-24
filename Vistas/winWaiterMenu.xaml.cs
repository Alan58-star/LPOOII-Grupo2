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
    /// Interaction logic for winWaiterMenu.xaml
    /// </summary>
    public partial class winWaiterMenu : Window
    {
        
       /* private void btnMesa_Click(object sender, RoutedEventArgs e)
        {
            winMesas mesas = new winMesas();
            mesas.Show();
            this.Close();
        }

        private void btnFamilia_Click(object sender, RoutedEventArgs e)
        {
            winClientes clientes = new winClientes();
            clientes.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            winLogin WinLogin = new winLogin();
            WinLogin.Show();
            this.Close();
        }*/
        public winWaiterMenu()
        {
            InitializeComponent();
            ocultarGrid();
            rb1.IsChecked = true;
            logoholdem.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnArticulos_Click(object sender, RoutedEventArgs e)
        {
            winArticulos winArticulos = new winArticulos(0);
            winArticulos.Show();
            this.Close();
        }


        private void informacionClick(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {

            }
            else
            {

            }

        }

        private void rb1_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            logoholdem.Visibility = System.Windows.Visibility.Visible;
            rb1.IsChecked = true;
        }
     

        private void rb2_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            griditem.Visibility = System.Windows.Visibility.Visible;
            rb2.IsChecked = true;
        }

        private void rb3_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            grdMesa.Visibility = System.Windows.Visibility.Visible;
            rb3.IsChecked = true;
        }

        private void rb4_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            grdCliente.Visibility = System.Windows.Visibility.Visible;
            rb4.IsChecked = true;
        }

       

        private void ocultarGrid()
        {
            logoholdem.Visibility = System.Windows.Visibility.Collapsed;
            griditem.Visibility = System.Windows.Visibility.Collapsed;
            grdMesa.Visibility = System.Windows.Visibility.Collapsed;
            grdCliente.Visibility = System.Windows.Visibility.Collapsed;
            
        }
      

        private void btnLogout_Click_1(object sender, RoutedEventArgs e)
        {
            winLogin WinLogin = new winLogin();
            MessageBoxResult result = MessageBox.Show("Cerrar Sesion", "¿Salir?", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.OK)
            {
                WinLogin.Show();
                this.Close();
            }
           
            
            
        }

        private void rb4_Click(object sender, RoutedEventArgs e)
        {
            winClientes winCliente = new winClientes();
            winCliente.Show();
        }

        private void rb3_Click(object sender, RoutedEventArgs e)
        {
            winMesas winMesa = new winMesas();
            winMesa.Show();
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

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

    }
}
