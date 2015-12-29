using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        //Load menu
        public static void loadMenu()
        {
            addMenuButton(483, 100, 250, 75, Color.White, "Start", 80, 16);
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
                    GEngine.Variables.intGameState = count + 1;
                }
            }
        }
    }
}
