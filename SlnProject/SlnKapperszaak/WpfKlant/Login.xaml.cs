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
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MyClassLibrary;

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;


        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtbUsername.Text == "" || txtbUsername.Text == "")
            {
                return;
            }

            string hashpsw = "";
            using(SHA256 sha = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(txtbPassword.Text);
                byte[] hashBytes = sha.ComputeHash(passwordBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                hashpsw = sb.ToString();
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"select * from Gebruiker where login like '{txtbUsername}' and paswoord like '{hashpsw}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lblComment.Content = "correct combination";
                        }
                        else
                        {
                            lblComment.Content = reader["login"];
                        }
                        
                    }
                }
                conn.Close();
            }
            
        }
    }
}
