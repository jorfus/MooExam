using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    class Text : IPersistence
    {
		public List<string> ReadLog()
		{
			List<string> gameLog = new();
			StreamReader reader = new("result.txt", new FileStreamOptions() { Access = FileAccess.Read, Mode = FileMode.OpenOrCreate });

			string line = "";

			using (reader)
				while ((line = reader.ReadLine()) is not null)
					gameLog.Add(line);
			
			return gameLog;
		}
		public void WriteLog(string name, int guesses)
		{
			StreamWriter writer = new("result.txt", append: true);

			using (writer)
				writer.WriteLine($"{name}#&#{guesses}");
		}
	}
}
