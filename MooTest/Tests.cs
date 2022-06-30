using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooRefactor;

namespace MooTest;

[TestClass]
public class Tests
{
    Controller TheController { get; set; }

    public Tests()
    {
        Game game = new();
        IUI console = new Display();
        TheController = new(console, game);
    }

    [TestMethod]
    public void ATest()
    {

    }
}