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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGebruiker
{
    /// <summary>
    /// Interaction logic for OnteleningenAanvragen.xaml
    /// </summary>
    public partial class OnteleningenAanvragen : Page
    {
        private readonly ontlening ontleningReader = new ontlening();
        private readonly auto autoReader = new auto();
        Gebruiker actualUser = new Gebruiker();
        public enum status
        {
            InAanvraag, Goedgekeurd, Verworpen
        }
        public OnteleningenAanvragen(Gebruiker gb)
        {
            InitializeComponent();
            actualUser = gb;
            foreach (var i in ontleningReader.getAllMineOntlening(gb.id))
            {
                ListBoxItem lb = new ListBoxItem();
                lb.Tag = i;
                lb.Content = autoReader.GetCarById(i.idVoertuig).naam + " - " + i.vanaf.ToString("dd/MM/yyyy") + " tot " + i.tot.ToString("dd/MM/yyyy") + " (" + (status)i.status + ")";
                lbxOntlening.Items.Add(lb);
            }


            foreach (var i in ontleningReader.getAllMineAanvragen(gb.id))
            {
                ListBoxItem lb = new ListBoxItem();
                lb.Tag = i;
                lb.Content = autoReader.GetCarById(i.idVoertuig).naam + " - " + i.vanaf.ToString("dd/MM/yyyy") + " tot " + i.tot.ToString("dd/MM/yyyy") + " door " + actualUser.GetUserById(i.idAanvrager).voornaam + ". " + actualUser.GetUserById(i.idAanvrager).familienaam;
                lbxAanvragen.Items.Add(lb);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxOntlening.SelectedItem;
            ontlening ontleningSelect = new ontlening();
            int id = (int)item.Tag;
            ontleningReader.DeleteOntlening(id);
            lbxOntlening.Items.Clear();
            foreach (var i in ontleningReader.getAllMineOntlening(actualUser.id))
            {
                ListBoxItem lb = new ListBoxItem();
                lb.Tag = i;
                lb.Content = autoReader.GetCarById(i.idVoertuig).naam + " - " + i.vanaf.ToString("dd/MM/yyyy") + " tot " + i.tot.ToString("dd/MM/yyyy") + " (" + (status)i.status + ")";
                lbxOntlening.Items.Add(lb);
            }
        }

        private void lbxOntlening_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxOntlening.SelectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)lbxOntlening.SelectedItem;
                ontlening ontleningSelect = new ontlening();
                ontleningSelect = (ontlening)item.Tag;
                if (ontleningSelect.vanaf > DateTime.Now)
                {
                    btnCancel.IsEnabled = true;
                }
                else
                {
                    btnCancel.IsEnabled = false;
                }
            }
        }

        private void lbxAanvragen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxAanvragen.SelectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)lbxAanvragen.SelectedItem;
                ontlening ontleningSelect = new ontlening();
                ontleningSelect = (ontlening)item.Tag;
                Gebruiker user = actualUser.GetUserById(ontleningSelect.idAanvrager);
                lblVoertuig.Content = "Voertuig: " + autoReader.GetCarById(ontleningSelect.idVoertuig).naam;
                lblPeriode.Content = $"Periode: {ontleningSelect.vanaf.ToString("dd/MM/yyyy")} tot {ontleningSelect.tot.ToString("dd/MM/yyyy")} ({(ontleningSelect.tot - ontleningSelect.vanaf).TotalDays} dagen)";
                lblAanvrager.Content = "Aanvrager: " + user.voornaam + " " + user.familienaam;
                lblBericht.Content = "Bericht: " + ontleningSelect.bericht;
            }
        }

        private void btnGoedekeuren_Click(object sender, RoutedEventArgs e)
        {
            if (lbxAanvragen.SelectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)lbxAanvragen.SelectedItem;
                ontlening ontleningSelect = new ontlening();
                ontleningSelect = (ontlening)item.Tag;
                ontleningReader.AanvraagGoedkeuren(ontleningSelect.id);
                lbxAanvragen.Items.Clear();
                foreach (var i in ontleningReader.getAllMineAanvragen(actualUser.id))
                {
                    ListBoxItem lb = new ListBoxItem();
                    lb.Tag = i;
                    lb.Content = autoReader.GetCarById(i.idVoertuig).naam + " - " + i.vanaf.ToString("dd/MM/yyyy") + " tot " + i.tot.ToString("dd/MM/yyyy") + " door " + actualUser.GetUserById(i.idAanvrager).voornaam + ". " + actualUser.GetUserById(i.idAanvrager).familienaam;
                    lbxAanvragen.Items.Add(lb);
                }
            }
        }

        private void btnAfwijzen_Click(object sender, RoutedEventArgs e)
        {
            if (lbxAanvragen.SelectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)lbxAanvragen.SelectedItem;
                ontlening ontleningSelect = new ontlening();
                ontleningSelect = (ontlening)item.Tag;
                ontleningReader.AanvraagAfwijzen(ontleningSelect.id);
                lbxAanvragen.Items.Clear();
                foreach (var i in ontleningReader.getAllMineAanvragen(actualUser.id))
                {
                    ListBoxItem lb = new ListBoxItem();
                    lb.Tag = i;
                    lb.Content = autoReader.GetCarById(i.idVoertuig).naam + " - " + i.vanaf.ToString("dd/MM/yyyy") + " tot " + i.tot.ToString("dd/MM/yyyy") + " door " + actualUser.GetUserById(i.idAanvrager).voornaam + ". " + actualUser.GetUserById(i.idAanvrager).familienaam;
                    lbxAanvragen.Items.Add(lb);
                }
            }
        }
    }
}
