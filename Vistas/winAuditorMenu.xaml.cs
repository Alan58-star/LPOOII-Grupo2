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
    /// Interaction logic for winAuditorMenu.xaml
    /// </summary>
    public partial class winAuditorMenu : Window
    {
        int idUsuarioLog = 0;
        string nombreUsuarioLog = "";

        public winAuditorMenu()
        {
            InitializeComponent();
            ocultarGrid();
            window.Width = SystemParameters.MaximizedPrimaryScreenWidth;
            window.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            rb1.IsChecked = true;
            logoholdem.Visibility = System.Windows.Visibility.Visible;
        }

        public winAuditorMenu(string usuario, int idUsuario)
        {
            InitializeComponent();
            ocultarGrid();
            window.Width = SystemParameters.MaximizedPrimaryScreenWidth;
            window.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            rb1.IsChecked = true;
            logoholdem.Visibility = System.Windows.Visibility.Visible;
            idUsuarioLog = idUsuario;
            nombreUsuarioLog = usuario;
            txbUsuario.Text = nombreUsuarioLog;
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


        private void ocultarGrid()
        {
            logoholdem.Visibility = System.Windows.Visibility.Collapsed;
            gridUsuarios.Visibility = System.Windows.Visibility.Collapsed;
            grdLogs.Visibility = System.Windows.Visibility.Collapsed;

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
            gridUsuarios.Visibility = System.Windows.Visibility.Visible;
            rb2.IsChecked = true;
        }

        private void rb3_MouseEnter(object sender, MouseEventArgs e)
        {
            ocultarGrid();
            grdLogs.Visibility = System.Windows.Visibility.Visible;
            rb3.IsChecked = true;
        }

        private void openUsrMenu(object sender, RoutedEventArgs e)
        {
            winABMUsuarios wABMUsers = new winABMUsuarios();
            wABMUsers.Show();
        }

        private void openWinLogs(object sender, RoutedEventArgs e)
        {
            winHistorialLogin wHLogin = new winHistorialLogin();
            wHLogin.Show();
        }

        private void btnLogout_Click_1(object sender, RoutedEventArgs e)
        {
            winLogin WinLogin = new winLogin();
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar sesión?", "¿Salir?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                WinLogin.Show();
                this.Close();
            }
        }



    }
}
