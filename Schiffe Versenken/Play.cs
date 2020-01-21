using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public abstract class GameBase
    {
        public Board board { get; set; }
        public GameBase(Board board)
        {
            this.board = board;
            this.board.shipfields = CountShipFields();
        }

        public abstract void Start();

        public abstract void GameWon(int winner  = 0);

        public void Render(IGameRenderer renderer)
        {
            renderer.Render(board);
        }

        public void DoATurn()
        {
            //Spielfeldgröße wird ermittelt
            int size = board.size;

            //Die Koordinaten werden übergeben
            List<int> actions = GetCoordinates(size);

            //Koordinaten werden zugeordnet
            var x = actions[0];
            var y = actions[1];

            //Wenn auf dem Feld auf das geschossen wurde ein Schiff steht
            //setze die Feldinfo "das war ein Treffer" auf wahr
            if (board.Matchfield[x, y].Ship && !board.Matchfield[x,y].Hit)
            {
                board.Matchfield[x, y].Hit = true;
                if (board.toSink == false)
                {
                    InitHit.x = x;
                    InitHit.y = y;
                }
                board.isHit = true;
                board.toSink = true;
  
                board.shipfields -= 1;
                if (isShipSunk(x, y, size))
                {
                    ShipIsSunk();
                    board.toSink = false;
                    
                }
            }

            //Wenn auf dem Feld auf das geschossen wurde kein Schiff steht
            //setze die Feldinfo "es war ein fehldschuss" auf wahr
            if (!board.Matchfield[x,y].Ship)
            {
                board.isHit = false;
                board.Matchfield[x, y].Miss = true;
            }

            //zähle die Versuche für Züge hoch
            board.countTry++;
        }

        public abstract List<int> GetCoordinates(int size);

        public abstract void ShipIsSunk();

        private int CountShipFields()
        {
            //Das Spielfeld wird durchgegangen und es wird geguckt
            //auf wievielen Feldern ein schiff steht
            var shipfields = 0;
            for (int x = 0; x < board.size; x++)
            {
                for (int y = 0; y < board.size; y++)
                {
                    if (board.Matchfield[x, y].Ship)
                        shipfields++;
                }
            }
            return shipfields;
        }

        private bool isShipSunkXPlus(int x, int y, int size)
        {
            for (int xCheck = x; xCheck < size; xCheck++)
            {
                if (board.Matchfield[xCheck, y].Ship && !board.Matchfield[xCheck, y].Hit)
                    return false;
                if (!board.Matchfield[xCheck, y].Ship)
                    return true;
            }
            return true;
        }
        private bool isShipSunkXMinus(int x, int y, int size)
        {
            for (int xCheck = x; xCheck >=0; xCheck--)
            {
                if (board.Matchfield[xCheck, y].Ship && !board.Matchfield[xCheck, y].Hit)
                    return false;
                if (!board.Matchfield[xCheck, y].Ship)
                    return true;
            }
            return true;
        }

        private bool isShipSunkYPlus(int x, int y, int size)
        {
            for (int yCheck = y; yCheck < size; yCheck++)
            {
                if (board.Matchfield[x, yCheck].Ship && !board.Matchfield[x, yCheck].Hit)
                    return false;
                if (!board.Matchfield[x, yCheck].Ship)
                    return true;
            }
            return true;
        }

        private bool isShipSunkYMinus(int x, int y, int size)
        {
            for (int yCheck = y; yCheck >= 0; yCheck--)
            {
                if (board.Matchfield[x, yCheck].Ship && !board.Matchfield[x, yCheck].Hit)
                    return false;
                if (!board.Matchfield[x, yCheck].Ship)
                    return true;
            }
            return true;
        }


        private bool isShipSunk(int x, int y, int size)
        {
            if (isShipSunkXPlus(x, y, size) && isShipSunkXMinus(x, y, size) && isShipSunkYPlus(x, y, size) && isShipSunkYMinus(x, y, size))
            {
                setSunkTrue(x, y, size);
                return true;
            }       
            return false;
        }

        private void setSunkTrue(int x, int y, int size)
        {
            for (int xPlus = x; xPlus < size; xPlus++)
            {
                if (board.Matchfield[xPlus, y].Ship)
                    board.Matchfield[xPlus, y].sunk = true;
                else
                    break;
            }
            for (int xMinus = x; xMinus >= 0; xMinus--)
            {
                if (board.Matchfield[xMinus, y].Ship)
                    board.Matchfield[xMinus, y].sunk = true;
                else
                    break;
            }
            for (int yPlus = y; yPlus < size; yPlus++)
            {
                if (board.Matchfield[x, yPlus].Ship)
                    board.Matchfield[x, yPlus].sunk = true;
                else
                    break;
            }
            for (int yMinus = y; yMinus >= 0; yMinus--)
            {
                if (board.Matchfield[x, yMinus].Ship)
                    board.Matchfield[x, yMinus].sunk = true;
                else
                    break;
            }         
        }
    }
}
