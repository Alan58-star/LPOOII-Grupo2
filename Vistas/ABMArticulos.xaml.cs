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
using System.Collections.ObjectModel;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMArticulos.xaml
    /// </summary>
    public partial class ABMArticulos : Window
    {
        public ABMArticulos()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Articulo> listaArticulos;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_ARTICULO"];
            listaArticulos = odp.Data as ObservableCollection<Articulo>;

            Vista = (CollectionView)CollectionViewSource.GetDefaultView(contentGrid.DataContext);
        }

        private void btn_first_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btn_Agregar(object sender, RoutedEventArgs e)
        {
            winArticulos winArticulos = new winArticulos();
            winArticulos.Show();
            this.Close();
        }


 
    }
}
