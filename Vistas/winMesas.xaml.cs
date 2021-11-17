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
using System.Collections.ObjectModel;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winMesas.xaml
    /// </summary>
    public partial class winMesas : Window
    {
        int numMesas = 1, cols = 0,rows = 0,limite=0;
        int columna = 5, fila = 5;
        int contc = 0;
        int id;
        Button btnAdd = new Button();

        ObservableCollection<Mesa> listaMesas;
        public winMesas()
        {
            InitializeComponent();
            cargarColeccion();
           
        }

        

       

        private void cargarColeccion()
        {
            listaMesas = TrabajarMesas.traerMesasColeccion();
            
       }

     

      
        public winMesas(int numeroMesas)
        {
            InitializeComponent();
            numMesas = numeroMesas;
        }
        
       
       

        private void preguntarMesa(object sender, RoutedEventArgs e)
        {

            Button mesa = sender as Button;

            if (mesa.Style == (Style)Application.Current.Resources["BotondeMesaVerde"])
            {
                MessageBoxResult result = MessageBox.Show("¿Agregar un Pedido?", "Agregar pedido", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    winNuevoPedido pedido = new winNuevoPedido(Convert.ToInt32(mesa.Content.ToString()));

                    pedido.Show();

                    this.Close();
                }
            }
            else
            {
                id = Convert.ToInt32(mesa.Content.ToString());
                Dialogo.IsOpen = true;
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
            /*//se definen numero de filas y columnas del grid de acuerdo al numero de mesas ingresadas

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
                
            }*/
            
            int cont = 0, contb = 0;
            while (cont < columna)
            {
                grdMesas.ColumnDefinitions.Add(new ColumnDefinition());
                cont++;
            }
            while (contb < fila)
            {
                grdMesas.RowDefinitions.Add(new RowDefinition());
                contb++;
            }
            cargarGrilla();
           
        }
        private  void cargarGrilla()
        {

            numMesas = listaMesas.Count;
            int limitef=0;

            for (int i = 0; i < fila; i++)
            {
                limitef++;
                for (int j = 0; j < columna; j++)
                {
                    if (contc < numMesas)
                    {
                        Button btn = new Button();
                        
                        btn.Content = listaMesas[contc].Mesa_Id.ToString();
                        
                        if (listaMesas[contc].Mesa_Estado == "Libre")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaVerde"];
                        }
                        else if (listaMesas[contc].Mesa_Estado=="En espera"){
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaEnEspera"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Ocupada")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaRoja"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Pidiendo")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaPidiendo"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Reservada")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaReservada"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Servidos")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaServidos"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Esperando Cuenta")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaEsperandoCuenta"];
                        }
                        else if (listaMesas[contc].Mesa_Estado == "Pagando")
                        {
                            btn.Style = (Style)Application.Current.Resources["BotondeMesaPagando"];
                        }
                        btn.Click += preguntarMesa;
                        grdMesas.Children.Add(btn);
                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);
                        contc++;
                        limite++;
                        if (limite == 5)
                        {
                            rows++;
                            limite = 0;
                        }
                        cols = limite;



                    }
                }
            }
            if (numMesas==25)
            {
           
            }
            else {
                btnAdd.Content = "Agregar";

                btnAdd.Style = (Style)Application.Current.Resources["BotonAgregar"];
                btnAdd.Click += crearMesa;
                grdMesas.Children.Add(btnAdd);
                Grid.SetRow(btnAdd, rows);
                Grid.SetColumn(btnAdd, cols);
            }

            
        }
        private void crearMesa(object sender, RoutedEventArgs e)
        {

                Mesa mesa = new Mesa();
                mesa.Mesa_Estado = "Libre";
                mesa.Mesa_Posicion = cols;
                TrabajarMesas.add_mesa(mesa);
                cargarColeccion();
                Button btnMesa = new Button();

               
                btnMesa.Content = listaMesas[contc].Mesa_Id.ToString();
                if (listaMesas[contc].Mesa_Estado == "Libre")
                {
                    btnMesa.Style = (Style)Application.Current.Resources["BotondeMesaVerde"];
                }
                btnMesa.Click += preguntarMesa;
                grdMesas.Children.Add(btnMesa);
                Grid.SetRow(btnMesa, rows);
                Grid.SetColumn(btnMesa, cols);
                cols++;
                Grid.SetRow(btnAdd, rows);
                Grid.SetColumn(btnAdd, cols);
                numMesas++;
                limite++;
                if (limite >= columna)
                {
                    if (numMesas==25)
                    {
                        MessageBox.Show("No se pueden agregar más mesas.","Límite de mesas alcanzado",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    }
                    else {
                        rows++;
                        cols = 0;
                        limite = 0;
                        Grid.SetRow(btnAdd, rows);
                        Grid.SetColumn(btnAdd, cols);
                    }
                }
                contc++;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Mesa mesa = new Mesa();
            Dialogo.IsOpen = false;
            mesa=TrabajarMesas.obtener_mesa(id);
            mesa.Mesa_Estado = Convert.ToString(cmbEstadoMesas.SelectedValue);
            TrabajarMesas.edit_mesa(mesa);

            winMesas refresh = new winMesas();
            refresh.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Dialogo.IsOpen = false;
        }

        

    }
}
