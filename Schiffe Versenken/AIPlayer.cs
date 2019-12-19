using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public class AIPlayer : GameBase
    {
        public AIPlayer (Board board) : base(board)
        {

        }
        public override void Start(IGameRenderer renderer)
        {
            while (board.shipfields > 0)
            {
                DoATurn(renderer);
            }
            ConsoleOutput.CreateMatchField(board);
            ConsoleOutput.GameEnd(board.countTry);
        }

        public override List<int> GetCoordinates (int size)
        {
            return simpleAI.Shoot(board);
        }

        public override void ShipIsSunk()
        {
            
        }
    }
}
