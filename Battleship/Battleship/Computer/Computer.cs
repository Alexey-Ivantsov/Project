
using Battleship.Enum;
using Battleship.System;
using System;


public class Computer : IPlayer
{
    public Status[,] Grid { get; set; }    
    public int LastI { get; set; }
    public int LastJ { get; set; }
    HitInformation _hitInformation;
    public Computer()
    {
        LastI = 0;
        LastJ = 0;
        GridComputer();
        _hitInformation = new HitInformation();
    }
    public void GridComputer()
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
    public void Hit(Status[,] playerGrid)
    {
        if (_hitInformation.ShipCount == 0)
        {
            Search(playerGrid);
        }
        if (_hitInformation.ShipCount != 0 && _hitInformation.ResDirection == ResultDirection.None)
        {

            do
            {
                Check.FindDirection(LastI, LastJ, playerGrid, _hitInformation);
            } while (_hitInformation.StatusShoot == ShootStatus.Hit);
            _hitInformation.StatusShoot = ShootStatus.Hit;
            if (LastJ + 1 < Const.MAX_BOUND && (_hitInformation.ResDirection == ResultDirection.Up || _hitInformation.ResDirection == ResultDirection.Down))
            {
                playerGrid[LastI, LastJ + 1] = Status.Used;//
            }
            if (LastJ - 1 > Const.MIN_BOUND && (_hitInformation.ResDirection == ResultDirection.Up || _hitInformation.ResDirection == ResultDirection.Down))
            {
                playerGrid[LastI, LastJ - 1] = Status.Used;//
            }

            if (LastI + 1 < Const.MAX_BOUND && (_hitInformation.ResDirection == ResultDirection.Right || _hitInformation.ResDirection == ResultDirection.Left))
            {
                playerGrid[LastI + 1, LastJ] = Status.Used;//
            }
            if (LastI - 1 > Const.MIN_BOUND && (_hitInformation.ResDirection == ResultDirection.Right || _hitInformation.ResDirection == ResultDirection.Left))
            {
                playerGrid[LastI - 1, LastJ] = Status.Used;//
            }
        }
        if (_hitInformation.ResDirection > 0)
        {
            do
            {
                Check.HitDirection(LastI, LastJ, playerGrid, _hitInformation);
            } while (_hitInformation.StatusShoot == ShootStatus.Hit && _hitInformation.ShipCount != 0);
            if (_hitInformation.ShipCount == 0)
            {
                _hitInformation.Count = 1;
                _hitInformation.ResDirection = ResultDirection.None;
            }
        }
    }
    public void Placement()
    {
        for (int i = Const.AMOUNT_SHIPS; i > 0; i--)
        {
            for (int j = i - 1; j < Const.AMOUNT_SHIPS; j++)
            {
                Place((TypeShip)i);
            }
        }
    }
    private void Place(TypeShip ship)
    {

        Random rand = new Random();
        switch (ship)
        {
            case TypeShip.SingleDeck:
                int i;
                int j;
                do

                {
                    i = rand.Next(10);
                    j = rand.Next(10);
                } while (Check.CheckPlacement(i, j, TypeShip.SingleDeck, Orientation.None, Grid));
                Fill.FillShip(i, j, TypeShip.SingleDeck, Orientation.None, Grid, Role.Computer);

                break;
            case TypeShip.DoubleDeck:
                Orientation Direction = (Orientation)rand.Next(1, 3);
                do
                {
                    i = rand.Next(10);
                    j = rand.Next(10);
                } while (Check.CheckPlacement(i, j, TypeShip.DoubleDeck, Direction, Grid));
                Fill.FillShip(i, j, TypeShip.DoubleDeck, Direction, Grid, Role.Computer);
                break;
            case TypeShip.ThreeDeck:
                Direction = (Orientation)rand.Next(1, 3);
                do
                {
                    i = rand.Next(10);
                    j = rand.Next(10);
                } while (Check.CheckPlacement(i, j, TypeShip.ThreeDeck, Direction, Grid));
                Fill.FillShip(i, j, TypeShip.ThreeDeck, Direction, Grid, Role.Computer);
                break;
            case TypeShip.FourDeck:
                Direction = (Orientation)rand.Next(1, 3);
                do
                {
                    i = rand.Next(10);
                    j = rand.Next(10);
                } while (Check.CheckPlacement(i, j, TypeShip.FourDeck, Direction, Grid));
                Fill.FillShip(i, j, TypeShip.FourDeck, Direction, Grid, Role.Computer);
                break;
            default:
                break;
        }
    }
    public void Search(Status[,] playerGrid)
    {
        int i;
        int j;
        Random rand = new Random();
        do
        {
            i = rand.Next(10);
            j = rand.Next(10);

            if (playerGrid[i, j] == Status.Occupied || playerGrid[i, j] == Status.Occupied2 || playerGrid[i, j] == Status.Occupied3 || playerGrid[i, j] == Status.Occupied4)
            {
                _hitInformation.PlayerCount--;

                if (playerGrid[i, j] == Status.Occupied)
                {

                    for (int k = -1; k < 2;)
                    {
                        for (int l = -1; l < 2;)
                        {
                            if (i + k < Const.MIN_BOUND || i + k > Const.MAX_BOUND || j + l < Const.MIN_BOUND || j + l > Const.MAX_BOUND)
                            {
                                l++;
                            }
                            else
                            {
                                playerGrid[i + k, j + l] = Status.Used;
                                l++;
                            }

                        }
                        k++;
                    }
                    playerGrid[i, j] = Status.Hit;
                    _hitInformation.ShipCount = 0;
                }
                else if (playerGrid[i, j] == Status.Occupied2) { playerGrid[i, j] = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 1; break; }
                else if (playerGrid[i, j] == Status.Occupied3) { playerGrid[i, j] = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 2; break; }
                else if (playerGrid[i, j] == Status.Occupied4) { playerGrid[i, j] = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 3; break; }

            }
            else if (playerGrid[i, j] != Status.Hit) playerGrid[i, j] = Status.Used;
            Print.PrintShip(playerGrid);

        } while (playerGrid[i, j] == Status.Hit && _hitInformation.PlayerCount != 0 && playerGrid[i, j] == Status.Used);
    }
    public bool IsWin()
    {
        return _hitInformation.PlayerCount == 0;
    }
}

