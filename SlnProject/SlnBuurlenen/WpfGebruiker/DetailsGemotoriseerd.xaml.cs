using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyClassLibrary;

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for DetailsGemotoriseerd.xaml
    /// </summary>
    public partial class DetailsGemotoriseerd : Window
    {
        private readonly Gebruiker gbReader = new Gebruiker();
        private readonly Foto fotoReader = new Foto();
        Gebruiker actualUser = new Gebruiker();
        gemotoriseerd autoReader = new gemotoriseerd();
        public enum brandstof { Benzine, Diesel, LPG }
        public enum transmissie { Manueel, Automatisch }
        public DetailsGemotoriseerd(auto auto, Gebruiker gb)
        {
            InitializeComponent();
            actualUser = gb;
            List<Foto> fotos = new List<Foto>();
            gemotoriseerd automotor = new gemotoriseerd();
            automotor = autoReader.getmotor(auto.id);
            autoReader = automotor;
            Gebruiker usereigenaar = new Gebruiker();
            usereigenaar = gbReader.GetUserById(auto.eigenaarId);
            txtName.Text = auto.naam;
            lblMerk.Content = "Merk: " + auto.merk;
            lblModel.Content = "Model: " + auto.model;
            lblbrandstof.Content = "Brandstof: " + Convert.ToString((brandstof)automotor.brandstof);
            lbljaar.Content = "Bouwjaar: " + automotor.bouwjaar;
            lblTransmissie.Content = "Transmissie: " + Convert.ToString((transmissie)automotor.transmissie);
            lbleigenaar.Content = "Eigenaar: " + usereigenaar.voornaam + " " + usereigenaar.familienaam;
            fotos = fotoReader.getAllPhotoFromID(auto.id);
            for (int i = 0; i < fotos.Count; i++)
            {
                if (fotos[i] != null)
                {
                    switch (i)
                    {
                        case 0:
                            img1.Source = fotoReader.DataToImage(fotos[i]);
                            break;
                        case 1:
                            img2.Source = fotoReader.DataToImage(fotos[i]);
                            break;
                        case 2:
                            img3.Source = fotoReader.DataToImage(fotos[i]);
                            break;
                    }
                }
            }
        }

        private void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            if (dpVan.SelectedDate == null || dpTot.SelectedDate == null || DateTime.Now > dpVan.SelectedDate || dpTot.SelectedDate <= dpVan.SelectedDate)
            {
                MessageBox.Show("Gelieve datum(s) deftig in te vullen", "Datum error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ontlening nieuw = new ontlening((DateTime)dpVan.SelectedDate, (DateTime)dpTot.SelectedDate, tbxBericht.Text, autoReader.id, actualUser.id);
                nieuw.AddAaanvraag(nieuw);
                this.Close();
            }
        }
    }
}
