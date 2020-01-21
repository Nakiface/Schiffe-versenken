using System.Collections.Generic;

namespace Schiffe_Versenken
{
    
    public class AIPlayer : GameBase
    {
        public AwesomeAI awesomeAI { get; set; }
        public AIPlayer (Board board) : base(board)
        {
            awesomeAI = new AwesomeAI(board);
        }
        public override void Start()
        {
            DoATurn();          
        }

        public override List<int> GetCoordinates (int size)
        {
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
