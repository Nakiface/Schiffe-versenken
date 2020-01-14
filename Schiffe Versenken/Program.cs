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
                        
                        playHu.Render(new GameRendererEnemy());
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
                        playAi.Render(new GameRendererBase());
                        playAi.Start();                       
                    }
                    playAi.GameWon();
                    break;

                case "Mensch vs KI":
                    var size = ConsoleOutput.SizeMatchField();
                    
                    var boardAi2 = Initialize.Start(size);
                    GameBase playAi2 = new AIPlayer(boardAi2);

                    var boardHu2 = Initialize.Start(size);
                    GameBase playHu2 = new HumanPlayer(boardHu2);

                    var playHuVsKi = new VersusPlay(playAi2, playHu2);
                    playHuVsKi.start();
                    break;

                case "Mensch vs Mensch":
                    var size2 = ConsoleOutput.SizeMatchField();

                    var boardHu3 = Initialize.Start(size2);
                    GameBase playHu3 = new HumanPlayer(boardHu3);

                    var boardHu4 = Initialize.Start(size2);
                    GameBase playHu4 = new HumanPlayer(boardHu4);

                    var playHuVsHu = new VersusPlay(playHu3, playHu4);
                    playHuVsHu.start();
                    break;                 
            }
            Console.ReadLine();
        }
    }

    public class VersusPlay
    {
        public GameBase player1 { get; set; }
        public GameBase player2 { get; set; }

        public VersusPlay(GameBase player1, GameBase player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void start()
        {
            var rendererEnemy = new GameRendererEnemy();
            var rendererKI = new GameRendererBase();
            var rendererMine = new GameRendererMine();

            {
                while (player2.board.shipfields > 0 && player1.board.shipfields > 0)
                {
                    Console.Clear();
                    if (player1 is AIPlayer)
                    {
                        player2.Render(rendererEnemy);
                        player1.Render(rendererMine);
                        player1.Start();
                        player2.Start();
                    }
                    else
                    {                    
                        player2.Render(rendererMine);
                        player1.Render(rendererEnemy);
                        player1.Start();
                        if (player1.board.shipfields == 0)
                            break;
                        ConsoleOutput.NextPlayer();
                        player1.Render(rendererMine);
                        player2.Render(rendererEnemy);
                        player2.Start();
                        if (player2.board.shipfields == 0)
                            break;
                        ConsoleOutput.NextPlayer();
                    }
                }
                if (player2.board.shipfields == 0)
                    player2.GameWon(2);
                else
                    player1.GameWon(1);
            }
        }
    }
}
