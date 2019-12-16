using System;

namespace Schiffe_Versenken
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Initialize.Start();
            ConsoleOutput.CreateMatchField(data);
            Console.ReadLine();       
        }
    }
}
