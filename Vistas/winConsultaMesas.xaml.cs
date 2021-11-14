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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winConsultaMesas.xaml
    /// </summary>
    public partial class winConsultaMesas : Window
    {
        public winConsultaMesas()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                winMesas winMesas = new winMesas(Convert.ToInt32(txtNroMesas.Text.ToString()));
                winMesas.Show();
                this.Close();
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

        private bool validarCampos()
        {
            bool valido = true;
            if (txtNroMesas.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar el número de mesas que desea.");
                return valido;
            }
            return valido;
        }
    }
}
