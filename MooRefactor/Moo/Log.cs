using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public class Log
    {
        internal string Name { get; private set; } = "";
        internal int Games { get; set; } = 0;
        internal double AverageScore { get; private set; } = 0;

        internal Log(string name, int games, double average)
        {
            Name = name;
            Games = games;
            AverageScore = average;
        }
    }
}
