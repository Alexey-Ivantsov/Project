using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.System
{
    interface IPlayer
    {
        Status[,] Grid { get; set; }
        void Hit(Status[,] grid);
        void Placement();
        bool IsWin();
        // bool FinishHit();
    }
}
