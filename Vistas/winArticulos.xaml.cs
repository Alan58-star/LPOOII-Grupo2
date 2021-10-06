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

        public winArticulos()
        {
           
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Artículo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Articulo oArticulo = new Articulo();
                oArticulo.Fam_Id = Convert.ToInt32(cboFlia.SelectedIndex.ToString());
                oArticulo.Art_Precio = Convert.ToDecimal(txtPrecio.Text);
                oArticulo.Um_Id = Convert.ToInt32(cboMedida.SelectedIndex.ToString());
                oArticulo.Art_Descrip = txtDescripcion.Text;

                if (chkStock.IsChecked == true) oArticulo.Art_Manejo_Stock = true;
                else oArticulo.Art_Manejo_Stock = false;

                TrabajarArticulos.add_articulo(oArticulo);

                MessageBox.Show("Artículo guardado con éxito");

                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                chkStock.IsChecked = false;

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
       

    }
}
