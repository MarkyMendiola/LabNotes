using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labnote
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
            progressBar1.Value = 0;
            timer1.Interval = 60; // Runs every 30 milliseconds (~3 seconds total)
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1; // Increases by 2% each tick
                label1.Text = $"Loading System {progressBar1.Value}%";
            }
            else
            {
                timer1.Stop();

                // Open LoginWindow (or MainWindow) after loading finishes
                Form2 main = new Form2();
                main.Show();
                this.Hide();
            }
        }
    }
}
