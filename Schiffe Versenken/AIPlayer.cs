﻿using System.Collections.Generic;

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
            return simpleAI.Shoot(board);
        }

        public override void ShipIsSunk()
        {
            
        }

        public override void GameWon()
        {
            ConsoleOutput.CreateMatchField(board);
            ConsoleOutput.GameEnd(board.countTry);
        }
    }
}