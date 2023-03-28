using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    public class Item
    {
        public string naam { get; set; }
        public string type { get; set; }

        public Item()
        {
        }

        public Item(string nm, string typeKunst)
        {
            naam = nm;
            type = typeKunst;
        }
        public List<Item> GetallItems()
        {
            List<Item> listItems = new List<Item>();
            // de bedoeling is die spelers later op te halen via een DB
            listItems.Add(new Item("joconde", "schilderij"));
            listItems.Add(new Item("Nimcha", "wapen"));
            listItems.Add(new Item("American Gothic", "Schilderij"));
            return listItems;
        }
    }
}
