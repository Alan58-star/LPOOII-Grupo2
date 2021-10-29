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
    /// Interaction logic for winUsuarios.xaml
    /// </summary>
    public partial class winUsuarios : Window
    {
        public winUsuarios()
        {
            InitializeComponent();
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Usuario oUsuario = new Usuario();

                oUsuario.Usr_ApellidoNombre = txtApellidoNombre.Text;
                oUsuario.Usr_NombreUsuario = txtUsuario.Text;
                oUsuario.Usr_Password = txtPassword.Text;
                oUsuario.Rol_Id = Convert.ToInt32(cboRol.SelectedValue.ToString());


                TrabajarUsuarios.add_usuario(oUsuario);

                MessageBox.Show("Usuario guardado con éxito");

                txtApellidoNombre.Text = "";
                txtPassword.Text = "";
                txtUsuario.Text = "";
                cboRol.SelectedItem = null;

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Roles();
        }

        private void Load_Roles()
        {

            var data = (TrabajarUsuarios.list_roles() as System.ComponentModel.IListSource).GetList();

            cboRol.DisplayMemberPath = "rol_descripcion";
            cboRol.SelectedValuePath = "rol_id";
            cboRol.ItemsSource = data;
        }
        





    }
}
