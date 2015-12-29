using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gip_opdracht___Game
{
    class Game
    {
        //Constants
        public const int CANVAS_WIDTH = 1216;
        public const int CANVAS_HEIGHT = 704;

        //Members
        private GEngine gEngine;

        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        public void stopGame()
        {
            gEngine.stop();
        }
    }
}
