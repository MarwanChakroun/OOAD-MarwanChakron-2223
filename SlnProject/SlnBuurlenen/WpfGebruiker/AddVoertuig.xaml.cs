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
    /// Interaction logic for AddVoertuig.xaml
    /// </summary>
    public partial class AddVoertuig : Window
    {
        Gebruiker actualuser = new Gebruiker();
        public AddVoertuig(Gebruiker gb)
        {
            InitializeComponent();
            actualuser = gb;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbType.SelectedItem != null) 
            {
                if (cmbType.SelectedIndex == 0) 
                { 
                    stplGetrokken.Visibility = Visibility.Collapsed;
                    stplMotor.Visibility = Visibility.Visible;
                }
                if (cmbType.SelectedIndex == 1) 
                {
                    stplMotor.Visibility = Visibility.Collapsed;
                    stplGetrokken.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbType.SelectedItem != null)
            {
                if (cmbType.SelectedIndex == 0)
                {
                    gemotoriseerd gm = new gemotoriseerd();
                    gm.naam = tbxnaam.Text;
                    gm.beschrijving = tbxBeschrijving.Text;
                    gm.bouwjaar = Convert.ToInt32(tbxJaar.Text);
                    gm.merk = tbxMerk.Text;
                    gm.model = tbxModel.Text;
                    gm.type = cmbType.SelectedIndex + 1;
                    if (cmbTransmissie.SelectedIndex == 0){gm.transmissie = 1;}
                    if (cmbTransmissie.SelectedIndex == 1){gm.transmissie = 2;}
                    if (cmbBrandstof.SelectedIndex == 0) { gm.brandstof = 1; }
                    if (cmbBrandstof.SelectedIndex == 1) { gm.brandstof = 2; }
                    if (cmbBrandstof.SelectedIndex == 0) { gm.brandstof = 3; }
                    gm.AddMotor(gm, actualuser.id);
                }
                if (cmbType.SelectedIndex == 1)
                {
                    getrokken gm = new getrokken();
                    gm.naam = tbxnaam.Text;
                    gm.beschrijving = tbxBeschrijving.Text;
                    gm.bouwjaar = Convert.ToInt32(tbxJaar.Text);
                    gm.merk = tbxMerk.Text;
                    gm.model = tbxModel.Text;
                    gm.type = cmbType.SelectedIndex + 1;
                    gm.gewicht = Convert.ToInt32(tbxGewicht.Text);
                    gm.maxbelasting = Convert.ToInt32(tbxMaxbelasting.Text);
                    gm.afmeting = tbxAfmeting.Text;
                    if (cmbGeremd.SelectedIndex == 0) { gm.geremd = 1; }
                    if (cmbGeremd.SelectedIndex == 1) { gm.geremd = 0; }
                    gm.AddGetrokken(gm);
                }
                this.Close();
            }
        }
    }
}
