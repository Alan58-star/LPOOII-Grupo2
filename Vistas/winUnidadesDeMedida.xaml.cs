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
    /// Interaction logic for winUnidadesDeMedida.xaml
    /// </summary>
    public partial class winUnidadesDeMedida : Window
    {
        Unidad_Medida oUnidadDeMedida = new Unidad_Medida();

        public winUnidadesDeMedida()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Unidades de Medida", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                oUnidadDeMedida.Um_Descrip = txtUMDescrip.Text;
                oUnidadDeMedida.Um_Abrev = txtUMAbrev.Text;
                MessageBox.Show("Se ha añadido la siguiente Unidad de Medida:\nDescripción: " + oUnidadDeMedida.Um_Descrip + "\nAbreviatura: " + oUnidadDeMedida.Um_Abrev, "¡Datos Guardados con éxito!", MessageBoxButton.OK, MessageBoxImage.Information);
                oUnidadDeMedida.Um_Descrip = txtUMDescrip.Text;
                oUnidadDeMedida.Um_Abrev = txtUMAbrev.Text;
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

    }
}
