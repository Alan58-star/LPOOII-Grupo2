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
    /// Interaction logic for winBusquedaArt.xaml
    /// </summary>
    public partial class winBusquedaArt : Window
    {
        private CollectionViewSource vistaColeccionFiltrada; 

        public winBusquedaArt()
        {
            InitializeComponent();

            vistaColeccionFiltrada = Resources["VISTA_ARTICULO"] as CollectionViewSource; 
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                vistaColeccionFiltrada.Filter += eventVistaArticulo_Filter;
            }
        }
        
        private void eventVistaArticulo_Filter(object sender, FilterEventArgs e)
        {
            Articulo art = e.Item as Articulo;

            if (art.Art_Descrip.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
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
                ABMArticulos winABM = new ABMArticulos();
                winABM.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnVistaImpresion_Click(object sender, RoutedEventArgs e)
        {
            winVistaPrevia winVP = new winVistaPrevia();
            winVP.Show();
        }


        //codigo para sacar el id de la fila seleccionada
        private void lvwArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();

            if (pDialog.ShowDialog() == true)
            {
                pDialog.PrintDocument(((IDocumentPaginatorSource)fdocArticulosPreview).DocumentPaginator, "Imprimir");
            }
        }

    }
}
