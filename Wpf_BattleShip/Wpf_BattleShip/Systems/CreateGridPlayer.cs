using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Wpf_BattleShip.Controls;
using Wpf_BattleShip.Enum;

namespace Wpf_BattleShip.Systems
{
    class CreateGridPlayer : FieldButtons
    {

        TypeShip typeShip;
        Orientations orientations = Orientations.Horizontal;
        public int fourDeckCount = Const.FourDeck;
        public int threeDeckCount = Const.ThreeDeck;
        public int doubleDeckCount = Const.DoubleDeck;
        public int singleDeckCount = Const.SingleDeck;
        bool singleDeckbool;
        bool doubleDeckbool;
        bool threeDeckbool;
        bool fourDeckbool;
        public Grid[,] fieldsPlayer;
        public CreateGridPlayer(Grid[,] field, TypeShip type)
        {
            fieldsPlayer = field;
            typeShip = type;
            foreach (var item in fieldsPlayer)
            {
                item.MouseDown += PlayerGridPlacement;
            }
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
            Print.PrintGrid(fieldsPlayer);
            if (singleDeckbool && doubleDeckbool && threeDeckbool && fourDeckbool)
            {
                Start.IsEnabled = true;
                MessageBox.Show("Жми старт!");
            }
        }

    }
}
