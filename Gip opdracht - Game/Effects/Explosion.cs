using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Effects
{
    class Explosion
    {
        //Variables
        public class Variables
        {
            public static List<Point> listExplosionLocations = new List<Point>();
            public static List<Size> listExplosionSize = new List<Size>();
            public static List<int> listExplosionVelocity = new List<int>();
            public static List<Brush> listExplosionColor = new List<Brush>();
        }
        //Add explosion
        public static void addExplosion(int x, int y, int velX, int velY, int width, int height, Brush color)
        {
            Variables.listExplosionLocations.Add(new Point(x, y));
            Variables.listExplosionSize.Add(new Size(width, height));
            Variables.listExplosionVelocity.Add(velX);
            Variables.listExplosionVelocity.Add(velY);
            Variables.listExplosionColor.Add(color);
        }
        //Recalculate explosions
        public static void recalculateExplosionLocations()
        {
            //New locations
            for (int count = 0; count <= Variables.listExplosionLocations.Count - 1; count++)
            {
                Variables.listExplosionLocations[count] = new Point(Variables.listExplosionLocations[count].X + Variables.listExplosionVelocity[count * 2], Variables.listExplosionLocations[count].Y + Variables.listExplosionVelocity[count * 2 + 1]);
            }

            for (int counter = 0; counter <= Variables.listExplosionLocations.Count - 1; counter++)
            {
                
                    //Void if out of map
                    if (Variables.listExplosionLocations[counter].X + Variables.listExplosionSize[counter].Width < 0 || Variables.listExplosionLocations[counter].X > Game.CANVAS_WIDTH || Variables.listExplosionLocations[counter].Y + Variables.listExplosionSize[counter].Height < 0 || Variables.listExplosionLocations[counter].Y > Game.CANVAS_HEIGHT)
                    {
                        deleteExplosion(counter);
                    }
                
            }

        }
        //Delete explosion
        public static void deleteExplosion(int id)
        {
            Variables.listExplosionLocations.RemoveAt(id);
            Variables.listExplosionSize.RemoveAt(id);
            Variables.listExplosionVelocity.RemoveAt(id * 2 + 1);
            Variables.listExplosionVelocity.RemoveAt(id * 2);
            Variables.listExplosionColor.RemoveAt(id);
        }
        //Delete all explosions
        public static void deleteAllExplosions()
        {
            Variables.listExplosionLocations.Clear();
            Variables.listExplosionSize.Clear();
            Variables.listExplosionVelocity.Clear();
            Variables.listExplosionColor.Clear();
        }
    }
}
