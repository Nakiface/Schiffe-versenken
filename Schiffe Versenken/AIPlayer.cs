using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public class AIPlayer : GameBase
    {
        public AIPlayer (Board board) : base(board)
        {

        }
        public override void Start()
        {
            DoATurn();          
        }

        public override List<int> GetCoordinates (int size)
        {
            AwesomeAI awesomeAI = new AwesomeAI(board);
            return awesomeAI.Shoot();
        }

        public override void ShipIsSunk()
        {
            
        }

        public override void GameWon(int winner = 0)
        {
            ConsoleOutput.CreateMatchField(board);
            ConsoleOutput.GameWonAi(board.countTry);
        }
    }
}
