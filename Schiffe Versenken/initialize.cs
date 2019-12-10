using System;

namespace Schiffe_Versenken
{
    static class initialize
    {
        static public void start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleOutput consoleOutput = new ConsoleOutput();
            consoleOutput.Greeting();
            CreateMatchField createMatchField = new CreateMatchField(consoleOutput.SizeMatchField());
        }
    }

}
