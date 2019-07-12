using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestRL.Core;
using RLNET;

namespace TestRL
{
    class Game
    {
        #region Consoles dimensions
        private static RLRootConsole rootConsole;
        private static readonly int  rootWidth = 120;
        private static readonly int  rootHeigth = 70;

        private static RLConsole mapConsole;
        private static readonly int  mapWidth = 100;
        private static readonly int  mapHeigth = 48;

        private static RLConsole logConsole;
        private static readonly int  logWidth = 120;
        private static readonly int  logHeigth = 11;

        private static RLConsole inventoryConsole;
        private static readonly int  inventoryWidth = 120;
        private static readonly int  inventoryHeigth = 11;

        private static RLConsole statsConsole;
        private static readonly int  statsWidth = 20;
        private static readonly int  statsHeigth = mapHeigth;
        #endregion

        public static DungeonMap dungeonMap;

        static void Main(string[] args)
        {
            rootConsole = new RLRootConsole("cheepicus12x12.png", rootWidth, rootHeigth, 12, 12, 1f, "TestRL");

            rootConsole.Update += OnRootConsoleUpdate;
            rootConsole.Render += OnRootConsoleRender;

            mapConsole = new RLConsole(mapWidth, mapHeigth);
            inventoryConsole = new RLConsole(inventoryWidth, inventoryHeigth);
            logConsole = new RLConsole(logWidth, logHeigth);
            statsConsole = new RLConsole(statsWidth, statsHeigth);

            MapGenerator mapGenerator = new MapGenerator(mapWidth, mapHeigth);
            dungeonMap = mapGenerator.CreateCave();

            rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            mapConsole.SetBackColor(0, 0, mapWidth, mapHeigth, RLColor.Black);
            //mapConsole.Print(1, 1, "Map", RLColor.White);

            logConsole.SetBackColor(0, 0, logWidth, logHeigth, RLColor.Gray);
            logConsole.Print(1, 1, "Log", RLColor.White);

            inventoryConsole.SetBackColor(0, 0, inventoryWidth, inventoryHeigth, RLColor.Brown);
            inventoryConsole.Print(1, 1, "Inventory", RLColor.White);

            statsConsole.SetBackColor(0, 0, statsWidth, statsHeigth, RLColor.Cyan);
            statsConsole.Print(1, 1, "Stats", RLColor.White);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            RLConsole.Blit(inventoryConsole, 0, 0, inventoryWidth, inventoryHeigth, rootConsole, 0, 0);
            RLConsole.Blit(mapConsole, 0, 0, mapWidth, mapHeigth, rootConsole, 0, inventoryHeigth);
            RLConsole.Blit(logConsole, 0, 0, logWidth, logWidth, rootConsole, 0, inventoryHeigth + mapHeigth);
            RLConsole.Blit(statsConsole, 0, 0, statsWidth, statsHeigth, rootConsole, mapWidth, inventoryHeigth);
            
            dungeonMap.Draw(mapConsole);
            rootConsole.Draw();

        }
    }
}
