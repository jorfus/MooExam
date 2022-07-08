using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public interface IGame
    {
        string GetPlayer();
        void SetPlayer(string name);
        void GenerateTarget();
        bool CheckGuess();
        bool Validate(string guess);
        void LogGame();
        List<Log> GetPlayerLog();
        string GetMessage(string msg);
        void GuessCounter();
        int[] GuessResult();
        void ClearGame();
        void SetGuess(string guess);
        string GetTarget();
    }
}
