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

        public MainWindow()
        {
            InitializeComponent();
            Print.PrintGrid(FieldPlayer.field, FieldEnemy.field);
            Game game = new Game(FieldPlayer.field, FieldEnemy.field);


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
