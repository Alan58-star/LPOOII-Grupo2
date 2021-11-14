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
    /// Interaction logic for winUnidadesDeMedida.xaml
    /// </summary>
    public partial class winUnidadesDeMedida : Window
    {
        Unidad_Medida um;

        public winUnidadesDeMedida(int umid)
        {
            InitializeComponent();

            int umID = umid;
            if (umID == 0)
            {
                btnEditar.IsEnabled = false;
                btnEditar.Visibility = Visibility.Hidden;
            }
            else
            {
                lblUMTitle.Content = "Actualizar UM";
                um = TrabajarUM.obtener_UM(umID);
                lblNewUMTitle.Content = "Actualizar";
                lblNewUMDescrip.Content = "Actualice los datos de la UM";
                btnGuardar.IsEnabled = false;
                btnGuardar.Visibility = Visibility.Hidden;

                txtUMDescrip.Text = um.Um_Descrip;
                txtUMAbrev.Text = um.Um_Abrev;
            }
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                winABMUMedidas ums = new winABMUMedidas();
                ums.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Unidad de medida", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Unidad_Medida oUM = new Unidad_Medida();

                    oUM.Um_Descrip = txtUMDescrip.Text;
                    oUM.Um_Abrev = txtUMAbrev.Text;

                    TrabajarUM.add_UM(oUM);

                    MessageBox.Show("Unidad de medida guardada con éxito", "Unidad de Medida Agregada", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtUMDescrip.Text = "";
                    txtUMAbrev.Text = "";

                    winABMUMedidas winABMUM = new winABMUMedidas();
                    winABMUM.Show();
                    this.Close();
                }
            } 
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(validarCampos())
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Unidad de medida", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Unidad_Medida oUM = new Unidad_Medida();

                    oUM.Um_Id = um.Um_Id;
                    oUM.Um_Descrip = txtUMDescrip.Text;
                    oUM.Um_Abrev = txtUMAbrev.Text;

                    TrabajarUM.edit_UM(oUM);

                    MessageBox.Show("Unidad de medida actualizada con éxito", "Unidad de Medida actualizada", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtUMAbrev.Text = "";
                    txtUMDescrip.Text = "";

                    winABMUMedidas winABMUM = new winABMUMedidas();
                    winABMUM.Show();
                    this.Close();
                }
            }
            
        }

        private bool validarCampos()
        {
            bool valido = true;
            if (txtUMDescrip.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar una descripción para la unidad de medida.");
                return valido;
            }
            if (txtUMAbrev.Text == "")
            {
                valido = false;
                MessageBox.Show("Debe ingresar una abreviatura para la unidad de medida.");
                return valido;
            }
            return valido;
        }

    }
}
