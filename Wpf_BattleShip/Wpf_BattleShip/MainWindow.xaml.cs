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
        Game game;
        CreateGridEnemy gridEnemy;
        CreateGridPlayer gridPlayer;
        public MainWindow()
        {
            InitializeComponent();
            gridEnemy = new CreateGridEnemy(FieldEnemy.field);
            gridPlayer = new CreateGridPlayer(FieldPlayer.field);
            gridPlayer.isE += Deactivation;
            Buttons.dataEvent += DataTrancfer;
            game = new Game(gridPlayer.fieldsPlayer, gridEnemy.fieldsEnemy);
            Print.PrintGrid(gridPlayer.fieldsPlayer, 0);
            Print.PrintGrid(gridEnemy.fieldsEnemy, 1);

        }

        public void Deactivation(TypeShip typeShip)
        {
            switch (typeShip)
            {
                case TypeShip.FourDeck:
                    Buttons.FourH.IsEnabled = false;
                    Buttons.FourV.IsEnabled = false;
                    Buttons.FourDeckHoriz.Opacity = 0.2;
                    Buttons.FourDeckVert.Opacity = 0.2;
                    break;
                case TypeShip.ThreeDeck:
                    Buttons.ThreeH.IsEnabled = false;
                    Buttons.ThreeV.IsEnabled = false;
                    Buttons.ThreeDeckHoriz.Opacity = 0.2;
                    Buttons.ThreeDeckVert.Opacity = 0.2;
                    break;
                case TypeShip.DoubleDeck:
                    Buttons.DoubleH.IsEnabled = false;
                    Buttons.DoubleV.IsEnabled = false;
                    Buttons.DoubleDeckHoriz.Opacity = 0.2;
                    Buttons.DoubleDeckVert.Opacity = 0.2;
                    break;
                case TypeShip.SingleDeck:
                    Buttons.Single.IsEnabled = false;
                    Buttons.SingleDeck.Opacity = 0.2;
                    break;
                default:
                    break;
            }
        }
        public void DataTrancfer(TypeShip typeShip, Orientations orientations)
        {
            gridPlayer.data(typeShip, orientations);
        }

        public static void IsWin(int ComputerCount)
        {
            if (Game.computer._hitInformation.PlayerCount == 0)
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
            foreach (var item in gridEnemy.fieldsEnemy)
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
            Print.PrintGrid(gridPlayer.fieldsPlayer, 0);
            Print.PrintGrid(gridEnemy.fieldsEnemy, 1);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Buttons.FourDeckHoriz.ToString());
        }
    }
}
