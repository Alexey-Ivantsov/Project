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
using Wpf_BattleShip.Enum;
using Wpf_BattleShip.Systems;

namespace Wpf_BattleShip
{

    public partial class MainWindow : Window
    {
        int ComputerCount;
        public Grid[,] fieldsEnemy;
        public Grid[,] fieldsPlayer;
        TypeShip typeShip = 0;
        Orientations orientations;
        public int fourDeckCount = Const.FourDeck;
        public int threeDeckCount = Const.ThreeDeck;
        public int doubleDeckCount = Const.DoubleDeck;
        public int singleDeckCount = Const.SingleDeck;
        public int fourDeckHit = 0;
        public int threeDeckHit = 0;
        public int doubleDeckHit = 0;
        bool singleDeckbool;
        bool doubleDeckbool;
        bool threeDeckbool;
        bool fourDeckbool;


        Game game;
        public MainWindow()
        {

            InitializeComponent();

            fieldsEnemy = new Grid[,]{
                                { A1, B1, C1, D1, E1, F1, G1, H1, I1, J1 },
                                { A2, B2, C2, D2, E2, F2, G2, H2, I2, J2},
                                { A3, B3, C3, D3, E3, F3, G3, H3, I3, J3},
                                { A4, B4, C4, D4, E4, F4, G4, H4, I4, J4},
                                { A5, B5, C5, D5, E5, F5, G5, H5, I5, J5},
                                { A6, B6, C6, D6, E6, F6, G6, H6, I6, J6},
                                { A7, B7, C7, D7, E7, F7, G7, H7, I7, J7},
                                { A8, B8, C8, D8, E8, F8, G8, H8, I8, J8},
                                { A9, B9, C9, D9, E9, F9, G9, H9, I9, J9},
                                { A10, B10, C10, D10, E10, F10, G10, H10, I10, J10 }
            };
            fieldsPlayer = new Grid[,]{
                                    {PA1,PB1,PC1,PD1,PE1,PF1,PG1,PH1,PI1,PJ1},
                                    {PA2,PB2,PC2,PD2,PE2,PF2,PG2,PH2,PI2,PJ2},
                                    {PA3,PB3,PC3,PD3,PE3,PF3,PG3,PH3,PI3,PJ3},
                                    {PA4,PB4,PC4,PD4,PE4,PF4,PG4,PH4,PI4,PJ4},
                                    {PA5,PB5,PC5,PD5,PE5,PF5,PG5,PH5,PI5,PJ5},
                                    {PA6,PB6,PC6,PD6,PE6,PF6,PG6,PH6,PI6,PJ6},
                                    {PA7,PB7,PC7,PD7,PE7,PF7,PG7,PH7,PI7,PJ7},
                                    {PA8,PB8,PC8,PD8,PE8,PF8,PG8,PH8,PI8,PJ8},
                                    {PA9,PB9,PC9,PD9,PE9,PF9,PG9,PH9,PI9,PJ9},
                                    {PA10,PB10,PC10,PD10,PE10,PF10,PG10,PH10,PI10,PJ10}
            };

            game = new Game(fieldsEnemy, fieldsPlayer);

            ComputerCount = Const.COMPUTER_START;
            //FieldsEnemy.IsEnabled = false;
            Start.IsEnabled = false;

        }


        /*private void Place_Ship(object sender, RoutedEventArgs e)
        {
            Grid square = (Grid)sender;

            int i = -1;
            int j = -1;

             string pattern = "^[a b c d e f g h i j]|[A B C D E F G H I J]";
             Regex regex = new Regex(pattern);
             if (!Int32.TryParse(BlockX.Text, out i) || i > 10)
             {
                 BlockX.Clear();
                 i = -1;
                 MessageBox.Show($"Невереный ввод, введите цифру от 1 до 10.");
             }
             else
             {
                 i = i - 1;
             }
             if (!Regex.IsMatch(BlockY.Text, pattern))
             {
                 BlockY.Clear();
                 MessageBox.Show($"Невереный ввод, введите верно букву от A до J.");
             }
             else
             {
                 int cha = (int)BlockY.Text[0];
                 if (cha <= 74)
                 {
                     j = cha - 65;
                 }
                 else
                     j = cha - 97;
             }

             if (i < 10 && j < 10 && i >= 0 && j >= 0)
             {
                 Fill.FillShip(i, j, TypeShip.FourDeck, Orientations.Horizontal, fieldsPlayer, 0);
                 foreach (var item in fieldsPlayer)
                 {
                     if (item.Tag.Equals(Status.Empty))
                     {
                         item.Background = Brushes.DeepSkyBlue;
                     }
                     else if (item.Tag.Equals(Status.OccupiedComputer))
                         item.Background = Brushes.Black;
                     else
                         item.Background = Brushes.Red;
                 }

             }
        }*/

