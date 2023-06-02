using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyClassLibrary
{
    public class Foto
    {
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public int id { get; set; }
        public int idAuto { get; set; }
        public byte[] data { get; set; }

        public Foto()
        {
        }

        public Foto(int ID,int idAUTO, byte[] DATA)
        {
            id = ID;
            idAuto = idAUTO;
            data = DATA;    
        }

        public List<Foto> getAllPhotoFromID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                List<Foto> fotos = new List<Foto>();
                Foto foto = new Foto();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Foto WHERE voertuig_id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    foto.id = Convert.ToInt32(reader["id"]);
                    foto.idAuto = Convert.ToInt32(reader["voertuig_id"]);
                    foto.data = (byte[])reader["data"];
                    fotos.Add(foto);
                    foto = new Foto();
                }
                return fotos;
            }
        }

        public Foto getFirstPhotoFromID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                Foto foto = new Foto();
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT TOP 1 * FROM Foto WHERE voertuig_id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    foto.id = Convert.ToInt32(reader["id"]);
                    foto.idAuto = Convert.ToInt32(reader["voertuig_id"]);
                    foto.data = (byte[])reader["data"];
                }
                return foto;
            }
        }

        public BitmapImage DataToImage(Foto foto)
        {
            var image = new BitmapImage();
            using (var ms = new System.IO.MemoryStream(foto.data))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }
            return image;
        }
    }
}
