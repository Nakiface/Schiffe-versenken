using System;
namespace Schiffe_Versenken
{
    class Data
    {
        public Field[,] Matchfield { get; set; }

        public Data(int size)
        {
            
            this.Matchfield = new Field[size, size];
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
