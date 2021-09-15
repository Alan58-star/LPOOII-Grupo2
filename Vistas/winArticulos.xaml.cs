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
    /// Interaction logic for winArticulos.xaml
    /// </summary>
    public partial class winArticulos : Window
    {
        Articulo oArticulo = new Articulo();


        public winArticulos()
        {
           
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            oArticulo.Fam_Id = Convert.ToInt32(cboFlia.SelectedIndex.ToString());
            oArticulo.Art_Precio = Convert.ToDecimal(txtPrecio.Text);
            oArticulo.Um_Id = Convert.ToInt32(cboMedida.SelectedIndex.ToString());
 
            oArticulo.Art_Descrip = txtDescripcion.Text;

            MessageBoxResult result = MessageBox.Show("Desea guardar los datos cargados?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (chkStock.IsChecked == true) oArticulo.Art_Manejo_Stock = true;
                else oArticulo.Art_Manejo_Stock = false;
                

                MessageBox.Show("Familia: " + oArticulo.Fam_Id + "\nUnidad de medida: " + oArticulo.Um_Id + "\nPrecio: " + oArticulo.Art_Precio + "\nStock: " + oArticulo.Art_Manejo_Stock + "\nDescripcion: " + oArticulo.Art_Descrip);
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

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {

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

                //throw;
            }
        }
       

    }
}
