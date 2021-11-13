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
    /// Interaction logic for winABMFamilias.xaml
    /// </summary>
    public partial class winABMFamilias : Window
    {

        private CollectionViewSource familiasColeccionFiltrada;

        public winABMFamilias()
        {
            InitializeComponent();

            familiasColeccionFiltrada = Resources["VISTA_FAMILIAS"] as CollectionViewSource; 
        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (familiasColeccionFiltrada != null)
            {
                familiasColeccionFiltrada.Filter += eventVistaFamilias_Filter;
            }
        }

        private void eventVistaFamilias_Filter(object sender, FilterEventArgs e)
        {
            Familia fam = e.Item as Familia;

            if (fam.Fam_Descrip.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
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


        private void btn_NuevaFamilia(object sender, RoutedEventArgs e)
        {
            winFamilias winC = new winFamilias(0);
            winC.Show();
            this.Close();
        }

        private void btn_ModifFamilia(object sender, RoutedEventArgs e)
        {
            Familia fam = (Familia)lvwFamilias.SelectedItem;
            winFamilias editFamilia = new winFamilias(fam.Fam_Id);
            editFamilia.Show();
            this.Close();
        }

        private void btn_ElimFamilia(object sender, RoutedEventArgs e)
        {
            Familia fam = (Familia)lvwFamilias.SelectedItem;
            int famID = fam.Fam_Id;
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar esta familia?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarFamilias.delete_familia(famID);
                MessageBox.Show("Familia eliminada con éxito", "Familia Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                //lo siguiente va a actualizar los datos al crear una nueva ventana con la informacion modificada
                winABMFamilias winABMF = new winABMFamilias();
                winABMF.Show();
                this.Close();
            }
        }

    }
}
