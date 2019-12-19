using System;
using System.Linq;

namespace Schiffe_Versenken
{
    class Program
    {
        public static void Main()
        {
            //menu
            var menu = ConsoleOutput.Greeting();

            //Game initalisieren
            switch (menu)
            {
                case "Mensch":
                    var boardHu = Initialize.Start();
                    IGame playHu = new HumanPlayer(boardHu);
                    //Spiel starten
                    playHu.Start(new GameRendererConsole());
                    break;
                case "Ki":
                    var boardAi = Initialize.Start();
                    IGame playAi = new AIPlayer(boardAi);
                    //Spiel starten
                    playAi.Start(new GameRendererBase());
                    break;
            }


            Console.ReadLine();
        }
    }
}
