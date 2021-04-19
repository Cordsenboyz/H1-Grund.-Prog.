using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reaction_Game
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            TextGuide.Visible = false;
            BackColor = Color.Red;
            KeyPreview = true;

        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;
            StartButton.Visible = false;
            TextGuide.Visible = true;
            await Task.Delay(8000);
            BackColor = Color.Green;
            if (BackColor == Color.Green)
            {
                myTimer.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void TextGuide_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && BackColor == Color.Green)
            {
                BackColor = Color.Red;
                TextGuide.Visible = false;
                StartButton.Visible = true;
                myTimer.Stop();
            }
        }
    }
}
