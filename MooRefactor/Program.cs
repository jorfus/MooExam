namespace MooRefactor
{
    class Program
    {
        public static void Main(string[] args)
        {
            Controller controller = new(new ConsoleUI(), new Game());
        }
    }
}