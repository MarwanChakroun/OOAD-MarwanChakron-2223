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

namespace WpfKlant
{
    /// <summary>
    /// Logique d'interaction pour afpbeheren.xaml
    /// </summary>
    public partial class afpbeheren : Window
    {
        Gebruiker Klant;
        public afpbeheren(Gebruiker klantinp)
        {
            InitializeComponent();
            Klant = klantinp;
            foreach (MyClassLibrary.Afspraak item in MyClassLibrary.Afspraak.GetAfspraken(Klant))
            {
                lbAfspraken.Items.Add(item);
            }

            //lbAfspraken.ItemsSource = MyClassLibrary.Afspraak.GetAfspraken(Klant);

        }

        private void lbAfspraken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbAfspraken.SelectedIndex != -1)
            {
                lblDate.Content = lbAfspraken.SelectedIndex;
                MyClassLibrary.Afspraak afsp = lbAfspraken.SelectedItem as MyClassLibrary.Afspraak;
                lblDate.Content = $"Tijdstip: {afsp.Datum.DayOfWeek} {afsp.Datum.Day} {afsp.Datum.Month} {afsp.Datum.Year} om {afsp.Tijd.ToString()}";
                lblKapper.Content = $"Kapper: {afsp.Kpper.Voornaam} {afsp.Kpper.Achternaam}";
            }
                
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MyClassLibrary.Afspraak.DeleteAfspraak((MyClassLibrary.Afspraak)lbAfspraken.SelectedItem);
            lbAfspraken.Items.Clear();
            foreach (MyClassLibrary.Afspraak item in MyClassLibrary.Afspraak.GetAfspraken(Klant))
            {
                lbAfspraken.Items.Add(item);
            }
        }
    }
}
