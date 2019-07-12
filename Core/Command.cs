using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRL.Core
{
    class Command
    {
        private int x, y;

        public bool MovePlayer(Player player, DungeonMap dungeonMap, RLKey key)
        {
            x = player.X;
            y = player.Y;

            switch (key)
            {
                case RLKey.Up:
                    {
                        y -= 1;
                        break;
                    }
                case RLKey.Down:
                    {
                        y += 1;
                        break;
                    }
                case RLKey.Left:
                    {
                        x -= 1;
                        break;
                    }
                case RLKey.Right:
                    {
                        x += 1;
                        break;
                    }
                default: return false;
            }



            return dungeonMap.SetActorPosition(ref player, x, y);
        }
    }
}
