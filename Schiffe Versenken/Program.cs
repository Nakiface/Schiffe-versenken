using System;
using System.Linq;

namespace Schiffe_Versenken
{
    class Program
    {
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            var data = Initialize.Start();
            ConsoleOutput.CreateMatchField(data);
            Play play = new Play(data);
            Console.ReadLine();
        }
    }
}
