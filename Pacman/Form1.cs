using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private Gamestate gs;
        private Renderer rend;

        public Form1()
        {
            // Initialize the window
            InitializeComponent();

            // Initialize the Game State
            gs = new Gamestate();
            gs.Map = MapLoader.Load("maps/level1.txt");
            gs.HighScore = 10000;
            gs.Lives = 3;

            // Initialize the renderer
            rend = new Renderer();
            rend.Init(Font);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            rend.Render(e.Graphics, gs);
        }
    }
}