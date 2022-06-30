namespace MooRefactor
{
    class Operations
    {
        internal string Target { get; private set; } = "";
        internal string Guess { get; private set; } = "";
        internal int Bulls { get; private set; } = 0;
        internal int Cows { get; private set; } = 0;

		internal void Generate()
		{
			Random rand = new();
			string target = "";
			string digit;
			int counter = 0;

			while (counter < 4)
			{
				digit = rand.Next(10).ToString();

				if (!target.Contains(digit))
				{
					target += digit;
					counter++;
				}
			}

			Target = target;
		}

        internal void Set(string guess)
        {
			Guess = guess;
        }

        internal bool Check()
		{
			Bulls = Cows = 0;

			for (int posT = 0; posT < 4; posT++)
				for (int posG = 0; posG < 4; posG++)
					if (Target[posT] == Guess[posG])
						if (posT == posG)
						{
							Bulls++;
						}
						else
						{
							Cows++;
						}

			return Guess != Target;
		}
	}
}