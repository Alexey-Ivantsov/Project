using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_BattleShip.Enum;
using Wpf_BattleShip.Systems;

namespace Wpf_BattleShip.Playerr
{
    public class Player
    {
        public Grid[,] Grid { get; set; }
        public Player(Grid[,] fieldsPlayer)
        {
            Grid = fieldsPlayer;
            GridPlayer();
        }
        public void GridPlayer()
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
                    Place((TypeShip)i, Grid);
                }
            }
        }

        private void Place(TypeShip ship, Grid[,] playerGrid)
        {
            int size = Convert.ToInt32(ship);
            int i;
            int j;
            Orientations direction;
            /*do
            {
                Console.WriteLine($"Расположите  {size}-х палубник на поле.");
                var values = MainWindow.btnAttack_Click();
                i = values.Item1;
                j = values.Item2;

            } while (Check.CheckPlacement(i, j, ship, direction, playerGrid));*/
            //Fill.FillShip(i, j, ship, direction, playerGrid, 0);

        }
    }
}
