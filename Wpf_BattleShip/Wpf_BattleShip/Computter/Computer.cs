using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf_BattleShip.Enum;
using Wpf_BattleShip.Systems;

namespace Wpf_BattleShip.Computter
{
    public class Computer
    {
        public Grid[,] Grid { get; set; }
        public int LastI { get; set; }
        public int LastJ { get; set; }
        public HitInformation _hitInformation;
        Random rand;

        public Computer(Grid[,] fieldsEnemy)
        {
            Grid = fieldsEnemy;
            LastI = 0;
            LastJ = 0;
            //GridComputer();
            _hitInformation = new HitInformation();
            rand = new Random();
        }
        public void GridComputer()
        {

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {

                    Grid[i, j].Tag = Status.Empty;
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
            switch (ship)
            {
                case TypeShip.SingleDeck:
                    int i;
                    int j;
                    do

                    {
                        i = rand.Next(10);
                        j = rand.Next(10);
                    } while (Check.CheckPlacement(i, j, TypeShip.SingleDeck, Orientations.None, Grid));

                    Fill.FillShip(i, j, TypeShip.SingleDeck, Orientations.None, Grid, Role.Computer);

                    break;
                case TypeShip.DoubleDeck:
                    Orientations Direction = (Orientations)rand.Next(1, 3);
                    do
                    {
                        i = rand.Next(10);
                        j = rand.Next(10);
                    } while (Check.CheckPlacement(i, j, TypeShip.DoubleDeck, Direction, Grid));
                    Fill.FillShip(i, j, TypeShip.DoubleDeck, Direction, Grid, Role.Computer);
                    break;
                case TypeShip.ThreeDeck:
                    Direction = (Orientations)rand.Next(1, 3);
                    do
                    {
                        i = rand.Next(10);
                        j = rand.Next(10);
                    } while (Check.CheckPlacement(i, j, TypeShip.ThreeDeck, Direction, Grid));
                    Fill.FillShip(i, j, TypeShip.ThreeDeck, Direction, Grid, Role.Computer);
                    break;
                case TypeShip.FourDeck:
                    Direction = (Orientations)rand.Next(1, 3);
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

        public void FindHit(Grid[,] playerGrid)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (playerGrid[i, j].Tag.Equals(Status.Hit))
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
                                    if (!playerGrid[i + k, j + l].Tag.Equals(Status.Hit) && !playerGrid[i + k, j + l].Tag.Equals(Status.Occupied) && !playerGrid[i + k, j + l].Tag.Equals(Status.Occupied2) && !playerGrid[i + k, j + l].Tag.Equals(Status.Occupied3) && !playerGrid[i + k, j + l].Tag.Equals(Status.Occupied4))
                                    {
                                        playerGrid[i + k, j + l].Tag = Status.Used;

                                    }
                                    l++;
                                }

                            }
                            k++;
                        }
                    }
                }
            }
        }
        public void Hit(Grid[,] playerGrid)
        {

            if (_hitInformation.ShipCount == 0)
            {
                FindHit(playerGrid);
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
                    playerGrid[LastI, LastJ + 1].Tag = Status.Used;//
                }
                if (LastJ - 1 > Const.MIN_BOUND && (_hitInformation.ResDirection == ResultDirection.Up || _hitInformation.ResDirection == ResultDirection.Down))
                {
                    playerGrid[LastI, LastJ - 1].Tag = Status.Used;//
                }

                if (LastI + 1 < Const.MAX_BOUND && (_hitInformation.ResDirection == ResultDirection.Right || _hitInformation.ResDirection == ResultDirection.Left))
                {
                    playerGrid[LastI + 1, LastJ].Tag = Status.Used;//
                }
                if (LastI - 1 > Const.MIN_BOUND && (_hitInformation.ResDirection == ResultDirection.Right || _hitInformation.ResDirection == ResultDirection.Left))
                {
                    playerGrid[LastI - 1, LastJ].Tag = Status.Used;//
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

        public void Search(Grid[,] playerGrid)
        {
            int i;
            int j;
            do
            {
                i = rand.Next(10);
                j = rand.Next(10);

                if (playerGrid[i, j].Tag.Equals(Status.Occupied) || playerGrid[i, j].Tag.Equals(Status.Occupied2) || playerGrid[i, j].Tag.Equals(Status.Occupied3) || playerGrid[i, j].Tag.Equals(Status.Occupied4))
                {
                    _hitInformation.PlayerCount--;

                    if (playerGrid[i, j].Tag.Equals(Status.Occupied))
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
                                    playerGrid[i + k, j + l].Tag = Status.Used;
                                    l++;
                                }

                            }
                            k++;
                        }
                        playerGrid[i, j].Tag = Status.Hit;
                        _hitInformation.ShipCount = 0;
                    }
                    else if (playerGrid[i, j].Tag.Equals(Status.Occupied2)) { playerGrid[i, j].Tag = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 1; break; }
                    else if (playerGrid[i, j].Tag.Equals(Status.Occupied3)) { playerGrid[i, j].Tag = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 2; break; }
                    else if (playerGrid[i, j].Tag.Equals(Status.Occupied4)) { playerGrid[i, j].Tag = Status.Hit; LastI = i; LastJ = j; _hitInformation.ShipCount = 3; break; }

                }
                else if (playerGrid[i, j].Tag.Equals(Status.Empty))
                { playerGrid[i, j].Tag = Status.Used; break; }
                if (_hitInformation.PlayerCount == 0)
                {
                    return;
                }


            } while (playerGrid[i, j].Tag.Equals(Status.Hit) || playerGrid[i, j].Tag.Equals(Status.Used));
        }

    }
}
