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
using System.Windows.Shapes;
using Wpf_BattleShip.Enum;
using Wpf_BattleShip.Systems;

namespace Wpf_BattleShip
{
    /// <summary>
    /// Interaction logic for Placement.xaml
    /// </summary>
    public partial class Placement : UserControl
    {
        public Grid[,] fieldsPlayer;
        int size;
        public Placement()
        {

            InitializeComponent();
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
            for (int i = 0; i < fieldsPlayer.GetLength(0); i++)
            {
                for (int j = 0; j < fieldsPlayer.GetLength(1); j++)
                {

                    fieldsPlayer[i, j].Tag = Status.Empty;
                }
            }

        }

        private void inn(object sender, RoutedEventArgs e)
        {
            Sh.Opacity = 0.3;
            size = 4;

            Fill.FillShip(0, 0, Enum.TypeShip.FourDeck, Enum.Orientations.Horizontal, fieldsPlayer, 0);


        }
    }
}
