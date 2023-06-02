using MyClassLibrary;
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

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for DetailsGetrokken.xaml
    /// </summary>
    public partial class DetailsGetrokken : Window
    {
        private readonly Gebruiker gbReader = new Gebruiker();
        private readonly Foto fotoReader = new Foto();
        Gebruiker actualUser = new Gebruiker();
        getrokken autoReader = new getrokken();
        public enum status { Nee, Ja }
        public DetailsGetrokken(auto auto, Gebruiker gb)
        {
            InitializeComponent();
            actualUser = gb;
            List<Foto> fotos = new List<Foto>();
            getrokken autotrok = new getrokken();
            autotrok = autoReader.getGetrokken(auto.id);
            autoReader = autotrok;
            Gebruiker usereigenaar = new Gebruiker();
            usereigenaar = gbReader.GetUserById(auto.eigenaarId);
            txtName.Text = autotrok.naam;
            lblMerk.Content = "Merk: " + autotrok.merk;
            lblModel.Content = "Model: " + autotrok.model;
            lbljaar.Content = "Bouwjaar: " + autotrok.bouwjaar;
            lbleigenaar.Content = "Eigenaar: " + usereigenaar.voornaam + " " + usereigenaar.familienaam;
            if (autotrok.gewicht != null){lblGewicht.Content = "Gewicht: " + autotrok.gewicht + " kg";}
            else{ lblGewicht.Content = "Gewicht: n.v.t."; }
            lblMaxBelasting.Content = "Max belasting: " + autotrok.maxbelasting + " kg";
            lblGeremd.Content = "Geremd: " + (status)autotrok.geremd;
            lblAfmeting.Content = "Afmeting: " + autotrok.afmeting;

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
