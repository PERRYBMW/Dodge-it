using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Hud
{
    class Hud
    {

        public class Variables
        {
            public static Font fontHud = new Font("Impact", 16);
            public static SolidBrush solidBrushHud= new SolidBrush(Color.White);

            public static Point pointLevel = new Point(0, 0);
            public static string stringLevel = "Wave: 0";
            
            public static Point pointStatus = new Point(475, 0);
            public static string stringStatus = "Wave time left: 0";          
        }
        
        public static void updateStrings()
        {
            Variables.stringLevel = "Wave: " + Control.LevelControl.Variables.intGameLevel;

            //Status
            if (Control.LevelControl.Variables.intTimerTicks >= Control.LevelControl.Variables.intLevelTicks - 3 || Control.LevelControl.Variables.boolForcespawn == true)
            {
                Variables.pointStatus = new Point(520, 0);
                Variables.stringStatus = "Wave is clearing";
                Entity.Enemy.Enemy.makeAllEnemiesVoidable();
            }
            else
            {
                Variables.pointStatus = new Point(560, 0);
                Variables.stringStatus = "Time left: " + Convert.ToString(Control.LevelControl.Variables.intLevelTicks - Control.LevelControl.Variables.intTimerTicks);
            }
            if(Control.LevelControl.Variables.intTimerTicks < 3 && Control.LevelControl.Variables.intGameLevel == 1)
            {
                Variables.pointStatus = new Point(530, 0);
                Variables.stringStatus = "Move with " + Menu.StartScreen.Variables.stringKeyInput;
            }
            if (Entity.Player.Player.Variables.boolPlayerIsDead == true)
            {
                Variables.pointStatus = new Point(390, 0);
                Variables.stringStatus = "You died, press R to start again or Backspace to give up";
            }
            
        }
        
    }
}
