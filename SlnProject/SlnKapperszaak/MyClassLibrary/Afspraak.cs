using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace MyClassLibrary
{
    public class Afspraak
    {
        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public int Id { get; set; } = -1;
        public DateTime Datum { get; set; }
        public TimeSpan Tijd { get; set; }
        public string Opmerking { get; set; }
        public Gebruiker Klant { get; set; }
        public Kapper Kpper { get; set; }

        public Afspraak(int idinp, DateTime datuminp, TimeSpan tijdinp, string opminp, Gebruiker klantinp, Kapper kpprinp)
        {
            Id = idinp;
            Datum = datuminp;
            Tijd = tijdinp;
            Opmerking = opminp;
            Klant = klantinp;
            Kpper = kpprinp;
        }

        static public List<Afspraak> GetAfspraken(Gebruiker usr)
        {
            List<Afspraak> Afspraken = new List<Afspraak>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Afspraak] where klant_id like '{usr.Id}'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Afspraken.Add(new Afspraak(Convert.ToInt32(reader["id"]), Convert.ToDateTime(reader["datum"]), TimeSpan.Parse(Convert.ToString(reader["tijd"])),
                                "", usr, Kapper.GetKapperById(Convert.ToInt32(reader["kapper_id"]))));
                        }

                    }
                }
                conn.Close();
            }
            return Afspraken;
        }

        static public bool ParseAfspraak(Afspraak afsp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Afspraak] ([datum] ,[tijd],[opmerking],[klant_id],[kapper_id]) " +
                    $"VALUES ('{afsp.Datum.ToString("yyyy-MM-dd")}','{afsp.Tijd.ToString()}','opmerking','{afsp.Klant.Id}','{afsp.Kpper.Id}')", conn))
                {
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    return true;
                }
                
            }
            return false;
        }

        static public void DeleteAfspraak(Afspraak afsp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM [Afspraak] where id = {afsp.Id}", conn))
                {
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

            }
        }

        public override string ToString()
        {
            return $"{Datum.DayOfWeek} {Datum.ToString("dd/MM/yyyy")} om {Tijd.ToString()} - {Kpper.Voornaam}";
        }

    }
}
