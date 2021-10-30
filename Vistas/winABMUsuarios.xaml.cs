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
        public winABMUsuarios()
        {
            InitializeComponent();
        }

        CollectionView Users;
        ObservableCollection<Usuario> listaUsuarios;

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
                this.WindowState = WindowState.Maximized;
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

                winAdminMenu AdminMenu = new winAdminMenu();
                AdminMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btn_first_Click(object sender, RoutedEventArgs e)
        {
           // Vista.MoveCurrentToFirst();
        }

        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
           // Vista.MoveCurrentToPrevious();
            //if (Vista.IsCurrentBeforeFirst)
            //{
            //    Vista.MoveCurrentToLast();
            //}

        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            //Vista.MoveCurrentToNext();
            //if (Vista.IsCurrentAfterLast)
            //{
            //    Vista.MoveCurrentToFirst();
            //}
        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            //Vista.MoveCurrentToLast();
        }

        private void btn_NuevoUsuario(object sender, RoutedEventArgs e)
        {
            winUsuarios newUsuario = new winUsuarios();
            newUsuario.Show();
            this.Close();
        }

        private void btn_ModifUsuario(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ElimUsuario(object sender, RoutedEventArgs e)
        {

        }
    }
}
