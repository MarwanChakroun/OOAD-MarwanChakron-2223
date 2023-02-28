using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfKerstverlichting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        bool button = true;
        int aantallampen = 0;
        List<Ellipse> lampjes = new List<Ellipse>();
        DispatcherTimer light = new DispatcherTimer();
        DispatcherTimer time = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            time.Interval = TimeSpan.FromMilliseconds(0.5);
            time.Tick += maakLamp;
            time.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Method to execute every 100 milliseconds goes here
            // ...
        }

        public static bool PixelIsWhite(Image img, int x, int y)
        {
            BitmapSource source = img.Source as BitmapSource;
            Color color = Colors.White;
            CroppedBitmap cb = new CroppedBitmap(source, new Int32Rect(x, y, 1, 1));
            byte[] pixels = new byte[4];
            cb.CopyPixels(pixels, 4, 0);
            color = Color.FromRgb(pixels[2], pixels[1], pixels[0]);
            return color.ToString() == "#FFFFFFFF";
        }

        private void maakLamp(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 300);
            int y = rnd.Next(50, 350);
            Ellipse newLight = new Ellipse();
            newLight.Width = 10;
            newLight.Height = 10;
            newLight.Fill = Brushes.Gray;
            newLight.Stroke = Brushes.Black;
            double xPos = x;
            double yPos = y;
            newLight.SetValue(Canvas.LeftProperty, (double)xPos);
            newLight.SetValue(Canvas.TopProperty, (double)yPos);

            if (PixelIsWhite(imgTree, x, y) == false)
            {
                lampjes.Add(newLight);
                cnvTree.Children.Add(newLight);
                aantallampen++;
            }

            if (aantallampen > 40)
            {
                time.Stop();
            }
        }

        private void buttonONOF_Click(object sender, RoutedEventArgs e)
        {
            if (button == true)
            {
                button = false;
                buttonONOF.Content = "OFF";
                light.Interval = TimeSpan.FromMilliseconds(1000);
                light.Tick += changeled;
                light.Start();
            }
            else
            {
                button = true;
                buttonONOF.Content = "ON";
                foreach (var item in lampjes)
                {
                    item.Fill = Brushes.Gray;
                }

            }
        }

        public void changeled(object sender, EventArgs e)
        {
            Random rndColor = new Random();
            foreach (var item in lampjes) { item.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rndColor.Next(0, 255)), Convert.ToByte(rndColor.Next(0, 255)), Convert.ToByte(rndColor.Next(0, 255)))); }
        }


    }
}
