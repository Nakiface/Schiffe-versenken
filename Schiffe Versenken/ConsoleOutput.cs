using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
    static class ConsoleOutput
    {
        static public string Greeting ()
        {
            Console.Clear();
            Console.WriteLine("Willkommen\nWer soll Spielen?: \n");
            List<string> menu = new List<string>() { "Mensch", "Ki", "Mensch vs KI", "Mensch vs Mensch"};
            int auswahl = 0;
            foreach(string menuitem in menu)
            {
                auswahl++;
                Console.WriteLine($"{auswahl}: {menuitem}");
            }
            Console.Write("\nEingabe bitte als Zahl: ");
            if (!int.TryParse(Console.ReadLine(), out auswahl))
                Program.Main();
            Console.WriteLine();
            return menu[auswahl - 1];
        }

        static public int SizeMatchField ()
        {
            int size = 0;
            Console.Write("Geben Sie ihre Spielfeldgröße ein: ");
            if (!int.TryParse(Console.ReadLine(), out size))
                IncorrectInputFieldsize();
            return size;
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

        static public void ShipIsSunk ()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDas Schiff ist untergegangen!!!");
            Console.WriteLine("Weiter mit belibiger Taste");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static public void IncorrectInputShot()
        {
            Console.WriteLine("Die Eingabe der Koordinaten war Fehlerhaft, Bitte nocheinmal...\n");
        }

        static public void IncorrectInputFieldsize()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFehlerhafte Eingabe das Programm startet neu\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Program.Main();
        }

        static public void GameWonHu(int countTry)
        {
            Console.WriteLine($"Sie haben gewonnen und {countTry} Versuche gebraucht");
            Console.Write("Wenn Sie nochmal Spielen wollen Tippen Sie bitte \"y\": ");
            var Eingabe = Console.ReadLine();
            if (Eingabe == "y" || Eingabe == "Y")
            {
                Console.Clear();
                Program.Main();
            }
        }

        static public void GameWonAi(int countTry)
        {
            Console.WriteLine($"Der Computer hat gewonnen und {countTry} Versuche gebraucht");
            Console.Write("Wenn Sie nochmal Spielen wollen Tippen Sie bitte \"y\": ");
            var Eingabe = Console.ReadLine();
            if (Eingabe == "y" || Eingabe == "Y")
            {
                Console.Clear();
                Program.Main();
            }
        }

        static public void MatchfieldToBig()
        {
            Console.WriteLine();
            Console.WriteLine("Digga das Spielfeld ist zu Groß Übertreib mal nicht!");
            Console.WriteLine("Jetzt starten wir nochmal und dann machst du mal Piano! \n");
            Program.Main();
        }

        static public void CantPlaceAllShips(int shipsplaced)
        {
            if (shipsplaced > 0)
            {
                Console.WriteLine($"Leider konnten nicht alle Schiffe plaziert werden");
                if (shipsplaced == 1)
                    Console.WriteLine($"Es wurden {shipsplaced} Schiff plaziert \n");
                else
                    Console.WriteLine($"Es wurden {shipsplaced} Schiffe palzert \n");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Das Spielfeld ist zu klein es konnte keine Boot gesetzt werden!");
                Console.WriteLine("Mit einem Tastendruck starten Sie das Spiel neu");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Program.Main();
            }
        }

        static public void CreateMatchField(Board data, bool myfield = false)
        {
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
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (data.Matchfield[x, y].Ship && myfield == true)
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
