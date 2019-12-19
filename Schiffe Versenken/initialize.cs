using System;

namespace Schiffe_Versenken
{
    static class Initialize
    {
        static public Board Start()
        {
            //Umstellen des Encordings und Begrüßung
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleOutput.Greeting();

            //Die Größe des Spielfeldes wird ermittelt und zu Große Eingaben abgefangen
            var size = ConsoleOutput.SizeMatchField();
            if (size > 25)
            {
                ConsoleOutput.MatchfieldToBig();
            }
            Console.Clear();

            //Ein leeres Spielfeld einer vorgegeben Größe wird gebaut
            Board board = new Board(size);

            //Die Schiffe werden auf dem Board plaziert
            CreateMatchField createMatchField = new CreateMatchField();
            createMatchField.PlaceShips(board);   
            
            //Wir geben ein Spielfeld mit plazierten Schiffen zurück
            return board;
        }
    }
}
