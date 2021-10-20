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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winAdminMenu.xaml
    /// </summary>
    public partial class winAdminMenu : Window
    {
        public winAdminMenu()
        {
            InitializeComponent();
            ocultarGrid();
            rb1.IsChecked = true;
            logoholdem.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnArticulos_Click(object sender, RoutedEventArgs e)
        {
            ABMArticulos winABMArticulos = new ABMArticulos();
            winABMArticulos.Show();
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
            grdArticulo.Visibility = System.Windows.Visibility.Visible;
            rb3.IsChecked = true;
        }

        private void rb4_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            grdFamilia.Visibility = System.Windows.Visibility.Visible;
            rb4.IsChecked = true;
        }

        private void rb5_MouseEnter(object sender, MouseEventArgs e)
        {

            ocultarGrid();
            grdCategoria.Visibility = System.Windows.Visibility.Visible;
            rb5.IsChecked = true;
        }

        private void rb6_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            grdUnidad.Visibility = System.Windows.Visibility.Visible;
            rb6.IsChecked = true;
        }

        private void ocultarGrid()
        {
            logoholdem.Visibility = System.Windows.Visibility.Collapsed;
            griditem.Visibility = System.Windows.Visibility.Collapsed;
            grdArticulo.Visibility = System.Windows.Visibility.Collapsed;
            grdFamilia.Visibility = System.Windows.Visibility.Collapsed;
            grdCategoria.Visibility = System.Windows.Visibility.Collapsed;
            grdUnidad.Visibility = System.Windows.Visibility.Collapsed;
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

        private void rb3_Click(object sender, RoutedEventArgs e)
        {
            ABMArticulos winABMArticulos = new ABMArticulos();
            winABMArticulos.Show();  
        }

        private void openFamMenu(object sender, RoutedEventArgs e)
        {
            winFamilias winFamilias = new winFamilias();
            winFamilias.Show();
        }

        private void openCatMenu(object sender, RoutedEventArgs e)
        {
            winCategorias winCategorias = new winCategorias();
            winCategorias.Show();
        }

        private void openUMMenu(object sender, RoutedEventArgs e)
        {
            winUnidadesDeMedida winnUnidadesDeMedida = new winUnidadesDeMedida();
            winnUnidadesDeMedida.Show();
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
