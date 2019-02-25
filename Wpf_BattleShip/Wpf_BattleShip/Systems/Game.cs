using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpf_BattleShip.Computter;
using Wpf_BattleShip.Playerr;

namespace Wpf_BattleShip.Systems
{
    public class Game
    {

        public static Computer computer;
        public Player player;
        public Game(Grid[,] fieldsPlayer, Grid[,] fieldsEnemy)
        {
            computer = new Computer(fieldsEnemy);
            player = new Player(fieldsPlayer);
            computer.Placement();
            foreach (var item in fieldsEnemy)
            {
                item.Background = Brushes.Gray;
            }
            foreach (var item in fieldsPlayer)
            {
                item.Background = Brushes.DeepSkyBlue;
            }
        }

    }
}
