using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Configuration;
using System.Data.SqlClient;

namespace MyClassLibrary
{
    public class Kapper : Gebruiker
    {
        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public DateTime Indiensttreding { get; set; } = DateTime.MinValue;
        public BitmapImage ProfielFoto { get; set; }

        public List<Specialiteit> Specialiteiten = new List<Specialiteit>();
        public Kapper(int idinp, string voornminp, string achternminp, string logininp, string passwordinp, eGeslacht geslachtinp, eRol rolinp, DateTime indstrinp, BitmapImage profielfotoinp, List<Specialiteit> specialiteitinp) : base(idinp, voornminp, achternminp, logininp, passwordinp, geslachtinp, rolinp)
        {
            Specialiteiten = specialiteitinp;
            ProfielFoto = profielfotoinp;
            Indiensttreding = indstrinp;
        }

        static public List<Kapper> GetKappersBySpec(Specialiteit specinp)
        {
            List<Kapper> Kappers = new List<Kapper>();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();
                //select id, voornaam, achternaam, login, paswoord, geslacht, rol, indiensttreding, profielfoto from Gebruiker G join KapperSpecialiteit K on g.id = K.kapper_id where rol = 2 and specialiteit_sleutelwoord like 'kleuren';
                using (SqlCommand cmd = new SqlCommand($"select id, voornaam, achternaam, login, paswoord, geslacht, rol, indiensttreding, profielfoto from Gebruiker G join KapperSpecialiteit K on g.id = K.kapper_id where rol = {(int)eRol.Kapper} and specialiteit_sleutelwoord like '{specinp.sleutelwoord}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BitmapImage img = new BitmapImage();
                            if (reader["profielfoto"] != DBNull.Value)
                            {
                                img = new BitmapImage();
                                img.BeginInit();
                                img.CacheOption = BitmapCacheOption.OnLoad;
                                img.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfoto"]);
                                img.EndInit();
                            }

                            Kappers.Add(new Kapper(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]),
                                (eRol)Convert.ToInt32(reader["rol"]), (reader["indiensttreding"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["indiensttreding"]),
                                img, Specialiteit.GetSpecialiteiten(Convert.ToInt32(reader["id"]))));

                        }
                    }
                }
                conn.Close();
            }
            return Kappers;
        }

        static public List<Kapper> GetAllKappers()
        {
            List<Kapper> Kappers = new List<Kapper>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT id, voornaam, achternaam, login, paswoord, geslacht, rol, indiensttreding, profielfoto FROM [Gebruiker] WHERE rol = {(int)eRol.Kapper}", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BitmapImage img = new BitmapImage();
                            if (reader["profielfoto"] != DBNull.Value)
                            {
                                img = new BitmapImage();
                                img.BeginInit();
                                img.CacheOption = BitmapCacheOption.OnLoad;
                                img.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfoto"]);
                                img.EndInit();
                            }

                            Kappers.Add(new Kapper(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]),
                                (eRol)Convert.ToInt32(reader["rol"]), (reader["indiensttreding"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["indiensttreding"]),
                                img, Specialiteit.GetSpecialiteiten(Convert.ToInt32(reader["id"])))) ;


                            /*
                            Gebruikers.Add(new Gebruiker(Convert.ToInt32(reader["id"]), Convert.ToString(reader["voornaam"]), Convert.ToString(reader["achternaam"]),
                                Convert.ToString(reader["login"]), Convert.ToString(reader["paswoord"]), (eGeslacht)Convert.ToInt32(reader["geslacht"]), (eRol)Convert.ToInt32(reader["rol"]),
                                (reader["indiensttreding"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["indiensttreding"]),
                                (reader["email"] == null) ? String.Empty : Convert.ToString(reader["email"]),
                                (reader["gsm"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["gsm"]))); ;
                            */
                            //(reader["indiensttreding"] == null) ? DateTime.MinValue : Convert.ToDateTime(reader["indiensttreding"])
                        }
                    }
                }
                conn.Close();
            }
            return Kappers;
        }

        public string GetSpecsString()
        {
            string specs = "";

            foreach (Specialiteit spec in Specialiteiten)
            {
                specs += spec.sleutelwoord + " ";
            }

            return specs;
        }

    }
}
