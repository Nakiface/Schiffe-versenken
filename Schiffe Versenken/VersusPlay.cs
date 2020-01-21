using System;

namespace Schiffe_Versenken
{
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
