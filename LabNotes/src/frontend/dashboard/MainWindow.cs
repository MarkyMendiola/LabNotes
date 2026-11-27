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

            // A PC that was already Faulty or Broken when the app started gets its log now
            IssueLogs.AddMissingLogs(Auth.CurrentUser.id);

            label2.Text = Auth.CurrentUser.name;                // "Welcome back, <name>"
            Frontend.ShowNextClass(label7, label6, label5);     // date, time, lab of the next class
            Frontend.ShowBrokenLab(label8, label9);            // lab with the most broken PCs
            Frontend.WireLogout(this);

            // Text for the four boxes on the main page
            AddTile(panel5, "Computer Labs", "Check which PCs are available, faulty or broken in each lab.");
            AddTile(panel6, "Book a Lab", "Pick a date and time, then reserve a free lab for your class.");
            AddTile(panel7, "Your Schedule", "Your upcoming classes and the labs you booked will show here.");
            AddTile(panel8, "Notices", "Reports about PC problems and other updates will show here.");
        }

        // Puts a title and a short line of text inside one of the boxes
        private void AddTile(Panel box, string title, string text)
        {
            var titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            titleLabel.Location = new Point(15, 15);

            var textLabel = new Label();
            textLabel.Text = text;
            textLabel.AutoSize = true;
            textLabel.MaximumSize = new Size(box.Width - 30, 0);   // long text goes to the next line inside the box
            textLabel.Font = new Font("Segoe UI", 11F);
            textLabel.Location = new Point(15, 55);

            box.Controls.Add(titleLabel);
            box.Controls.Add(textLabel);
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
