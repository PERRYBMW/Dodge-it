using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gip_opdracht___Game.Control
{
    class ScoreControl
    {

        public class Variables
        {

        }

        public static void calculateHighScoreNormal(int score)
        {
            if(score > Properties.Settings.Default.HighScoreNormal)
            {
                Properties.Settings.Default.HighScoreNormal = score;
            }
        }
        public static void calculateHighScoreRandom(int score)
        {
            if (score > Properties.Settings.Default.HighScoreRandom)
            {
                Properties.Settings.Default.HighScoreRandom = score;
            }
        }
    }
}
