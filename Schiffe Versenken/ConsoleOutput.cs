using System;

namespace Schiffe_Versenken
{
    static class ConsoleOutput
    {
        static public void Greeting ()
        {
            Console.WriteLine("Hallo gleich gehts los");
        }

        static public string SizeMatchField ()
        {
            Console.Write("Geben Sie ihre Spielfeldgröße ein: ");
            return Console.ReadLine();
        }

        static public void CreateMatchField(Data data)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int z = 0; z < data.Matchfield.GetLength(0); z++)
            {
                if (z < 9)
                    Console.Write($"{z + 1}   ");
                else
                    Console.Write($"{z + 1}  ");
            }
            Console.WriteLine();
            for (int x = 0; x < data.Matchfield.GetLength(0); x++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (x < 9)
                    Console.Write($"{x + 1}  ");
                else
                    Console.Write($"{x + 1} ");
                for (int y = 0; y < data.Matchfield.GetLength(1); y++)
                {
                    if (data.Matchfield[x, y].Water)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
 
                    if (data.Matchfield[x, y].Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (data.Matchfield[x, y].Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.White;                        
                    }
                    if (data.Matchfield[x, y].Ship)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write("\u25A0   ");

                }
                Console.Write("\n\n");
            }
        }
    }
}
