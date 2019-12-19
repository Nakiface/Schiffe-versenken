using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public class AI_Play : GameBase
    {
        public AI_Play (Board board) : base(board)
        {

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
