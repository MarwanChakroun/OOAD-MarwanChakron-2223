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

namespace WpfAdmin
{
    /// <summary>
    /// Logique d'interaction pour Afpbeheren.xaml
    /// </summary>
    public partial class Afpbeheren : Window
    {
        public Afpbeheren()
        {
            InitializeComponent();
            lbAfspraken.Items.Add("Selecteer een datum");
        }

        private void lbAfspraken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbAfspraken.SelectedIndex != -1)
            {
                MyClassLibrary.Afspraak afsp = lbAfspraken.SelectedItem as MyClassLibrary.Afspraak;
                lblDate.Content = $"Tijdstip: {afsp.Datum.DayOfWeek} {afsp.Datum.Day} {afsp.Datum.Month} {afsp.Datum.Year} om {afsp.Tijd.ToString()}";
                lblKapper.Content = $"Kapper: {afsp.Kpper.Voornaam} {afsp.Kpper.Achternaam}";
                lblKlant.Content = $"Klant: {afsp.Klant.Achternaam} {afsp.Klant.Voornaam}";
            }

        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dit afspraak te willen annuleren?", "Verwijderen", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                MyClassLibrary.Afspraak.DeleteAfspraak((MyClassLibrary.Afspraak)lbAfspraken.SelectedItem);
                lbAfspraken.Items.Clear();
                foreach (Afspraak item in Afspraak.GetAfsprakenByDate((DateTime)CalDatePicker.SelectedDate))
                {
                    lbAfspraken.Items.Add(item);
                }
            }
            
        }

        private void CalDatePicker_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            lbAfspraken.Items.Clear();

            foreach (Afspraak item in Afspraak.GetAfsprakenByDate((DateTime)CalDatePicker.SelectedDate))
            {
                lbAfspraken.Items.Add(item);
            }
        }
    }
}
