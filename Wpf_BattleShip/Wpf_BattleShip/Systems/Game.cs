using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_BattleShip.Computter;
using Wpf_BattleShip.Playerr;

namespace Wpf_BattleShip.Systems
{
    public class Game
    {
        Computer computer;
        Player player;
        public Game(Grid[,] fieldsEnemy, Grid[,] fieldsPlayer)
        {
            computer = new Computer(fieldsEnemy);
            player = new Player(fieldsPlayer);
            computer.Placement();

        }

    }
}
