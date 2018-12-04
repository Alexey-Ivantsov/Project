using Battleship.Enum;
using Battleship.System;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class CheckPlacement
    {
        [Fact]
        public void CheckPlacement_Success()
        {
            //Arange            
            Status[,] grid;
            grid = new Status[10, 10];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = Status.Empty;
                }
            }
            grid[2, 2] = Status.Occupied;
            int k = 2;
            int l = 2;
            TypeShip ship = TypeShip.SingleDeck;
            Orientation orientation = Orientation.None;

            //Act
            var result = Check.CheckPlacement(k, l, ship, orientation, grid);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CheckPlacement_Out_of_Range()
        {
            Status[,] grid;
            grid = new Status[10, 10];
            int k = 2;
            int l = -2;
            TypeShip ship = TypeShip.SingleDeck;
            Orientation orientation = Orientation.None;

            //Act
            var result = Check.CheckPlacement(k, l, ship, orientation, grid);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckPlacement_Grid_Length()
        {
            Status[,] grid;
            grid = new Status[10, 15];
            int k = 2;
            int l = 2;
            TypeShip ship = TypeShip.SingleDeck;
            Orientation orientation = Orientation.None;
            //Act
            var result = Check.CheckPlacement(k, l, ship, orientation, grid);
            //Assert
            Assert.False(result);
        }
    }
    public class CheckGetValues
    {
        [Fact]
        public void CheckGetValues_out_of_range_Player_Grid()
        {
            //Arange            
            Status[,] playerGrid;
            playerGrid = new Status[11, 10];
            for (int i = 0; i < playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < playerGrid.GetLength(1); j++)
                {
                    playerGrid[i, j] = Status.Empty;
                }
            }
            //Act
            var result = Check.GetValues(playerGrid);
            //Assert

            Assert.False(result.Item1 == -1 && result.Item2 == -1);
        }
    }
    public class CheckFindDirection
    {
        [Fact]
        public void FindDirection_value_out_of_grid()
        {
            //Arange            
            Status[,] playerGrid;
            playerGrid = new Status[10, 10];
            for (int i = 0; i < playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < playerGrid.GetLength(1); j++)
                {
                    playerGrid[i, j] = Status.Empty;
                }
            }
            int k = -2;
            int l = 3;
            HitInformation hitInformation = new HitInformation();
            //Act
            var result = Check.FindDirection(k, l, playerGrid, hitInformation);
            //Assert

            Assert.False(result);
        }
    }
}
