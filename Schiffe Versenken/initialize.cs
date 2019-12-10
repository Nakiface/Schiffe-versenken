using System;

namespace Schiffe_Versenken
{
    static class Initialize
    {
        static public Data Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleOutput consoleOutput = new ConsoleOutput();
            consoleOutput.Greeting();
            Data data = new Data(consoleOutput.SizeMatchField());
            return data;
        }
    }
}
