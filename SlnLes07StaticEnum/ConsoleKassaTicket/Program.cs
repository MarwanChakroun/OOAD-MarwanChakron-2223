using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    public class Program
    {
        public enum Betaalwijze {visa, cash, bancontact}
        static void Main(string[] args)
        {
            bool codeCorrect = false;
            Product p = new Product();
            List<Product> products = new List<Product>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("geef de naam van het product: ");
                string productnaam = Console.ReadLine();
                Console.Write("geef de prijs van het product: ");
                double productprijs = Convert.ToDouble(Console.ReadLine());
                Console.Write("geef de code van het product: ");
                string productcode = Console.ReadLine();
                codeCorrect = p.ValideerCode(productcode); 

                while (codeCorrect == false)
                {
                    Console.WriteLine("Je code moet 6 karakters bevatten en begint met 'P' en vervolgens vijf nummers (vb: P45982)");
                    Console.Write("geef de code van het product: ");
                    productcode = Console.ReadLine();
                    codeCorrect = p.ValideerCode(productcode);
                }
                products.Add(new Product(productnaam, productprijs, productcode));
                codeCorrect = false;
                Console.WriteLine("");
            }

            Ticket kassaTicket = new Ticket(products);
            kassaTicket.DrukTicket(kassaTicket);
        }
    }
}
