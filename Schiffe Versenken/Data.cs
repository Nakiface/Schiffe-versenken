using System;
namespace Schiffe_Versenken
{
    class Data
    {
        public Field[,] Matchfield { get; set; }

        public Data(string size)
        {
            
            this.Matchfield = new Field[Convert.ToInt32(size), Convert.ToInt32(size)];
            Initialize(this.Matchfield,Convert.ToInt32(size));
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
