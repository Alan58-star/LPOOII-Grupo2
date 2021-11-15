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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winStartupScreen.xaml
    /// </summary>
    public partial class winStartupScreen : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        

        public winStartupScreen()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,2);
            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = Directory.GetCurrentDirectory() + @"\Media\SONIDO.wav"; // SACAR 'Directory.GetParent' AL COMPILAR EL RELEASE
            sp.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            winLogin oWinLogin = new winLogin();
            oWinLogin.Show();
            timer.Stop();
            this.Close();
        }
    }
}
