using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game.Entity.Enemy
{
    class Enemy
    {
        //Variables
        public class Variables
        {
            public static List<Point> listEnemyLocations = new List<Point>();
            public static List<Size> listEnemySize = new List<Size>();
            public static List<Brush> listEnemyColor = new List<Brush>();
            public static List<int> listEnemyVelocity = new List<int>();
            public static List<bool> listEnemyVoidable = new List<bool>();
        }
        
        //Add enemy
        public static void createEnemy(int x, int y, int width, int height, int velX, int velY, bool voidable, Brush color)
        {
            Variables.listEnemyLocations.Add(new Point(x, y));
            Variables.listEnemySize.Add(new Size(width, height));
            Variables.listEnemyColor.Add(color);
            Variables.listEnemyVelocity.Add(velX);
            Variables.listEnemyVelocity.Add(velY);
            Variables.listEnemyVoidable.Add(voidable);
        }

        //Calculate new locations
        public static void recalculateEnemyLocations()
        {
            //For each enemy
            for (int count = 0; count <= Variables.listEnemyLocations.Count - 1; count++)
            {
                //If it can return by touching the window
                if (Variables.listEnemyVoidable[count] == false)
                {
                    if (Variables.listEnemyLocations[count].X <= 0)
                    {
                        Variables.listEnemyVelocity[count * 2] *= -1;
                    }
                    if (Variables.listEnemyLocations[count].X >= Game.CANVAS_WIDTH - Variables.listEnemySize[count].Width)
                    {
                        Variables.listEnemyVelocity[count * 2] *= -1;
                    }
                    if (Variables.listEnemyLocations[count].Y <= 0)
                    {
                        Variables.listEnemyVelocity[count * 2 + 1] *= -1;
                    }
                    if (Variables.listEnemyLocations[count].Y >= Game.CANVAS_HEIGHT - Variables.listEnemySize[count].Height)
                    {
                        Variables.listEnemyVelocity[count * 2 + 1] *= -1;
                    }
                }
                //Excicute
                Variables.listEnemyLocations[count] = new Point(Variables.listEnemyLocations[count].X + Variables.listEnemyVelocity[count * 2], Variables.listEnemyLocations[count].Y + Variables.listEnemyVelocity[count * 2 + 1]);
                //Delete if nesesary
                for (int counter = 0; counter <= Variables.listEnemyLocations.Count - 1; counter++)
                {
                    //If he can void
                    if (Variables.listEnemyVoidable[counter] == true)
                    {
                        //Void if out of map
                        if (Variables.listEnemyLocations[counter].X + Variables.listEnemySize[counter].Width < 0 || Variables.listEnemyLocations[counter].X > Game.CANVAS_WIDTH || Variables.listEnemyLocations[counter].Y + Variables.listEnemySize[counter].Height < 0 || Variables.listEnemyLocations[counter].Y > Game.CANVAS_HEIGHT)
                        {
                            deleteEnemy(counter);
                        }
                    }
                }
            }
        }
        //Delete enemy
        public static void deleteEnemy(int id)
        {
            Variables.listEnemyLocations.RemoveAt(id);
            Variables.listEnemySize.RemoveAt(id);
            Variables.listEnemyColor.RemoveAt(id);
            Variables.listEnemyVelocity.RemoveAt(id * 2 + 1);
            Variables.listEnemyVelocity.RemoveAt(id * 2);
            Variables.listEnemyVoidable.RemoveAt(id);
        }

        //Delete all enemies
        public static void deleteAllEnemies()
        {
           
                Variables.listEnemyLocations.Clear();
                Variables.listEnemySize.Clear();
                Variables.listEnemyColor.Clear();
                Variables.listEnemyVelocity.Clear();
                Variables.listEnemyVelocity.Clear();
                Variables.listEnemyVoidable.Clear();
                 
        }

        //Make voidable
        public static void makeEnemyVoidable(int id)
        {
            Variables.listEnemyVoidable[id] = true;
        }
        
        //Make all voidable
        public static void makeAllEnemiesVoidable()
        {
            for (int count = 0; count <= Variables.listEnemyVoidable.Count - 1; count++)
            {

                Variables.listEnemyVoidable[count] = true;

            }
        }
    }
}
