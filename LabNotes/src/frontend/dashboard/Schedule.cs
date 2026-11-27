using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LabPCTracker.Backend;

namespace Labnote
{
    public partial class Schedule : UserControl
    {
        public Schedule()
        {
            InitializeComponent();

            // Visual Studio's designer also runs this constructor, so don't touch the database there
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            label2.Text = Auth.CurrentUser.name;   // "Welcome back, <name>"

            // The two summary cards at the top (next class + lab with the most broken PCs)
            Frontend.ShowNextClass(label7, label6, label5);
            Frontend.ShowBrokenLab(label8, label9);
            Frontend.ShowNextClass(label15, label16, label17);
            Frontend.ShowBrokenLab(label14, label13);

            LoadSchedule();
            Frontend.WireLogout(this);
        }

        // Fills the table with every booking of the logged-in teacher
        private void LoadSchedule()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();

            foreach (var item in Schedules.GetSchedulesForUser(Auth.CurrentUser.id))
            {
                string time = item.start.ToString("h:mm tt") + " - " + item.end.ToString("h:mm tt");

                // Column order: Day, Subjects, Section, Time, Computer Lab
                dataGridView1.Rows.Add(item.dayOfWeek, item.subject, item.section, time, item.labName);
            }
            FillRows();
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

        private void FillRows()
        {
            int count = dataGridView1.Rows.Count;
            if (count == 0) return;

            int available = dataGridView1.ClientSize.Height - dataGridView1.ColumnHeadersHeight;
            int rowHeight = available / count;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Height = rowHeight;
        }
    }
}
