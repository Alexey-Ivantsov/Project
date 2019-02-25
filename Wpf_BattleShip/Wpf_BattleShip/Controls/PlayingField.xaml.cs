using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Wpf_BattleShip.Controls
{
    /// <summary>
    /// Interaction logic for PlayingField.xaml
    /// </summary>
    public partial class PlayingField : UserControl
    {
        int ComputerCount;

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
        public static Grid[,] fieldsPlayer;
        public static Grid[,] fieldsEnemy;

        public PlayingField()
        {
            InitializeComponent();
            ComputerCount = Const.COMPUTER_START;
            fieldsPlayer = CreateGridPlayer.CreatePlayerGrid(FieldPlayer, PlayerGridPlacement);
            fieldsEnemy = CreateGridEnemy.CreateEnemyGrid(FieldsEnemy, ShootEnemyGrid);
            Game game = new Game(fieldsPlayer, fieldsEnemy);

            FieldsEnemy.IsEnabled = false;
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
                            DoubleDeckHoriz.Opacity = 0.2;
                            DoubleDeckVert.Opacity = 0.2;
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
                            ThreeDeckHoriz.Opacity = 0.2;
                            ThreeDeckVert.Opacity = 0.2;
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
                            FourDeckHoriz.Opacity = 0.2;
                            FourDeckVert.Opacity = 0.2;
                            typeShip = 0;
                            fourDeckbool = true;
                        }
                        break;

                    default:
                        break;
                }
                MessageBox.Show("Неверное расположение");
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
                            SingleDeck.Opacity = 0.2;
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
                            DoubleDeckHoriz.Opacity = 0.2;
                            DoubleDeckVert.Opacity = 0.2;
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
                            ThreeDeckHoriz.Opacity = 0.2;
                            ThreeDeckVert.Opacity = 0.2;
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
                            FourDeckHoriz.Opacity = 0.2;
                            FourDeckVert.Opacity = 0.2;
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
            Print.PrintGrid(fieldsPlayer, fieldsEnemy);
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
                Game.computer.Hit(fieldsPlayer);
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
            if (Game.computer._hitInformation.PlayerCount == 0)
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
