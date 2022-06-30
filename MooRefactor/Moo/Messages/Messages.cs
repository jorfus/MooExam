using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    class Messages : IMessage
    {
		internal static string StartMsg()
		{
			return "New Game";
		}
		internal static string NameMsg()
		{
			return "Enter Player Name: ";
		}
		internal static string PromptMsg()
		{
			return "Have A Guess: ";
		}
		internal static string WrongMsg()
		{
			return "Have Another Guess: ";
		}
        internal static string Again()
        {
			return "Play Again?";
        }
    }
}
