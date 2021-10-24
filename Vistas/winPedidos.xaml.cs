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
    /// Interaction logic for winPedidos.xaml
    /// </summary>
    public partial class winPedidos : Window
    {
        public winPedidos()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            winAltaItemPedido winAltaitemPedido = new winAltaItemPedido();
            winAltaitemPedido.Show();

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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

     
    }
}
