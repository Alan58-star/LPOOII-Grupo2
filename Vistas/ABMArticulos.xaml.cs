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
    /// Interaction logic for ABMArticulos.xaml
    /// </summary>
    public partial class ABMArticulos : Window
    {
        public ABMArticulos()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Articulo> listaArticulos;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarColeccion();
        }

        private void cargarColeccion()
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_ARTICULO"];
            listaArticulos = odp.Data as ObservableCollection<Articulo>;
            
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(contentGrid.DataContext);
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btn_first_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst) {
                Vista.MoveCurrentToLast();
            }
            
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
            }
        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btn_Agregar(object sender, RoutedEventArgs e)
        {
            winArticulos winArticulos = new winArticulos(0);
            winArticulos.Show();
            this.Close();
        }

        private void btnModifArt_Click(object sender, RoutedEventArgs e)
        {
            int idarticulo = Convert.ToInt32(txbCodigo.Text);
            winArticulos winArticulosEdit = new winArticulos(idarticulo);
            winArticulosEdit.Show();
            this.Close();            
        }

        private void btnDeleteArt_Click(object sender, RoutedEventArgs e)
        {
            int idarticulo = Convert.ToInt32(txbCodigo.Text);
            var confirmResult = MessageBox.Show("¿Está seguro de borrar este artículo?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Articulo eliminado con éxito", "Confirmar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                TrabajarArticulos.delete_articulo(idarticulo);
                (FindResource("LIST_ARTICULO") as ObjectDataProvider).Refresh();
                
                cargarColeccion();
            }

        }

        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            winBusquedaArt winBusqueda = new winBusquedaArt();
            winBusqueda.Show();
            this.Close();
        } 
    }
}
