using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LabPCTracker.Backend;
using BackendLab = LabPCTracker.Backend.Lab;   // this screen is also called Lab, so the database Lab gets a nickname

namespace Labnote
{
    public partial class Lab : UserControl
    {
        public Lab()
        {
            InitializeComponent();

            // Visual Studio's designer also runs this constructor, so don't touch the database there
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Put every lab in the dropdown, then show the PCs of the first one
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var lab in Computers.GetLabs())
            {
                comboBox1.Items.Add(lab);
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;   // this also calls LoadPcs()
            }

            Frontend.WireLogout(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        // Runs when a different lab is picked in the dropdown
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPcs();
        }

        // Colors every PC button by its status and updates the three counters
        private void LoadPcs()
        {
            var lab = comboBox1.SelectedItem as BackendLab;
            if (lab == null) return;

            // Only the PCs of the chosen lab, in order (PC01, PC02, ...)
            var pcs = Computers.GetStatus().Where(pc => pc.labId == lab.id).ToList();

            int available = 0;
            int broken = 0;

            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c is Button b && b.Text.StartsWith("PC "))
                {
                    int number = int.Parse(b.Text.Substring(3));   // "PC 7" -> 7

                    // The screen has 36 buttons but a lab may have fewer PCs, so hide the extra buttons
                    if (number > pcs.Count)
                    {
                        b.Visible = false;
                        b.Tag = null;
                        continue;
                    }

                    var pc = pcs[number - 1];
                    b.Visible = true;
                    b.Tag = pc;   // remember which computer this button stands for

                    if (pc.status == Constants.StatusBroken)
                    {
                        b.BackColor = Color.Tomato;
                        broken++;
                    }
                    else if (pc.status == Constants.StatusFaulty)
                    {
                        b.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        b.UseVisualStyleBackColor = true;   // back to the normal look
                        available++;
                    }
                }
            }

            label5.Text = pcs.Count.ToString();   // Total PCs
            label6.Text = available.ToString();   // Available
            label7.Text = broken.ToString();      // Broken
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

        // Runs when any PC button is clicked: opens that computer's page
        private void PcButton_Click(object sender, EventArgs e)
        {
            // The whole Lab screen is also connected to this method (see Lab.Designer.cs),
            // so ignore clicks that did not come from a PC button
            if (sender is not Button clickedPc || clickedPc.Tag == null) return;

            var pc = (Computer)clickedPc.Tag;

            using (PCpage popup = new PCpage(pc))
            {
                popup.ShowDialog(this); // Pops up centered over your main window!
            }

            LoadPcs();   // the PC may have been reported or fixed, so refresh the colors
        }
    }
}
