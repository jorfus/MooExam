using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public interface IUI
    {
        //void Print(string str);
        void Print(string str, int lineBreaks = 2);
        string TextInput();
        ConsoleKey KeyInput();
        void PrintList(List<Log> games);
        void ClearDisplay();
        string FormatResult(int[] bullsCows);
    }
}