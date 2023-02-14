using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTafels
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tafel = DrukTafel(4, 8);
            foreach (var a in tafel) { Console.WriteLine(a); }
            Console.WriteLine("");
            tafel = null;
            tafel = DrukTafel(2, 5);
            foreach (var a in tafel) { Console.WriteLine(a); }
            tafel = null;
            Console.WriteLine("");
            Console.Write("geef nummer van tafel: ");
            int nummer = Convert.ToInt32(Console.ReadLine());
            nummer = VraagPositiefGetal(nummer);
            Console.Write("geef lengte van tafel: ");
            int lengte = Convert.ToInt32(Console.ReadLine());
            lengte = VraagPositiefGetal(lengte);
            tafel = DrukTafel(nummer, lengte);
            foreach (var a in tafel) { Console.WriteLine(a); }
            Console.ReadLine();

        }

        public static List<string> DrukTafel(int num, int length)
        {
            List<string> tafel = new List<string>();
            tafel.Add($"{num}x{length} tafel:");
            for (int i = 1; i <= length; i++)
            {
                string a = $"{num} x {i} = {num * i}";
                tafel.Add(a);
            }
            return tafel;
        }

        public static int VraagPositiefGetal(int num)
        {
            while (num < 0)
            {
                Console.Write("Het ingevoerde getal is negatief!!! Voer een positief getal in: ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return num;
        }
    }
}
