using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public enum geslacht
    {
        man,
        vrouw,
        onbekend
    }
    public class Gebruiker
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int id { get; set; }
        public string voornaam { get; set; }
        public string familienaam { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public DateTime aanmakdatum { get; set; }
        public byte[] profielphoto  { get; set; }
        public geslacht geslacht { get; set; }

        public Gebruiker()
        {
        }

        public Gebruiker(int ID,string VOORNAAM,string FAMILIENAAM, string MAIL,string PASSWORD,DateTime AANMAAKDATUM,byte[] PHOTO,geslacht GESLACHT)
        {
            id = ID;
            voornaam = VOORNAAM;
            familienaam = FAMILIENAAM;
            mail = MAIL;
            password = PASSWORD;
            aanmakdatum = AANMAAKDATUM;
            profielphoto = PHOTO;
            geslacht = GESLACHT;
        }

        public Gebruiker Login(string MAIL, string PASSWORD)
        {
            Gebruiker gebruiker = new Gebruiker();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Gebruiker WHERE email = @parEmail AND paswoord = @parPwd", conn);
                comm.Parameters.AddWithValue("@parEmail", MAIL);
                comm.Parameters.AddWithValue("@parPwd", PASSWORD);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string firstname = Convert.ToString(reader["firstname"]);
                }
            }

        }

    }
}
