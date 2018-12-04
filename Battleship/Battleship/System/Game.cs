
using System;


namespace Battleship.System
{
    public class Game
    {
        public static void Start()
        {
            Player player = new Player();
            Computer computer = new Computer();
            player.Placement();
            computer.Placement();
            Console.Clear();
            Print.PrintShip(computer.Grid);
            Console.WriteLine();
            Print.PrintShip(player.Grid);
            do
            {
                player.Hit(computer.Grid);
                computer.Hit(player.Grid);
                Console.Clear();
                Print.PrintShip(computer.Grid);
                Console.WriteLine();
                Print.PrintShip(player.Grid);
            } while (!player.IsWin() && !computer.IsWin());

            Print.PrintWinner(computer, player);
            Console.ReadKey();
        }
    }
}