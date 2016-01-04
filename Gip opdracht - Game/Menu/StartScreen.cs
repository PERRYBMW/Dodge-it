using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gip_opdracht___Game.Menu
{
    class StartScreen
    {
        //Variables
        public class Variables
        {
            public static List<Point> listPointButtonLocations = new List<Point>();
            public static List<Size> listSizeButtonSize = new List<Size>();
            public static List<Size> listSizeStringButtonOffset = new List<Size>();
            public static List<Color> listColorButtonColor = new List<Color>();
            public static List<string> listStringButtonString = new List<string>();
            public static Font fontMenu = new Font("Arial", 25);
            public static Color colorMenu = Color.DarkBlue;

            public static string stringKeyInput = "azerty";
            public static int intCoolDownTime = 10;
            public static int intCoolDown = intCoolDownTime;
        }
        //Load menu
        public static void loadMenu()
        {
            addMenuButton(483, 150, 250, 75, Color.White, "Start", 80, 16);
            addMenuButton(483, 250, 250, 75, Color.White, "Play random", 32, 16);
            addMenuButton(483, 350, 250, 75, Color.White, Variables.stringKeyInput, 80, 16);
            addMenuButton(483, 450, 250, 75, Color.White, "Player color", 30, 16);
        }
        //Add button
        public static void addMenuButton(int x, int y, int width, int height, Color color, string stringButton, int offsetX, int offsetY)
        {
            Variables.listPointButtonLocations.Add(new Point(x, y));
            Variables.listSizeButtonSize.Add(new Size(width, height));
            Variables.listColorButtonColor.Add(color);
            Variables.listStringButtonString.Add(stringButton);
            Variables.listSizeStringButtonOffset.Add(new Size(offsetX, offsetY));
        }
        //Calculate
        public static void calculateMenu()
        {
            for (int count = 0; count <= Variables.listPointButtonLocations.Count - 1; count++)
            {
                if (GameWindow.Variables.mouseClick.X <= Variables.listPointButtonLocations[count].X + Variables.listSizeButtonSize[count].Width && GameWindow.Variables.mouseClick.X >= Variables.listPointButtonLocations[count].X && GameWindow.Variables.mouseClick.Y >= Variables.listPointButtonLocations[count].Y && GameWindow.Variables.mouseClick.Y <= Variables.listPointButtonLocations[count].Y + Variables.listSizeButtonSize[count].Height)
                {

                    if (count == 0)
                    {
                        Effects.Sound.playSoundSelect();
                        //Start
                        GEngine.Variables.intGameState = 1;
                        Control.GameControl.saveGame();
                    }
                    else if (count == 1)
                    {
                        Effects.Sound.playSoundSelect();
                        //Random
                        GEngine.Variables.intGameState = 2;
                    }
                    else if (count == 2 && Variables.intCoolDown == Variables.intCoolDownTime)
                    {
                        Effects.Sound.playSoundSelect();
                        Control.GameControl.saveGame();
                        //Keys
                        if (Variables.stringKeyInput == "qwerty")
                        {
                            Variables.stringKeyInput = "azerty";
                            Properties.Settings.Default.keyUp = 90;
                            Properties.Settings.Default.keyDown = 83;
                            Properties.Settings.Default.keyLeft = 81;
                            Properties.Settings.Default.keyRight = 68;
                        }
                        else if (Variables.stringKeyInput == "azerty")
                        {
                            Variables.stringKeyInput = "arrows";
                            Properties.Settings.Default.keyUp = 38;
                            Properties.Settings.Default.keyDown = 40;
                            Properties.Settings.Default.keyLeft = 37;
                            Properties.Settings.Default.keyRight = 39;
                        }
                        else if (Variables.stringKeyInput == "arrows")
                        {
                            Variables.stringKeyInput = "qwerty";
                            Properties.Settings.Default.keyUp = 87;
                            Properties.Settings.Default.keyDown = 83;
                            Properties.Settings.Default.keyLeft = 65;
                            Properties.Settings.Default.keyRight = 68;
                        }
                        Variables.listStringButtonString[2] = Variables.stringKeyInput;
                        Variables.intCoolDown = 0;
                        Control.GameControl.saveGame();
                    }

                    else if (count == 3)
                    {
                        Effects.Sound.playSoundSelect();
                        ColorDialog colorDialog = new ColorDialog();   
                        DialogResult dialog = colorDialog.ShowDialog();                                                                   
                        if (dialog == DialogResult.OK)
                        {
                            Properties.Settings.Default.playerColor = colorDialog.Color;
                            Effects.Sound.playSoundSelect();
                        }
                        else if(dialog == DialogResult.Cancel)
                        {
                            Effects.Sound.playSoundSelect();
                        }
                        Control.GameControl.saveGame();
                    }
                    else
                    {
                        if (Variables.intCoolDown < Variables.intCoolDownTime)
                        {
                            Variables.intCoolDown++;
                        }
                    }
                }
            }
        }
    }
}

