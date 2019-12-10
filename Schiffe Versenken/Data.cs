using System;

namespace Schiffe_Versenken
{
    class Data
    {
        public int size { get; set; }
        public Field[,] Ai_MatchField { get; set; }
        public Field[,] Hu_Matchfield { get; set; }

        public Data(string size)
        {
            this.size = Convert.ToInt32(size);
            this.Ai_MatchField = new Field[this.size, this.size];
            this.Hu_Matchfield = new Field[this.size, this.size];
        }
    }
}
