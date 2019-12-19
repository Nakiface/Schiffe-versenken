using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
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
            var countTry = 0;
            while (shipFields != 0)
            {
                var incorrectInput = true;
                int x = 0;
                int y = 0;
                int size = data.Matchfield.GetLength(1);

                while (incorrectInput == true)
                {
                    List<string> actions = ConsoleOutput.Action();
                    if((int.TryParse(actions[1], out x)) && (int.TryParse(actions[0], out y)))
                    {
                        if(x <= size && y <= size)
                        {
                            x--;
                            y--;
                            incorrectInput = false;
                        }
                    }
                    if (incorrectInput == true)
                    {
                        ConsoleOutput.IncorrectInputShot();
                    }
                }
                if (data.Matchfield[x, y].Ship)
                {
                    data.Matchfield[x, y].Hit = true;
                    shipFields -= 1;
                }
                else
                {
                    data.Matchfield[x, y].Miss = true;
                }
                countTry++;
                ConsoleOutput.CreateMatchField(data);
            }
            ConsoleOutput.GameEnd(countTry);
            return data;
        }
    }
}
