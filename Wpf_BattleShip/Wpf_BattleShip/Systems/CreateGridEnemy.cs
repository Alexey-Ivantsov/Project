using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    public static class CreateGridEnemy
    {
        public static Grid[,] CreateEnemyGrid(Grid FieldsEnemy, MouseButtonEventHandler func)
        {
            Grid[,] fieldsEnemy = new Grid[10, 10];
            var bc = new BrushConverter();

            for (int i = 0; i < 11; i++)
            {
                FieldsEnemy.ColumnDefinitions.Add(new ColumnDefinition());
                FieldsEnemy.RowDefinitions.Add(new RowDefinition());
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
                FieldsEnemy.Children.Add(txt1);

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
                FieldsEnemy.Children.Add(txt2);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grid grid = new Grid();
                    grid.Name = "i" + i + j;
                    Grid.SetColumn(grid, 1 + j);
                    Grid.SetRow(grid, 1 + i);
                    grid.Tag = Status.Empty;
                    fieldsEnemy[i, j] = grid;
                    fieldsEnemy[i, j].MouseDown += func;
                    FieldsEnemy.Children.Add(grid);
                }

            }

            return fieldsEnemy;
        }
    }
}
