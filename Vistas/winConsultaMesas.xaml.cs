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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winConsultaMesas.xaml
    /// </summary>
    public partial class winConsultaMesas : Window
    {
        public winConsultaMesas()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            winMesas winMesas = new winMesas(Convert.ToInt32(txtNroMesas.Text.ToString()));
            winMesas.Show();
            this.Close();
        }
    }
}