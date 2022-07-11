using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooRefactor
{
    public class Controller
    {
        public IUI UI { get; private set; }
        public IGame Game { get; private set; }

        public Controller(IUI ui, IGame game)
        {
            UI = ui;
            Game = game;
        }

        public void Run()
        {
            SetUp();
            ControllerLoop();
        }
        void ControllerLoop()
        {
            string guess = "", message;
            bool menuLoop = true, gameLoop, invalidGuess;
            
            while (menuLoop)
            {
                Game.GenerateTarget();
                message = "prompt";

                UI.Print(Game.GetMessage("start"), 1);
                UI.Print(Game.GetMessage("debug_show") + Game.GetTarget());
                
                gameLoop = true;

                while (gameLoop)
                {
                    invalidGuess = true;

                    UI.Print($"{Game.GetMessage(message)}");
                    message = "wrong";
                    
                    while (invalidGuess)
                    {
                        guess = UI.TextInput();

                        if(invalidGuess = Game.NotValid(guess))
                            UI.Print(Game.GetMessage("invalid"), 1);
                    }
                    
                    Game.SetGuess(guess);
                    Game.GuessCounter();

                    gameLoop = Game.CheckGuess();
                    
                    UI.Print(UI.FormatResult(Game.GuessResult()), 1);
                }

                Game.LogGame();
                PrintGamesLog();
                UI.Print(Game.GetMessage("again"));

                menuLoop = UI.KeyInput() != ConsoleKey.N;
                Clear();
            }
        }
        void Clear()
        {
            Game.ClearGame();
            UI.ClearDisplay();
        }
        void PrintGamesLog()
        {
            List<Log> games = Game.GetPlayerLog();
            UI.PrintList(games);
        }
        internal void SetUp()
        {
            string name = "";
            bool invalidName = true;

            while (invalidName)
            {
                UI.Print($"{Game.GetMessage("name")}");
                
                name = UI.TextInput();

                if (!(invalidName = Game.NotValid(name.ToCharArray())))
                    Game.SetPlayer(name);
            }
        }
    }
}
