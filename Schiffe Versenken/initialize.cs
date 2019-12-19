using System;

namespace Schiffe_Versenken
{
    static class Initialize
    {
        static public Data Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleOutput.Greeting();
            var size = ConsoleOutput.SizeMatchField();
            if (size > 25)
            {
                ConsoleOutput.MatchfieldToBig();
            }
            Data data = new Data(size);
            Console.Clear();
            CreateMatchField createMatchField = new CreateMatchField();
            createMatchField.PlaceShips(data);          
            return data;
        }
    }

    //class BuildMatch
}
