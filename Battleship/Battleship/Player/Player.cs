
using Battleship.Enum;
using Battleship.System;
using System;
using System.Collections.Generic;
using System.Text;


public class Player : IPlayer
{   
    public int ComputerCount { get; set; }
    public Status[,] Grid { get; set; }
    public Player()
    {
        ComputerCount = Const.COMPUTER_START;
        GridPlayer();
    }

    public void GridPlayer()
    {
        Grid = new Status[10, 10];
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Grid[i, j] = Status.Empty;
            }
        }

    }

    public void Placement()
    {
        for (int i = Const.AMOUNT_SHIPS; i > 0; i--)
        {
            for (int j = i - 1; j < Const.AMOUNT_SHIPS; j++)
            {
                Place((TypeShip)i, Grid);
            }
        }
    }
    private void Place(TypeShip ship, Status[,] playerGrid)
    {
        int size = Convert.ToInt32(ship);
        int i;
        int j;
        Orientation direction;
        do
        {
            Console.Clear();
            Print.PrintShip(playerGrid);
            Console.WriteLine($"Расположите  {size}-х палубник на поле.");
            var values = Check.GetValues(playerGrid);
            i = values.Item1;
            j = values.Item2;
            if (size == 1)
            {
                direction = Orientation.None;
            }
            else direction = Check.GetDirection(playerGrid);
        } while (Check.CheckPlacement(i, j, ship, direction, playerGrid));
        Fill.FillShip(i, j, ship, direction, playerGrid, 0);

    }
    public void Hit(Status[,] computerGrid)
    {
        int i;
        int j;
        do
        {
            var values = Check.GetValues(computerGrid);
            i = values.Item1;
            j = values.Item2;
            if (computerGrid[i, j] == Status.OccupiedComputer)
            {
                ComputerCount--;
                computerGrid[i, j] = Status.Hit;
            }
            else if (computerGrid[i, j] == Status.Empty) computerGrid[i, j] = Status.Used;
        } while (computerGrid[i, j] == Status.Hit && ComputerCount != 0);

    }
    public bool IsWin()
    {
        return ComputerCount == 0;
    }
}

