using Battleship.System;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class TestPrint
    {
        [Fact]
        public void Print_class_null()
        {
            Computer computer = new Computer();
            Player player = null;
            //Act
            var result = Print.PrintWinner(computer, player);
            //Assert
            Assert.False(result);
        }
    }
}
