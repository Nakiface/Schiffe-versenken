using System;

namespace Schiffe_Versenken
{
    class CreateMatchField
    {
        private int size { get; set; }
        public int[,] matchfield { get; set; }

        public CreateMatchField(Data data)
        {
            this.size = data.size;
            this.matchfield = new int[this.size, this.size];
            Build();
        }

        private void Build ()
        {
            //Konsole Curser.Left Curser.Top
            Console.WriteLine();
            Console.Write("   ");
            for (int z = 0; z < matchfield.GetLength(0); z++)
            {
                if (z<9)
                    Console.Write($"{z+1}   ");
                else
                    Console.Write($"{z + 1}  ");
            }
            Console.WriteLine();
            for (int x = 0; x < matchfield.GetLength(0); x++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (x < 9)
                    Console.Write($"{x + 1}  ");
                else
                    Console.Write($"{x + 1} ");
                for (int y = 0; y < matchfield.GetLength(1); y++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\u25A0   ");
                }
                Console.Write("\n\n");
            }
        }
    }
}
