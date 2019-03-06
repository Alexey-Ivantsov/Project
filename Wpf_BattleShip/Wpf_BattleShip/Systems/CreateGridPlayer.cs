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
    public class CreateGridPlayer : UserControl
    {

        TypeShip typeShip;
        Orientations orientations;
        int _fourDeckCount = Const.FourDeck;
        int _threeDeckCount = Const.ThreeDeck;
        int _doubleDeckCount = Const.DoubleDeck;
        int _singleDeckCount = Const.SingleDeck;
        bool singleDeckbool;
        bool doubleDeckbool;
        bool threeDeckbool;
        bool fourDeckbool;
        public Grid[,] fieldsPlayer;
        public delegate void IsEnables(TypeShip typeShip);
        public event IsEnables DisableButtonEvent;
        public delegate void StartEnabled();
        public event StartEnabled StartEvent;
        public CreateGridPlayer(Grid[,] field)
        {
            fieldsPlayer = field;
            foreach (var item in fieldsPlayer)
            {
                item.Tag = Status.Empty;
                item.MouseDown += PlayerGridPlacement;
                item.MouseEnter += EnterGrid;
                item.MouseLeave += LeaveGrid;
            }
        }
        public void SendData(TypeShip typeShip, Orientations orientations)
        {
            this.typeShip = typeShip;
            this.orientations = orientations;
        }
        public void EnterGrid(object sender, MouseEventArgs e)
        {
            Grid square = (Grid)sender;
            int j = Grid.GetColumn(square) - 1;
            int i = Grid.GetRow(square) - 1;
            if (!Check.CheckPlacement(i, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal || orientations == Orientations.None)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i, j + k].Background = Brushes.Cornsilk;
                }
            }
            else if (!Check.CheckPlacement(i, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i + k, j].Background = Brushes.Cornsilk;
                }
            }
            else if (!Check.CheckPlacement(i - ((int)typeShip - 1), j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i - k, j].Background = Brushes.Cornsilk;
                }
            }
            else if (!Check.CheckPlacement(i, j - ((int)typeShip - 1), typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i, j - k].Background = Brushes.Cornsilk;
                }
            }
        }
        public void LeaveGrid(object sender, MouseEventArgs e)
        {
            Grid square = (Grid)sender;
            int j = Grid.GetColumn(square) - 1;
            int i = Grid.GetRow(square) - 1;
            if (!Check.CheckPlacement(i, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal || orientations == Orientations.None)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i, j + k].Background = Brushes.DeepSkyBlue;
                }
            }
            else if (!Check.CheckPlacement(i, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i + k, j].Background = Brushes.DeepSkyBlue;
                }
            }
            else if (!Check.CheckPlacement(i - ((int)typeShip - 1), j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i - k, j].Background = Brushes.DeepSkyBlue;
                }
            }
            else if (!Check.CheckPlacement(i, j - ((int)typeShip - 1), typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
            {
                for (int k = 0; k < (int)typeShip; k++)
                {
                    fieldsPlayer[i, j - k].Background = Brushes.DeepSkyBlue;
                }
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
                switch (typeShip)
                {

                    case TypeShip.DoubleDeck:
                        if (!Check.CheckPlacement(i - 1, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {
                            Fill.FillShip(i - 1, j, typeShip, orientations, fieldsPlayer, 0);
                            _doubleDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 1, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {
                            Fill.FillShip(i, j - 1, typeShip, orientations, fieldsPlayer, 0);
                            _doubleDeckCount--;
                        }
                        if (_doubleDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.DoubleDeck);
                            typeShip = 0;
                            doubleDeckbool = true;
                        }
                        break;
                    case TypeShip.ThreeDeck:
                        if (!Check.CheckPlacement(i - 2, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {
                            Fill.FillShip(i - 2, j, typeShip, orientations, fieldsPlayer, 0);
                            _threeDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 2, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {
                            Fill.FillShip(i, j - 2, typeShip, orientations, fieldsPlayer, 0);
                            _threeDeckCount--;
                        }
                        if (_threeDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.ThreeDeck);
                            typeShip = 0;
                            threeDeckbool = true;
                        }
                        break;
                    case TypeShip.FourDeck:
                        if (!Check.CheckPlacement(i - 3, j, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Vertical)
                        {
                            Fill.FillShip(i - 3, j, typeShip, orientations, fieldsPlayer, 0);
                            _fourDeckCount--;
                        }
                        if (!Check.CheckPlacement(i, j - 3, typeShip, orientations, fieldsPlayer) && orientations == Orientations.Horizontal)
                        {
                            Fill.FillShip(i, j - 3, typeShip, orientations, fieldsPlayer, 0);
                            _fourDeckCount--;
                        }
                        if (_fourDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.FourDeck);
                            typeShip = 0;
                            fourDeckbool = true;
                        }
                        break;

                    default:
                        break;
                }
                //MessageBox.Show("Неверное расположение");
            }
            else
            {
                Fill.FillShip(i, j, typeShip, orientations, fieldsPlayer, 0);
                switch (typeShip)
                {
                    case TypeShip.SingleDeck:
                        _singleDeckCount--;
                        if (_singleDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.SingleDeck);
                            typeShip = 0;
                            singleDeckbool = true;
                        }
                        break;
                    case TypeShip.DoubleDeck:
                        _doubleDeckCount--;
                        if (_doubleDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.DoubleDeck);
                            typeShip = 0;
                            doubleDeckbool = true;
                        }
                        break;
                    case TypeShip.ThreeDeck:
                        _threeDeckCount--;
                        if (_threeDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.ThreeDeck);
                            typeShip = 0;
                            threeDeckbool = true;
                        }
                        break;
                    case TypeShip.FourDeck:
                        _fourDeckCount--;
                        if (_fourDeckCount == 0)
                        {
                            DisableButtonEvent?.Invoke(TypeShip.FourDeck);
                            typeShip = 0;
                            fourDeckbool = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            Print.PrintGrid(fieldsPlayer, 0);
            if (singleDeckbool && doubleDeckbool && threeDeckbool && fourDeckbool)
            {
                StartEvent?.Invoke();
                MessageBox.Show("Жми старт!");
            }
        }

    }
}
