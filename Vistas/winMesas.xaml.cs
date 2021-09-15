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
    /// Interaction logic for winMesas.xaml
    /// </summary>
    public partial class winMesas : Window
    {
        public winMesas()
        {
            InitializeComponent();
        }


       /* private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

           
            Button btn = new Button();
            btn.Name = "Prueba";
            btn.Content = "Prueba";
            btn.Background = Brushes.Green;
            btn.Click += preguntarMesa;
            grdMesas.Children.Add(btn);

            //btnMesa17.Background = Brushes.Tomato;
            //btnMesa11.Background = Brushes.Tomato;
        }*/

        private void preguntarMesa(object sender, RoutedEventArgs e)
        {

            Button mesa = sender as Button;


            if (mesa.Background == Brushes.Tomato)
            {
                MessageBox.Show("Esta mesa esta Ocupada");
            }
            else
            {
                MessageBox.Show("Esta mesa esta Desocupada");
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

       

        private void grdMesas_Loaded(object sender, RoutedEventArgs e)
        {

            

            btnMesa17.Background = Brushes.Tomato;
            btnMesa11.Background = Brushes.Tomato;
    
    
            
            
           
        }

        
    }
}
