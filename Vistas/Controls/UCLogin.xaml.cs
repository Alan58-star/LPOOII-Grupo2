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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.Controls
{
    /// <summary>
    /// Interaction logic for UCLogin.xaml
    /// </summary>
    public partial class UCLogin : UserControl
    {
        public UCLogin()
        {
            InitializeComponent();
            txtUserLogin.Text = "Usuario";
            txtUserLogin.Foreground = Brushes.Gray;

            pwdPassLogin.Password = "PWD";

            pwdPassLogin.Foreground = Brushes.Gray;
        }

        public string Username
        {
            get
            {
                return txtUserLogin.Text;
            }
        }


        public string Password
        {
            get
            {
                return pwdPassLogin.Password;
            }
        }


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
    }
}
