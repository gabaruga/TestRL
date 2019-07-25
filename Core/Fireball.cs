using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;

namespace TestRL.Core
{
    class Fireball
    {
        private int range = 4;
        private char symbol = '*';
        private RLColor color = RLColor.LightRed;

        private int x, y;
        private Tuple<int, int> d;

        private int last_update;

        public Fireball(int x, int y, Tuple<int, int>d)
        {
            this.x = x;
            this.y = y;

            this.d = d;

            this.last_update = Game.time;
        }

        public void Draw()
        {
            if (last_update < Game.time) {
                x += d.Item1;
                y += d.Item2;
                last_update = Game.time;

                if (range == 0)
                // dispose
                { }
                else
                    range--;
            }
                

            Game.mapConsole.Set(x, y, color, RLColor.Black, symbol);
        }
    }
}
