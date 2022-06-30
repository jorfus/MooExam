using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public interface IUI
    {
        void Print(string str);
        string TextInput();
        ConsoleKey KeyInput();
        void PrintList(List<string> games);
        void ClearDisplay();
        string FormatResult(int[] bullsCows);
    }
}