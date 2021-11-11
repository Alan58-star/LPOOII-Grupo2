﻿using System;
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
    /// Interaction logic for winPedidos.xaml
    /// </summary>
    public partial class winPedidos : Window
    {
        Mesa mesa = new Mesa();
        public winPedidos()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            
            Pedido ped = (Pedido)lvwPedidos.SelectedItem;
           
            winAltaItemPedido winAltaitemPedido = new winAltaItemPedido(ped);
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

        private void verPedido_Click(object sender, RoutedEventArgs e)
        {
            Pedido ped = (Pedido)lvwPedidos.SelectedItem;
            winVistaPreviaPedido vp = new winVistaPreviaPedido(ped);
            MessageBoxResult result = MessageBox.Show("¿Facturar Pedido?", "Facturacion", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
            
            if (result == MessageBoxResult.Yes)
            {
                TrabajarPedido.edit_pedido(true, ped.Ped_Id);
                ped.Mesa.Mesa_Estado = "Libre";
                TrabajarMesas.edit_mesa(ped.Mesa);
                (FindResource("LIST_PEDIDO") as ObjectDataProvider).Refresh();
                vp.Show();
                
            }
            else if (result == MessageBoxResult.No)
            {
                vp.Show();
                
            }       
                      
           
        }

        private void lvwPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAddItem.Foreground = (Brush)(new BrushConverter().ConvertFromString("#fefefe"));
            btnAddItem.IsEnabled = true;
            btnverPedido.Foreground = (Brush)(new BrushConverter().ConvertFromString("#fefefe"));
            btnverPedido.IsEnabled = true;
        }
    }
}
