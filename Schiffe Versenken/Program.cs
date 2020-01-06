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
                    GameBase playHu = new HumanPlayer(boardHu);
                    //Spiel starten
                    while (playHu.board.shipfields > 0)
                    {
                        playHu.Start(new GameRendererConsole());
                    }
                    playHu.GameEnd();
                    break;
                case "Ki":
                    var boardAi = Initialize.Start();
                    GameBase playAi = new AIPlayer(boardAi);
                    //Spiel starten
                    while (playAi.board.shipfields > 0)
                    {
                        playAi.Start(new GameRendererBase());
                    }
                    playAi.GameEnd();
                    break;
                case "Mensch vs KI":
                    var boardAi2 = Initialize.Start();
                    GameBase playAi2 = new AIPlayer(boardAi2);

                    var boardHu2 = Initialize.Start();
                    GameBase playHu2 = new HumanPlayer(boardHu2);

                    while (playAi2.board.shipfields > 0 && playHu2.board.shipfields > 0)
                    {
                        playHu2.Start(new GameRendererConsole());
                        playAi2.Start(new GameRendererConsole());
                        Console.ReadLine();
                    }
                    playHu2.GameEnd();

                    break;
            }


            Console.ReadLine();
        }
    }
}
