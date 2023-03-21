using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Speler
    {
        public string Naam { get; set; }
        public List<Kaart> Kaarten { get; set; }
        public bool HeeftNogKaarten { get; set; }

        public Speler(string name)
        {
            Naam = name;
        }

        public Speler(string name, List<Kaart> kaarten)
        {
            Naam = name;
            Kaarten = kaarten;
        }

        public Kaart LegKaart()
        {

            Random rnd = new Random();
            Kaart selectKaart = Kaarten[rnd.Next(Kaarten.Count())];
            return selectKaart;
        }
    }
}
