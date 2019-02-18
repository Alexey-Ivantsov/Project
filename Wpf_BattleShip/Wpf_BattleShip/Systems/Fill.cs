using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    class Fill
    {
        public static void FillShip(int i, int j, TypeShip ship, Orientations direction, Grid[,] grid, Role role)
        {
            int size = Convert.ToInt32(ship);

            if (direction == Orientations.Vertical)
            {
                for (int l = 0; l < size; l++)
                {
                    if (role == Role.Computer)
                    {
                        grid[(i + l), j].Tag = Status.OccupiedComputer;
                    }
                    else
                    {
                        grid[i + l, j].Tag = Status.Occupied + size - 1;
                    }
                }
            }
            else
            {
                for (int l = 0; l < size; l++)
                {
                    if (role == Role.Computer)
                    {
                        grid[i, j + l].Tag = Status.OccupiedComputer;
                    }
                    else
                    {
                        grid[i, j + l].Tag = Status.Occupied + size - 1;
                    }
                }
            }
        }
    }
}
