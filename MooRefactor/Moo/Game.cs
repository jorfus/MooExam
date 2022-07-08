using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
	public class Game : IGame
	{
		IPersistence Log { get; set; } = new Text();
        Operations Operator { get; set; } = new();
		Player ThePlayer { get; set; } = new();
		Messages Messager { get; set; }

		public Game()
		{
			string[] messages = { "New Game", "Enter Player Name: ", "Have A Guess: ", "Have Another Guess: ",
			"Play Again?", "Type In Four Digits, Please: ", "for practice, check the number: "};
			
			Messager = new(messages);
		}
		public Game(string[] messages)
		{
			Messager = new(messages);
		}

		public string GetPlayer()
		{
			return ThePlayer.Name;
		}
		public void GenerateTarget()
		{
			Operator.Generate();
		}
		public bool Validate(string guess)
		{
			return guess.Length != 4;
		}
		public bool CheckGuess()
		{
			return Operator.Check();
		}
		public int[] GuessResult()
		{
			return new int[] { Operator.Bulls, Operator.Cows };
		}
		public void SetPlayer(string name)
		{
			ThePlayer.SetName(name);
		}
		public string GetMessage(string msg)
		{
			return Messager.Switch(msg);	
		}
		public void LogGame()
		{
			Log.WriteLog(ThePlayer.Name, ThePlayer.Guesses);
		}
		public List<Log> GetPlayerLog()
		{
			List<string> logs = Log.ReadLog();
			List<string[]> dataPairs = new();
			List<Log> playerLogs = new();
			int playedGames;
			double average;

            foreach (string log in logs)
				dataPairs.Add(log.Split("#&#"));
            
			var players = dataPairs.Select(pair => pair[0]).Distinct().ToList();

			foreach (string player in players)
			{
				var awk = dataPairs.Where(pair => pair[0] == player);
				
				playedGames = awk.ToList().Count;
				average = awk.Select(pair => int.Parse(pair[1])).ToList().Average();
				
				playerLogs.Add(new Log(player, playedGames, average));
			}

			return playerLogs;
		}
		public void ClearGame()
        {
			Operator = new();
        }
        public void GuessCounter()
        {
			ThePlayer.Guess();
        }
		public void SetGuess(string guess)
		{
			Operator.Set(guess);
		}
        public string GetTarget()
        {
			return Operator.Target;
        }
    }
}
