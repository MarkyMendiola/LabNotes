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

        // Lists the installed software in the left-hand box, each name inside a rounded bubble
        private void LoadSoftware()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;   // bubbles go side by side...
            flowLayoutPanel1.WrapContents = true;                         // ...and continue on the next line when the row is full

            foreach (string name in Computers.GetSoftware(_pc.id))
            {
                flowLayoutPanel1.Controls.Add(MakeBubble(name));
            }
        }

        // Makes one bubble (a label with rounded corners) for a software name
        private Label MakeBubble(string text)
        {
            var font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            Size textSize = TextRenderer.MeasureText(text, font);

            var bubble = new Label();
            bubble.Text = text;
            bubble.Font = font;
            bubble.AutoSize = false;
            bubble.TextAlign = ContentAlignment.MiddleCenter;
            bubble.BackColor = Color.White;
            bubble.ForeColor = SystemColors.MenuHighlight;
            bubble.Margin = new Padding(8, 8, 3, 3);
            bubble.Size = new Size(textSize.Width + 24, textSize.Height + 12);   // a little space around the text

            // Round the corners: the corner size is the full height, so both ends are fully round
            int d = bubble.Height;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(bubble.Width - d, 0, d, d, 270, 90);
            path.AddArc(bubble.Width - d, bubble.Height - d, d, d, 0, 90);
            path.AddArc(0, bubble.Height - d, d, d, 90, 90);
            path.CloseFigure();
            bubble.Region = new Region(path);

            return bubble;
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

            ShowLogRows();

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

        // Fills the Logs box. Every log gets a "PC Dead" row (when it was reported)
        // and, if it was fixed, a "PC Alive" row (when it was fixed). Newest first.
        private void ShowLogRows()
        {
            panel1.Controls.Clear();
            panel1.AutoScroll = true;   // if there are more rows than the box can show, a scroll bar appears

            if (_logs.Count == 0)
            {
                AddLogRow(0, "", "No issues yet", Color.PaleGreen);
                return;
            }

            int row = 0;
            foreach (var log in _logs)
            {
                AddLogRow(row, log.reportedAt.ToString("MM/dd/yy"), "PC Dead", Color.Salmon);
                row++;

                if (log.resolvedAt != null)
                {
                    AddLogRow(row, log.resolvedAt.Value.ToString("MM/dd/yy"), "PC Alive", Color.PaleGreen);
                    row++;
                }
            }
        }

        // Adds one row to the Logs box: the date on the left and the colored tag next to it
        private void AddLogRow(int row, string date, string tag, Color tagColor)
        {
            int y = 10 + row * 44;   // every row is 44 pixels below the one before
            var font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            if (date != "")
            {
                var dateLabel = new Label();
                dateLabel.Text = date;
                dateLabel.AutoSize = true;
                dateLabel.Font = font;
                dateLabel.BackColor = SystemColors.ControlLightLight;
                dateLabel.ForeColor = SystemColors.MenuHighlight;
                dateLabel.Location = new Point(13, y);
                panel1.Controls.Add(dateLabel);
            }

            var tagLabel = new Label();
            tagLabel.Text = tag;
            tagLabel.AutoSize = true;
            tagLabel.Font = font;
            tagLabel.BackColor = tagColor;
            tagLabel.Location = new Point(120, y);
            panel1.Controls.Add(tagLabel);
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
                    if (!AskIssue(out string description, out string status)) return;   // cancelled

                    IssueLogs.ReportIssue(_pc.id, Auth.CurrentUser.id, description, status);
                }

                LoadLogs();   // show the new status
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.AppTitle);
            }
        }

        // Pop-up for reporting a PC. The teacher picks Faulty or Broken and types what is wrong.
        // Returns false if the pop-up was cancelled.
        private bool AskIssue(out string description, out string status)
        {
            description = "";
            status = "";

            using var form = new Form();
            form.Text = "Report Issue";
            form.ClientSize = new Size(380, 260);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.BackColor = SystemColors.ControlLightLight;

            var title = new Label { Text = "Report " + _pc.name, Font = new Font("Segoe UI", 14.25F, FontStyle.Bold), Left = 15, Top = 12, AutoSize = true };
            var kindLabel = new Label { Text = "What kind of problem is it?", Left = 15, Top = 55, AutoSize = true };
            var faulty = new RadioButton { Text = "Faulty (software problem)", Left = 25, Top = 80, AutoSize = true, Checked = true };
            var broken = new RadioButton { Text = "Broken (hardware problem)", Left = 25, Top = 105, AutoSize = true };
            var detailLabel = new Label { Text = "What is wrong with it?", Left = 15, Top = 140, AutoSize = true };
            var box = new TextBox { Left = 15, Top = 163, Width = 350, MaxLength = 500 };
            var report = new Button { Text = "Report", Left = 195, Top = 215, Width = 80, BackColor = Color.Salmon };
            var cancel = new Button { Text = "Cancel", Left = 285, Top = 215, Width = 80, DialogResult = DialogResult.Cancel };

            // "Report" only closes the pop-up when something was typed
            report.Click += (sender, e) =>
            {
                if (box.Text.Trim() == "")
                {
                    MessageBox.Show("Please type what is wrong.", Constants.AppTitle);
                    return;
                }
                form.DialogResult = DialogResult.OK;
            };

            form.Controls.Add(title);
            form.Controls.Add(kindLabel);
            form.Controls.Add(faulty);
            form.Controls.Add(broken);
            form.Controls.Add(detailLabel);
            form.Controls.Add(box);
            form.Controls.Add(report);
            form.Controls.Add(cancel);
            form.AcceptButton = report;   // Enter = Report
            form.CancelButton = cancel;   // Esc = Cancel

            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return false;
            }

            description = box.Text.Trim();
            status = broken.Checked ? Constants.StatusBroken : Constants.StatusFaulty;
            return true;
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

    }
}
