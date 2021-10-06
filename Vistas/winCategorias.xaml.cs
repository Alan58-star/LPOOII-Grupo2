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
    /// Interaction logic for winCategorias.xaml
    /// </summary>
    public partial class winCategorias : Window
    {
        Categoria oCategorias = new Categoria();

        public winCategorias()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                oCategorias.Cat_Descrip = txtCatDescrip.Text;
                
                MessageBox.Show("Se ha añadido la siguiente categoria:\nDescripcion: " + oCategorias.Cat_Descrip, "¡Datos Guardados con éxito!", MessageBoxButton.OK, MessageBoxImage.Information);

                txtCatDescrip.Text = "";

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
