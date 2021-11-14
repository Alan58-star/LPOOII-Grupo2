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
    /// Interaction logic for winNuevoPedido.xaml
    /// </summary>
    public partial class winNuevoPedido : Window
    {
        public winNuevoPedido()
        {
            InitializeComponent();
        }
        public winNuevoPedido(int idmesa)
        {
            InitializeComponent();
            dpFecha.BlackoutDates.AddDatesInPast();
            Load_TextMesa(idmesa);
            Load_ComboCliente();
        }

        Mesa mesa = new Mesa();


        private void Load_TextMesa(int idmesa)
        {
            mesa = TrabajarMesas.obtener_mesa(idmesa);
            txbMesas.Text = mesa.Mesa_Id.ToString();

        }
        private void Load_ComboCliente()
        {
            var data2 = (TrabajarClientes.traerClientes() as System.ComponentModel.IListSource).GetList();
            cboCliente.DisplayMemberPath = "cli_apellido";
            cboCliente.SelectedValuePath = "cli_id";
            cboCliente.ItemsSource = data2;

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
                winMesas oWinMesa = new winMesas();
                oWinMesa.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnagregarPed_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Crear Pedido", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Pedido oPedido = new Pedido();
                    //oPedido.Mesa_Id = Convert.ToInt32(cboMesas.SelectedValue.ToString());
                    oPedido.Mesa_Id = mesa.Mesa_Id;
                    mesa.Mesa_Estado = "En espera";
                    TrabajarMesas.edit_mesa(mesa);
                    oPedido.Cli_Id = Convert.ToInt32(cboCliente.SelectedValue.ToString());
                    oPedido.Ped_Fecha_Emision = DateTime.Now;
                    oPedido.Ped_Facturado = false;

                    oPedido.Ped_Fecha_Entrega = Convert.ToDateTime(dpFecha.SelectedDate);
                    oPedido.Ped_Comensales = Convert.ToInt32(txtComensal.Text);
                    oPedido.Usr_Id = 4;
                    Console.WriteLine(oPedido.Ped_Fecha_Entrega);
                    TrabajarPedido.add_pedido(oPedido);

                    MessageBox.Show("Pedido Guardado con éxito", "Datos Creados", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtComensal.Text = "";

                    winPedidos oWinPedidos = new winPedidos(1);
                    oWinPedidos.Show();
                    this.Close();

                }
            }
            
        }

        private bool validarCampos()
        {
            bool valido = true;
            int comboCliente = Convert.ToInt32(cboCliente.SelectedValue);
            if (dpFecha.SelectedDate == null)
            {
                valido = false;
                MessageBox.Show("Debe seleccionar la fecha de entrega del pedido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valido;
            }
            if ((string.IsNullOrEmpty(cboCliente.Text)) || (comboCliente == -1))
            {
                valido = false;
                MessageBox.Show("Debe seleccionar el cliente al que le corresponde el pedido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valido;
            }
            if (Convert.ToInt32(txtComensal.Text) <= 0)
            {
                valido = false;
                MessageBox.Show("Debe ingresar 1 o más comensales", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valido;
            }

            if(txtComensal.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar la cantidad de comensales.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valido;
            }
            return valido;
        }
    }


}
