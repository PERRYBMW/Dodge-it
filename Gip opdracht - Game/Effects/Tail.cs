using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Effects
{
    class Tail
    {
        //Variables
        public class Variables
        {
            public static List<Point> listTailLocations = new List<Point>();
            public static List<Size> listTailSize = new List<Size>();
            public static List<Color> listTailColor = new List<Color>();

            public static double doubleTailAccurance = 1.3;
        }
        //Calculate
        public static void calculateTail()
        {
            //for each enemy add tail
            for (int count = 0; count <= Entity.Enemy.Enemy.Variables.listEnemyLocations.Count - 1; count++)
            {
                Variables.listTailLocations.Add(Entity.Enemy.Enemy.Variables.listEnemyLocations[count]);
                Variables.listTailSize.Add(Entity.Enemy.Enemy.Variables.listEnemySize[count]);
                Variables.listTailColor.Add((Entity.Enemy.Enemy.Variables.listEnemyColor[count] as SolidBrush).Color);
            }
            //Alpha
            for (int count = 0; count <= Variables.listTailLocations.Count - 1; count++)
            {
                if (Variables.listTailColor[count].A < 4)
                {
                    removeTail(count);
                }
                else
                {
                    Variables.listTailColor[count] = (Color.FromArgb(Convert.ToInt16(Variables.listTailColor[count].A / Variables.doubleTailAccurance), Variables.listTailColor[count].R, Variables.listTailColor[count].G, Variables.listTailColor[count].B));
                }
            }         

        }
        //Remove tail by id
        public static void removeTail(int id)
        {
            Variables.listTailLocations.RemoveAt(id);
            Variables.listTailSize.RemoveAt(id);
            Variables.listTailColor.RemoveAt(id);
        }
        //Remove all tails
        public static void removeAllTails()
        {
            Variables.listTailLocations.Clear();
            Variables.listTailSize.Clear();
            Variables.listTailColor.Clear();
        }
    }
}
