using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    class Messages : IMessage
    {
		internal string[] TheMessages { get; private set; }

		internal Messages(string[] messages)
		{
			TheMessages = messages;
		}

		//internal static string Start()
		//{
		//	return "New Game";
		//}
		//internal static string Name()
		//{
		//	return "Enter Player Name: ";
		//}
		//internal static string Prompt()
		//{
		//	return "Have A Guess: ";
		//}
		//internal static string Wrong()
		//{
		//	return "Have Another Guess: ";
		//}
  //      internal static string Again()
  //      {
		//	return "Play Again?";
  //      }
  //      internal static string Invalid()
  //      {
		//	return "Type In Four Digits, Please: ";
		//}
  //      internal static string DebugShow()
  //      {
  //          return "for practice, check the number: ";
		//}
		internal string Switch(string msg) => msg switch
		{
			"start" => TheMessages[0],
			"prompt" => TheMessages[1],
			"wrong" => TheMessages[2],
			"name" => TheMessages[3],
			"again" => TheMessages[4],
			"invalid" => TheMessages[5],
			"debug_show" => TheMessages[6],

			_ => throw new NotImplementedException()

		};
    }
}
