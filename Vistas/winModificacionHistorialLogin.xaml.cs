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
    /// Interaction logic for winModificacionHistorialLogin.xaml
    /// </summary>
    public partial class winModificacionHistorialLogin : Window
    {

        Historial_Login logNew = new Historial_Login();

        public winModificacionHistorialLogin()
        {
            InitializeComponent();
        }

        public winModificacionHistorialLogin(Historial_Login log)
        {
            InitializeComponent();
            logNew = TrabajarHistorialLogin.obtener_log(log.Log_Id);

            txtDescripcion.Text = log.Log_Descrip;
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
        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                winHistorialLogin winHLogin = new winHistorialLogin();
                winHLogin.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Log", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TrabajarHistorialLogin.edit_log(logNew.Log_Id, txtDescripcion.Text);

                    MessageBox.Show("Log actualizado con éxito", "Usuario actualizado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                winHistorialLogin winHLog = new winHistorialLogin();
                winHLog.Show();
                this.Close();
            }
            
        }

        private bool validarCampos()
        {
            bool valido = true;
            if (txtDescripcion.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar la descripción para el login seleccionado.");
                return valido;
            }
            return valido;
        }

    }
}
