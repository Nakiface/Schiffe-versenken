using System;

namespace Schiffe_Versenken
{
    static class Initialize
    {
        static public Data Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleOutput.Greeting();
            Data data = new Data(ConsoleOutput.SizeMatchField());
            CreateMatchField createMatchField = new CreateMatchField();
            createMatchField.PlaceShips(data);
            

            return data;
        }
    }

    //class BuildMatch
}
