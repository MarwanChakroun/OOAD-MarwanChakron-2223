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
        public afpbeheren(Gebruiker klant)
        {
            InitializeComponent();
            foreach (Afspraak afsp in Afspraak.GetAfspraakByKlant(klant))
            {
                lbAfspraken.Items.Add(afsp);
            }

        }
    }
}
