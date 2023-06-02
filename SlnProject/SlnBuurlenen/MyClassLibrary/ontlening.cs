using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyClassLibrary
{
    public class ontlening
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int id { get; set; }
        public DateTime vanaf { get; set; }
        public DateTime tot { get; set; }
        public string bericht { get; set; }
        public int status { get; set; }
        public int idVoertuig { get; set; }
        public int idAanvrager { get; set; }

        public ontlening()
        {
        }

        public ontlening(DateTime VANAF, DateTime TOT, string BERICHT, int IDVOERTUIG, int IDAANVRAGER)
        {
            vanaf = VANAF;
            tot = TOT;
            bericht = BERICHT;
            idVoertuig = IDVOERTUIG;
            idAanvrager = IDAANVRAGER;
        }

        public ontlening(DateTime VANAF, DateTime TOT, string BERICHT, int STATUS,int IDVOERTUIG, int IDAANVRAGER)
        {
            vanaf = VANAF;
            tot = TOT;
            bericht = BERICHT;
            status = STATUS;
            idVoertuig = IDVOERTUIG;
            idAanvrager = IDAANVRAGER;
        }

        public void AddAaanvraag(ontlening aanvraag)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                List<gemotoriseerd> motorVoertuigen = new List<gemotoriseerd>();
                gemotoriseerd motorVoertuig = new gemotoriseerd();
                conn.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO Ontlening (vanaf, tot, bericht, status, voertuig_id, aanvrager_id) VALUES (@1,@2,@3,@4,@5,@6) ", conn);
                comm.Parameters.AddWithValue("@1", aanvraag.vanaf);
                comm.Parameters.AddWithValue("@2", aanvraag.tot);
                comm.Parameters.AddWithValue("@3", aanvraag.bericht);
                comm.Parameters.AddWithValue("@4", 1);
                comm.Parameters.AddWithValue("@5", aanvraag.idVoertuig);
                comm.Parameters.AddWithValue("@6", aanvraag.idAanvrager);
                comm.ExecuteScalar();
            }

            //DELETE FROM Ontlening WHERE id = @delete
        }

        public void DeleteOntlening(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Ontlening WHERE id=@delete", conn);
                comm.Parameters.AddWithValue("@delete", id);
                comm.ExecuteNonQuery();
            }
        }

        public List<ontlening> getAllMineOntlening(int id)
        {
            List<ontlening> ontleningen = new List<ontlening>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                ontlening ont = new ontlening();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Ontlening WHERE aanvrager_id = @id ORDER BY vanaf DESC", conn);
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ont.id = Convert.ToInt32(reader["id"]);
                    ont.vanaf = Convert.ToDateTime(reader["vanaf"]);
                    ont.tot = Convert.ToDateTime(reader["tot"]);
                    ont.bericht = Convert.ToString(reader["bericht"]);
                    ont.status = Convert.ToInt32(reader["status"]);
                    ont.idVoertuig = Convert.ToInt32(reader["voertuig_id"]);
                    ont.idAanvrager = Convert.ToInt32(reader["aanvrager_id"]);
                    ontleningen.Add(ont);
                    ont = new ontlening();
                }
            }
            return ontleningen;
        }

        public List<ontlening> getAllMineAanvragen(int id)
        {
            List<ontlening> ontleningen = new List<ontlening>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                ontlening ont = new ontlening();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT O.* FROM Ontlening O JOIN (SELECT DISTINCT V.id FROM Voertuig V WHERE V.eigenaar_id = @id) AS V ON O.voertuig_id = V.id WHERE O.status = 1 ORDER BY vanaf DESC", conn);
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ont.id = Convert.ToInt32(reader["id"]);
                    ont.vanaf = Convert.ToDateTime(reader["vanaf"]);
                    ont.tot = Convert.ToDateTime(reader["tot"]);
                    ont.bericht = Convert.ToString(reader["bericht"]);
                    ont.status = Convert.ToInt32(reader["status"]);
                    ont.idVoertuig = Convert.ToInt32(reader["voertuig_id"]);
                    ont.idAanvrager = Convert.ToInt32(reader["aanvrager_id"]);
                    ontleningen.Add(ont);
                    ont = new ontlening();
                }
            }
            return ontleningen;
        }

        public void AanvraagGoedkeuren(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE Ontlening SET status = 2 WHERE id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
            }
        }

        public void AanvraagAfwijzen(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE Ontlening SET status = 3 WHERE id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
            }
        }
    }
}
