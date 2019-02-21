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
                                || grid[i + column, j + Line].Tag.Equals(Status.OccupiedComputer2)
                                || grid[i + column, j + Line].Tag.Equals(Status.OccupiedComputer3)
                                || grid[i + column, j + Line].Tag.Equals(Status.OccupiedComputer4)
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
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer2)
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer3)
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer4)
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
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer2)
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer3)
                                || grid[i + Column, j + Line].Tag.Equals(Status.OccupiedComputer4)
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
        public static bool FindDirection(int i, int j, Grid[,] playerGrid, HitInformation hitInformation)
        {
            if (i < 0 || j < 0 || i > 9 || j > 9)
            {
                return true;
            }
            switch (hitInformation.DirectionCheck)
            {
                case DirectionCheck.Up:

                    if (i - 1 < Const.MIN_BOUND || playerGrid[i - 1, j].Tag.Equals(Status.Used))
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i - 1, j].Tag.Equals(Status.Empty))
                    {
                        playerGrid[i - 1, j].Tag = Status.Used;
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }
                    else
                    {
                        playerGrid[i - 1, j].Tag = Status.Hit;
                        if (j + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i - 1, j + 1].Tag = Status.Used;//
                        }
                        if (j - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i - 1, j - 1].Tag = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Up;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Right:

                    if (j + 1 > Const.MAX_BOUND || playerGrid[i, j + 1].Tag.Equals(Status.Used))
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i, j + 1].Tag.Equals(Status.Empty))
                    {
                        playerGrid[i, j + 1].Tag = Status.Used;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        hitInformation.DirectionCheck++;
                        break;
                    }
                    else
                    {
                        playerGrid[i, j + 1].Tag = Status.Hit;
                        if (i + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i + 1, j + 1].Tag = Status.Used;//
                        }
                        if (i - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i - 1, j + 1].Tag = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Right;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Down:

                    if (i + 1 > Const.MAX_BOUND || playerGrid[i + 1, j].Tag.Equals(Status.Used))
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i + 1, j].Tag.Equals(Status.Empty))
                    {
                        playerGrid[i + 1, j].Tag = Status.Used;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        hitInformation.DirectionCheck++;
                        break;
                    }
                    else
                    {
                        playerGrid[i + 1, j].Tag = Status.Hit;
                        if (j + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i + 1, j + 1].Tag = Status.Used;//
                        }
                        if (j - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i + 1, j - 1].Tag = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Down;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Left:

                    playerGrid[i, j - 1].Tag = Status.Hit;
                    if (i + 1 < Const.MAX_BOUND)
                    {
                        playerGrid[i + 1, j - 1].Tag = Status.Used;//
                    }
                    if (i - 1 > Const.MIN_BOUND)
                    {
                        playerGrid[i - 1, j - 1].Tag = Status.Used;//
                    }
                    hitInformation.PlayerCount--;
                    hitInformation.ShipCount--;
                    hitInformation.ResDirection = ResultDirection.Left;
                    hitInformation.DirectionCheck = DirectionCheck.Up;
                    hitInformation.StatusShoot = ShootStatus.Miss;
                    break;

                default:
                    break;
            }
            return false;
        }
        public static void HitDirection(int i, int j, Grid[,] playerGrid, HitInformation hitInformation)
        {

            switch (hitInformation.ResDirection)
            {
                case ResultDirection.Up:
                    for (; hitInformation.Count < 4;)
                    {

                        if (i - hitInformation.Count < Const.MIN_BOUND || playerGrid[i - hitInformation.Count, j].Tag.Equals(Status.Used))
                        {
                            hitInformation.ResDirection = ResultDirection.Down;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i - hitInformation.Count, j].Tag.Equals(Status.Hit))
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i - hitInformation.Count, j].Tag.Equals(Status.Empty))
                        {
                            playerGrid[i - hitInformation.Count, j].Tag = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Down;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i - hitInformation.Count, j].Tag = Status.Hit;
                            if (j + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i - hitInformation.Count, j + 1].Tag = Status.Used;//
                            }
                            if (j - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - hitInformation.Count, j - 1].Tag = Status.Used;//
                            }
                            hitInformation.PlayerCount--;
                            hitInformation.ShipCount--;
                            hitInformation.Count++;
                            if (hitInformation.ShipCount == 0)
                            {
                                hitInformation.StatusShoot = ShootStatus.Miss;
                                return;
                            }
                        }
                    }
                    break;

                case ResultDirection.Right:
                    for (; hitInformation.Count < 4;)
                    {

                        if (j + hitInformation.Count > Const.MAX_BOUND || playerGrid[i, j + hitInformation.Count].Tag.Equals(Status.Used))
                        {
                            hitInformation.ResDirection = ResultDirection.Left;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i, j + hitInformation.Count].Tag.Equals(Status.Hit))
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i, j + hitInformation.Count].Tag.Equals(Status.Empty))
                        {
                            playerGrid[i, j + hitInformation.Count].Tag = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Left;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i, j + hitInformation.Count].Tag = Status.Hit;
                            if (i + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + 1, j + hitInformation.Count].Tag = Status.Used;//
                            }
                            if (i - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - 1, j + hitInformation.Count].Tag = Status.Used;//
                            }
                            hitInformation.PlayerCount--;
                            hitInformation.ShipCount--;
                            hitInformation.Count++;
                            if (hitInformation.ShipCount == 0)
                            {
                                hitInformation.StatusShoot = ShootStatus.Miss;
                                return;
                            }
                        }
                    }
                    break;
                case ResultDirection.Down:
                    for (; hitInformation.Count < 4;)
                    {
                        if (i + hitInformation.Count > Const.MAX_BOUND || playerGrid[i + hitInformation.Count, j].Tag.Equals(Status.Used))
                        {
                            hitInformation.ResDirection = ResultDirection.Up;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i + hitInformation.Count, j].Tag.Equals(Status.Hit))
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i + hitInformation.Count, j].Tag.Equals(Status.Empty))
                        {
                            playerGrid[i + hitInformation.Count, j].Tag = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Up;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i + hitInformation.Count, j].Tag = Status.Hit;
                            if (j + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + hitInformation.Count, j + 1].Tag = Status.Used;//
                            }
                            if (j - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i + hitInformation.Count, j - 1].Tag = Status.Used;//
                            }
                            hitInformation.PlayerCount--;
                            hitInformation.ShipCount--;
                            hitInformation.Count++;
                            if (hitInformation.ShipCount == 1)
                            {
                                hitInformation.StatusShoot = ShootStatus.Miss;
                                return;
                            }
                        }
                    }
                    break;
                case ResultDirection.Left:
                    for (; hitInformation.Count < 4;)
                    {

                        if (j - hitInformation.Count < Const.MIN_BOUND || playerGrid[i, j - hitInformation.Count].Tag.Equals(Status.Used))
                        {
                            hitInformation.ResDirection = ResultDirection.Right;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i, j - hitInformation.Count].Tag.Equals(Status.Hit))
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i, j - hitInformation.Count].Tag.Equals(Status.Empty))
                        {
                            playerGrid[i, j - hitInformation.Count].Tag = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Right;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i, j - hitInformation.Count].Tag = Status.Hit;
                            if (i + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + 1, j - hitInformation.Count].Tag = Status.Used;//
                            }
                            if (i - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - 1, j - hitInformation.Count].Tag = Status.Used;//
                            }
                            hitInformation.PlayerCount--;
                            hitInformation.ShipCount--;
                            hitInformation.Count++;
                            if (hitInformation.ShipCount == 0)
                            {
                                hitInformation.StatusShoot = ShootStatus.Miss;
                                return;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
