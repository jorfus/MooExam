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

			using (reader)
				while (reader.ReadLine() != null)
					gameLog.Add(reader.ReadLine());

			return gameLog;
		}
		public void WriteLog(string log)
		{
			StreamWriter writer = new("result.txt", append: true);

			using (writer)
				writer.WriteLine(log + "\n");
		}
	}
}
