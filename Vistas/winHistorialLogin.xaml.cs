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
    /// Interaction logic for winHistorialLogin.xaml
    /// </summary>
    public partial class winHistorialLogin : Window
    {
        private CollectionViewSource vistaColeccionFiltrada;


        public winHistorialLogin()
        {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["VISTA_LOGS"] as CollectionViewSource;

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

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                vistaColeccionFiltrada.Filter += eventVistaLogs_Filter;
            }
        }

        private void eventVistaLogs_Filter(object sender, FilterEventArgs e)
        {
            Historial_Login log = e.Item as Historial_Login;
            //Usuario usu = e.Item as Usuario;

            if (log.Usuario.Usr_NombreUsuario.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }


        private void lvwLogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnActualizar.IsEnabled = true;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Historial_Login log = (Historial_Login)lvwLogs.SelectedItem;

            winModificacionHistorialLogin winActualizarLog = new winModificacionHistorialLogin(log);
            winActualizarLog.Show();
            this.Close();
        }
    }
}
