using LabPCTracker.Backend;

namespace Labnote
{
    // The app's entry point. Put this file in C:\Labnotes\Labnotes\src
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Frontend.Start();
        }
    }

    // The backend's main file can also call Frontend.Start() to open the UI.
    // Start-up and the small helpers that every screen shares
    public static class Frontend
    {
        public static void Start()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Db.Initialize();   // creates MyDb and its tables the first time the app runs
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the database:\n" + ex.Message, Constants.AppTitle);
                return;
            }

            Application.Run(new Form2());   // Form2 is the login screen
        }

        // Forgets the logged-in user, then restarts the app so the login screen shows again
        public static void Logout()
        {
            Auth.Logout();
            Application.Restart();
        }

        // Finds every button that says "Log out" inside this screen and connects it to Logout()
        public static void WireLogout(Control screen)
        {
            foreach (Control c in screen.Controls)
            {
                if (c is Button b && b.Text == "Log out")
                {
                    b.Click += (sender, e) => Logout();
                }
                WireLogout(c);   // also look inside panels
            }
        }

        // Fills three labels with the logged-in user's next class (date, time, lab)
        public static void ShowNextClass(Label date, Label time, Label lab)
        {
            var next = Schedules.GetNextSchedule(Auth.CurrentUser.id);

            if (next == null)
            {
                date.Text = "-";
                time.Text = "No upcoming class";
                lab.Text = "";
                return;
            }

            date.Text = next.start.ToString("MM/dd/yy");
            time.Text = next.start.ToString("h:mm tt") + " - " + next.end.ToString("h:mm tt");
            lab.Text = next.labName;
        }

        // Fills two labels with the lab that has the most broken PCs, and how many
        public static void ShowBrokenLab(Label lab, Label count)
        {
            string labName = Computers.GetMostBrokenLab(out int brokenCount);

            lab.Text = labName == "" ? "None" : labName;
            count.Text = brokenCount.ToString();
        }
    }
}
