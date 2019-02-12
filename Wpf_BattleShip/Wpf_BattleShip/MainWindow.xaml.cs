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

namespace Wpf_BattleShip
{

    public partial class MainWindow : Window
    {

        public Grid[,] fieldsEnemy;
        public Grid[,] fieldsPlayer;
        public MainWindow()
        {
            InitializeComponent();

            fieldsEnemy = new Grid[,]{
                                { A1, A2, A3, A4, A5, A6, A7, A8, A9, A10 },
                                { B1, B2, B3, B4, B5, B6, B7,B8,B9,B10},
                                { C1, C2, C3, C4, C5, C6, C7,C8,C9,C10},
                                { D1, D2, D3, D4, D5, D6, D7,D8,D9,D10},
                                { E1, E2, E3, E4, E5, E6, E7,E8,E9,E10},
                                { F1, F2, F3, F4, F5, F6, F7,F8,F9,F10},
                                { G1, G2, G3, G4, G5, G6, G7,G8,G9,G10},
                                { H1, H2, H3, H4, H5, H6, H7,H8,H9,H10},
                                { I1, I2, I3, I4, I5, I6, I7,I8,I9,I10},
                                { J1, J2, J3, J4, J5, J6, J7,J8,J9,J10 }
            };
            fieldsPlayer = new Grid[,]{
                                { PA1, PA2, PA3, PA4, PA5, PA6, PA7, PA8, PA9, PA10},
                                { PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8, PB9, PB10},
                                { PC1, PC2, PC3, PC4, PC5, PC6, PC7, PC8, PC9, PC10},
                                { PD1, PD2, PD3, PD4, PD5, PD6, PD7, PD8, PD9, PD10},
                                { PE1, PE2, PE3, PE4, PE5, PE6, PE7, PE8, PE9, PE10},
                                { PF1, PF2, PF3, PF4, PF5, PF6, PF7, PF8, PF9, PF10},
                                { PG1, PG2, PG3, PG4, PG5, PG6, PG7, PG8, PG9, PG10},
                                { PH1, PH2, PH3, PH4, PH5, PH6, PH7, PH8, PH9, PH10},
                                { PI1, PI2, PI3, PI4, PI5, PI6, PI7, PI8, PI9, PI10},
                                { PJ1, PJ2, PJ3, PJ4, PJ5, PJ6, PJ7, PJ8, PJ9, PJ10}
            };

            Game game = new Game(fieldsEnemy, fieldsPlayer);
        }


        private void gridMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            if ((Status)square.Tag == Status.Empty)
            {
                square.Background = Brushes.DeepSkyBlue;
            }
            else if ((Status)square.Tag == Status.OccupiedComputer)
                square.Background = Brushes.OrangeRed;
            // else
            //  square.Background = Brushes.Red;

        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(fieldsEnemy[9, 9].Tag.Equals(Status.OccupiedComputer).ToString());
            foreach (var item in fieldsEnemy)
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
        private void button_Click_2(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(fieldsEnemy[9, 9].Tag.Equals(Status.OccupiedComputer).ToString());
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
    }
}
