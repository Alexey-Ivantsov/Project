using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_BattleShip.Systems
{
    static class CreateGrid
    {
        public static void CreatePlayerGrid(Grid FieldPlayer)
        {
            var bc = new BrushConverter();
            /////////////////////////////////
            for (int i = 0; i < 11; i++)
            {
                FieldPlayer.ColumnDefinitions.Add(new ColumnDefinition());
                FieldPlayer.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 10; i++)
            {
                TextBlock txt1 = new TextBlock();
                txt1.FontFamily = new FontFamily("Times new roman");
                txt1.TextAlignment = TextAlignment.Center;
                Char first = 'A';
                Char newf = Convert.ToChar(first + i);
                txt1.Text = Convert.ToString(newf);
                txt1.FontSize = 32;
                txt1.FontWeight = FontWeights.SemiBold;
                txt1.Background = (Brush)bc.ConvertFrom("#191970");
                txt1.Foreground = (Brush)bc.ConvertFrom("#FFF5EE");
                Grid.SetColumn(txt1, i + 1);
                Grid.SetRow(txt1, 0);
                FieldPlayer.Children.Add(txt1);

                TextBlock txt2 = new TextBlock();
                txt2.FontFamily = new FontFamily("Times new roman");
                txt2.TextAlignment = TextAlignment.Center;
                txt2.Text = Convert.ToString(1 + i);
                txt2.FontSize = 32;
                txt2.FontWeight = FontWeights.SemiBold;
                txt2.Background = (Brush)bc.ConvertFrom("#191970");
                txt2.Foreground = (Brush)bc.ConvertFrom("#FFF5EE");
                Grid.SetColumn(txt2, 0);
                Grid.SetRow(txt2, 1 + i);
                FieldPlayer.Children.Add(txt2);
            }

        }
    }
}
