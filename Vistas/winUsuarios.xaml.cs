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

        Usuario user = new Usuario();
        public winUsuarios(int uid)
        {
            InitializeComponent();

            int usrID = uid;
            if (usrID == 0)
            {
                btnEditar.IsEnabled = false;
                btnEditar.Visibility = Visibility.Hidden;
            }
            else
            {
                lblWinTitle.Content = "Actualizar Usuario";
                user = TrabajarUsuarios.obtener_usuario(usrID);
                lblNewUserTitle.Content = "Actualizar";
                lblNewUserDescrip.Content = "Actualice los datos del usuario";
                btnGuardar.IsEnabled = false;
                btnGuardar.Visibility = Visibility.Hidden;

                txtApellidoNombre.Text = user.Usr_ApellidoNombre;
                txtUsuario.Text = user.Usr_NombreUsuario;
                txtPassword.Text = user.Usr_Password;
                cboRol.SelectedIndex = user.Rol.Rol_Id - 1;
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

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                winABMUsuarios abmUsuarios = new winABMUsuarios();
                abmUsuarios.Show();
                this.Close();
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
            if (validarCampos())
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

                    MessageBox.Show("Usuario guardado con éxito", "Usuario añadido", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtApellidoNombre.Text = "";
                    txtPassword.Text = "";
                    txtUsuario.Text = "";
                    cboRol.SelectedItem = null;

                    winABMUsuarios winABMU = new winABMUsuarios();
                    winABMU.Show();
                    this.Close();
                } 
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Usuario oUsuario = new Usuario();

                    oUsuario.Usr_Id = user.Usr_Id;
                    oUsuario.Usr_ApellidoNombre = txtApellidoNombre.Text;
                    oUsuario.Usr_NombreUsuario = txtUsuario.Text;
                    oUsuario.Usr_Password = txtPassword.Text;
                    oUsuario.Rol_Id = Convert.ToInt32(cboRol.SelectedValue.ToString());


                    TrabajarUsuarios.edit_usuario(oUsuario);

                    MessageBox.Show("Usuario actualizado con éxito", "Usuario actualizado", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtApellidoNombre.Text = "";
                    txtPassword.Text = "";
                    txtUsuario.Text = "";
                    cboRol.SelectedItem = null;

                    winABMUsuarios winABMU = new winABMUsuarios();
                    winABMU.Show();
                    this.Close();
                } 
            }
            
        }

        private bool validarCampos()
        {
            bool valido = true;
            int comboRol = Convert.ToInt32(cboRol.SelectedValue);
            if (txtApellidoNombre.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar el apellido y nombre del usuario.");
                return valido;
            }
            if (txtUsuario.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar el nombre de usuario que usará para ingresar en el sistema.");
                return valido;
            }
            if (txtPassword.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar la contraseña que usará el usuario para ingresar en el sistema.");
                return valido;
            }
            if (txtPassword.Text.Length < 8)
            {
                valido = false;
                MessageBox.Show("La contraseña debe tener como mínimo 8 caractéres.");
                return valido;
            }
            if ((string.IsNullOrEmpty(cboRol.Text)) || (comboRol == -1))
            {
                valido = false;
                MessageBox.Show("Debe seleccionar el rol que tendrá el usuario en el sistema.");
                return valido;
            }
            return valido;
        }
    }
}
