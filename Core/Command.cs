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
            Game.time++;

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

        public bool CastSpell(Player player, RLKey key)
        {
            int x = player.X;
            int y = player.Y;
            Tuple<int, int> d = null;

            switch (key)
            {
                case RLKey.S: { y++; d = new Tuple<int, int>(0,1); break; }
                case RLKey.W: { y--; d = new Tuple<int, int>(0,-1); break; }
                case RLKey.D: { x++; d = new Tuple<int, int>(1,0); break; }
                case RLKey.A: { x--; d = new Tuple<int, int>(-1,0); break; }
            }

            
            Fireball fireball = new Fireball(x, y, d);
            fireball.Draw();

            Game.spells.Add(fireball);

            return false;
        }
    }
}
