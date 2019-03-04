using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpf_BattleShip.Controls;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    public class CreateGridEnemy : UserControl
    {
        public delegate void ComputeHit();
        public event ComputeHit Hitting;
        int _computerCount;
        public Grid[,] fieldsEnemy;
        int _fourDeckHit = 0;
        int _threeDeckHit = 0;
        int _doubleDeckHit = 0;
        public CreateGridEnemy(Grid[,] field)
        {
            _computerCount = Const.COMPUTER_START;
            fieldsEnemy = field;
            foreach (var item in fieldsEnemy)
            {
                item.Tag = Status.Empty;
                item.Background = Brushes.Gray;
                item.MouseDown += ShootEnemyGrid;
            }
        }
        public void ShootEnemyGrid(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            int j = Grid.GetColumn(square) - 1;
            int i = Grid.GetRow(square) - 1;
            if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer))
            {
                _computerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                FindStatusHit(fieldsEnemy);
                MessageBox.Show("Вы потопили однопалубный корабль!");
                if (Check.IsWin(_computerCount))
                {
                    MessageBox.Show("Вы выиграли!");
                }
                Print.PrintGrid(fieldsEnemy, 1);
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer2))
            {
                _computerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                _doubleDeckHit++;
                if (_doubleDeckHit == 2)
                {
                    FindStatusHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили двухпалубный корабль!");
                    _doubleDeckHit = 0;
                }
                if (Check.IsWin(_computerCount))
                {
                    MessageBox.Show("Вы выиграли!");
                }
                Print.PrintGrid(fieldsEnemy, 1);
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer3))
            {
                _computerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                _threeDeckHit++;
                if (_threeDeckHit == 3)
                {
                    FindStatusHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили трёхпалубный корабль!");
                    _threeDeckHit = 0;
                }

                if (Check.IsWin(_computerCount))
                {
                    MessageBox.Show("Вы выиграли!");
                }
                Print.PrintGrid(fieldsEnemy, 1);
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer4))
            {
                _computerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                _fourDeckHit++;
                if (_fourDeckHit == 4)
                {
                    FindStatusHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили четырёхпалубный корабль!");
                    _fourDeckHit = 0;
                }

                if (Check.IsWin(_computerCount))
                {
                    MessageBox.Show("Вы выиграли!");
                }
                Print.PrintGrid(fieldsEnemy, 1);
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.Empty))
            {
                fieldsEnemy[i, j].Tag = Status.Used;
                if (Check.IsWin(_computerCount))
                {
                    MessageBox.Show("Вы выиграли!");
                }
                Print.PrintGrid(fieldsEnemy, 1);
                if (Hitting != null)
                {
                    Hitting();
                }
                return;
            }
            Print.PrintGrid(fieldsEnemy, 1);
        }
        public void FindStatusHit(Grid[,] fieldsEnemy)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (fieldsEnemy[i, j].Tag.Equals(Status.Hit))
                    {
                        EmptyZone(i, j);
                    }
                }
            }
        }
        public void EmptyZone(int i, int j)
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
                        if (!fieldsEnemy[i + k, j + l].Tag.Equals(Status.Hit) && !fieldsEnemy[i + k, j + l].Tag.Equals(Status.Occupied) && !fieldsEnemy[i + k, j + l].Tag.Equals(Status.Occupied2) && !fieldsEnemy[i + k, j + l].Tag.Equals(Status.Occupied3) && !fieldsEnemy[i + k, j + l].Tag.Equals(Status.Occupied4))
                        {
                            fieldsEnemy[i + k, j + l].Tag = Status.Used;
                        }
                        l++;
                    }
                }
                k++;
            }
        }
    }
}
