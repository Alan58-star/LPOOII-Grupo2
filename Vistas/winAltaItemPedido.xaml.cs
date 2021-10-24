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
using System.Data;

using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winAltaItemPedido.xaml
    /// </summary>
    public partial class winAltaItemPedido : Window
    {
        public winAltaItemPedido()
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ////No logra castear de datarow a articulo
            //Articulo art = (Articulo)lvwArticulos.SelectedItem;
            //System.Windows.MessageBox.Show(art.Art_Descrip);
        }


        private void lvwArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ////no reconoce la columna
            //DataRowView drv = (DataRowView)lvwArticulos.SelectedItem;
            //MessageBox.Show(drv["id"].ToString());

        }

        //las dos funciones de arriba tienen errores

    }
}
