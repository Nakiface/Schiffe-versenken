using System;
using System.Collections.Generic;
using System.Linq;

namespace Schiffe_Versenken
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Initialize.Start();
            ConsoleOutput.CreateMatchField(data);
            Play play = new Play(data);
            Console.ReadLine();       
        }
    }

    class Play
    {
        public int turns { get; set; } = 0;

        public Play(Data data)
        {
            DoATurn(data);
        }

        private int CountShipFields (Data data)
        {
            var shipfields = 0;
            for (int x = 0; x < data.Matchfield.GetLength(1); x++)
            {
                for (int y = 0; y < data.Matchfield.GetLength(1); y++)
                {
                    if (data.Matchfield[x, y].Ship)
                        shipfields++;                  
                }
            }
            return shipfields;
        }

        private Data DoATurn(Data data)
        {
            var shipFields = CountShipFields(data);
            var counttry = 0;
            while (shipFields != 0)
            {
                List<string> actions = ConsoleOutput.Action();
                Console.Clear();
                var x = Convert.ToInt32(actions[1]) - 1;
                var y = Convert.ToInt32(actions[0]) - 1;
                if (data.Matchfield[x, y].Ship)
                {
                    data.Matchfield[x, y].Hit = true;
                    shipFields -= 1;
                }
                else
                {
                    data.Matchfield[x, y].Miss = true;
                }
                counttry++;
                ConsoleOutput.CreateMatchField(data);
            }
            ConsoleOutput.GameEnd(counttry);
            return data;
        }
    }
}
