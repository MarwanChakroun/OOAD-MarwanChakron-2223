using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.IO;
using System.Security.Cryptography;

namespace MyClassLibrary
{
    public enum eGeslacht { OnBekend = 0, Man = 1, Vrouw = 2, Null = 9}
    public enum eRol { Admin = 1, Kapper = 2, Klant = 3 }
    public class Gebruiker
    {
        public int Id { get; } = -1;
        public string Voornaam { get; set; } = "Onbekend";
        public string Achternaam { get; set; } = "Onbekend";
        public string Login { get; set; } = "Onbekend";
        public string Password { get; set; } = "Onbekend";
        public eGeslacht Geslacht { get; set; } = eGeslacht.OnBekend;
        public eRol Rol { get; set; } = eRol.Klant;
        
        
        public string Email { get; set; } = "Onbekend";
        public string GSM { get; set; } = "Onbekend";
        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //Constructor
        public Gebruiker(int idinp, string voornminp, string achternminp, string logininp, string passwordinp, eGeslacht geslachtinp,
            eRol rolinp, string emailinp, string gsminp)
        {
            Id = idinp;
            Voornaam = voornminp;
            Achternaam = achternminp;
            Login = logininp;
            Password = passwordinp;
            Geslacht = geslachtinp;
            Rol = rolinp;
            Email = emailinp;
            GSM = gsminp;
        }
        public Gebruiker (int idinp, string voornminp, string achternminp, string logininp, string passwordinp, eGeslacht geslachtinp,
            eRol rolinp)
        {
            Id = idinp;
            Voornaam = voornminp;
            Achternaam = achternminp;
            Login = logininp;
            Password = passwordinp;
            Geslacht = geslachtinp;
            Rol = rolinp;
        }

        static public List<Gebruiker> GetAll()
        {
            List<Gebruiker> Gebruikers = new List<Gebruiker>();
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Gebruiker]", conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*
                            BitmapImage img = new BitmapImage();
                            if (reader["profielfoto"] != DBNull.Value)
                            {
                                img = new BitmapImage();
                                img.BeginInit();
                                img.CacheOption = BitmapCacheOption.OnLoad;
                                img.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfoto"]);
                                img.EndInit();
                            }
                            */


                            Gebruikers.Add(new Gebruiker(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]), (eRol)Convert.ToInt32(reader["rol"]),
                                (reader["email"] == null) ? String.Empty : Convert.ToString(reader["email"]),
                                (reader["gsm"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["gsm"])));

                            //(reader["indiensttreding"] == null) ? DateTime.MinValue : Convert.ToDateTime(reader["indiensttreding"])
                        }
                    }
                }
                conn.Close();
            }
            return Gebruikers;
        }

        static public void ParseNewGebruiker(Gebruiker geb)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Gebruiker] ([voornaam] ,[achternaam],[login],[paswoord],[geslacht],[rol]) " +
                    $"VALUES ('{geb.Voornaam}','{geb.Achternaam}','{geb.Login}','{geb.Password}','{(int)geb.Geslacht}','{(int)geb.Rol}')", conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        static public Gebruiker GetGebById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Gebruiker] where id like '{id}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Gebruiker(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]), (eRol)Convert.ToInt32(reader["rol"]),
                                (reader["email"] == null) ? String.Empty : Convert.ToString(reader["email"]),
                                (reader["gsm"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["gsm"]));
                        }

                    }
                }
                conn.Close();
            }
            return new Gebruiker(-1, "", "", "", "", eGeslacht.Null, eRol.Klant);
        }

        static public Gebruiker GetGebByUsername(string usrname)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Gebruiker] where login like '{usrname}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Gebruiker(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]), (eRol)Convert.ToInt32(reader["rol"]),
                                (reader["email"] == null) ? String.Empty : Convert.ToString(reader["email"]),
                                (reader["gsm"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["gsm"]));
                        }

                    }
                }
                conn.Close();
            }
            return new Gebruiker(-1,"","","","",eGeslacht.Null, eRol.Klant);
        }

        static public Gebruiker LogGebruikerIn(string username, string password)
        {
            string hashpsw = "";
            using (SHA256 sha = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
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
                using (SqlCommand cmd = new SqlCommand($"select * from Gebruiker where login like '{username}' and paswoord like '{hashpsw}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            
                            return Gebruiker.GetGebByUsername(username);
                            
                        }
                        else
                        {
                            return new Gebruiker(-1, "", "", "", "", eGeslacht.Null, eRol.Klant);
                        }

                    }
                }
                conn.Close();
            }
        }
        

        public override string ToString()
        {
            return $" ( {Login} ) {Achternaam} {Voornaam}"; 
        }

    }
}
