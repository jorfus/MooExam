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
            string target, guess = "", msg;
            bool menuLoop = true, gameLoop = true, invalidGuess;
            
            while (menuLoop)
            {
                target = Game.GenerateTarget();
                msg = "prompt";

                UI.Print($"\n{Game.GetMessage("start")}");
                UI.Print($"\n\nFor practice, number is: {target}");

                while (gameLoop)
                {
                    invalidGuess = true;
                    UI.Print($"\n\n{Game.GetMessage(msg)}");
                    
                    while (invalidGuess)
                    {
                        guess = UI.TextInput();
                        
                        if(invalidGuess = Game.Validate(guess))
                            UI.Print("Type Four Digits, Please");
                    }
                    
                    msg = "wrong";

                    Game.SetGuess(guess);
                    Game.GuessCounter();

                    gameLoop = Game.CheckGuess();
                    
                    UI.Print(UI.FormatResult(Game.GuessResult()));
                }

                Game.LogGame();
                PrintGamesLog();
                UI.Print($"\n\n{Game.GetMessage("again")}");

                gameLoop = UI.KeyInput() != ConsoleKey.N;
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
            List<string> games = Game.GetLog();
            
                UI.PrintList(games);
        }
        internal void SetUp()
        {
            UI.Print($"{Game.GetMessage("name")}");
            Game.SetPlayer(UI.TextInput());
        }
    }
}
