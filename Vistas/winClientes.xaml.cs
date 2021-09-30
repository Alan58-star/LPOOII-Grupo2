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

        public winClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cliente oCliente = new Cliente();

                oCliente.Cli_Apellido = txtApellidos.Text;
                oCliente.Cli_Nombre = txtNombres.Text;
                oCliente.Cli_Telefono = txtTel.Text;
                oCliente.Cli_Domicilio = txtDomicilio.Text;
                oCliente.Cli_Email = txtMail.Text;


                TrabajarClientes.add_cliente(oCliente);

                MessageBox.Show("Cliente guardado con éxito");

                txtApellidos.Text = "";
                txtNombres.Text = "";
                txtDomicilio.Text = "";
                txtTel.Text = "";
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
