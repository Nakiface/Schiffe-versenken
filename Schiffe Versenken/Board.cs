using System;
namespace Schiffe_Versenken
{
    public class Board
    {
        //wir bauen das Spielfeld und setzen auf jede Koordinate ein "Field"
        public Field[,] Matchfield { get; set; }
        public int size { get; set; }
        public int shipfields { get; set; }
        public int countTry { get; set; }
        public bool isHit { get; set; } = false;
        public bool toSink { get; set; }

        public Board(int size)
        {   
            this.Matchfield = new Field[size, size];
            this.size = size;
            this.countTry = 0;
            this.shipfields = 0;
            Initialize(Matchfield, size);
        }

        private Field[,] Initialize (Field[,] field, int size)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    field[x, y] = new Field();
                }
            }
            return field;
        }
    }
}
