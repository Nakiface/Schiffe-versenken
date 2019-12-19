using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public interface IGameRenderer
    {
        void Render(Board board);
    }

    public class GameRendererBase:IGameRenderer
    {
        public virtual void Render(Board board)
        { }
    }

    public class GameRendererConsole:GameRendererBase
    {
        public override void Render(Board board)
        {
            ConsoleOutput.CreateMatchField(board);
        }
    }

    public interface IGame
    {
        void Start(IGameRenderer renderer);
    }

    public abstract class GameBase : IGame
    {
        protected Board board { get; set; }
        public GameBase(Board board)
        {
            this.board = board;
        }

        public void Start(IGameRenderer renderer)
        {
            //Gebe das neue Spielfeld aus 
            renderer.Render(board);

            //zählt die Anzahl der Felder auf denen Schiffe stehen 
            //damit er weiß nach wievielen Treffern das Spiel zuende ist
            var shipFields = CountShipFields();

            //Variable zum Zählen der Züge
            var countTry = 0;

            //Solange noch nicht alle Felder mit Schiffen getroffen wurden
            while (shipFields != 0)
            {
                //Spielfeldgröße wird ermittelt
                int size = board.Matchfield.GetLength(1);

                //Die Koordinaten werden übergeben
                List<int> actions = GetCoordinates(size);

                //Koordinaten werden zugeordnet
                var x = actions[0];
                var y = actions[1];

                //Wenn auf dem Feld auf das geschossen wurde ein Schiff steht
                //setze die Feldinfo "das war ein Treffer" auf wahr
                if (board.Matchfield[x, y].Ship)
                {
                    board.Matchfield[x, y].Hit = true;
                    shipFields -= 1;
                    if (isShipSunk(x, y, size))
                    {
                        ShipIsSunk();
                    }
                }

                //Wenn auf dem Feld auf das geschossen wurde kein Schiff steht
                //setze die Feldinfo "es war ein fehldschuss" auf wahr
                else
                {
                    board.Matchfield[x, y].Miss = true;
                }

                //zähle die Versuche für Züge hoch
                countTry++;

                //Gebe das neue Spielfeld aus 
                renderer.Render(board);
            }

            //Das Spiel ist nun zu Ende es wird eine Nachricht ausgegeben
            //und gefragt ob man nochmal Spielen will
            ConsoleOutput.CreateMatchField(board);
            ConsoleOutput.GameEnd(countTry);
        }

        public abstract List<int> GetCoordinates(int size);

        public abstract void ShipIsSunk();

        private int CountShipFields()
        {
            //Das Spielfeld wird durchgegangen und es wird geguckt
            //auf wievielen Feldern ein schiff steht
            var shipfields = 0;
            for (int x = 0; x < board.Matchfield.GetLength(1); x++)
            {
                for (int y = 0; y < board.Matchfield.GetLength(1); y++)
                {
                    if (board.Matchfield[x, y].Ship)
                        shipfields++;
                }
            }
            return shipfields;
        }

        private bool isShipSunk(int x, int y, int size)
        {
            for (int xadd = -1; xadd < 2; xadd++)
            {
                if (!(x + xadd < 0) && !(x + xadd >= size))
                    if (board.Matchfield[x + xadd, y].Ship && !board.Matchfield[x + xadd, y].Hit)
                        return false;
            }
            for (int yadd = -1; yadd < 2; yadd++)
            {
                if (!(y + yadd < 0) && !(y + yadd >= size))
                    if (board.Matchfield[x, y + yadd].Ship && !board.Matchfield[x, y + yadd].Hit)
                        return false;
            }
            return true;
        }
    }
}
