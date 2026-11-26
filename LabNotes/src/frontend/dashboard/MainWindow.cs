namespace Labnote
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
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