using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfMatchImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer chronometer = new DispatcherTimer();
        int tijd = 0;
        Button button1 = new Button();
        Button button2 = new Button();
        bool firstORsecund = false;
        int a = 8;
        public MainWindow()
        {
            InitializeComponent();
            chronometer.Interval = TimeSpan.FromSeconds(1);
            chronometer.Tick += tellen;
            chronometer.Start();
        }

        public void tellen(object a, EventArgs b)
        {
            tijd++;
            TimeSpan time = TimeSpan.FromSeconds(tijd);
            string timeString = time.ToString(@"hh\:mm\:ss");
            lblTime.Content = timeString;
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (firstORsecund == false)
            {
                button1 = (Button)sender;
                button1.Opacity = 0.5;
                button1.IsEnabled = false;
                firstORsecund = true;
            }
            else
            {
                button2 = (Button)sender;
                button2.Opacity = 0.5;
                button2.IsEnabled = false;
                firstORsecund = false;
                string tag1 = Convert.ToString(button1.Tag);
                string tag2 = Convert.ToString(button2.Tag);

                if (tag1 == tag2)
                {
                    a--;
                    lblAantal.Content = "Juist nog " + a + " te vinden";
                }
                else
                {
                    button1.IsEnabled = true;
                    button1.Opacity = 1;
                    button2.IsEnabled = true;
                    button2.Opacity = 1;
                    button1 = null;
                    button2 = null;
                    lblAantal.Content = "FOUT";
                }

                if (a == 0)
                {
                    lblAantal.Content = "Spel is klaar";
                    chronometer.Stop();
                }
            }
        }
    }
}
