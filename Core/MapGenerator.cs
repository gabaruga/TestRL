using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRL.Core
{
    class MapGenerator
    {
        private readonly DungeonMap map;
        private readonly int width;
        private readonly int heigth;

        public MapGenerator (int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;
            map = new DungeonMap();
        }

        public DungeonMap CreateMap()
        {
            map.Initialize(width, heigth);

            foreach (Cell cell in map.GetAllCells())
            {
                map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            foreach (Cell cell in map.GetCellsInRows(0, heigth -1))
            {
                map.SetCellProperties(cell.X, cell.Y, true, false, true);
            }

            foreach (Cell cell in map.GetCellsInColumns(0, width - 1))
            {
                map.SetCellProperties(cell.X, cell.Y, true, false, true);
            }

            return map;
        }
    }
}
