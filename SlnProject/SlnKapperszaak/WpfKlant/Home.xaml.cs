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
using MyClassLibrary;

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Gebruiker usr = new Gebruiker(-1, "", "", "", "", eGeslacht.Null, eRol.Klant);

        public void initPanel(List<Kapper> kappersinp)
        {
            PanelKappers.Children.Clear();
            foreach (Kapper kapper in kappersinp)
            {
                Image img = new Image();
                try
                {
                    img.Source = kapper.ProfielFoto;
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
                lblSpecs.Content = kapper.GetSpecsString();
                lblName.Content = kapper.Achternaam + " " + kapper.Voornaam;

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
                PanelKappers.Children.Add(mainsp);


            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            initPanel(Kapper.GetKappersBySpec((Specialiteit)cbFilters.SelectedItem));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Afspraak afsp = new Afspraak(usr);
            afsp.Show();
        }

        private MainWindow Mainwin;
        private void btnLoginClick(object sender, RoutedEventArgs e)
        {
            Login lgn = new Login(Mainwin);
            lgn.Show();
        }
        public Home(MainWindow mw)
        {
            Mainwin = mw;
            InitializeComponent();
            cbFilters.ItemsSource = Specialiteit.GetAllSpecs();
            initPanel(Kapper.GetAllKappers());

        }

        public Home(Gebruiker user)
        {
            InitializeComponent();
            cbFilters.ItemsSource = Specialiteit.GetAllSpecs();
            initPanel(Kapper.GetAllKappers());
            lblWelcome.Content = "Welcome " + user.Voornaam;
            usr = user;
        }
    }
}
