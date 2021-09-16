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
    /// Interaction logic for winClientes.xaml
    /// </summary>
    public partial class winClientes : Window
    {
        Cliente oClientes = new Cliente();

        public winClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                oClientes.Cli_Apellido = txtApellidos.Text;
                oClientes.Cli_Nombre = txtNombres.Text;
                oClientes.Cli_Telefono = txtTel.Text;
                oClientes.Cli_Domicilio = txtDomicilio.Text;
                oClientes.Cli_Email = txtMail.Text;
                MessageBox.Show("Se ha añadido al siguiente cliente:\nApellido/s: " + oClientes.Cli_Apellido + "\nNombre/s: " + oClientes.Cli_Nombre + "\nDomicilio: " + oClientes.Cli_Domicilio + "\nTelefono: " + oClientes.Cli_Telefono +
                    "\nE-mail: " + oClientes.Cli_Email, "¡Datos Guardados con éxito!", MessageBoxButton.OK, MessageBoxImage.Information);

                txtApellidos.Text = "";
                txtNombres.Text = "";
                txtTel.Text = "";
                txtDomicilio.Text = "";
                txtMail.Text = "";
                
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
