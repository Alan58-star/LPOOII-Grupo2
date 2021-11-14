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
    /// Interaction logic for winCategorias.xaml
    /// </summary>
    public partial class winCategorias : Window
    {
        Categoria cat;

        public winCategorias(int cid)
        {
            InitializeComponent();
            int catID = cid;
            if (catID == 0)
            {
                btnEditar.IsEnabled = false;
                btnEditar.Visibility = Visibility.Hidden;
            }
            else
            {
                lblCatTitle.Content = "Actualizar Categoría";
                cat = TrabajarCategorias.obtener_categoria(catID);
                lblNewCatTitle.Content = "Actualizar";
                lblNewCatDescrip.Content = "Actualice los datos de la categoría";
                btnGuardar.IsEnabled = false;
                btnGuardar.Visibility = Visibility.Hidden;

                txtCatDescrip.Text = cat.Cat_Descrip;
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
                winABMCategorias cat = new winABMCategorias();
                cat.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Categoría", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Categoria oCategoria = new Categoria();

                    oCategoria.Cat_Descrip = txtCatDescrip.Text;


                    TrabajarCategorias.add_categoria(oCategoria);

                    MessageBox.Show("Categoría guardada con éxito", "Categoría agregada", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtCatDescrip.Text = "";

                    winABMCategorias winABMC = new winABMCategorias();
                    winABMC.Show();
                    this.Close();
                }
            }
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Categoría", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Categoria oCategoria = new Categoria();

                    oCategoria.Cat_Id = cat.Cat_Id;
                    oCategoria.Cat_Descrip = txtCatDescrip.Text;

                    TrabajarCategorias.edit_categoria(oCategoria);

                    MessageBox.Show("Categoría actualizada con éxito", "Categoría actualizada", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtCatDescrip.Text = "";

                    winABMCategorias winABMC = new winABMCategorias();
                    winABMC.Show();
                    this.Close();
                }
            }
            
        }

        private bool validarCampos()
        {
            bool valido = true;
            if (txtCatDescrip.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar una descripción para la categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valido;
            }
            return valido;
        }
    }
}
