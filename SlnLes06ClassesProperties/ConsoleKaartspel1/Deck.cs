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
        }

        public void Schudden()
        {
            Random rnd = new Random();
            int selectKaart = Kaarten.Count;
            do
            {
                selectKaart--;
                int rndKaart = rnd.Next(selectKaart + 1);
                Kaart temp = Kaarten[rndKaart];
                Kaarten[rndKaart] = Kaarten[selectKaart];
                Kaarten[selectKaart] = temp;
            } while (selectKaart > 1);
        }

        public Kaart NeemKaart()
        {
            Random rnd = new Random();
            Kaart selectKaart = Kaarten[rnd.Next(Kaarten.Count())];
            Kaarten.Remove(selectKaart);
            return selectKaart;
        }
    }

}
