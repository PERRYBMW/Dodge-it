using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Entity.Player
{
    class Player
    {

        public class Variables
        {
            public static Point pointPlayerStartLocation = new Point(608, 344);
            public static Point pointPlayerLocation = pointPlayerStartLocation;
            public static Size sizePlayerSize = new Size(32, 32);
            public static bool boolPlayerCanMove = true;
            public static bool boolPlayerIsDead = false;
            public static bool boolGodMode = false;
        }

        public static int xVel = 0;
        public static int yVel = 0;
        public static int playerHorizontalMoveSpeed = 4;
        public static int playerVerticalMoveSpeed = 4;

        public static void recalculatePlayerLocation()
        {
            //Reset
            xVel = 0;
            yVel = 0;
            //If he can move
            if (Variables.boolPlayerCanMove == true)
            {
                //Up
                if (GameWindow.Variables.keyBoard[Properties.Settings.Default.keyUp] == true && Variables.pointPlayerLocation.Y - playerVerticalMoveSpeed >= 0)
                {
                    yVel = yVel - playerVerticalMoveSpeed;
                }
                //Down
                if (GameWindow.Variables.keyBoard[Properties.Settings.Default.keyDown] == true && Variables.pointPlayerLocation.Y + playerVerticalMoveSpeed <= Game.CANVAS_HEIGHT - Variables.sizePlayerSize.Height)
                {
                    yVel = yVel + playerVerticalMoveSpeed;
                }
                //Left
                if (GameWindow.Variables.keyBoard[Properties.Settings.Default.keyLeft] == true && Variables.pointPlayerLocation.X - playerHorizontalMoveSpeed >= 0)
                {
                    xVel = xVel - playerHorizontalMoveSpeed;
                }
                //Right
                if (GameWindow.Variables.keyBoard[Properties.Settings.Default.keyRight] == true && Variables.pointPlayerLocation.X + playerHorizontalMoveSpeed <= Game.CANVAS_WIDTH - Variables.sizePlayerSize.Width)
                {
                    xVel = xVel + playerHorizontalMoveSpeed;
                }

                Variables.pointPlayerLocation = new Point(Variables.pointPlayerLocation.X + xVel, Variables.pointPlayerLocation.Y + yVel);
            }
        }

    }
}
