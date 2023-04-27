using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    public class Ticket
    {
        public enum Betaalwijze { visa, cash, bancontact }

        public List<Product> Producten { get; set; }

        public Betaalwijze betaalwijze { get; set; } = Betaalwijze.bancontact;

        public string Kassier { get; set; }

        public double TotaalPrijs { get; set; }

        public Ticket(List<Product> _Producten)
        {
            Producten = _Producten;
            Kassier = "Marwan";
            foreach (Product p in Producten)
            {
                TotaalPrijs += p.eenheidprijs;
            }

        }

        public void DrukTicket(Ticket tk)
        {
            Console.WriteLine($"KASSATICKET\n================= \nUw kassier: {Kassier}\n");
            foreach (var product in tk.Producten)
            {
                Console.WriteLine(product.ToString(product));
            }
            Console.WriteLine("----------------");
            if (tk.betaalwijze == Betaalwijze.visa)
            {
                Console.WriteLine("Extra kosten: 0,12");
                Console.WriteLine($"Totaal: {tk.TotaalPrijs + 0.12}");
            }
            else
            {
                Console.WriteLine($"Totaal: {tk.TotaalPrijs /100} euro");
            }
            Console.ReadLine();
        }
    }
}
