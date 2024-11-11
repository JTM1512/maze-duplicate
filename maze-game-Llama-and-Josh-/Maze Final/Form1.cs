using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Final
{
    [Serializable]
    public partial class Form1 : Form
    {
        private GameEngine engine;
        //public Form3 startMenu = new Form3();


        public Form1()
        {
            int numbLevels = 10;
            InitializeComponent();
            engine = new GameEngine(numbLevels);
            UpdateDisplay();
            this.KeyPreview = true;
            this.Hide();
        }

        private void MoveLeft()
        {
            engine.TriggerMovement(Level.Direction.Up);
            engine.TriggerAttack(Level.Direction.Up);
            UpdateDisplay();
        }

        private void MoveUp()
        {
            engine.TriggerMovement(Level.Direction.Left);
            engine.TriggerAttack(Level.Direction.Left);
            UpdateDisplay();
        }

        private void MoveRight()
        {
            engine.TriggerMovement(Level.Direction.Down);
            engine.TriggerAttack(Level.Direction.Down);
            UpdateDisplay();
        }

        private void MoveDown()
        {
            engine.TriggerMovement(Level.Direction.Right);
            engine.TriggerAttack(Level.Direction.Right);
            UpdateDisplay();
        }

        public void UpdateDisplay() // places level display in label
        {
            label1.Text = engine.ToString();
            //displays hero stats in a label
            label2.Text = engine.HeroStats;
            label3.Text = "Level: " + engine.currentLevelNumber + "/10";
            label4.Text = " Tile legend:\n .: Empty tile\n █: Wall tile\n +: Health pickup\n (restores health by 10)\n *: Attack buff\n (AP * 2 for next 3 attacks)\n ▓: Locked exit tile\n ░: Unlocked exit tile\n ▼: Hero tile\n X: Dead hero\n Ϫ: Grunt enemy (10 HP / 1 AP)\n ᐂ: Warlock enemy (10 HP / 5 AP)\n §: Tyrant enemy (15 HP / 5 AP)\n x: Dead enemy\n";
            //label5.Text = engine.;
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

        private void button4_Click(object sender, EventArgs e)
        {
            engine.TriggerMovement(Level.Direction.Up);
            engine.TriggerAttack(Level.Direction.Up);
            UpdateDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            engine.TriggerMovement(Level.Direction.Left);
            engine.TriggerAttack(Level.Direction.Left);
            UpdateDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.TriggerMovement(Level.Direction.Right);
            engine.TriggerAttack(Level.Direction.Right);
            UpdateDisplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.TriggerMovement(Level.Direction.Down);
            engine.TriggerAttack(Level.Direction.Down);
            UpdateDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.SaveGame();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            engine.LoadGame();
            UpdateDisplay();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Objective: \n Unlock and reach the exit by defeating all the enemies\n\nControls: \n W: UP \n A: LEFT \n S: DOWN \n D: LEFT\n Arrow buttons can also be used for movement\n\nComing into contact with an enemy causes both parties to attack one another and the corresponding attack power (AP) is subtracted from the corresponing hit points (HP)");
        }
    }
}
