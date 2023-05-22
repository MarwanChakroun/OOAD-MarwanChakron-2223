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
        public Gebruiker gebruiker = new Gebruiker();
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
            if (gebruiker.Login(tbxEmail.Text, tbxPasword.Text).id == 0) 
            {
                lblLogin.Content = "Foute login gegevens";
            }
            else
            {
                lblLogin.Content = "Welkom " + gebruiker.Login(tbxEmail.Text, tbxPasword.Text).voornaam;
                Menu window = new Menu(gebruiker.Login(tbxEmail.Text, tbxPasword.Text));
                window.Show();
                this.Close();
            }
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
