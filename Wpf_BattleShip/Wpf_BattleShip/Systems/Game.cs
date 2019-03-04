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
        public Computer computer;
        Grid[,] fieldsPlayer;
        public Game(Grid[,] fieldsPlayer, Grid[,] fieldsEnemy, CreateGridEnemy gridEnemy)
        {
            this.fieldsPlayer = fieldsPlayer;
            computer = new Computer(fieldsEnemy);
            gridEnemy.Hitting += Hitting;
        }
        public void Hitting()
        {
            computer.Hit(fieldsPlayer);
            Print.PrintGrid(fieldsPlayer, 0);
        }

    }
}
