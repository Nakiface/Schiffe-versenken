using System;
using System.Linq;

namespace Schiffe_Versenken
{
    class Program
    {
        public static void Main()
        {
            //Initialisierung
            var board = Initialize.Start();
            //Game initalisieren
            IGame play = new AI_Play(board);
            //Spiel starten
            play.Start(new GameRendererBase());

            Console.ReadLine();
        }
    }
}
