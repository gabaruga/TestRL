using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRL.Core
{
    class Player
    {
        public string name = "Player";
        public int X = 10;
        public int Y = 10;
        public int fov_distance = 10;
        public readonly char symbol = '@';
        public RLColor color = RLColor.Green;

        public void Draw(RLConsole console, DungeonMap map)
        {
            console.Set(X, Y, color, RLColor.Black, symbol);
        }
    }
}
