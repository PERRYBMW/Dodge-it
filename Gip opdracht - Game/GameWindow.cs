using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;
using System.Configuration;

namespace Gip_opdracht___Game
{
    public partial class GameWindow : Form
    {
        private Game game = new Game();
        public static System.Timers.Timer tmrTick;

        public class Variables
        {
            public static bool[] keyBoard = new bool[255];
            public static Point mouseClick = new Point();
            public static int gameWindowHeight;
            public static int gameWindowWidth;                   
        }
    
        public GameWindow()
        {
            InitializeComponent();
            tmrTick = new System.Timers.Timer(1000);
            tmrTick.Elapsed += aTimer_Elapsed;
            tmrTick.Enabled = true;
            tmrTick.Interval = 1000;
        }

        private void aTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //If the game is playing
            if(GEngine.Variables.intGameState == 1 || GEngine.Variables.intGameState == 2)
            {
                Control.LevelControl.Variables.intTimerTicks++;     
            }
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            //Debug Console
            if(Properties.Settings.Default.cmdInfo == true)
            {
                AllocConsole();
            }

            //Size 
            Variables.gameWindowHeight = Size.Height;
            Variables.gameWindowHeight = Size.Width;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }

        //Command line for debugging
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Variables.keyBoard[e.KeyValue] = true;
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            Variables.keyBoard[e.KeyValue] = false;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Variables.mouseClick = new Point(e.X, e.Y);
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Variables.mouseClick = new Point(-1, -1);
        }

 

    }
}
