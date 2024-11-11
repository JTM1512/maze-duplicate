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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Objective: \n Unlock and reach the exit by defeating all the enemies\n\nControls: \n W: UP \n A: LEFT \n S: DOWN \n D: LEFT\n Arrow buttons can also be used for movement\n\nComing into contact with an enemy causes both parties to attack one another and the corresponding attack power (AP) is subtracted from the corresponing hit points (HP)");
            Form1 form = new Form1();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            Form3 form3 = new Form3();
            form3.Hide();
        }

    }
}
