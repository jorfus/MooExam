using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public interface IUserIO
    {
        void Output(string str);
        string Input();
    }
}
