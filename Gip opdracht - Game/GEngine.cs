using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Configuration;

namespace Gip_opdracht___Game
{
    class GEngine
    {
        //Variables
        public class Variables
        {
            public static int intGameState = 0;
        }

        //Members
        private Graphics drawHandle;
        private Thread renderThread;       

        //Functions
        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        //Init
        public void init()
        {
            //Start the render thread
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }     

        //Stop rendering
        public void stop()
        {
            //Save settings
            Control.GameControl.saveGame();
            //Stop / abort
            renderThread.Abort();
        }

        //Calculate
        public void recalculateGame()
        {
            //Hud
            Hud.Hud.updateStrings();
            //Level
            Control.LevelControl.calculateLevel();
            //Entity
            Entity.Enemy.Enemy.recalculateEnemyLocations();
            Entity.Player.Player.recalculatePlayerLocation();
            //Effects
            Effects.Explosion.recalculateExplosionLocations();
            Effects.Tail.calculateTail();
            //Player
            Control.Collision.calculatePlayerCollision();
            //Game
            Control.GameControl.calculateResetGame();
        }

        //Render
        private void render()
        {
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);

            //Load
            Menu.StartScreen.loadMenu();

            while (true)
            {
                //Background
                frameGraphics.FillRectangle(Brushes.Black, 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
                //Menu
                if(Variables.intGameState == 0)
                {
                    
                    //Enemy
                    for (int count = 0; count <= Entity.Enemy.Enemy.Variables.listEnemyLocations.Count - 1; count++)
                    {
                        frameGraphics.FillRectangle(Entity.Enemy.Enemy.Variables.listEnemyColor[count], Entity.Enemy.Enemy.Variables.listEnemyLocations[count].X, Entity.Enemy.Enemy.Variables.listEnemyLocations[count].Y, Entity.Enemy.Enemy.Variables.listEnemySize[count].Width, Entity.Enemy.Enemy.Variables.listEnemySize[count].Height);
                    }
                    //Buttons
                    for (int count = 0; count <= Menu.StartScreen.Variables.listPointButtonLocations.Count - 1; count++)
                    {
                        //Draw button panel
                        frameGraphics.FillRectangle(new SolidBrush(Menu.StartScreen.Variables.colorMenu), Menu.StartScreen.Variables.listPointButtonLocations[count].X, Menu.StartScreen.Variables.listPointButtonLocations[count].Y, Menu.StartScreen.Variables.listSizeButtonSize[count].Width, Menu.StartScreen.Variables.listSizeButtonSize[count].Height);
                        //Draw the string
                        frameGraphics.DrawString(Menu.StartScreen.Variables.listStringButtonString[count], Menu.StartScreen.Variables.fontMenu, new SolidBrush(Menu.StartScreen.Variables.listColorButtonColor[count]), Menu.StartScreen.Variables.listPointButtonLocations[count].X + Menu.StartScreen.Variables.listSizeStringButtonOffset[count].Width, Menu.StartScreen.Variables.listPointButtonLocations[count].Y + Menu.StartScreen.Variables.listSizeStringButtonOffset[count].Height);
                    }
                    //Draw highscores
                    frameGraphics.DrawString(("Normal highscore: " + Properties.Settings.Default.HighScoreNormal), Menu.StartScreen.Variables.fontMenuSmall, new SolidBrush(Menu.StartScreen.Variables.listColorButtonColor[0]), 0, 0);
                    frameGraphics.DrawString(("Random highscore: " + Properties.Settings.Default.HighScoreRandom), Menu.StartScreen.Variables.fontMenuSmall, new SolidBrush(Menu.StartScreen.Variables.listColorButtonColor[0]), 0, 22);
                    //Draw player preview
                    frameGraphics.DrawString("Your player", Menu.StartScreen.Variables.fontMenuSmall, new SolidBrush(Menu.StartScreen.Variables.listColorButtonColor[0]), 1018, 620);
                    frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)), 1050, 650, Entity.Player.Player.Variables.sizePlayerSize.Width, Entity.Player.Player.Variables.sizePlayerSize.Height);
                    //Draw logo
                    frameGraphics.DrawImage(Properties.Resources.Dodge_it, new Point(415, 10));
                    //Calculate menu
                    Menu.StartScreen.calculateMenu();
                    Menu.StartScreen.calculateMenuEffects();
                }
                //Game
                if (Variables.intGameState == 1 || Variables.intGameState == 2)
                {
                    //Effects
                    //Tail
                    for (int count = 0; count <= Effects.Tail.Variables.listTailLocations.Count - 1; count++)
                    {
                        frameGraphics.FillRectangle(new SolidBrush(Effects.Tail.Variables.listTailColor[count]), Effects.Tail.Variables.listTailLocations[count].X, Effects.Tail.Variables.listTailLocations[count].Y, Effects.Tail.Variables.listTailSize[count].Width, Effects.Tail.Variables.listTailSize[count].Height);
                    }

                    //Enemy
                    for (int count = 0; count <= Entity.Enemy.Enemy.Variables.listEnemyLocations.Count - 1; count++)
                    {
                        frameGraphics.FillRectangle(Entity.Enemy.Enemy.Variables.listEnemyColor[count], Entity.Enemy.Enemy.Variables.listEnemyLocations[count].X, Entity.Enemy.Enemy.Variables.listEnemyLocations[count].Y, Entity.Enemy.Enemy.Variables.listEnemySize[count].Width, Entity.Enemy.Enemy.Variables.listEnemySize[count].Height);
                    }

                    //Player
                    if (Entity.Player.Player.Variables.boolPlayerIsDead == false)
                    {
                        frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(Properties.Settings.Default.playerColor.R, Properties.Settings.Default.playerColor.G, Properties.Settings.Default.playerColor.B)), Entity.Player.Player.Variables.pointPlayerLocation.X, Entity.Player.Player.Variables.pointPlayerLocation.Y, Entity.Player.Player.Variables.sizePlayerSize.Width, Entity.Player.Player.Variables.sizePlayerSize.Height);
                    }

                    //Effects              
                    //Explosion
                    for (int count = 0; count <= Effects.Explosion.Variables.listExplosionLocations.Count - 1; count++)
                    {
                        frameGraphics.FillRectangle(Effects.Explosion.Variables.listExplosionColor[count], Effects.Explosion.Variables.listExplosionLocations[count].X, Effects.Explosion.Variables.listExplosionLocations[count].Y, Effects.Explosion.Variables.listExplosionSize[count].Width, Effects.Explosion.Variables.listExplosionSize[count].Height);
                    }

                    //HUD
                    //Level
                    frameGraphics.DrawString(Hud.Hud.Variables.stringLevel, Hud.Hud.Variables.fontHud, Hud.Hud.Variables.solidBrushHud, Hud.Hud.Variables.pointLevel);
                    //Status / ingame info
                    frameGraphics.DrawString(Hud.Hud.Variables.stringStatus, Hud.Hud.Variables.fontHud, Hud.Hud.Variables.solidBrushHud, Hud.Hud.Variables.pointStatus);

                    //Do not change
                    //Calculate
                }
                recalculateGame();

                //Draw to panel

                drawHandle.DrawImage(frame, 0, 0);             

                //Benchmarking
                framesRendered++;
                if((Environment.TickCount) >= startTime + 1000 && Properties.Settings.Default.cmdInfo == true)
                {
                    Console.Clear();                
                    Console.WriteLine("GEngine: " + framesRendered + " fps");
                    Console.WriteLine("");
                    Console.WriteLine("Enemies count: " + Entity.Enemy.Enemy.Variables.listEnemyLocations.Count);
                    Console.WriteLine("Explosion count: " + Effects.Explosion.Variables.listExplosionLocations.Count);
                    Console.WriteLine("Tail count: " + Effects.Tail.Variables.listTailLocations.Count);
                    Console.WriteLine("");
                    Console.WriteLine("Level: " + Convert.ToString(Control.LevelControl.Variables.intGameLevel));
                    Console.WriteLine("Time left: " + Convert.ToString(Control.LevelControl.Variables.intLevelTicks - Control.LevelControl.Variables.intTimerTicks) + " / " + Convert.ToString(Control.LevelControl.Variables.intLevelTicks));
                    Console.WriteLine("");
                    Console.WriteLine("Clicked at: " + GameWindow.Variables.mouseClick);
                    Console.WriteLine("");
                    Console.WriteLine("Timer enabled: " + GameWindow.tmrTick.Enabled);
                    Console.WriteLine("");
                    Console.WriteLine("Player color: " + Properties.Settings.Default.playerColor);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }

    }
}
