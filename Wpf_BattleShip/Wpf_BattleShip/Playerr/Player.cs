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


    }
}
