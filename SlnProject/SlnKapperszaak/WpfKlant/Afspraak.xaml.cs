﻿using System;
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
using System.Security.Cryptography;

using MyClassLibrary;

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour Afspraak.xaml
    /// </summary>
    public partial class Afspraak : Window
    {
        Gebruiker usr;
        public Afspraak(Gebruiker usrinp)
        {
            InitializeComponent();
            cbKappers.ItemsSource = Kapper.GetAllKappers();
            usr = usrinp;
            wpSignup.Visibility = (usrinp.Id == -1) ? Visibility.Visible : Visibility.Hidden;
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

        private void btnBevestigen_Click(object sender, RoutedEventArgs e)
        {
            Gebruiker User = usr;
            if(usr.Id == -1)
            {
                eGeslacht gesl;

                if (txtbVoornaam.Text == "" || txtbAchternaam.Text == "" || txtbLogin.Text == "" || txtbPaswoord.Text == "")
                {
                    return;
                }

                if (rbopt1.IsChecked == true)
                    gesl = eGeslacht.Man;
                else if (rbopt2.IsChecked == true)
                    gesl = eGeslacht.Vrouw;
                else if (rbopt3.IsChecked == true)
                    gesl = eGeslacht.OnBekend;
                else
                    return;

                string hashpsw = "";
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(txtbPaswoord.Text);
                    byte[] hashBytes = sha.ComputeHash(passwordBytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    hashpsw = sb.ToString();
                }

                User = new Gebruiker(-1, txtbVoornaam.Text, txtbAchternaam.Text, txtbLogin.Text, hashpsw, gesl, eRol.Klant)
                Gebruiker.ParseNewGebruiker(User);
            }
            

        }
    }
}
