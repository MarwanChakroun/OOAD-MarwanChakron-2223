using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class gemotoriseerd : auto
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int transmissie { get; set; }
        public int brandstof { get; set; }

        public gemotoriseerd()
        {
        }

        public List<gemotoriseerd> getallmotor()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                List<gemotoriseerd> motorVoertuigen = new List<gemotoriseerd>();
                gemotoriseerd motorVoertuig = new gemotoriseerd();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Voertuig WHERE type = 1", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    motorVoertuig.id = Convert.ToInt32(reader["id"]);
                    motorVoertuig.naam = Convert.ToString(reader["naam"]);
                    motorVoertuig.beschrijving = Convert.ToString(reader["beschrijving"]);
                    motorVoertuig.bouwjaar = Convert.ToInt32(reader["bouwjaar"]);
                    motorVoertuig.merk = Convert.ToString(reader["merk"]);
                    motorVoertuig.model = Convert.ToString(reader["model"]);
                    motorVoertuig.type = Convert.ToInt32(reader["type"]);
                }
            }
        }

    }
}
