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

namespace WpfGebruiker
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Gebruiker actualUser = new Gebruiker();
        public Menu(Gebruiker gb)
        {
            InitializeComponent();
            actualUser = gb;
            MainFrame.Content = new Home(gb);
        }

        private void btnOntlening_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OnteleningenAanvragen(actualUser);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Home(actualUser);
        }

        private void btnVoertuigen_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Voertuigen(actualUser);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginPage = new MainWindow();
            loginPage.Show();
            this.Close();
        }
    }
}
