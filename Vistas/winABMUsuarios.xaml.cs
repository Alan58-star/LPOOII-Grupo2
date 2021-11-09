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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winABMUsuarios.xaml
    /// </summary>
    public partial class winABMUsuarios : Window
    {
        private CollectionViewSource usuariosColeccionFiltrada;

        public winABMUsuarios()
        {
            InitializeComponent();
           usuariosColeccionFiltrada = Resources["VISTA_USUARIOS"] as CollectionViewSource; 
        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (usuariosColeccionFiltrada != null)
            {
                usuariosColeccionFiltrada.Filter += eventVistaUsuarios_Filter;
            }
        }

        private void eventVistaUsuarios_Filter(object sender, FilterEventArgs e)
        {
            Usuario usr = e.Item as Usuario;

            if (usr.Usr_NombreUsuario.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
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
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        
        private void btn_NuevoUsuario(object sender, RoutedEventArgs e)
        {
            winUsuarios newUsuario = new winUsuarios(0);
            newUsuario.Show();
            this.Close();
        }

        private void btn_ModifUsuario(object sender, RoutedEventArgs e)
        {
            //int UserID = Convert.ToInt32(txtUsrID.Content);
            
            Usuario usr = (Usuario)lvgUsuarios.SelectedItem;
            winUsuarios editUsuario = new winUsuarios(usr.Usr_Id);
            editUsuario.Show();
            this.Close();
        }

        private void btn_ElimUsuario(object sender, RoutedEventArgs e)
        {
            Usuario usr = (Usuario)lvgUsuarios.SelectedItem;
            int UserID = usr.Usr_Id;
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            
            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarUsuarios.delete_usuario(UserID);
                MessageBox.Show("Usuario eliminado con éxito", "Usuario Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                
                //lo siguiente va a actualizar los datos al crear una nueva ventana con la informacion modificada
                winABMUsuarios winABMU = new winABMUsuarios();
                winABMU.Show();
                this.Close();
            }
        }
        
    }
}

