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
    /// Interaction logic for winABMUMedidas.xaml
    /// </summary>
    public partial class winABMUMedidas : Window
    {
        private CollectionViewSource UMColeccionFiltrada;
        public winABMUMedidas()
        {
            InitializeComponent();
            UMColeccionFiltrada = Resources["VISTA_UM"] as CollectionViewSource;
        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UMColeccionFiltrada != null)
            {
                UMColeccionFiltrada.Filter += eventVistaUM_Filter;
            }
        }

        private void eventVistaUM_Filter(object sender, FilterEventArgs e)
        {
            Unidad_Medida UM = e.Item as Unidad_Medida;

            if (UM.Um_Descrip.StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
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

        private void btn_NuevaUM(object sender, RoutedEventArgs e)
        {
            winUnidadesDeMedida winUM = new winUnidadesDeMedida(0);
            winUM.Show();
            this.Close();
        }

        private void btn_ModifUM(object sender, RoutedEventArgs e)
        {
            Unidad_Medida UM = (Unidad_Medida)lvwUM.SelectedItem;
            winUnidadesDeMedida editUM = new winUnidadesDeMedida(UM.Um_Id);
            editUM.Show();
            this.Close();
        }

        private void btn_ElimUM(object sender, RoutedEventArgs e)
        {
            Unidad_Medida UM = (Unidad_Medida)lvwUM.SelectedItem;
            int UMID = UM.Um_Id;
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar esta Unidad de medida?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (confirmResult == MessageBoxResult.Yes)
            {
                TrabajarUM.delete_UM(UMID);
                MessageBox.Show("Unidad de medida eliminada con éxito", "UM Eliminada", MessageBoxButton.OK, MessageBoxImage.Information);

                //lo siguiente va a actualizar los datos al crear una nueva ventana con la informacion modificada
                winABMUMedidas winABMUM = new winABMUMedidas();
                winABMUM.Show();
                this.Close();
            }
        }

    }
}
