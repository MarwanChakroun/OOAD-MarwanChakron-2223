using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    public class Product
    {
        public string naam { get; set; }
        public double eenheidprijs { get; set; }
        public string code { get; set; }

        public Product()
        {
        }
        public Product(string nm, double eenPrijs, string cd)
        {
            naam = nm;
            eenheidprijs = eenPrijs;
            code = cd;
        }

        public bool ValideerCode(string code)
        {
            // Hier word er gecontroleerd als de code 6 karakters bevat en dat de eerste karater 'P' is --> gevonden op stackoverflow https://stackoverflow.com/questions/3222125/fastest-way-to-remove-first-char-in-a-string
            if (code.Length != 6 || code[0] != 'P')
            {
                return false;
            }

            // we maken een tweede string zonder die "P" en checken met en (IsDigit) als het een nummer is.
            string code2TO6 = code.Substring(1);
            if (!code2TO6.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }

        public string ToString(Product product)
        {
            return $"({product.code}) {product.naam} {product.eenheidprijs / 100} euro";
        }
    }
}
