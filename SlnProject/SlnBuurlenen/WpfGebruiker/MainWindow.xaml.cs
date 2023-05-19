using MyClassLibrary;
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

namespace WpfGebruiker
{
    public partial class MainWindow : Window
    {
        private string strEmail = "";
        private string strPWD = "";
        public Gebruiker gebruiker;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tbxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxEmail.Text = strEmail;
        }
        private void tbxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            strEmail = tbxEmail.Text;
        }
        private void tbxPasword_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxPasword.Text = strPWD;
        }
        private void tbxPasword_LostFocus(object sender, RoutedEventArgs e)
        {
            strPWD = tbxPasword.Text;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (gebruiker.Login(tbxEmail.Text, tbxPasword.Text).Count == 1)
            {
                lblLogin.Content = "Foute login";
            }
            else
            {
                Gebruiker gb = new Gebruiker();
                gb = gebruiker.Login(tbxEmail.Text, tbxPasword.Text)[1];
                lblLogin.Content = $"Welkom {gb.voornaam}";
            }
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
