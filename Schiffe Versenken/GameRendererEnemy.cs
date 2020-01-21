using System;

namespace Schiffe_Versenken
{
    public class GameRendererEnemy:GameRendererBase
    {
        public override void Render(Board board)
        {
            Console.WriteLine("Das ist das Gegner Feld: ");
            ConsoleOutput.CreateMatchField(board);
        }
    }
}
