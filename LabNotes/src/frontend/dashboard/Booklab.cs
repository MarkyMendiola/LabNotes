using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LabPCTracker.Backend;
using BackendLab = LabPCTracker.Backend.Lab;   // the Lab screen has the same name, so the database Lab gets a nickname

namespace Labnote
{
    public partial class Booklab : UserControl
    {
        // The five lab cards on the screen, in order: the card, its name label, its status label, its color chip
        private Panel[] cards;
        private Label[] nameLabels;
        private Label[] statusLabels;
        private Panel[] chips;

        private List<BackendLab> labs;   // every lab from the database (same order as the cards)
        private int selected = -1;       // which card the teacher clicked (-1 = none yet)

        public Booklab()
        {
            InitializeComponent();

            // Visual Studio's designer also runs this constructor, so don't touch the database there
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            cards = new Panel[] { panel2, panel5, panel7, panel9, panel11 };
            nameLabels = new Label[] { label5, label7, label9, label12, label14 };
            statusLabels = new Label[] { label6, label8, label10, label13, label15 };
            chips = new Panel[] { panel3, panel6, panel8, panel10, panel12 };

            // Dropdowns: Date = the next 14 days, Start and End = every 30 minutes
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 0; i < 14; i++)
            {
                comboBox1.Items.Add(DateTime.Today.AddDays(i).ToString("ddd, MMM dd"));
            }
            FillTimes(comboBox2);
            FillTimes(comboBox3);

            // Software dropdown: the first choice means "no software needed", then every software name from the database
            comboSoftware.Items.Add("Any software");
            foreach (string name in Computers.GetAllSoftware())
            {
                comboSoftware.Items.Add(name);
            }

            // Show the lab names on the cards. Cards without a lab are hidden.
            labs = Computers.GetLabs();
            for (int i = 0; i < cards.Length; i++)
            {
                if (i < labs.Count)
                {
                    nameLabels[i].Text = labs[i].name;
                    ClickToSelect(cards[i], i);
                }
                else
                {
                    cards[i].Visible = false;
                }
            }

            // Default choice: today, 08:00 to 10:00, any software (set before the events are connected)
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 6;
            comboSoftware.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += TimeChanged;
            comboBox2.SelectedIndexChanged += TimeChanged;
            comboBox3.SelectedIndexChanged += TimeChanged;
            comboSoftware.SelectedIndexChanged += TimeChanged;   // choosing a software also refreshes the cards

            button1.Click += button1_Click;   // the "Schedule" button in the side menu
            button7.Click += button7_Click;   // "Add booking"

            ShowAvailability();
            Frontend.WireLogout(this);
        }

        // Adds "07:00", "07:30", ... "21:00" to a dropdown
        private void FillTimes(ComboBox box)
        {
            for (int minutes = 7 * 60; minutes <= 21 * 60; minutes += 30)
            {
                box.Items.Add(TimeSpan.FromMinutes(minutes).ToString(@"hh\:mm"));
            }
        }

        // Makes the card (and everything inside it) select that lab when clicked
        private void ClickToSelect(Panel card, int index)
        {
            card.Click += (sender, e) => SelectLab(index);
            foreach (Control inside in card.Controls)
            {
                inside.Click += (sender, e) => SelectLab(index);
            }
        }

        private void SelectLab(int index)
        {
            selected = index;

            // The chosen card is dark blue, the others are the normal blue
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].BackColor = (i == selected) ? Color.Navy : SystemColors.MenuHighlight;
            }
        }

        // The start and end the teacher picked in the dropdowns
        private DateTime GetStart()
        {
            DateTime day = DateTime.Today.AddDays(comboBox1.SelectedIndex);
            return day + TimeSpan.Parse(comboBox2.Text);
        }

        private DateTime GetEnd()
        {
            DateTime day = DateTime.Today.AddDays(comboBox1.SelectedIndex);
            return day + TimeSpan.Parse(comboBox3.Text);
        }

        private void TimeChanged(object sender, EventArgs e)
        {
            ShowAvailability();
        }

        // The labs that have the software chosen in the dropdown.
        // "Any software" (the first choice) means every lab counts.
        private List<BackendLab> GetLabsWithSoftware()
        {
            if (comboSoftware.SelectedIndex <= 0)
            {
                return labs;
            }
            return Computers.GetLabsWithSoftware(comboSoftware.Text);
        }

        // True when the list has a lab with the same id
        private bool ListHasLab(List<BackendLab> list, BackendLab lab)
        {
            foreach (var other in list)
            {
                if (other.id == lab.id)
                    return true;
            }
            return false;
        }
        
        // Sets the text of a card's status label, and colors both the label and the strip on top of the card
        private void SetStatus(int i, string text, Color color)
        {
            statusLabels[i].Text = text;
            statusLabels[i].BackColor = color;
            chips[i].BackColor = color;
        }

        // Marks each lab card "Available" (green), "In Use" (red) or "No software" (gray) for the chosen time and software
        private void ShowAvailability()
        {
            DateTime start = GetStart();
            DateTime end = GetEnd();

            if (end <= start)
            {
                for (int i = 0; i < labs.Count; i++)
                {
                    SetStatus(i, "Check time", Color.LightGray);
                }
                return;
            }

            // Discrete math: free labs = all labs - booked labs (set difference)
            var booked = Schedules.GetBookedLabs(start, end);
            var free = Logic.Difference(labs, booked);

            // Discrete math: bookable labs = free labs ∩ labs that have the software (set intersection)
            var withSoftware = GetLabsWithSoftware();
            var bookable = Logic.Intersection(free, withSoftware);

            for (int i = 0; i < labs.Count; i++)
            {
                if (ListHasLab(bookable, labs[i]))
                {
                    SetStatus(i, "Available", Color.LightGreen);
                }
                else if (ListHasLab(free, labs[i]))
                {
                    // free at that time, but it does not have the software
                    SetStatus(i, "No software", Color.LightGray);
                }
                else
                {
                    SetStatus(i, "In Use", Color.Salmon);
                }
            }
        }

        // "Add booking" button
        private void button7_Click(object sender, EventArgs e)
        {
            if (selected < 0)
            {
                MessageBox.Show("Click a lab first.", Constants.AppTitle);
                return;
            }

            if (statusLabels[selected].Text == "No software")
            {
                MessageBox.Show(labs[selected].name + " does not have " + comboSoftware.Text + ".", Constants.AppTitle);
                return;
            }

            try
            {
                // The class name and the section typed in the two boxes are saved with the booking
                Schedules.AddSchedule(GetStart(), GetEnd(), Auth.CurrentUser.id, labs[selected].id, txtSubject.Text.Trim(), txtSection.Text.Trim(), GetStart().DayOfWeek.ToString());
                MessageBox.Show(labs[selected].name + " is booked.", Constants.AppTitle);
                txtSubject.Clear();
                txtSection.Clear();
                ShowAvailability();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, Constants.AppTitle);   // wrong time, empty class name or section, or lab already taken
            }
        }

        // "Schedule" button in the side menu
        private void button1_Click(object sender, EventArgs e)
        {
            Schedule uc = new Schedule();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        private void main_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.FindForm().Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab uc = new Lab();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
