namespace MooRefactor
{
    class Player
    {
        internal string Name { get; private set; } = "";
        internal int Guesses { get; private set; } = 0;
        
        internal void Guess()
        {
            Guesses++;
        }
        internal void SetName(string name)
        {
            Name = name;
        }
    }
}