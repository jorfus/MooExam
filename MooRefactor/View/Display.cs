using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public class Display : IUI
    {
        public string TextInput()
        {
            return Console.ReadLine() ?? "";
        }
        public void Print(string str)
        {
            Console.Write(str);
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
        public void PrintList(List<string> games)
        {
            foreach (string log in games)
                Print($"\t{log}");
        }
        public void ClearDisplay()
        {
            Console.Clear();
        }
    }
}
