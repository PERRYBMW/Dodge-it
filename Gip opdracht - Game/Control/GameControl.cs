using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gip_opdracht___Game.Control
{
    class GameControl
    {
        //Calculate reset
        public static void calculateResetGame()
        {
            if(Entity.Player.Player.Variables.boolPlayerIsDead == true && GameWindow.Variables.keyBoard[82] == true)
            {
                Effects.Sound.playSoundSelect();
                resetGame();
                //Play again
            }
            if (Entity.Player.Player.Variables.boolPlayerIsDead == true && GameWindow.Variables.keyBoard[8] == true)
            {
                Effects.Sound.playSoundSelect();
                resetGame();
                GEngine.Variables.intGameState = 0;
                //Go to menu
            }
        }       
        //Reset
        public static void resetGame()
        {
            //Player
            Entity.Player.Player.Variables.pointPlayerLocation = Entity.Player.Player.Variables.pointPlayerStartLocation;
            Entity.Player.Player.Variables.boolPlayerCanMove = true;
            Entity.Player.Player.Variables.boolPlayerIsDead = false;
            //Clear list
            Entity.Enemy.Enemy.deleteAllEnemies();
            Effects.Tail.removeAllTails();
            Effects.Explosion.deleteAllExplosions();
            //Reset level + score
            LevelControl.Variables.intGameLevel = 0;
            LevelControl.Variables.intTimerTicks = LevelControl.Variables.intLevelTicks;
        }
        //Save
        public static void saveGame()
        {
            //Save
            Properties.Settings.Default.Save();
        }
    }
}