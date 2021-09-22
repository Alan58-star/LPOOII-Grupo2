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
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        public winLogin()
        {
            System.Threading.Thread.Sleep(700); //Pausa del sistema para visibilizar el splash y que no sea una vista instantánea
            InitializeComponent();


            /*
            txtUserLogin.Text = "Usuario";
            txtUserLogin.Foreground = Brushes.Gray;

            pwdPassLogin.Password = "PWD";

            pwdPassLogin.Foreground = Brushes.Gray;
             */

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

        /*
        private void UsrGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUserLogin.Text == "Usuario")
            {
                txtUserLogin.Text = "";
                txtUserLogin.Foreground = Brushes.White;
            }
            else
            {
                txtUserLogin.Foreground = Brushes.White;
            }

        }

        private void PwdGotFocus(object sender, RoutedEventArgs e)
        {
            if (pwdPassLogin.Password == "PWD")
            {
                pwdPassLogin.Password = "";
                pwdPassLogin.Foreground = Brushes.White;
            }
            else
            {
                pwdPassLogin.Foreground = Brushes.White;
            }

        }


        private void UsrLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtUserLogin.Text != "")
            {
                txtUserLogin.Foreground = Brushes.LightGray;
            }
            else
            {
                txtUserLogin.Text = "Usuario";
                txtUserLogin.Foreground = Brushes.Gray;
            }
        }

        private void PwdLostFocus(object sender, RoutedEventArgs e)
        {
            if (pwdPassLogin.Password != "")
            {
                pwdPassLogin.Foreground = Brushes.LightGray;
            }
            else
            {
                pwdPassLogin.Password = "PWD";
                pwdPassLogin.Foreground = Brushes.Gray;
            }
        }
         * */

        private void login(object sender, RoutedEventArgs e)
        {
            String username = userlogin.txtUserLogin.Text;
            String password = userlogin.pwdPassLogin.Password;

            Usuario oUser1 = new Usuario();
            oUser1.Usr_NombreUsuario = "Admin";
            oUser1.Usr_Password = "123";
            Usuario oUser2 = new Usuario();
            oUser2.Usr_NombreUsuario = "Mozo";
            oUser2.Usr_Password = "123";
            Usuario oUser3 = new Usuario();
            oUser3.Usr_NombreUsuario = "Vendedor";
            oUser3.Usr_Password = "123";

            if (username == oUser1.Usr_NombreUsuario && password == oUser1.Usr_Password)
            {
                MessageBox.Show("Sesión iniciada como Administrador", "Bienvenido", MessageBoxButton.OK, MessageBoxImage.Information);
                winAdminMenu winAdminMenu = new winAdminMenu();
                winAdminMenu.Show();
                this.Close();
            }
            else
            {
                if (username == oUser2.Usr_NombreUsuario && password == oUser2.Usr_Password)
                {
                    MessageBox.Show("Sesión iniciada como Mozo", "Bienvenido", MessageBoxButton.OK, MessageBoxImage.Information);
                    winWaiterMenu winMozoVendedorMenu = new winWaiterMenu();
                    winMozoVendedorMenu.Show();
                    this.Close();
                }
                else
                {
                    if (username == oUser3.Usr_NombreUsuario && password == oUser3.Usr_Password)
                    {
                        MessageBox.Show("Sesión iniciada como Vendedor", "Bienvenido", MessageBoxButton.OK, MessageBoxImage.Information);
                        winWaiterMenu winMozoVendedorMenu = new winWaiterMenu();
                        winMozoVendedorMenu.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña y/o Usuario inválidos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}