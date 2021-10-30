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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for winAcercaDe.xaml
    /// </summary>
    public partial class winAcercaDe : Window
    {
        DispatcherTimer timer;
        public winAcercaDe()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);

        }

        void timer_Tick(object sender, EventArgs e)
        {
            slider1.Value = mediaElement1.Position.TotalSeconds;
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Volume = (double)slider2.Value; 
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Position = TimeSpan.FromSeconds(slider1.Value);
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string filename = (string)((DataObject)e.Data).GetFileDropList()[0];

            mediaElement1.Source = new Uri(filename);

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)slider2.Value;
            mediaElement1.Play();

        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediaElement1.NaturalDuration.TimeSpan;
            slider1.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string name = "D:/-N-/Trabajos/TorresIsmael-RíosDaniel-Jira.mp4";
            mediaElement1.Source = new Uri(name);

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)slider2.Value;
            mediaElement1.Play();
        }

    }
}
