using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    public class Check
    {
        public static bool CheckPlacement(int i, int j, TypeShip ship, Orientations direction, Grid[,] grid)
        {
            if (i < 0 || j < 0 || i > 9 || j > 9)
            {
                return true;
            }
            if (grid.GetLength(0) > 10 || grid.GetLength(1) > 10)
            {
                return true;
            }
            int size = Convert.ToInt32(ship);
            switch (direction)
            {
                case Orientations.Vertical:
                    for (int column = -1; column < size + 1; column++)
                    {
                        for (int Line = -1; Line < 2; Line++)
                        {
                            if (i + column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }

                            else if (i > grid.GetLength(0) - size || grid[i + column, j + Line].Tag.Equals(Status.Occupied) || grid[i + column, j + Line].Tag.Equals(Status.OccupiedComputer)
                                || grid[i + column, j + Line].Tag.Equals(Status.Occupied2)
                                || grid[i + column, j + Line].Tag.Equals(Status.Occupied3)
                                || grid[i + column, j + Line].Tag.Equals(Status.Occupied4)
                                )
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case Orientations.Horizontal:
                    for (int Column = -1; Column < 2; Column++)
                    {
                        for (int Line = -1; Line < size + 1; Line++)
                        {

                            if (i + Column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + Column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }

                            else if (j > grid.GetLength(0) - size || grid[i + Column, j + Line].Tag.Equals(Status.Occupied) || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 1)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 2)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 3)
                                )
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case Orientations.None:
                    for (int Column = -1; Column < 2; Column++)
                    {
                        for (int Line = -1; Line < 2; Line++)
                        {
                            if (i + Column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + Column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }
                            else if (grid[i + Column, j + Line].Tag.Equals(Status.Occupied) || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 1)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 2)
                                || grid[i + Column, j + Line].Tag.Equals(Status.Occupied + 3)
                                )
                            {
                                return true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
