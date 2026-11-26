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
    public partial class PCpage : Form
    {
        private string _pcName;
        private string _labName;

        private Computer _pc;                  // the computer this page is about
        private List<IssueLog> _logs;          // this computer's issue logs, newest first

        public PCpage(Computer pc)
        {
            InitializeComponent();
            _pc = pc;

            linkLabel1.Click += linkLabel1_Click;   // "view full history"
            button1.Click += button1_Click;         // "Report Issue" / "Mark Fixed"

            LoadSoftware();
            LoadLogs();
        }
        public PCpage(string pcName, string labName)
        {
            InitializeComponent();
            _pcName = pcName;
            _labName = labName;

            PCtitle.Text = _pcName; // Updates "PC-xx" to "PC-06", etc.
                                    // Next: Load Installed Software & Logs for _pcName and _labName from SQL!
        }
        public PCpage()
        {
            InitializeComponent();
        }

        // Lists the installed software on the right-hand list
        private void LoadSoftware()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;   // one name per line
            flowLayoutPanel1.WrapContents = false;

            foreach (string name in Computers.GetSoftware(_pc.id))
            {
                var label = new Label();
                label.Text = name;
                label.AutoSize = true;
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
                label.Margin = new Padding(10, 6, 3, 3);
                flowLayoutPanel1.Controls.Add(label);
            }
        }

        // Shows the title, the latest issue and sets the button to "Report Issue" or "Mark Fixed"
        private void LoadLogs()
        {
            // Get the newest status of this computer (it may have changed since the Lab screen loaded)
            foreach (var pc in Computers.GetStatus())
            {
                if (pc.id == _pc.id)
                    _pc = pc;
            }
            PCtitle.Text = _pc.ToString();   // e.g. "LAB1-PC07 - Broken"

            // Keep only the logs of this computer
            _logs = new List<IssueLog>();
            foreach (var log in IssueLogs.GetIssueLogs())
            {
                if (log.computerId == _pc.id)
                    _logs.Add(log);
            }

            // The top row = when it was reported (PC Dead), the second row = when it was fixed (PC Alive)
            label2.Visible = label5.Visible = false;
            label3.Visible = label4.Visible = false;

            if (_logs.Count == 0)
            {
                label4.Text = "No issues yet";
                label4.Visible = true;
            }
            else
            {
                var latest = _logs[0];

                label2.Text = latest.reportedAt.ToString("MM/dd/yy");
                label5.Text = "PC Dead";
                label2.Visible = label5.Visible = true;

                if (latest.resolvedAt != null)
                {
                    label3.Text = latest.resolvedAt.Value.ToString("MM/dd/yy");
                    label4.Text = "PC Alive";
                    label3.Visible = label4.Visible = true;
                }
            }

            // If an issue is still open the button fixes it, otherwise it reports a new one
            if (GetOpenIssue() != null)
            {
                button1.Text = "Mark Fixed";
                button1.BackColor = Color.PaleGreen;
            }
            else
            {
                button1.Text = "Report Issue";
                button1.BackColor = Color.Salmon;
            }
        }

        // The newest issue that is not fixed yet (null if there is none)
        private IssueLog GetOpenIssue()
        {
            foreach (var log in _logs)
            {
                if (log.resolvedAt == null)
                    return log;
            }
            return null;
        }

        // "Report Issue" / "Mark Fixed" button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var open = GetOpenIssue();

                if (open != null)
                {
                    IssueLogs.ResolveIssue(open.id);
                }
                else
                {
                    string description = AskDescription();
                    if (description == "") return;   // cancelled or left empty

                    IssueLogs.ReportIssue(_pc.id, Auth.CurrentUser.id, description);
                }

                LoadLogs();   // show the new status
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.AppTitle);
            }
        }

        // Small pop-up asking what is wrong with the PC. Returns "" if cancelled.
        private string AskDescription()
        {
            using var form = new Form();
            form.Text = "Report Issue";
            form.ClientSize = new Size(360, 130);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            var label = new Label { Text = "What is wrong with " + _pc.name + "?", Left = 10, Top = 10, AutoSize = true };
            var box = new TextBox { Left = 10, Top = 35, Width = 340, MaxLength = 500 };
            var ok = new Button { Text = "Report", Left = 270, Top = 80, DialogResult = DialogResult.OK };

            form.Controls.Add(label);
            form.Controls.Add(box);
            form.Controls.Add(ok);
            form.AcceptButton = ok;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                return box.Text.Trim();
            }
            return "";
        }

        // "view full history" link: lists every log of this computer
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (_logs.Count == 0)
            {
                MessageBox.Show("No issues have been logged for this PC.", Constants.AppTitle);
                return;
            }

            var lines = new List<string>();
            foreach (var log in _logs)
            {
                lines.Add(log.reportedAt.ToString("MM/dd/yy") + "  " + log.ToString());
            }
            MessageBox.Show(string.Join("\n", lines), _pc.name + " history");
        }

        private void PCpage_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
