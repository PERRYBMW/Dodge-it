using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Gip_opdracht___Game.Effects
{
    class Sound
    {

        public class Variabeles
        {
            //Sound effects
            public static SoundPlayer soundExplosion = new SoundPlayer(Properties.Resources.Explosion);
            public static SoundPlayer soundSelect = new SoundPlayer(Properties.Resources.Select);
            public static SoundPlayer soundSpawn = new SoundPlayer(Properties.Resources.Spawn);
        }

        public static void playSoundExplosion()
        {
            Variabeles.soundExplosion.Play();
        }
        public static void playSoundSelect()
        {
            Variabeles.soundSelect.Play();
        }
        public static void playSoundSpawn()
        {
            Variabeles.soundSpawn.Play();
        }

    }
}
