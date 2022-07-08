using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public class ConsoleUI : IUI
    {
        public string TextInput()
        {
            return Console.ReadLine() ?? "";
        }
        public string FormatResult(int[] bullCow)
        {
            int bulls = bullCow[0];
            int cows = bullCow[1];

            return $"{new string('B', bulls)},{new string('C', cows)}";
        }
        public ConsoleKey KeyInput()
        {
            return Console.ReadKey().Key;
        }
        public void PrintList(List<Log> logs)
        {
            foreach (Log log in logs)
                Print($"Player '{log.Name}'\t\tGames Played {log.Games}\t\tAverage Score {Math.Round(log.AverageScore, 2)}");
        }
        public void ClearDisplay()
        {
            Console.Clear();
        }
        public void Print(string str, int lineBreaks = 2)
        {
            Console.Write($"{new string('\n', lineBreaks)}{str}");
        }
    }
}
