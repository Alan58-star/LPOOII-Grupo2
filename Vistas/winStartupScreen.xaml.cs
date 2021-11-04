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
using System.Media;
using System.Reflection;
using System.IO;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winStartupScreen.xaml
    /// </summary>
    public partial class winStartupScreen : Window
    {
        public winStartupScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();

            //SFX de prueba xd
            sp.SoundLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Media\bruh.wav"; // SACAR 'Directory.GetParent' AL COMPILAR EL RELEASE

            sp.Play();
        }
    }
}
