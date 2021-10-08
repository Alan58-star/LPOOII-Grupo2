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
using System.Globalization;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winMesas.xaml
    /// </summary>
    public partial class winMesas : Window
    {
        int numMesas = 0;
        public winMesas()
        {
            InitializeComponent();
        }

        public winMesas(int numeroMesas)
        {
            InitializeComponent();
            numMesas = numeroMesas;
        }


        [ValueConversion (typeof(string), typeof(Brush))]
        public class ConversorDeEstados : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is string)
                {
                    switch (value.ToString()){
                        case "Libre": return Brushes.Green; break;
                        case "Reservada": return Brushes.Goldenrod; break;
                        case "Ocupada": return Brushes.Red; break;
                        case "Pidiendo": return Brushes.Fuchsia; break;
                        case "En espera": return Brushes.Honeydew; break;
                        case "Servidos": return Brushes.Salmon; break;
                        case "Esperando Cuenta": return Brushes.RoyalBlue; break;
                        case "Pagando": return Brushes.DarkOliveGreen; break;
                    }                        
                }
                return value;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
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


            if (mesa.Style == (Style)Application.Current.Resources["BotondeMesaRoja"])
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

       

        private void grdMesas_Loaded(object sender, RoutedEventArgs e)
        {
            //se definen numero de filas y columnas del grid de acuerdo al numero de mesas ingresadas

            int cols = 0, rows = 0;

            if (numMesas == 1)
            {
                cols = rows = 1;
            }
            else if (numMesas <= 4)
            {
                cols = rows = 2;
            }
            else if (numMesas <= 9)
            {
                cols = rows = 3;
            }
            else if (numMesas <= 16)
            {
                cols = rows = 4;
            }
            else if (numMesas <= 20)
            {
                cols = 4;
                rows = 5;
            }


            //se crean las filas y columnas en el grid
            int cont = 0, contb = 0;
            while (cont < cols)
            {
                grdMesas.ColumnDefinitions.Add(new ColumnDefinition());
                cont++;
            }
            while (contb < rows)
            {
                grdMesas.RowDefinitions.Add(new RowDefinition());
                contb++;
            }

            //Se recorre el grid y se agregan los botones de mesas
            int contc = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (contc < numMesas)
                    {
                        contc++;
                        Button btn = new Button();
                        btn.Content = "Mesa " + contc;
                        if (contc == 11 || contc == 17)
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaRoja"];
                        }
                        else
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaVerde"];
                        }
                        btn.Click += preguntarMesa;
                        grdMesas.Children.Add(btn);
                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);
                        
                    }
                }
            }

           
        }

    }
}
