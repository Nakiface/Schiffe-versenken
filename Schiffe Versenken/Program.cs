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

            //Initialisierung
            var board = Initialize.Start();

            //Game initalisieren
            switch (menu)
            {
                case "Mensch":
                    IGame playHu = new HumanPlayer(board);
                    //Spiel starten
                    playHu.Start(new GameRendererConsole());
                    break;
                case "Ki":
                    IGame playAi = new AIPlayer(board);
                    //Spiel starten
                    playAi.Start(new GameRendererBase());
                    break;
            }


            Console.ReadLine();
        }
    }
}
