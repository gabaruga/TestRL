using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RogueSharp;
using RLNET;
using RogueSharp.MapCreation;

namespace TestRL.Core
{
    class DungeonMap : Map, IMap
    {
        public void Draw( RLConsole mapConsole)
        {
            mapConsole.Clear();

            foreach (Cell cell in GetAllCells())
            {
                SetSymbolForCell(mapConsole, cell);
            }
        }

        private void SetSymbolForCell( RLConsole console, Cell cell)
        {
            if (!cell.IsExplored) return;

            if (IsInFov(cell.X, cell.Y))
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, RLColor.LightGray, RLColor.Black, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, RLColor.LightGray, RLColor.Black, '#');
                }
            }
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, RLColor.Gray, RLColor.Black, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, RLColor.Gray, RLColor.Black, '#');
                }
            }
        }       
    }
}
