using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maze_game
{
    public partial class Form1 : Form
    {
        private GameEngine engine;
        public Form1()
        {
            int numbLevels = 10;
            InitializeComponent();
            engine = new GameEngine(numbLevels);
            UpdateDisplay();
        }

        
        public void UpdateDisplay() // places level display in label
        {
            label1.Text = engine.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
