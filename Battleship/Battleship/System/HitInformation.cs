using Battleship.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.System
{
    public class HitInformation
    {
        public int PlayerCount { get; set; }
        public ResultDirection ResDirection;
        public ShootStatus StatusShoot;
        public int ShipCount { get; set; }
        public int Count { get; set; }
        public DirectionCheck DirectionCheck;
        public HitInformation()
        {
            PlayerCount = Const.PLAYER_START;
            ShipCount = 0;
            ResDirection = ResultDirection.None;
            StatusShoot = ShootStatus.Hit;
            Count = 1;
            DirectionCheck = DirectionCheck.Up;
        }
    }
}
