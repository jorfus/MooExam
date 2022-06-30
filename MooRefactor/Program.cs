namespace MooRefactor
{
    class Program
    {
        public static void Main(string[] args)
        {
            Controller controller = new(new Display(), new Game());
            controller.Run();
        }
    }
}