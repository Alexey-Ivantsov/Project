
using Battleship.System;
using System;
using System.Collections.Generic;
using System.Text;
using static Battleship.System.Const;

namespace Battleship.System
{
    public static class Print
    {
        public static void PrintShip(Status[,] grid)
        {
            Console.WriteLine($"   1 2 3 4 5 6 7 8 9 10");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (i < 9)
                {
                    Console.Write(i + 1 + "  ");
                }
                else
                    Console.Write(i + 1 + " ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == Status.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Occupied)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Direct)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.OccupiedComputer)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Used)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Occupied2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Occupied3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (grid[i, j] == Status.Occupied4)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine();
            }
        }
        public static bool PrintWinner(Computer computer, Player player)
        {
            if (computer == null || player == null)
            {
                return true;
            }
            Console.Clear();
            if (player.IsWin())
            {
                PrintShip(computer.Grid);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Конец игры.Поздравляем вы выиграли");
            }
            else
            {
                PrintShip(player.Grid);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Конец игры.Вы проиграли");

            }
            return false;
        }

    }
}
