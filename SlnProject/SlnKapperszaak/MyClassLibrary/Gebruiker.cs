using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.IO;

namespace MyClassLibrary
{
    enum eGeslacht { OnBekend = 0, Man = 1, Vrouw = 2, Null = 9}
    enum eRol { Admin = 1, Kapper = 2, Klant = 3 }
    internal class Gebruiker
    {
        public int Id { get; } = -1;
        public string Voornaam { get; set; } = "Onbekend";
        public string Achternaam { get; set; } = "Onbekend";
        public string Login { get; set; } = "Onbekend";
        public string Password { get; set; } = "Onbekend";
        public eGeslacht Geslacht { get; set; } = eGeslacht.OnBekend;
        public eRol Rol { get; set; } = eRol.Klant;
        public DateTime Indiensttreding { get; set; }
        public BitmapImage ProfielFoto { get; set; }
        public string Email { get; set; } = "Onbekend";
        public string GSM { get; set; } = "Onbekend";
        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //Constructor
        public Gebruiker(int idinp, string voornminp, string achternminp, string logininp, string passwordinp
            , eGeslacht geslachtinp, eRol rolinp, DateTime indstrinp, BitmapImage profielfotoinp, string emailinp, string gsminp)
        {
            Id = idinp;
            Voornaam = voornminp;
            Achternaam = achternminp;
            Login = logininp;
            Password = passwordinp;
            Geslacht = geslachtinp;
            Rol = rolinp;
            Indiensttreding = indstrinp;
            ProfielFoto = profielfotoinp; 
            Email = emailinp;
            GSM = gsminp;
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
                            BitmapImage img = new BitmapImage();
                            img.BeginInit();
                            img.CacheOption = BitmapCacheOption.OnLoad;
                            img.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfoto"]);
                            img.EndInit();

                            Gebruikers.Add(new Gebruiker(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]), (eRol)Convert.ToInt32(reader["rol"]),
                                Convert.ToDateTime(reader["indiensttreding"]), img, Convert.ToString(reader["email"]), Convert.ToString(reader["gsm"])));
                        }
                    }
                }
                conn.Close();
            }
            return Gebruikers;
        }
        

    }
}
