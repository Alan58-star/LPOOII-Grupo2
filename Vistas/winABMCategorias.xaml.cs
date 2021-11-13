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
    /// Interaction logic for winABMCategorias.xaml
    /// </summary>
    public partial class winABMCategorias : Window
    {
        private CollectionViewSource categoriasColeccionFiltrada;

        public winABMCategorias()
        {
            InitializeComponent();

            categoriasColeccionFiltrada = Resources["VISTA_CATEGORIAS"] as CollectionViewSource; 
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categoriasColeccionFiltrada != null)
            {
                categoriasColeccionFiltrada.Filter += eventVistaCategorias_Filter;
            }
        }

        private void eventVistaCategorias_Filter(object sender, FilterEventArgs e)
        {
            Categoria cat = e.Item as Categoria;

            if (cat.Cat_Descrip.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
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

        private void btn_NuevaCategoria(object sender, RoutedEventArgs e)
        {
            winCategorias winC = new winCategorias(0);
            winC.Show();
            this.Close();
        }

        private void btn_ModifCategoria(object sender, RoutedEventArgs e)
        {
            Categoria cat = (Categoria)lvwCategorias.SelectedItem;
            winCategorias editCategoria = new winCategorias(cat.Cat_Id);
            editCategoria.Show();
            this.Close();
        }

        private void btn_ElimCategoria(object sender, RoutedEventArgs e)
        {
            Categoria cat = (Categoria)lvwCategorias.SelectedItem;
            int catID = cat.Cat_Id;
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarCategorias.delete_categoria(catID);
                MessageBox.Show("Categoría eliminada con éxito", "Categoría Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                //lo siguiente va a actualizar los datos al crear una nueva ventana con la informacion modificada
                winABMCategorias winABMC = new winABMCategorias();
                winABMC.Show();
                this.Close();
            }
        }
    }
}
