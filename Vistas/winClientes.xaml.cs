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
        Cliente cli;

        public winClientes(int cid)
        {
            InitializeComponent();

            int cliID = cid;
            if (cliID == 0)
            {
                btnEditar.IsEnabled = false;
                btnEditar.Visibility = Visibility.Hidden;
            }
            else
            {
                lblWinTitle.Content = "Actualizar Cliente";
                cli = TrabajarClientes.obtener_cliente(cliID);
                lblNewCliTitle.Content = "Actualizar";
                lblNewCliDescrip.Content = "Actualice los datos del cliente";
                btnGuardar.IsEnabled = false;
                btnGuardar.Visibility = Visibility.Hidden;

                txtApellidos.Text = cli.Cli_Apellido;
                txtNombres.Text = cli.Cli_Nombre;
                txtDomicilio.Text = cli.Cli_Domicilio;
                txtTel.Text = cli.Cli_Telefono;
                txtMail.Text = cli.Cli_Email;
            }
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

                winABMClientes winABMC = new winABMClientes();
                winABMC.Show();
                this.Close();
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
                winABMClientes winABMC = new winABMClientes();
                winABMC.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cliente oCliente = new Cliente();

                oCliente.Cli_Id = cli.Cli_Id;
                oCliente.Cli_Nombre = txtNombres.Text;
                oCliente.Cli_Apellido = txtApellidos.Text;
                oCliente.Cli_Domicilio = txtDomicilio.Text;
                oCliente.Cli_Telefono = txtTel.Text;
                oCliente.Cli_Email = txtMail.Text;

                TrabajarClientes.edit_cliente(oCliente);

                MessageBox.Show("Cliente actualizado con éxito", "Cliente actualizado", MessageBoxButton.OK, MessageBoxImage.Information);

                txtApellidos.Text = "";
                txtNombres.Text = "";
                txtDomicilio.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";

                winABMClientes winABMC = new winABMClientes();
                winABMC.Show();
                this.Close();
            }
        }

       
    }
}
