using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> playerNames = new List<string> { "Zakaria", "Saleha", "Indra", "Ralph", "Francisco", "Marie" };
            List<string> games = new List<string> { "Dammen", "Schaken", "Backgammon" };

            Random random = new Random();
            int playerScore;
            int opponentScore;
            
            int playerIndex;
            int opponentIndex;
            int counter = 0;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "matches.csv");
            StringBuilder csvMatches = new StringBuilder();

            while (counter < 100)
            {
                playerScore = random.Next(0, 4);
                opponentScore = 3 - playerScore;
                counter++;
                playerIndex = random.Next(0, playerNames.Count);
                opponentIndex = random.Next(0, playerNames.Count);
                Console.WriteLine(counter + " " + playerNames[playerIndex] + " " + playerNames[opponentIndex] + " " + games[random.Next(0, 3)] + " " + playerScore + "-" + opponentScore);
                csvMatches.AppendLine(counter + ";" + playerNames[playerIndex] + ";" + playerNames[opponentIndex] + ";" + games[random.Next(0, 3)] + ";" + playerScore + "-" + opponentScore);
            }

            File.AppendAllText(filePath, Convert.ToString(csvMatches));
            Console.WriteLine("The CSV file has been saved to your desktop.");
            Console.ReadLine();

        }
    }
}
