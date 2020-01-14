using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
    static public class simpleAI
    {
        static public List<int> Shoot (Board board)
        {
            for (int x = 0; x < board.size; x++)
            {
                for (int y = 0; y < board.size ; y++)
                {
                    if (!board.Matchfield[x,y].Hit && !board.Matchfield[x,y].Miss)
                    {
                        return new List<int>() { x, y };
                    }
                }
            }
            return null;
        }
    }

    public class AwesomeAI
    {
        public Board board { get; set; }
        public AwesomeAI (Board board)
        {
            this.board = board;
        }
        public List<int> Shoot ()
        {
            var goodshoot = false;
            Random random = new Random();
            while (goodshoot == false)
            {
                int x = random.Next(0, board.size);
                int y = random.Next(0, board.size);
                if (
                    notHitYet(x, y))
                {
                    goodshoot = true;
                    List<int> action = new List<int>();
                    action.Add(x);
                    action.Add(y);
                    return action;
                }                           
            }
            return null;        
        }

        private bool notHitYet (int x, int y)
        {
            if (board.Matchfield[x, y].Hit == true || board.Matchfield[x, y].Miss == true)
                return false;
            else
                return true;
        }
    }
}
