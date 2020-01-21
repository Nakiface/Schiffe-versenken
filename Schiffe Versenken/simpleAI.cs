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
}
