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
        public MainWindow()
        {
            InitializeComponent();
            fieldsEnemy = FieldEnemy.field;
            fieldsPlayer = FieldPlayer.field;

            Print.PrintGrid(FieldPlayer.field, FieldEnemy.field);
            Game game = new Game(FieldPlayer.field, FieldEnemy.field);
        }
        private void sk(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int c = Grid.GetColumn(element);
            if (c == 0)
            {

            }
            // MessageBox.Show(c.ToString());


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
