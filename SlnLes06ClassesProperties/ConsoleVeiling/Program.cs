using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Koper> spelers = new List<Koper>();
            Koper koop = new Koper();
            List<Item> listItems = new List<Item>();
            Item item = new Item();
            Bod win = new Bod();
            int intWin;

            spelers = koop.GetallKopers();
            listItems = item.GetallItems();

            Console.WriteLine("==============================================================================================================================");
            Console.WriteLine("                                                   HALLO EN WELKOM                                                            ");
            Console.WriteLine("ELKE SPELER HEEFT HET RECHT OM SLECHTS ÉÉN KEER IN TE ZETTEN OM HET ITEM VAN ZIJN KEUZE TE WINNEN ALLE INZETTEN BEGINNEN BIJ 0");
            Console.WriteLine("==============================================================================================================================\n");

            foreach (Item i in listItems)
            {
                Console.WriteLine($"Deze mooie {i.type} genoemd {i.naam} is nu aanbieding\n");
                foreach (Koper koper in spelers)
                {
                    try
                    {
                        Console.Write($"Wat is u aanbod {koper.naam}: ");
                        intWin = Convert.ToInt32(Console.ReadLine());
                        if (intWin > win.aanbod)
                        {
                            win.aanbod = intWin;
                            win.deelnemer = koper;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
                    }
                }
                Console.WriteLine($"\n{win.deelnemer.naam} is de winnaar van {i.naam} door een aanbod van {win.aanbod}");
                Console.ReadLine();
                win = new Bod();
            }
        }
    }
}
