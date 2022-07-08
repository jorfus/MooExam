using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public interface IPersistence
    {
        void WriteLog(string name, int guesses);
        List<string> ReadLog();
    }
}
