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
    /// Interaction logic for winVistaPrevia.xaml
    /// </summary>
    public partial class winVistaPrevia : Window
    {
        public winVistaPrevia()
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
                //ABMArticulos winABM = new ABMArticulos();
                //winABM.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();

            if (pDialog.ShowDialog() == true)
            {
                pDialog.PrintDocument(((IDocumentPaginatorSource)fdocArticulosPreview).DocumentPaginator, "Imprimir");
            }
        }
    }
}
