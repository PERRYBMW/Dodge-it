using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Control
{
    class LevelControl
    {

        public class Variables
        {
            public static int intLevelTicks = 20;
            public static int intTimerTicks = intLevelTicks;
            public static int intGameLevel = 0;

            public static bool boolForcespawn = false;

            public static int intLastWave = 0;
        }
        //Calculate
        public static void calculateLevel()
        {
            if(Variables.intTimerTicks == Variables.intLevelTicks)
            {
                GameWindow.tmrTick.Enabled = false;
                Variables.intGameLevel++;
                Variables.intTimerTicks = 0;
                getSpawnControlByLevel(Variables.intGameLevel);
            }
            if(Variables.boolForcespawn == true)
            {
                Variables.boolForcespawn = false;
                getSpawnControlByLevel(Variables.intGameLevel);
            }
        }

        //          UTILS           //
        //  Screen size : 1216, 704  

        //By Level
        public static void getSpawnControlByLevel(int level)
        {
            if (level == 1 && Entity.Enemy.Enemy.Variables.listEnemyLocations.Count == 0)
            {
                //Line 1
                Entity.Enemy.Enemy.createEnemy(0, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 0, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 0, 16, 16, 0, 3, true, Brushes.Red);
                //Line 2
                Entity.Enemy.Enemy.createEnemy(50, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(150, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(250, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(350, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(450, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(550, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(650, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(750, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(850, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(950, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1050, 75, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1150, 75, 16, 16, 0, 3, true, Brushes.Red);
                //Line 3
                Entity.Enemy.Enemy.createEnemy(0, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 150, 16, 16, 0, 3, true, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 150, 16, 16, 0, 3, true, Brushes.Red);
                //Bouncers
                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 2, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, 2, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, -2, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 687, 16, 16, -2, -2, false, Brushes.Red);

                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 3, 3, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, 3, -3, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, -3, 3, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 687, 16, 16, -3, -3, false, Brushes.Red);

                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 1, 1, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, 1, -1, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, -1, 1, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 687, 16, 16, -1, -1, false, Brushes.Red);

                Entity.Enemy.Enemy.createEnemy(1, 500, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 500, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 204, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 204, 16, 16, -2, 0, false, Brushes.Red);

                Entity.Enemy.Enemy.createEnemy(600, 1, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 687, 16, 16, 0, 2, false, Brushes.Red);
                GameWindow.tmrTick.Enabled = true;
            }
            else if (level == 2 && Entity.Enemy.Enemy.Variables.listEnemyLocations.Count == 0)
            {
                //Line 1 - top
                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 1, 16, 16, 0, 2, false, Brushes.Red);
                //Line 2 - down
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 687, 16, 16, 0, -2, false, Brushes.Red);
                //Line 3 - Left
                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 100, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 200, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 300, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 400, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 500, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 600, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 700, 16, 16, 2, 0, false, Brushes.Red);
                //Line 4 - right
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 100, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 200, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 300, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 400, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 500, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 600, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 700, 16, 16, -2, 0, false, Brushes.Red);
                GameWindow.tmrTick.Enabled = true;
            }
            else if (level == 3 && Entity.Enemy.Enemy.Variables.listEnemyLocations.Count == 0)
            {
                Entity.Enemy.Enemy.createEnemy(1, 1, 128, 128, -4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1087, 1, 128, 128, 4, -4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 575, 128, 128, -4, -4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1087, 575, 128, 128, -4, -4, false, Brushes.Red);
                GameWindow.tmrTick.Enabled = true;
            }
            else if (level == 4 && Entity.Enemy.Enemy.Variables.listEnemyLocations.Count == 0)
            {
                //Line 1
                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(50, 50, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 100, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(150, 150, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 200, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(250, 250, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 300, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(350, 350, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 400, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(450, 450, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 500, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(550, 550, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 600, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(650, 650, 16, 16, 4, 4, false, Brushes.Red);

                //Line 2 by 1
                Entity.Enemy.Enemy.createEnemy(1, 51, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(50, 100, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 150, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(150, 200, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 250, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(250, 300, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 350, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(350, 400, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 450, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(450, 500, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 550, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(550, 600, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 650, 16, 16, 4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(650, 687, 16, 16, 4, 4, false, Brushes.Red);

                //Line 3
                Entity.Enemy.Enemy.createEnemy(0, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 1, 16, 16, 0, 2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 1, 16, 16, 0, 2, false, Brushes.Red);

                //Line 3
                Entity.Enemy.Enemy.createEnemy(1, 1, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 100, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 200, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 300, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 400, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 500, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 600, 16, 16, 2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 700, 16, 16, 2, 0, false, Brushes.Red);

                //Line 4
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 100, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 200, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 300, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 400, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 500, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 600, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 700, 16, 16, -2, 0, false, Brushes.Red);

                //Line 5
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 687, 16, 16, 0, -2, false, Brushes.Red);
                GameWindow.tmrTick.Enabled = true;
            }
            else if (level == 5 && Entity.Enemy.Enemy.Variables.listEnemyLocations.Count == 0)
            {
                //4 biggers
                Entity.Enemy.Enemy.createEnemy(1, 1, 128, 128, -4, 4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1087, 1, 128, 128, 4, -4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1, 575, 128, 128, -4, -4, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1087, 575, 128, 128, -4, -4, false, Brushes.Red);
                
                //Line 1
                Entity.Enemy.Enemy.createEnemy(1199, 1, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 100, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 200, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 300, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 400, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 500, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 600, 16, 16, -2, 0, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1199, 700, 16, 16, -2, 0, false, Brushes.Red);

                //Line 2
                Entity.Enemy.Enemy.createEnemy(1, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(200, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(300, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(400, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(500, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(600, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(700, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(800, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(900, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1000, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1100, 687, 16, 16, 0, -2, false, Brushes.Red);
                Entity.Enemy.Enemy.createEnemy(1200, 687, 16, 16, 0, -2, false, Brushes.Red);

                GameWindow.tmrTick.Enabled = true;
            }
            else
            {
                Variables.boolForcespawn = true;
            }
        }

    }
}
