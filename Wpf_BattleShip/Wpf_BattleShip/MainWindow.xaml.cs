using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_BattleShip.Controls;
using Wpf_BattleShip.Enum;
using Wpf_BattleShip.Systems;

namespace Wpf_BattleShip
{

    public partial class MainWindow : Window
    {
        int ComputerCount;
        public Grid[,] fieldsEnemy;
        public Grid[,] fieldsPlayer;
        public int fourDeckCount = Const.FourDeck;
        public int threeDeckCount = Const.ThreeDeck;
        public int doubleDeckCount = Const.DoubleDeck;
        public int singleDeckCount = Const.SingleDeck;
        public int fourDeckHit = 0;
        public int threeDeckHit = 0;
        public int doubleDeckHit = 0;

        Game game;
        public MainWindow()
        {
            InitializeComponent();
            fieldsEnemy = FieldEnemy.field;
            fieldsPlayer = FieldPlayer.field;
            ComputerCount = Const.COMPUTER_START;
            Print.PrintGrid(FieldPlayer.field, FieldEnemy.field);
            game = new Game(FieldPlayer.field, FieldEnemy.field);
        }
        private void sk(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int c = Grid.GetColumn(element);
            if (c == 1)
            {
                foreach (var item in fieldsEnemy)
                {
                    item.MouseDown += ShootEnemyGrid;
                }
            }
            // MessageBox.Show(c.ToString());


        }
        public void ShootEnemyGrid(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            int j = Grid.GetColumn(square) - 1;
            int i = Grid.GetRow(square) - 1;
            if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer))
            {
                ComputerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                FindHit(fieldsEnemy);
                MessageBox.Show("Вы потопили однопалубный корабль!");
                Print.PrintGrid(fieldsPlayer, fieldsEnemy);
                IsWin();
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer2))
            {
                ComputerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                doubleDeckHit++;
                if (doubleDeckHit == 2)
                {
                    FindHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили двухпалубный корабль!");
                    doubleDeckHit = 0;
                }
                Print.PrintGrid(fieldsPlayer, fieldsEnemy);
                IsWin();
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer3))
            {
                ComputerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                threeDeckHit++;
                if (threeDeckHit == 3)
                {
                    FindHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили трёхпалубный корабль!");
                    threeDeckHit = 0;
                }
                Print.PrintGrid(fieldsPlayer, fieldsEnemy);
                IsWin();
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.OccupiedComputer4))
            {
                ComputerCount--;
                fieldsEnemy[i, j].Tag = Status.Hit;
                fourDeckHit++;
                if (fourDeckHit == 4)
                {
                    FindHit(fieldsEnemy);
                    MessageBox.Show("Вы потопили четырёхпалубный корабль!");
                    fourDeckHit = 0;
                }
                Print.PrintGrid(fieldsPlayer, fieldsEnemy);
                IsWin();
                return;
            }
            else if (fieldsEnemy[i, j].Tag.Equals(Status.Empty))
            {
                fieldsEnemy[i, j].Tag = Status.Used;
                game.computer.Hit(fieldsPlayer);
                Print.PrintGrid(fieldsPlayer, fieldsEnemy);
                IsWin();
                return;
            }
        }

        public void FindHit(Grid[,] fieldsEnemy)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (fieldsEnemy[i, j].Tag.Equals(Status.Hit))
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
        }
        public void IsWin()
        {
            if (game.computer._hitInformation.PlayerCount == 0)
            {
                MessageBox.Show("Компьютер выиграл!");
                // Stack.IsEnabled = false;
            }
            if (ComputerCount == 0)
            {
                MessageBox.Show("Вы выиграли!");
                // Stack.IsEnabled = false;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in FieldEnemy.field)
            {
                if (item.Tag.Equals(Status.Empty))
                {
                    item.Background = Brushes.Gray;
                }
                else if (item.Tag.Equals(Status.OccupiedComputer))
                    item.Background = Brushes.Black;
                else if (item.Tag.Equals(Status.OccupiedComputer2))
                    item.Background = Brushes.Yellow;
                else if (item.Tag.Equals(Status.OccupiedComputer3))
                    item.Background = Brushes.Green;
                else if (item.Tag.Equals(Status.OccupiedComputer4))
                    item.Background = Brushes.DarkBlue;
                else
                    item.Background = Brushes.Red;
            }
        }


    }
}
