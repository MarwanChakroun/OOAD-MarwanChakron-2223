using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    public class Kaart
    {
        public int Nummer { get; set; }
        public string Kleur { get; set; }

        public Kaart(int num, string color)
        {
            Nummer = num;
            Kleur = color;
        }
    }
}
