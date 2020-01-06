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
                    var boardHu = Initialize.Start(ConsoleOutput.SizeMatchField());
                    GameBase playHu = new HumanPlayer(boardHu);
                    //Spiel starten
                    while (playHu.board.shipfields > 0)
                    {
                        playHu.Start();
                        playHu.Render(new GameRendererMine());
                    }
                    playHu.GameWon();
                    break;

                case "Ki":
                    var boardAi = Initialize.Start(ConsoleOutput.SizeMatchField());
                    GameBase playAi = new AIPlayer(boardAi);
                    //Spiel starten
                    while (playAi.board.shipfields > 0)
                    {
                        playAi.Start();
                        playAi.Render(new GameRendererBase());
                    }
                    playAi.GameWon();
                    break;

                case "Mensch vs KI":
                    var size = ConsoleOutput.SizeMatchField();
                    
                    var boardAi2 = Initialize.Start(size);
                    GameBase playAi2 = new AIPlayer(boardAi2);

                    var boardHu2 = Initialize.Start(size);
                    GameBase playHu2 = new HumanPlayer(boardHu2);

                    while (playAi2.board.shipfields > 0 && playHu2.board.shipfields > 0)
                    {
                        Console.Clear();
                        playHu2.Render(new GameRendererEnemy());
                        playAi2.Render(new GameRendererMine());
                        playHu2.Start();                      
                        playAi2.Start();                       
                    }
                    playHu2.GameWon();
                    break;
            }


            Console.ReadLine();
        }
    }
}
