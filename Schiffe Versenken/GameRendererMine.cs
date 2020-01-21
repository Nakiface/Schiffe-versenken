using System;

namespace Schiffe_Versenken
{
    public class GameRendererMine:GameRendererBase
    {
        public override void Render(Board board)
        {
            Console.WriteLine("Das ist mein Feld: ");
            ConsoleOutput.CreateMatchField(board, true);
        }
    }
}
