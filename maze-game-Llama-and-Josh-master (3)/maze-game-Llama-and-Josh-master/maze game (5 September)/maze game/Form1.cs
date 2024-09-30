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
            this.KeyPreview = true;
        }

        private void MoveUp()
        {
            engine.TriggerMovement(Level.Direction.Up);
            UpdateDisplay();
        }

        private void MoveLeft()
        {
            engine.TriggerMovement(Level.Direction.Left);
            UpdateDisplay();
        }

        private void MoveDown()
        {
            engine.TriggerMovement(Level.Direction.Down);
            UpdateDisplay();
        }

        private void MoveRight()
        {
            engine.TriggerMovement(Level.Direction.Right);
            UpdateDisplay();
        }

        public void UpdateDisplay() // places level display in label
        {
            label1.Text = engine.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {   
                case Keys.W:
                    MoveUp();
                    break;
                case Keys.A:
                    MoveLeft();
                    break;
                case Keys.S:
                    MoveDown(); 
                    break;
                case Keys.D:
                    MoveRight();
                    break;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveRight();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveLeft();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }
    }
}


