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

namespace Wpf_BattleShip.Controls
{
    public partial class FieldButtons : UserControl
    {
        TypeShip typeShip;
        Orientations orientations;
        public delegate void dataField(TypeShip typeShip, Orientations orientations);
        public event dataField DataEvent;
        public FieldButtons()
        {
            InitializeComponent();
        }
        public void FourVertShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Vertical;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void FourHoriztShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Horizontal;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void ThreeVertShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Vertical;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void ThreeHoriztShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Horizontal;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void DoubleVertShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Vertical;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void DoubleHoriztShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Horizontal;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void SingleShip(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.SingleDeck;
            orientations = Orientations.None;
            DataEvent?.Invoke(typeShip, orientations);
        }
        private void StartButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Игра Началась!Найди Корабли соперника.");
        }
    }
}
