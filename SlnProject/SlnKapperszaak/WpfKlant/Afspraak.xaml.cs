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
using System.Windows.Shapes;
using MyClassLibrary;

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour Afspraak.xaml
    /// </summary>
    public partial class Afspraak : Window
    {
        public Afspraak(bool ingelogd)
        {
            InitializeComponent();
            cbKappers.ItemsSource = Kapper.GetAllKappers();
            wpSignup.Visibility = ingelogd? Visibility.Hidden : Visibility.Visible;
        }

        public void ShowKapper(Kapper kp)
        {
            Image img = new Image();
            try
            {
                img.Source = kp.ProfielFoto;
                img.Width = 60;
                img.Height = 60;
            }
            catch (Exception)
            {
            }

            StackPanel mainsp = new StackPanel();

            mainsp.Margin = new Thickness(10, 5, 0, 0);
            mainsp.Width = 250;

            Label lblName = new Label();
            Label lblSpecs = new Label();
            lblSpecs.Content = kp.GetSpecsString();
            lblName.Content = kp.Achternaam + " " + kp.Voornaam;

            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Background = new SolidColorBrush(Color.FromRgb(141, 154, 165));
            sp.Margin = new Thickness(10, 5, 10, 0);


            StackPanel splbl = new StackPanel();
            splbl.Margin = new Thickness(5, 0, 0, 0);
            splbl.Children.Add(lblName);
            splbl.Children.Add(lblSpecs);

            sp.Children.Add(img);
            sp.Children.Add(splbl);
            mainsp.Children.Add(sp);
            wpKapper.Children.Add(mainsp);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wpKapper.Children.Clear();
            ShowKapper((Kapper)cbKappers.SelectedItem);
        }

    }
}