        private void FourVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Vertical;
        }
        private void FourHoriztShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Horizontal;
        }

        private void ThreeVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Vertical;


        }
        private void ThreeHoriztShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Horizontal;
        }

        private void DoubleVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Vertical;
        }
        private void DoubleHoriztShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Horizontal;
        }

        private void SingleShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.SingleDeck;
            orientations = Orientations.None;
        }


        public void PlayerGridPlacement(object sender, MouseButtonEventArgs e)
        {


            Grid square = (Grid)sender;
            int j = Grid.GetColumn(square) - 1;
            int i = Grid.GetRow(square) - 1;
            if (typeShip == 0)
            {
                MessageBox.Show("Выберите тип корабля");
            }
            if (Check.CheckPlacement(i, j, typeShip, orientations, fieldsPlayer))
            {
                int flag = Convert.ToInt32(typeShip);

                switch (flag)
                {

                    case 2:
                        if (!Check.CheckPlacement(i - 1, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {

                            Fill.FillShip(i - 1, j, typeShip, orientations, fieldsPlayer, 0);
                            doubleDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 1, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {

                            Fill.FillShip(i, j - 1, typeShip, orientations, fieldsPlayer, 0);
                            doubleDeckCount--;
                        }
                        if (doubleDeckCount == 0)
                        {
                            DoubleH.IsEnabled = false;
                            DoubleV.IsEnabled = false;
                            typeShip = 0;
                            doubleDeckbool = true;
                        }
                        break;
                    case 3:
                        if (!Check.CheckPlacement(i - 2, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {

                            Fill.FillShip(i - 2, j, typeShip, orientations, fieldsPlayer, 0);
                            threeDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 2, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {

                            Fill.FillShip(i, j - 2, typeShip, orientations, fieldsPlayer, 0);
                            threeDeckCount--;
                        }
                        if (threeDeckCount == 0)
                        {
                            ThreeH.IsEnabled = false;
                            ThreeV.IsEnabled = false;
                            typeShip = 0;
                            threeDeckbool = true;
                        }
                        break;
                    case 4:
                        if (!Check.CheckPlacement(i - 3, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {

                            Fill.FillShip(i - 3, j, typeShip, orientations, fieldsPlayer, 0);
                            fourDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 3, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {

                            Fill.FillShip(i, j - 3, typeShip, orientations, fieldsPlayer, 0);
                            fourDeckCount--;
                        }
                        if (fourDeckCount == 0)
                        {
                            FourH.IsEnabled = false;
                            FourV.IsEnabled = false;
                            typeShip = 0;
                            fourDeckbool = true;
                        }
                        break;

                    default:
                        break;
                }
                // MessageBox.Show("Неверное расположение");
            }
            else
            {
                Fill.FillShip(i, j, typeShip, orientations, fieldsPlayer, 0);
                int size = Convert.ToInt32(typeShip);
                switch (size)
                {
                    case 1:
                        singleDeckCount--;
                        if (singleDeckCount == 0)
                        {
                            Single.IsEnabled = false;
                            typeShip = 0;
                            singleDeckbool = true;
                        }
                        break;
                    case 2:
                        doubleDeckCount--;
                        if (doubleDeckCount == 0)
                        {
                            DoubleH.IsEnabled = false;
                            DoubleV.IsEnabled = false;
                            typeShip = 0;
                            doubleDeckbool = true;
                        }
                        break;
                    case 3:
                        threeDeckCount--;
                        if (threeDeckCount == 0)
                        {
                            ThreeH.IsEnabled = false;
                            ThreeV.IsEnabled = false;
                            typeShip = 0;
                            threeDeckbool = true;
                        }
                        break;
                    case 4:
                        fourDeckCount--;
                        if (fourDeckCount == 0)
                        {
                            FourH.IsEnabled = false;
                            FourV.IsEnabled = false;
                            typeShip = 0;
                            fourDeckbool = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            Print.PrintGrid(fieldsPlayer, fieldsEnemy);
            if (singleDeckbool && doubleDeckbool && threeDeckbool && fourDeckbool)
            {
                Start.IsEnabled = true;
                MessageBox.Show("Жми старт!");
            }
        }
        private void StartButton(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Игра Началась!");
            FieldPlayer.IsEnabled = false;
            Start.IsEnabled = false;
            FieldsEnemy.IsEnabled = true;
        }
        private void ShootEnemyGrid(object sender, MouseButtonEventArgs e)
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
                Stack.IsEnabled = false;
            }
            if (ComputerCount == 0)
            {
                MessageBox.Show("Вы выиграли!");
                Stack.IsEnabled = false;
            }
        }

        private void ShowEnemyGrid(object sender, RoutedEventArgs e)
        {
            foreach (var item in fieldsEnemy)
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
