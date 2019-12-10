using System;

namespace Schiffe_Versenken
{
    class ConsoleOutput
    {
        public void Greeting ()
        {
            Console.WriteLine("Hallo gleich gehts los");
        }

        public string SizeMatchField ()
        {
            Console.Write("Geben Sie ihre Spielfeldgröße ein: ");
            return Console.ReadLine();
        }
    }
}
