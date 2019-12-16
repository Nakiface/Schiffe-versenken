using System;
using System.Collections.Generic;

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

        static public List<string> Action ()
        {
            List<string> actions = new List<string>();
            Console.Write("Geben Sie die X-Koordinate ihres Schusses an: ");
            actions.Add(Console.ReadLine());
            Console.Write("Geben Sie die Y-Koordinate ihres Schusses an: ");
            actions.Add(Console.ReadLine());
            return actions;
        }

        static public void GameEnd(int countTry)
        {
            Console.WriteLine($"Sie haben gewonnen und {countTry} Versuche gebraucht");
        }

        static public void CreateMatchField(Data data)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int z = 0; z < data.Matchfield.GetLength(0); z++)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
                    if (data.Matchfield[x, y].Ship)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (data.Matchfield[x, y].Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (data.Matchfield[x, y].Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;                        
                    }

                    Console.Write("\u25A0   ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\n\n");
            }
        }
    }
}
