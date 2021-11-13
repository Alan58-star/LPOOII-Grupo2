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
    /// Interaction logic for winFamilias.xaml
    /// </summary>
    public partial class winFamilias : Window
    {
        Familia fam;

        public winFamilias(int fid)
        {
            InitializeComponent();

            int famID = fid;
            if (famID == 0)
            {
                btnEditar.IsEnabled = false;
                btnEditar.Visibility = Visibility.Hidden;
            }
            else
            {
                lblFamTitle.Content = "Actualizar Familia";
                fam = TrabajarFamilias.obtener_familia(famID);
                lblNewFamTitle.Content = "Actualizar";
                lblNewFamDescrip.Content = "Actualice los datos de la familia";
                btnGuardar.IsEnabled = false;
                btnGuardar.Visibility = Visibility.Hidden;

                txtFamDescrip.Text=fam.Fam_Descrip;
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

            MessageBoxResult result = MessageBox.Show("¿Desea guardar estos datos?", "Guardar Familia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Familia oFamilia = new Familia();

                oFamilia.Fam_Descrip = txtFamDescrip.Text;


                TrabajarFamilias.add_familia(oFamilia);

                MessageBox.Show("Familia guardada con éxito");

                txtFamDescrip.Text = "";

                winABMFamilias winABMF = new winABMFamilias();
                winABMF.Show();
                this.Close();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea actualizar estos datos?", "Actualizar Familia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Familia oFamilia = new Familia();

                oFamilia.Fam_Id = fam.Fam_Id;
                oFamilia.Fam_Descrip = txtFamDescrip.Text;

                TrabajarFamilias.edit_familia(oFamilia);

                MessageBox.Show("Familia actualizada con éxito", "Familia actualizada", MessageBoxButton.OK, MessageBoxImage.Information);

                txtFamDescrip.Text = "";

                winABMFamilias winABMF = new winABMFamilias();
                winABMF.Show();
                this.Close();
            }
        }
    }
}
