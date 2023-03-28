using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    public class Koper
    {
        public string naam { get; set; }

        public Koper()
        {

        }

        public Koper(string nm)
        {
            naam = nm;
        }

        public List<Koper> GetallKopers()
        {
            List<Koper> spelers = new List<Koper>();
            // de bedoeling is die spelers later op te halen via een DB
            spelers.Add(new Koper("Marwan"));
            spelers.Add(new Koper("Nico"));
            spelers.Add(new Koper("Mohamed-Henni"));

            return spelers;
        }
    }
}
