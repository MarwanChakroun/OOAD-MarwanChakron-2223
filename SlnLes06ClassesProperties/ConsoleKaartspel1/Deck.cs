using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    public class Deck
    {
        public List<Kaart> Kaarten { get; set; }

        public Deck()
        {
            string[] kleuren = { "C", "S", "H", "D" };
            List<Kaart> kaarten = new List<Kaart>();
            foreach (string kleur in kleuren)
            {
                for (int nummer = 1; nummer < 14; nummer++)
                {
                    Kaart kaart = new Kaart(nummer, kleur);
                    kaarten.Add(kaart);
                }
            }
            Kaarten = kaarten;
        }

        public void Schudden()
        {
            Deck spel = new Deck();
            Random rnd = new Random();
            int aantal = spel.Kaarten.Count;
            while (aantal > 1)
            {
                aantal--;
                int kaart = rnd.Next(aantal + 1);
                Kaart value = spel.Kaarten[kaart];
                spel.Kaarten[kaart] = spel.Kaarten[aantal];
                spel.Kaarten[aantal] = value;
            }
        }

        public Kaart NeemKaart()
        {
            Deck spel = new Deck();
            Random rnd = new Random();
            Kaart krt = spel.Kaarten[rnd.Next(Kaarten.Count()) + 1];
            Kaarten.Remove(krt);
            return krt;
        }
    }

}
