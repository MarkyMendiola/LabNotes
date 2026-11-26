using System.ComponentModel;
using LabPCTracker.Backend;

namespace Labnote
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            // Closing the dashboard closes the whole app
            FormClosed += (sender, e) => Application.Exit();

            // Visual Studio's designer also runs this constructor, so don't touch the database there
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            label2.Text = Auth.CurrentUser.name;                // "Welcome back, <name>"
            Frontend.ShowNextClass(label7, label6, label5);     // date, time, lab of the next class
            Frontend.ShowBrokenLab(label8, label9);            // lab with the most broken PCs
            Frontend.WireLogout(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Schedule uc = new Schedule();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear(); // Clears MainWindow's current screen
            this.Controls.Add(uc); // Replaces it with your Schedule screen
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab uc = new Lab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        private void booklab_Click(object sender, EventArgs e)
        {
            Booklab uc = new Booklab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }
    }
}
