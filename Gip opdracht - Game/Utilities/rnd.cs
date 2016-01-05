using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Utilities
{
    class rnd
    {
        public static Random r = new Random();
        public static int getRandomInt(int lower, int upper)
        {
            int rnd = r.Next(lower, upper);
            if(rnd != 0)
            {
                return rnd;
            }
            else
            {
                return getRandomInt(lower, upper);
            }
            
        }
        public static bool getRandomBool()
        {
            if(getRandomInt(1, 3) == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Color getRandomColor()
        {
            return Color.FromArgb(255, Utilities.rnd.getRandomInt(1, 255), Utilities.rnd.getRandomInt(1, 255), Utilities.rnd.getRandomInt(1, 255));
        }
    }

}

