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
        HitInformation _hitInformation;
        Random rand;

        public Computer(Grid[,] fieldsEnemy)
        {
            Grid = fieldsEnemy;
            LastI = 0;
            LastJ = 0;
            GridComputer();
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
    }
}
