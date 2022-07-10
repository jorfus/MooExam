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
			string[] messages = {"Enter Player Name: ", "New Game", "Have A Guess: ", "Have Another Guess: ",
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
			List<string[]> allPlayerData = new();
			
			List<Log> playerLogs = new();

            foreach (string log in logs)
				allPlayerData.Add(log.Split("#&#"));

			var playerNames = allPlayerData.Select(data => data[0]).Distinct().ToList();

			foreach (string name in playerNames)
			{
				var playerData = allPlayerData.Where(data => data[0] == name);

				var gamesPlayed = playerData.Count();

				var averageScore = playerData.Average(data => Math.Round(double.Parse(data[1]), 2));

				playerLogs.Add(new Log(name, gamesPlayed, averageScore));
			}

			return playerLogs;
		}
		public void ClearGame()
        {
			Operator = new();
			ThePlayer.ResetGuesses();
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
