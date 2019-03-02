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
    /// <summary>
    /// Interaction logic for FieldButtons.xaml
    /// </summary>
    public partial class FieldButtons : UserControl
    {
        TypeShip typeShip;
        Orientations orientations;
        public delegate void dataField(TypeShip typeShip, Orientations orientations);
        public event dataField dataEvent;
        public FieldButtons()
        {
            InitializeComponent();
        }



        public void FourVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Vertical;
            dataEvent(typeShip, orientations);
        }
        private void FourHoriztShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.FourDeck;
            orientations = Orientations.Horizontal;
            dataEvent(typeShip, orientations);

        }

        private void ThreeVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Vertical;
            dataEvent(typeShip, orientations);
        }
        private void ThreeHoriztShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.ThreeDeck;
            orientations = Orientations.Horizontal;
            dataEvent(typeShip, orientations);
        }

        private void DoubleVertShip(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Vertical;
            dataEvent(typeShip, orientations);
        }
        private void DoubleHoriztShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.DoubleDeck;
            orientations = Orientations.Horizontal;
            dataEvent(typeShip, orientations);
        }

        private void SingleShip(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Укажите на поле игрока место расположения");
            typeShip = TypeShip.SingleDeck;
            orientations = Orientations.None;
            dataEvent(typeShip, orientations);
        }

        private void StartButton(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Игра Началась!");
            //FieldPlayer.IsEnabled = false;
            Start.IsEnabled = false;
            //FieldsEnemy.IsEnabled = true;
            //Print.PrintGrid(fieldsPlayer, fieldsEnemy);
        }
    }
}
