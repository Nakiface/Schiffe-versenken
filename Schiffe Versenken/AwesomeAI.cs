using System;
using System.Collections.Generic;

namespace Schiffe_Versenken
{
    public class AwesomeAI
    {
        public Board board { get; set; }
        public int lastX { get; set; }
        public int lastY { get; set; }
        public bool checkinit { get; set; } = true;
        public AwesomeAI (Board board)
        {
            this.board = board;
        }
        public List<int> Shoot()
        {
            var goodshoot = false;
            Random random = new Random();

            List<int> actions = new List<int>();
            if (!board.toSink)
                checkinit = true;
            if (board.toSink)
            {
                if (checkinit)
                {
                    if(InitHit.x + 1 < board.size && !board.Matchfield[InitHit.x+1, InitHit.y].Miss && !board.Matchfield[InitHit.x + 1, InitHit.y].Hit)
                    {
                        actions.Add(InitHit.x + 1);
                        actions.Add(InitHit.y);
                        InitHit.directory = "east";
                        if (board.Matchfield[InitHit.x + 1, InitHit.y].Ship)
                        {
                            checkinit = false;
                            lastX = InitHit.x + 1;
                            lastY = InitHit.y;
                        }
                        if (InitHit.x + 2 == board.size)
                            checkinit = true;
                        return actions;
                    }
                    if (InitHit.x > 0 && !board.Matchfield[InitHit.x - 1, InitHit.y].Miss && !board.Matchfield[InitHit.x - 1, InitHit.y].Hit)
                    {
                        actions.Add(InitHit.x - 1);
                        actions.Add(InitHit.y);
                        InitHit.directory = "west";
                        if (board.Matchfield[InitHit.x - 1, InitHit.y].Ship)
                        {
                            checkinit = false;
                            lastX = InitHit.x - 1;
                            lastY = InitHit.y;
                        }
                        if (InitHit.x - 1 == 0)
                            checkinit = true;
                        return actions;
                    }
                    if (InitHit.y + 1 < board.size && !board.Matchfield[InitHit.x, InitHit.y + 1].Miss && !board.Matchfield[InitHit.x, InitHit.y + 1].Hit)
                    {
                        actions.Add(InitHit.x);
                        actions.Add(InitHit.y + 1);
                        InitHit.directory = "north";
                        if (board.Matchfield[InitHit.x, InitHit.y + 1].Ship)
                        {
                            checkinit = false;
                            lastX = InitHit.x;
                            lastY = InitHit.y + 1;
                        }
                        if (InitHit.y + 2 == board.size)                            
                            checkinit = true;
                        return actions;
                    }
                    if (InitHit.y > 0 && !board.Matchfield[InitHit.x, InitHit.y - 1].Miss && !board.Matchfield[InitHit.x, InitHit.y - 1].Hit)
                    {
                        actions.Add(InitHit.x);
                        actions.Add(InitHit.y - 1);
                        InitHit.directory = "south";
                        if (board.Matchfield[InitHit.x, InitHit.y - 1].Ship)
                        {
                            checkinit = false;
                            lastX = InitHit.x;
                            lastY = InitHit.y - 1;
                        }
                        if (InitHit.y - 1 == 0)
                            checkinit = true;
                        return actions;
                    }
                }
                else
                {
                    switch (InitHit.directory)
                    {
                        case "east":
                            if (lastX + 2 == board.size || !board.Matchfield[lastX + 1, lastY].Ship)
                                checkinit = true;
                            actions.Add(lastX + 1);
                            actions.Add(lastY);
                            lastX++;
                            return actions;
                            break;
                        case "west":
                            if (lastX == 0 || !board.Matchfield[lastX - 1, lastY].Ship)
                                checkinit = true;
                            actions.Add(lastX - 1);
                            actions.Add(lastY);
                            lastX--;
                            return actions;
                            break;
                        case "north":
                            if (lastY + 2 == board.size || !board.Matchfield[lastX, lastY + 1].Ship)
                                checkinit = true;
                            actions.Add(lastX);
                            actions.Add(lastY + 1);
                            lastY++;
                            return actions;
                            break;
                        case "south":
                            if (lastY == 0 || !board.Matchfield[lastX, lastY - 1].Ship)
                                checkinit = true;
                            actions.Add(lastX);
                            actions.Add(lastY - 1);
                            lastY--;
                            return actions;
                            break;
                    }
                }
                return null;
            }


            while (goodshoot == false)
            {
                int x = random.Next(0, board.size);
                int y = random.Next(0, board.size);
                if (
                    notHitYet(x, y))

                {
                    goodshoot = true;
                    List<int> action = new List<int>();
                    action.Add(x);
                    action.Add(y);
                    lastX = x;
                    lastY = y;
                    return action;
                }
            }
            return null;
        }

        private bool notHitYet (int x, int y)
        {
            if (x >= board.size || x<0 || y >= board.size || y<0)
                return false;
            if (board.Matchfield[x, y].Hit == true || board.Matchfield[x, y].Miss == true)
                return false;
            else
                return true;
        }
    }


}
