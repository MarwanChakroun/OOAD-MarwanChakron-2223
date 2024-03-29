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
using System.Configuration;
using System.Data.SqlClient;
using MyClassLibrary;

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private MainWindow Mainwin;


        public Login(MainWindow mainwininp)
        {
            InitializeComponent();
            Mainwin = mainwininp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtbUsername.Text == "" || txtbUsername.Text == "")
            {
                return;
                
            }

            Gebruiker gb = Gebruiker.LogGebruikerIn(txtbUsername.Text, txtbPassword.Text);

            if (gb.Id != -1)
            {
                if(gb.Rol != eRol.Admin)
                {
                    lblComment.Content = "Dit Toepassing dient alleen voor administrators";
                    return;
                }

                lblComment.Content = "Connected";
                Mainwin.ReloadFrame(gb);
                this.Close();
            }
            else
            {
                lblComment.Content = "Wrong combination";
            }

        }
    }
}
