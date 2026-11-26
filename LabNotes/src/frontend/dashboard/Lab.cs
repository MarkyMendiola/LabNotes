using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labnote
{
    public partial class Lab : UserControl
    {
        public Lab()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void main_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.FindForm().Hide(); // Hides the window currently holding Schedule
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            Schedule uc = new Schedule();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear(); // Clears MainWindow's current screen
            this.Controls.Add(uc);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void booklab_Click(object sender, EventArgs e)
        {
            Booklab uc = new Booklab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }
        private void PcButton_Click(object sender, EventArgs e)
        {
            Button clickedPc = (Button)sender;
            string pcName = clickedPc.Text.Replace("\n", "-").Replace(" ", "-"); // e.g., "PC-6"
            string currentLab = comboBox1.Text; // e.g., "Comlab 1"

            using (PCpage popup = new PCpage(pcName, currentLab))
            {
                popup.ShowDialog(this); // Pops up centered over your main window!
            }
        }
    }
}
