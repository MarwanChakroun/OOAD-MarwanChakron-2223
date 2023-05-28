using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class auto
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int id { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        public int bouwjaar { get; set; }

        public string merk { get; set; }
        public string model { get; set; }
        public int type { get; set; }
        public int eigenaarId { get; set; }

        public List<auto> getallcar()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                List<auto> autos = new List<auto>();
                auto auto = new auto();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Voertuig", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    auto.id = Convert.ToInt32(reader["id"]);
                    auto.naam = Convert.ToString(reader["naam"]);
                    auto.beschrijving = Convert.ToString(reader["beschrijving"]);
                    auto.bouwjaar = Convert.ToInt32(reader["bouwjaar"]);
                    auto.merk = Convert.ToString(reader["merk"]);
                    auto.model = Convert.ToString(reader["model"]);
                    auto.type = Convert.ToInt32(reader["type"]);
                    auto.eigenaarId = Convert.ToInt32(reader["eigenaar_id"]);
                    autos.Add(auto);
                    auto = new auto();
                }
                return autos;
            }
        }
    }
}
