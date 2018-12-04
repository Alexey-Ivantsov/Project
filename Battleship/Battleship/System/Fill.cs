
using Battleship.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using static Battleship.System.Const;

namespace Battleship.System
{
    class Fill
    {
        public static void FillShip(int i, int j, TypeShip ship, Orientation direction, Status[,] grid, Role role)
        {
            int size = Convert.ToInt32(ship);
            if (direction == Orientation.Vertical)
            {
                for (int l = 0; l < size; l++)
                {
                    if (role == Role.Computer)
                    {
                        grid[i + l, j] = Status.OccupiedComputer;
                    }
                    else
                    {
                        grid[i + l, j] = Status.Occupied + size - 1;
                    }
                }
            }
            else
            {
                for (int l = 0; l < size; l++)
                {
                    if (role == Role.Computer)
                    {
                        grid[i, j + l] = Status.OccupiedComputer;
                    }
                    else
                    {
                        grid[i, j + l] = Status.Occupied + size - 1;
                    }
                }
            }
        }
    }
}
