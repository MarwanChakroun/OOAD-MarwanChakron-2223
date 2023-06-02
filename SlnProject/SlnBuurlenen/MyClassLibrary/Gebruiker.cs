using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        public Gebruiker(int ID, string VOORNAAM, string FAMILIENAAM)
        {
            id = ID;
            voornaam = VOORNAAM;
            familienaam = FAMILIENAAM;
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
            Random rnd = new Random();
            Byte[] b = new Byte[10];
            Gebruiker gebruiker = new Gebruiker();
            Gebruiker login = new Gebruiker(0, "none", "none", "none", "none", DateTime.Now, b, geslacht.onbekend);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Gebruiker WHERE email = @parEmail AND paswoord = @parPwd", conn);
                comm.Parameters.AddWithValue("@parEmail", MAIL);
                comm.Parameters.AddWithValue("@parPwd", PASSWORD);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    gebruiker.id = Convert.ToInt32(reader["id"]);
                    gebruiker.voornaam = Convert.ToString(reader["voornaam"]);
                    gebruiker.familienaam = Convert.ToString(reader["achternaam"]);
                    gebruiker.mail = Convert.ToString(reader["email"]);
                    gebruiker.password = Convert.ToString(reader["paswoord"]);
                    gebruiker.aanmakdatum = Convert.ToDateTime(reader["aanmaakdatum"]);
                    gebruiker.geslacht = NumberToGender(Convert.ToInt32(reader["geslacht"]));
                    //Convert image naar byte[]
                    byte[] imageData = (byte[])reader["profielfoto"];
                    gebruiker.profielphoto = imageData;
                    //
                    if (gebruiker.mail == MAIL && gebruiker.password == PASSWORD)
                    {
                        login = gebruiker;
                    }
                }
            }
            return login;
        }

        public Gebruiker GetUserById(int userId)
        {
            Gebruiker gebruiker = new Gebruiker();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Gebruiker WHERE id = @userId", conn);
                comm.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    gebruiker.id = Convert.ToInt32(reader["id"]);
                    gebruiker.voornaam = Convert.ToString(reader["voornaam"]);
                    gebruiker.familienaam = Convert.ToString(reader["achternaam"]);
                    gebruiker.mail = Convert.ToString(reader["email"]);
                    gebruiker.password = Convert.ToString(reader["paswoord"]);
                    gebruiker.aanmakdatum = Convert.ToDateTime(reader["aanmaakdatum"]);
                    gebruiker.geslacht = NumberToGender(Convert.ToInt32(reader["geslacht"]));
                }
            }
            return gebruiker;
        }

        public geslacht NumberToGender(int i)
        {
            geslacht x = geslacht;
            switch (i)
            {
                case 0:
                    x = geslacht.man;
                    break;
                case 1:
                    x = geslacht.vrouw;
                    break;
                case 2:
                    x = geslacht.onbekend;
                    break;
            }
            return x;
        }

    }
}
