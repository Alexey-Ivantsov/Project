
using System;


namespace Battleship.System
{
    public class Game
    {
        Player player;
        Computer computer;
        public Game()
        {
            player = new Player();
            computer = new Computer();
        }
        delegate void Move();
        public void Start()
        {

            Move move;
            player.Placement();
            computer.Placement();
            Console.Clear();
            Print.PrintShip(computer.Grid);
            Console.WriteLine();
            Print.PrintShip(player.Grid);
            move = PlayerHit;
            move += ComputerHit;
            do
            {
                move();
                Console.Clear();
                Print.PrintShip(computer.Grid);
                Console.WriteLine();
                Print.PrintShip(player.Grid);
            } while (!player.IsWin() && !computer.IsWin());

            Print.PrintWinner(computer, player);
            Console.ReadKey();
        }
        private void PlayerHit()
        {
            player.Hit(computer.Grid);
        }
        private void ComputerHit()
        {
            computer.Hit(player.Grid);
        }
    }
}