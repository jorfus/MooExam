using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
	public class Game : IGame
	{
		IPersistence DataAccess { get; set; } = new Text();
        Operations Operation { get; set; } = new();
		Player ThePlayer { get; set; } = new();
		
		public string GetPlayer()
		{
			return ThePlayer.PlayerName;
		}
		public string GenerateTarget()
		{
			Operation.Generate();
			return Operation.Target;
		}
		public bool Validate(string guess)
		{
			return guess.Length != 4;
		}
		public bool CheckGuess()
		{
			return Operation.Check();
		}
		public int[] GuessResult()
		{
			return new int[] { Operation.Bulls, Operation.Cows };
		}
		public void SetPlayer(string name)
		{
			ThePlayer.SetName(name);
		}
		public string GetMessage(string msg) => msg switch
		{
			"start" => Messages.StartMsg(),
			"prompt" => Messages.PromptMsg(),
			"wrong" => Messages.WrongMsg(),
			"name" => Messages.NameMsg(),
			"again" => Messages.Again(),

			_ => throw new NotImplementedException()
		};
		public void LogGame()
		{
			DataAccess.WriteLog($"{ThePlayer.PlayerName}#&#{ThePlayer.Guesses}");
		}
		public List<string> GetLog()
		{
			return DataAccess.ReadLog();
		}
		void AddGuess()
		{
			ThePlayer.Guess();
		}
        public void ClearGame()
        {
			Operation = new();
        }
        public void GuessCounter()
        {
			ThePlayer.Guess();
        }
		public void SetGuess(string guess)
		{
			Operation.Set(guess);
		}
    }
}
