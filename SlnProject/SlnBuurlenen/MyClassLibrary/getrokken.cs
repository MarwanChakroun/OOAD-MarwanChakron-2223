using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class getrokken : auto
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int gewicht { get; set; }
        public int maxbelasting { get; set; }
        public string afmeting { get; set; }
        public bool geremd { get; set; }

        public getrokken()
        {
        }

        public getrokken(int ID, string Naam, string Beschrijving, int Bouwjaar, string Merk, string Model, int Type, int EigenaarID, int GEWICHT, int MAXBELASTING, string AFMETING, bool GEREMD)
        {
            id = ID;
            naam = Naam;
            beschrijving = Beschrijving;
            bouwjaar = Bouwjaar;
            merk = Merk;
            model = Model;
            type = Type;
            eigenaarId = EigenaarID;
            gewicht = GEWICHT;
            maxbelasting = MAXBELASTING;
            afmeting = AFMETING;
            geremd = GEREMD;
        }

        public List<getrokken> getallGetrokken()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                List<getrokken> trokVoertuigen = new List<getrokken>();
                getrokken trokVoertuig = new getrokken();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Voertuig WHERE type = 2", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    trokVoertuig.id = Convert.ToInt32(reader["id"]);
                    trokVoertuig.naam = Convert.ToString(reader["naam"]);
                    trokVoertuig.beschrijving = Convert.ToString(reader["beschrijving"]);
                    trokVoertuig.bouwjaar = Convert.ToInt32(reader["bouwjaar"]);
                    trokVoertuig.merk = Convert.ToString(reader["merk"]);
                    trokVoertuig.model = Convert.ToString(reader["model"]);
                    trokVoertuig.type = Convert.ToInt32(reader["type"]);
                    trokVoertuig.eigenaarId = Convert.ToInt32(reader["eigenaar_id"]);
                    trokVoertuig.gewicht = Convert.ToInt32(reader["gewicht"]);
                    trokVoertuig.maxbelasting = Convert.ToInt32(reader["maxbelasting"]);
                    trokVoertuig.afmeting = Convert.ToString(reader["afmetingen"]);
                    trokVoertuig.geremd = Convert.ToBoolean(reader["geremd"]);
                    trokVoertuigen.Add(trokVoertuig);
                    trokVoertuig = new getrokken();
                }
                return trokVoertuigen;
            }
        }

        public getrokken getGetrokken(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                getrokken trokVoertuig = new getrokken();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Voertuig WHERE id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    trokVoertuig.id = Convert.ToInt32(reader["id"]);
                    trokVoertuig.naam = Convert.ToString(reader["naam"]);
                    trokVoertuig.beschrijving = Convert.ToString(reader["beschrijving"]);
                    trokVoertuig.bouwjaar = Convert.ToInt32(reader["bouwjaar"]);
                    trokVoertuig.merk = Convert.ToString(reader["merk"]);
                    trokVoertuig.model = Convert.ToString(reader["model"]);
                    trokVoertuig.type = Convert.ToInt32(reader["type"]);
                    trokVoertuig.eigenaarId = Convert.ToInt32(reader["eigenaar_id"]);
                    trokVoertuig.gewicht = Convert.ToInt32(reader["gewicht"]);
                    trokVoertuig.maxbelasting = Convert.ToInt32(reader["maxbelasting"]);
                    trokVoertuig.afmeting = Convert.ToString(reader["afmetingen"]);
                    trokVoertuig.geremd = Convert.ToBoolean(reader["geremd"]);
                }
                return trokVoertuig;
            }
        }
    }
}
