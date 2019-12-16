using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
    class CreateMatchField
    {
        public Data PlaceShips(Data data)
        {
            List<int> ships = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var size = data.Matchfield.GetLength(0);
            return PlaceShip(data, ships, size);


        }

        private static Data PlaceShip(Data data, List<int> ships, int size)
        {
            foreach (int ship in ships)
            {
                var allowedToPlace = false;
                int xPositionStart = 0;
                int yPositionStart = 0;
                int directory = 0;
                while (!allowedToPlace)
                {
                    try
                    {
                        Random random = new Random();
                        xPositionStart = random.Next(0, size);
                        yPositionStart = random.Next(0, size);
                        directory = random.Next(0, 2);
                        for (int i = 0; i < ship; i++)
                        {
                            var xPositionCheck = xPositionStart;
                            var yPositioncheck = yPositionStart;
                            if (directory == 0)
                                xPositionCheck += i;
                            else
                                yPositioncheck += i;
                            if (data.Matchfield[xPositionCheck, yPositioncheck].Placing)
                                allowedToPlace = true;
                            else
                                allowedToPlace = false;
                            if (!allowedToPlace)
                                break;
                        }
                    }
                    catch
                    {
                        allowedToPlace = false;
                    }

                }
                int xPosition = xPositionStart;
                int yPosition = yPositionStart;
                for (int i = 0; i < ship; i++)
                {
                    if (directory == 0)
                        xPosition = xPositionStart + i;
                    else
                        yPosition = yPositionStart + i;
                    data.Matchfield[xPosition, yPosition].Ship = true;
                }
                setProhibitedFields(data, size);
            }
            return data;
        }

        private static void setProhibitedFields(Data data, int size)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (data.Matchfield[x, y].Ship)
                    {
                        for (int xadd = -1; xadd < 2; xadd++)
                        {
                            try
                            {
                                data.Matchfield[x + xadd, y].Placing = false;
                            }
                            catch { }
                        }
                        for (int yadd = -1; yadd < 2; yadd++)
                        {
                            try
                            {
                                data.Matchfield[x, y+yadd].Placing = false;
                            }
                            catch { }
                        }

                        
                    }
                }
            }
        }
    }


}
