using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Gip_opdracht___Game.Control
{
    class Collision
    {
        //Collision
        public static void calculatePlayerCollision()
        {
            //For each enemy
            for (int count = 0; count <= Entity.Enemy.Enemy.Variables.listEnemyLocations.Count - 1; count++) { 
                if (Entity.Player.Player.Variables.pointPlayerLocation.X < Entity.Enemy.Enemy.Variables.listEnemyLocations[count].X + Entity.Enemy.Enemy.Variables.listEnemySize[count].Width && Entity.Player.Player.Variables.pointPlayerLocation.X + Entity.Player.Player.Variables.sizePlayerSize.Width > Entity.Enemy.Enemy.Variables.listEnemyLocations[count].X && Entity.Player.Player.Variables.pointPlayerLocation.Y < Entity.Enemy.Enemy.Variables.listEnemyLocations[count].Y + Entity.Enemy.Enemy.Variables.listEnemySize[count].Height && Entity.Player.Player.Variables.sizePlayerSize.Height + Entity.Player.Player.Variables.pointPlayerLocation.Y > Entity.Enemy.Enemy.Variables.listEnemyLocations[count].Y && (GEngine.Variables.intGameState == 1 || GEngine.Variables.intGameState == 2))
                {
                    collision();
                }
            }
        
        }
        //Collided

        public static void collision()
        {
            if (Entity.Player.Player.Variables.boolPlayerIsDead == Entity.Player.Player.Variables.boolGodMode)
            {
                Effects.Sound.playSoundExplosion();
                GameWindow.tmrTick.Enabled = false;
                Entity.Player.Player.Variables.boolPlayerIsDead = true;
                Entity.Player.Player.Variables.boolPlayerCanMove = false;
                //Explosion effect
                Effects.Explosion.addExplosion(Entity.Player.Player.Variables.pointPlayerLocation.X, Entity.Player.Player.Variables.pointPlayerLocation.Y, -2, -2, Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.sizePlayerSize.Height / 2, new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)));
                Effects.Explosion.addExplosion(Entity.Player.Player.Variables.pointPlayerLocation.X + Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.pointPlayerLocation.Y, 2, -2, Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.sizePlayerSize.Height / 2, new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)));
                Effects.Explosion.addExplosion(Entity.Player.Player.Variables.pointPlayerLocation.X + Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.pointPlayerLocation.Y + Entity.Player.Player.Variables.sizePlayerSize.Height / 2, 2, 2, Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.sizePlayerSize.Height / 2, new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)));
                Effects.Explosion.addExplosion(Entity.Player.Player.Variables.pointPlayerLocation.X, Entity.Player.Player.Variables.pointPlayerLocation.Y + Entity.Player.Player.Variables.sizePlayerSize.Height / 2, -2, 2, Entity.Player.Player.Variables.sizePlayerSize.Width / 2, Entity.Player.Player.Variables.sizePlayerSize.Height / 2, new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)));
                
                //Wave scores
                if(GEngine.Variables.intGameState == 1)
                {
                    ScoreControl.calculateHighScoreNormal(LevelControl.Variables.intGameLevel);
                }
                else if(GEngine.Variables.intGameState == 2)
                {
                    ScoreControl.calculateHighScoreRandom(LevelControl.Variables.intGameLevel);
                }
                Control.GameControl.saveGame();
            }

        }
    }
}
