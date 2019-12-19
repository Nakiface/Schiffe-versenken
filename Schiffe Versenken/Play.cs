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
            ConsoleOutput.GameEnd(countTry);
        }

        public abstract List<int> GetCoordinates(int size);

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
    }

    public class HumanPlayer : GameBase
    {
        public HumanPlayer(Board board) : base(board)
        {
        }

        public override List<int> GetCoordinates(int size)
        {
            //Initialisierung der Variablen für
            //Das Abfangen falscher Eingaben, X und Y Koordinate
            var incorrectInput = true;
            int x = 0;
            int y = 0;


            //Solange noch die Eingabe Falsch aber min. einmal
            while (incorrectInput == true)
            {
                //Benutzer Eingabe der X und Y Koordinate
                List<string> actions = ConsoleOutput.Action();

                //Wenn die Eingabe eine Zahl war und diese im Bereich der Spielfeldgröße liegt
                //Wird der Schleife bescheid gegeben das die Eingabe korrekt war
                if ((int.TryParse(actions[1], out x)) && (int.TryParse(actions[0], out y)))
                {
                    if (x <= size && y <= size)
                    {
                        x--;
                        y--;
                        incorrectInput = false;
                    }
                }

                //Wenn Die Eingabe Falsch war wird der Beutzer darüber Benachrichtigt
                if (incorrectInput == true)
                {
                    ConsoleOutput.IncorrectInputShot();
                }
            }
            return new List<int>() { x, y };
        }

    }

    public class AI_Play : GameBase
    {
        public AI_Play (Board board) : base(board)
        {

        }

        public override List<int> GetCoordinates (int size)
        {
            return null;
        }

    }

    //public class Play
    //{
    //    public Board board { get; set; }
    //    public Play(Board board)
    //    {
    //        this.board = board;
    //    }
    //    public void Start ()
    //    {
    //        //zählt die Anzahl der Felder auf denen Schiffe stehen 
    //        //damit er weiß nach wievielen Treffern das Spiel zuende ist
    //        var shipFields = CountShipFields();

    //        //Variable zum Zählen der Züge
    //        var countTry = 0;

    //        //Solange noch nicht alle Felder mit Schiffen getroffen wurden
    //        while (shipFields != 0)
    //        {
    //            //Spielfeldgröße wird ermittelt
    //            int size = board.Matchfield.GetLength(1);

    //            //Die Koordinaten werden übergeben
    //            List<int> actions = GetCoordinates(size);

    //            //Koordinaten werden zugeordnet
    //            var x = actions[0];
    //            var y = actions[1];

    //            //Wenn auf dem Feld auf das geschossen wurde ein Schiff steht
    //            //setze die Feldinfo "das war ein Treffer" auf wahr
    //            if (board.Matchfield[x, y].Ship)
    //            {
    //                board.Matchfield[x, y].Hit = true;
    //                shipFields -= 1;
    //            }

    //            //Wenn auf dem Feld auf das geschossen wurde kein Schiff steht
    //            //setze die Feldinfo "es war ein fehldschuss" auf wahr
    //            else
    //            {
    //                board.Matchfield[x, y].Miss = true;
    //            }

    //            //zähle die Versuche für Züge hoch
    //            countTry++;

    //            //Gebe das neue Spielfeld aus 
    //            MatchFieldOutput();               
    //        }

    //        //Das Spiel ist nun zu Ende es wird eine Nachricht ausgegeben
    //        //und gefragt ob man nochmal Spielen will
    //        ConsoleOutput.GameEnd(countTry);
    //    }
    //    public virtual void MatchFieldOutput()
    //    {
    //        ConsoleOutput.CreateMatchField(board);
    //    }

    //    public virtual List<int> GetCoordinates (int size)
    //    {
    //        //Initialisierung der Variablen für
    //        //Das Abfangen falscher Eingaben, X und Y Koordinate
    //        var incorrectInput = true;
    //        int x = 0;
    //        int y = 0;
            

    //        //Solange noch die Eingabe Falsch aber min. einmal
    //        while (incorrectInput == true)
    //        {
    //            //Benutzer Eingabe der X und Y Koordinate
    //            List<string> actions = ConsoleOutput.Action();

    //            //Wenn die Eingabe eine Zahl war und diese im Bereich der Spielfeldgröße liegt
    //            //Wird der Schleife bescheid gegeben das die Eingabe korrekt war
    //            if ((int.TryParse(actions[1], out x)) && (int.TryParse(actions[0], out y)))
    //            {
    //                if (x <= size && y <= size)
    //                {
    //                    x--;
    //                    y--;
    //                    incorrectInput = false;
    //                }
    //            }

    //            //Wenn Die Eingabe Falsch war wird der Beutzer darüber Benachrichtigt
    //            if (incorrectInput == true)
    //            {
    //                ConsoleOutput.IncorrectInputShot();
    //            }               
    //        }
    //        return new List<int>() { x, y };
    //    }

    //    private int CountShipFields()
    //    {
    //        //Das Spielfeld wird durchgegangen und es wird geguckt
    //        //auf wievielen Feldern ein schiff steht
    //        var shipfields = 0;
    //        for (int x = 0; x < board.Matchfield.GetLength(1); x++)
    //        {
    //            for (int y = 0; y < board.Matchfield.GetLength(1); y++)
    //            {
    //                if (board.Matchfield[x, y].Ship)
    //                    shipfields++;                  
    //            }
    //        }
    //        return shipfields;
    //    }
    //}
}
