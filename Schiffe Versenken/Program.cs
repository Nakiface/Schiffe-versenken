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
            var rendererEnemy = new GameRendererEnemy();
            var rendererKI = new GameRendererBase();
            var rendererMine = new GameRendererMine();
            
            switch (menu)
            {
                case "Mensch":
                    var boardHu = Initialize.Start(ConsoleOutput.SizeMatchField());
                    GameBase playHu = new HumanPlayer(boardHu);
                    //Spiel starten
                    while (playHu.board.shipfields > 0)
                    {
                        
                        playHu.Render(rendererEnemy);
                        playHu.Start();
                        Console.Clear();
                    }
                    //playHu.Render(rendererEnemy);
                    playHu.GameWon();
                    break;

                case "Ki":
                    var boardAi = Initialize.Start(ConsoleOutput.SizeMatchField());
                    GameBase playAi = new AIPlayer(boardAi);
                    //Spiel starten
                    while (playAi.board.shipfields > 0)
                    {
                        playAi.Start();
                        playAi.Render(rendererKI);
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
                        playHu2.Render(rendererEnemy);
                        playAi2.Render(rendererMine);
                        playHu2.Start();                      
                        playAi2.Start();                       
                    }
                    if (playAi2.board.shipfields == 0)
                        playAi2.GameWon();
                    else
                        playHu2.GameWon();
                    break;

                case "Mensch vs Mensch":
                    var size2 = ConsoleOutput.SizeMatchField();

                    var boardHu3 = Initialize.Start(size2);
                    GameBase playHu3 = new HumanPlayer(boardHu3);

                    var boardHu4 = Initialize.Start(size2);
                    GameBase playHu4 = new HumanPlayer(boardHu4);

                    while (playHu3.board.shipfields > 0 && playHu4.board.shipfields > 0)
                    {
                        Console.Clear();
                        playHu3.Render(rendererEnemy);
                        playHu4.Render(rendererMine);
                        playHu3.Start();
                        playHu4.Start();
                    }
                    if (playHu3.board.shipfields == 0)
                        playHu3.GameWon();
                    else
                        playHu4.GameWon();
                    break;
            }


            Console.ReadLine();
        }
    }
}
