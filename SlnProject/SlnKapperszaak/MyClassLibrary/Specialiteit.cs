using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace MyClassLibrary
{
    public class Specialiteit
    {
        static string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int id;
        public string sleutelwoord;

        public Specialiteit(int idinp, string sleutelwrdinp)
        {
            id = idinp;
            sleutelwoord = sleutelwrdinp;
        }

        static public List<Specialiteit> GetAllSpecs()
        {
            List<Specialiteit> Specialiteiten = new List<Specialiteit>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Specialiteit", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Specialiteiten.Add(new Specialiteit(-1, Convert.ToString(reader["sleutelwoord"])));
                        }
                    }
                }
            }
            return Specialiteiten;
        }

        static public List<Specialiteit> GetSpecialiteiten(int kapperid)
        {
            List<Specialiteit> Specialiteiten = new List<Specialiteit>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM KapperSpecialiteit WHERE kapper_id = {kapperid}", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Specialiteiten.Add(new Specialiteit(Convert.ToInt32(reader["kapper_id"]),Convert.ToString(reader["specialiteit_sleutelwoord"])));
                        }
                    }
                }
            }
            return Specialiteiten;
        }

        public override string ToString()
        {
            return sleutelwoord;
        }
    }
}
