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
       // private CollectionViewSource usuariosColeccionFiltrada;

        public winABMUsuarios()
        {
            InitializeComponent();
           // usuariosColeccionFiltrada = Resources["VISTA_USUARIO"] as CollectionViewSource; 
        }

        CollectionView Users;
        ObservableCollection<Usuario> listaUsuarios;

        //private void txtSearchUser_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (usuariosColeccionFiltrada != null)
        //    {
        //        usuariosColeccionFiltrada.Filter += eventVistaUsuario_Filter;
        //    }
        //}

        //private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        //{
        //    Usuario usr = new Usuario();

        //    if (usr.Usr_NombreUsuario.StartsWith(txtSearchUser.Text, StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        e.Accepted = true;
        //    }
        //    else
        //    {
        //        e.Accepted = false;
        //    }
        //}


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarColeccion();
        }

        private void cargarColeccion()
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USUARIO"];
            listaUsuarios = odp.Data as ObservableCollection<Usuario>;

            Users = (CollectionView)CollectionViewSource.GetDefaultView(contentGrid.DataContext);
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
        
        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
            Users.MoveCurrentToPrevious();
            if (Users.IsCurrentBeforeFirst)
            {
                Users.MoveCurrentToLast();
            }

        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            Users.MoveCurrentToNext();
            if (Users.IsCurrentAfterLast)
            {
                Users.MoveCurrentToFirst();
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
            int UserID = Convert.ToInt32(txtUsrID.Content);
            winUsuarios editUsuario = new winUsuarios(UserID);
            editUsuario.Show();
            this.Close();
        }

        private void btn_ElimUsuario(object sender, RoutedEventArgs e)
        {
            int UserID = Convert.ToInt32(txtUsrID.Content);
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarUsuarios.delete_usuario(UserID);
                MessageBox.Show("Usuario eliminado con éxito", "Usuario Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                (FindResource("LIST_USUARIO") as ObjectDataProvider).Refresh();

                cargarColeccion();
            }
        }
        
    }
}

