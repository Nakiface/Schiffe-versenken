using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public class HumanPlayer : GameBase
    {
        public HumanPlayer(Board board) : base(board)
        {
        }

        public override void Start()
        {
            DoATurn();          
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
                if ((int.TryParse(actions[0], out x)) && (int.TryParse(actions[1], out y)))
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

        public override void ShipIsSunk()
        {
            ConsoleOutput.ShipIsSunk();
        }

        public override void GameWon(int winner = 0)
        {
            ConsoleOutput.GameWonHu(board.countTry);
        }
    }
}
