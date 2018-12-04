
using Battleship.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using static Battleship.System.Const;
using static Computer;

namespace Battleship.System
{
    public class Check
    {
        public static bool CheckPlacement(int i, int j, TypeShip ship, Orientation direction, Status[,] grid)
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
                case Orientation.Vertical:
                    for (int column = -1; column < size + 1; column++)
                    {
                        for (int Line = -1; Line < 2; Line++)
                        {
                            if (i + column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }
                            else if (i > grid.GetLength(0) - size || grid[i + column, j + Line] == Status.Occupied || grid[i + column, j + Line] == Status.OccupiedComputer
                                || grid[i + column, j + Line] == Status.Occupied2
                                || grid[i + column, j + Line] == Status.Occupied3
                                || grid[i + column, j + Line] == Status.Occupied4
                                )
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case Orientation.Horizontal:
                    for (int Column = -1; Column < 2; Column++)
                    {
                        for (int Line = -1; Line < size + 1; Line++)
                        {

                            if (i + Column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + Column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }

                            else if (j > grid.GetLength(0) - size || grid[i + Column, j + Line] == Status.Occupied || grid[i + Column, j + Line] == Status.OccupiedComputer
                                || grid[i + Column, j + Line] == Status.Occupied + 1
                                || grid[i + Column, j + Line] == Status.Occupied + 2
                                || grid[i + Column, j + Line] == Status.Occupied + 3
                                )
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case Orientation.None:
                    for (int Column = -1; Column < 2; Column++)
                    {
                        for (int Line = -1; Line < 2; Line++)
                        {
                            if (i + Column > Const.MAX_BOUND || j + Line > Const.MAX_BOUND || i + Column < Const.MIN_BOUND || j + Line < Const.MIN_BOUND)
                            {
                                continue;
                            }
                            else if (grid[i + Column, j + Line] == Status.Occupied || grid[i + Column, j + Line] == Status.OccupiedComputer
                                                                || grid[i + Column, j + Line] == Status.Occupied + 1
                                || grid[i + Column, j + Line] == Status.Occupied + 2
                                || grid[i + Column, j + Line] == Status.Occupied + 3
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
        public static (int, int) GetValues(Status[,] playerGrid)
        {
            if (playerGrid.GetLength(0) > 10 || playerGrid.GetLength(1) > 10)
            {
                return (-1, -1);
            }
            (int, int) result;
            int i;
            int j;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Введите колонку и ряд начального сектора от 1 до 10.\n");
                Console.WriteLine($"Введите Ряд:");
                if (!Int32.TryParse(Console.ReadLine(), out i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Невереный ввод,введите цифру от 1 до 10.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                i--;
                Console.WriteLine($"Введите столбец:");
                if (!Int32.TryParse(Console.ReadLine(), out j))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Невереный ввод,введите цифру от 1 до 10.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                j--;
                result = (i, j);
                if (i < Const.MIN_BOUND || j < Const.MIN_BOUND || i > Const.MAX_BOUND || j > Const.MAX_BOUND)
                {
                    Console.Clear();
                    Print.PrintShip(playerGrid);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Невереный ввод,начни сначала.");
                }

            } while (i < Const.MIN_BOUND || j < Const.MIN_BOUND || i > Const.MAX_BOUND || j > Const.MAX_BOUND);
            return result;
        }

        public static Orientation GetDirection(Status[,] playerGrid)
        {
            Orientation direction;
            int directionInt;
            do
            {
                Console.Clear();
                Print.PrintShip(playerGrid);

                Console.WriteLine($" \n Выберите направление расположения корабля  \n  \n \n ■ --- Для вертикального нажмите 1 \n ■ \n ■ \n ■ \n \n ■ ■ ■ ■ --- Для горизантально нажмите 2");
                if (!Int32.TryParse(Console.ReadLine(), out directionInt))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Невереный ввод,выберите направление 1 или 2.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            } while (directionInt < 1 || directionInt > 2);
            direction = (Orientation)directionInt;
            return direction;
        }
        public static bool FindDirection(int i, int j, Status[,] playerGrid, HitInformation hitInformation)
        {
            if (i < 0 || j < 0 || i > 9 || j > 9)
            {
                return true;
            }
            switch (hitInformation.DirectionCheck)
            {
                case DirectionCheck.Up:

                    if (i - 1 < Const.MIN_BOUND || playerGrid[i - 1, j] == Status.Used)
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i - 1, j] == Status.Empty)
                    {
                        playerGrid[i - 1, j] = Status.Used;
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }
                    else
                    {
                        playerGrid[i - 1, j] = Status.Hit;
                        if (j + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i - 1, j + 1] = Status.Used;//
                        }
                        if (j - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i - 1, j - 1] = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Up;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Right:

                    if (j + 1 > Const.MAX_BOUND || playerGrid[i, j + 1] == Status.Used)
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i, j + 1] == Status.Empty)
                    {
                        playerGrid[i, j + 1] = Status.Used;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        hitInformation.DirectionCheck++;
                        break;
                    }
                    else
                    {
                        playerGrid[i, j + 1] = Status.Hit;
                        if (i + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i + 1, j + 1] = Status.Used;//
                        }
                        if (i - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i - 1, j + 1] = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Right;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Down:

                    if (i + 1 > Const.MAX_BOUND || playerGrid[i + 1, j] == Status.Used)
                    {
                        hitInformation.DirectionCheck++;
                        hitInformation.StatusShoot = ShootStatus.Hit;
                        break;
                    }
                    else if (playerGrid[i + 1, j] == Status.Empty)
                    {
                        playerGrid[i + 1, j] = Status.Used;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        hitInformation.DirectionCheck++;
                        break;
                    }
                    else
                    {
                        playerGrid[i + 1, j] = Status.Hit;
                        if (j + 1 < Const.MAX_BOUND)
                        {
                            playerGrid[i + 1, j + 1] = Status.Used;//
                        }
                        if (j - 1 > Const.MIN_BOUND)
                        {
                            playerGrid[i + 1, j - 1] = Status.Used;//
                        }
                        hitInformation.PlayerCount--;
                        hitInformation.ShipCount--;
                        hitInformation.ResDirection = ResultDirection.Down;
                        hitInformation.DirectionCheck = DirectionCheck.Up;
                        hitInformation.StatusShoot = ShootStatus.Miss;
                        break;
                    }

                case DirectionCheck.Left:

                    playerGrid[i, j - 1] = Status.Hit;
                    if (i + 1 < Const.MAX_BOUND)
                    {
                        playerGrid[i + 1, j - 1] = Status.Used;//
                    }
                    if (i - 1 > Const.MIN_BOUND)
                    {
                        playerGrid[i - 1, j - 1] = Status.Used;//
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

        public static void HitDirection(int i, int j, Status[,] playerGrid, HitInformation hitInformation)
        {

            switch (hitInformation.ResDirection)
            {
                case ResultDirection.Up:
                    for (; hitInformation.Count < 4;)
                    {

                        if (i - hitInformation.Count < Const.MIN_BOUND || playerGrid[i - hitInformation.Count, j] == Status.Used)
                        {
                            hitInformation.ResDirection = ResultDirection.Down;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i - hitInformation.Count, j] == Status.Hit)
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i - hitInformation.Count, j] == Status.Empty)
                        {
                            playerGrid[i - hitInformation.Count, j] = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Down;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i - hitInformation.Count, j] = Status.Hit;
                            if (j + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i - hitInformation.Count, j + 1] = Status.Used;//
                            }
                            if (j - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - hitInformation.Count, j - 1] = Status.Used;//
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

                        if (j + hitInformation.Count > Const.MAX_BOUND || playerGrid[i, j + hitInformation.Count] == Status.Used)
                        {
                            hitInformation.ResDirection = ResultDirection.Left;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i, j + hitInformation.Count] == Status.Hit)
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i, j + hitInformation.Count] == Status.Empty)
                        {
                            playerGrid[i, j + hitInformation.Count] = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Left;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i, j + hitInformation.Count] = Status.Hit;
                            if (i + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + 1, j + hitInformation.Count] = Status.Used;//
                            }
                            if (i - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - 1, j + hitInformation.Count] = Status.Used;//
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
                        if (i + hitInformation.Count > Const.MAX_BOUND || playerGrid[i + hitInformation.Count, j] == Status.Used)
                        {
                            hitInformation.ResDirection = ResultDirection.Up;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i + hitInformation.Count, j] == Status.Hit)
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i + hitInformation.Count, j] == Status.Empty)
                        {
                            playerGrid[i + hitInformation.Count, j] = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Up;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i + hitInformation.Count, j] = Status.Hit;
                            if (j + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + hitInformation.Count, j + 1] = Status.Used;//
                            }
                            if (j - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i + hitInformation.Count, j - 1] = Status.Used;//
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

                        if (j - hitInformation.Count < Const.MIN_BOUND || playerGrid[i, j - hitInformation.Count] == Status.Used)
                        {
                            hitInformation.ResDirection = ResultDirection.Right;
                            hitInformation.Count = 1;
                            return;
                        }
                        else if (playerGrid[i, j - hitInformation.Count] == Status.Hit)
                        {
                            hitInformation.Count++;
                        }
                        else if (playerGrid[i, j - hitInformation.Count] == Status.Empty)
                        {
                            playerGrid[i, j - hitInformation.Count] = Status.Used;
                            hitInformation.ResDirection = ResultDirection.Right;
                            hitInformation.Count = 1;
                            hitInformation.StatusShoot = ShootStatus.Miss;
                            return;
                        }
                        else
                        {
                            playerGrid[i, j - hitInformation.Count] = Status.Hit;
                            if (i + 1 < Const.MAX_BOUND)
                            {
                                playerGrid[i + 1, j - hitInformation.Count] = Status.Used;//
                            }
                            if (i - 1 > Const.MIN_BOUND)
                            {
                                playerGrid[i - 1, j - hitInformation.Count] = Status.Used;//
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
