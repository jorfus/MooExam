namespace MooRefactor
{
	class Player
	{
		internal string PlayerName { get; private set; } = "";
		internal int Guesses { get; private set; } = 0;

        internal void Guess()
        {
            Guesses++;
        }
        internal void SetName(string name)
        {
            PlayerName = name;
        }
    }
}