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
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winArticulos.xaml
    /// </summary>
    public partial class winArticulos : Window
    {
        String archivo, route, destino;

        Articulo art1 = new Articulo();
        public winArticulos(int idarticulo)
        {
            InitializeComponent();
            int idart=idarticulo;
            if (idart == 0)
            {
                btneditart.IsEnabled = false;
                btneditart.Visibility = Visibility.Hidden;
                //txtPrecio.Text = "";
            }
            else {
                lblWinTitle.Content = "Actualización de Artículo";
                lblNewArtDescrip.Content = "Modifique los datos del Artículo";
                art1 = TrabajarArticulos.obtener_articulo(idarticulo);
                lblNewArtTitle.Content = "Actualizar Artículo";
                btnagregarart.IsEnabled = false;
                btnagregarart.Visibility = Visibility.Hidden;


                txtPrecio.Text = ((art1.Art_Precio)).ToString().Replace(",",".");

                chkStock.IsChecked=art1.Art_Manejo_Stock;
                txtDescripcion.Text = art1.Art_Descrip;
                cboFlia.SelectedIndex = art1.Familia.Fam_Id-1;  
                cboMedida.SelectedIndex = art1.Unidad_Medida.Um_Id-1;          
                cboCategoria.SelectedIndex = art1.Categoria.Cat_Id-1;
                Uri resourceUri = new Uri(art1.Art_Imagen);
                imgArticulo.Source = new BitmapImage(resourceUri);
            }
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //validarCampos();
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Crear Artículo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Articulo oArticulo = new Articulo();
                    oArticulo.Fam_Id = Convert.ToInt32(cboFlia.SelectedValue.ToString());
                    oArticulo.Art_Precio = Convert.ToDecimal(txtPrecio.Text.Replace(".", ","));
                    oArticulo.Um_Id = Convert.ToInt32(cboMedida.SelectedValue.ToString());
                    oArticulo.Cat_Id = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                    oArticulo.Art_Descrip = txtDescripcion.Text;

                    if (chkStock.IsChecked == true) oArticulo.Art_Manejo_Stock = true;
                    else oArticulo.Art_Manejo_Stock = false;
                    oArticulo.Art_Imagen = imgArticulo.Source.ToString();
                    TrabajarArticulos.add_articulo(oArticulo);

                    MessageBox.Show("Artículo Guardado con éxito", "Datos Creados", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtDescripcion.Text = "";
                    txtPrecio.Text = "";
                    chkStock.IsChecked = false;
                    cboCategoria.SelectedItem = null;
                    cboFlia.SelectedItem = null;
                    cboMedida.SelectedItem = null;
                }
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
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ABMArticulos winABM = new ABMArticulos();
                winABM.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_ComboFamilias();
            Load_ComboUM();
            Load_ComboCategorias();
        }

        private void Load_ComboFamilias()
        {
            
            var data = (TrabajarArticulos.list_familias() as System.ComponentModel.IListSource).GetList();
            
            cboFlia.DisplayMemberPath = "fam_descripcion";
            cboFlia.SelectedValuePath = "fam_id";
            cboFlia.ItemsSource = data;
        }
        private void Load_ComboCategorias()
        {

            var data = (TrabajarArticulos.list_categorias() as System.ComponentModel.IListSource).GetList();
            cboCategoria.DisplayMemberPath = "cat_descripcion";
            cboCategoria.SelectedValuePath = "cat_id";
            cboCategoria.ItemsSource = data;
        }
        private void Load_ComboUM()
        {
            var data2 = (TrabajarArticulos.list_UM() as System.ComponentModel.IListSource).GetList();
            cboMedida.DisplayMemberPath = "UM_descripcion";
            cboMedida.SelectedValuePath = "UM_id";
            cboMedida.ItemsSource = data2;

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Artículo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Articulo oArticulo1 = new Articulo();
                    oArticulo1.Art_Id = art1.Art_Id;
                    oArticulo1.Fam_Id = Convert.ToInt32(cboFlia.SelectedValue.ToString());
                    oArticulo1.Art_Precio = Convert.ToDecimal(txtPrecio.Text.Replace(".", ","));
                    oArticulo1.Um_Id = Convert.ToInt32(cboMedida.SelectedValue.ToString());
                    oArticulo1.Cat_Id = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                    oArticulo1.Art_Descrip = txtDescripcion.Text;

                    if (chkStock.IsChecked == true) oArticulo1.Art_Manejo_Stock = true;
                    else oArticulo1.Art_Manejo_Stock = false;
                    oArticulo1.Art_Imagen = imgArticulo.Source.ToString();
                    TrabajarArticulos.edit_articulo(oArticulo1);

                    MessageBox.Show("Artículo actualizado con éxito", "Datos Actualizados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }  
        }

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
         
            openFileDialog.Title = "Por favor Seleccione una Imagen";

            if (openFileDialog.ShowDialog() == true)
            {
                archivo = openFileDialog.FileName;
                route = @"D:\-N-\Trabajos\3° APU\LPOO II\TRABAJO PRÁCTICO\LPOOII-Grupo2\Vistas\Images";
                destino = System.IO.Path.Combine(route, openFileDialog.SafeFileName);
                System.IO.File.Copy(archivo, destino, true);

                Uri fileUri = new Uri(destino);
                imgArticulo.Source = new BitmapImage(fileUri);
            }
        }

        private bool validarCampos()
        {
            bool valido = true;
            int comboFamilia = Convert.ToInt32(cboFlia.SelectedValue);
            int comboMedida = Convert.ToInt32(cboMedida.SelectedValue);
            int comboCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            int textoPrecio = Convert.ToInt32(txtPrecio.Text);
            //string imagen = Convert.ToString(imgArticulo.Source);
            if( (string.IsNullOrEmpty(cboFlia.Text)) || (comboFamilia == -1) )
            {
                valido = false;
                MessageBox.Show("Debe seleccionar una familia para el artículo.");
                return valido;
            }
            if( (string.IsNullOrEmpty(cboMedida.Text)) || (comboMedida == -1) )
            {
                valido = false;
                MessageBox.Show("Debe seleccionar una unidad de medida para el artículo.");
                return valido;
            }
            if( (string.IsNullOrEmpty(cboCategoria.Text)) || (comboCategoria == -1) )
            {
                valido = false;
                MessageBox.Show("Debe seleccionar una categoría para el artículo.");
                return valido;
            }
            if( textoPrecio == 0 )
            {
                valido = false;
                MessageBox.Show("Debe ingresar el precio del artículo.");
                return valido;
            }
            if(txtDescripcion.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar una descripción del artículo.");
                return valido;
            }
            /*if(imagen == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar una imágen del artículo.");
                return valido;
            }*/
            return valido;
        }
    }
}
