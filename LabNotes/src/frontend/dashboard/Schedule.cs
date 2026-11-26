using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labnote
{
    public partial class Schedule : UserControl
    {
        public Schedule()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void main_Click_1(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.FindForm().Hide(); // Hides the window currently holding Schedule
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lab uc = new Lab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booklab uc = new Booklab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }
    }
}
