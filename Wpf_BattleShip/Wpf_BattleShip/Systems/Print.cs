using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    public static class Print
    {
        public static void PrintGrid(Grid[,] field, int i)
        {

            if (i == 0)
            {
                foreach (var item in field)
                {
                    if (item.Tag.Equals(Status.Empty))
                    {
                        item.Background = Brushes.DeepSkyBlue;
                    }
                    else if (item.Tag.Equals(Status.Occupied) || item.Tag.Equals(Status.Occupied2) || item.Tag.Equals(Status.Occupied3) || item.Tag.Equals(Status.Occupied4))
                        item.Background = Brushes.Black;
                    else if (item.Tag.Equals(Status.Used))
                        item.Background = Brushes.SlateGray;
                    else if (item.Tag.Equals(Status.Hit))
                        item.Background = Brushes.Red;
                }
            }
            else
            {
                foreach (var item in field)
                {

                    if (item.Tag.Equals(Status.Used))
                        item.Background = Brushes.DeepSkyBlue;
                    else if (item.Tag.Equals(Status.Hit))
                    { item.Background = Brushes.Red; }
                    else if (item.Tag.Equals(Status.Empty))
                    { item.Background = Brushes.Gray; }

                }
            }
        }
    }
}
