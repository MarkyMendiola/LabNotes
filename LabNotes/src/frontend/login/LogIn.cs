using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labnote
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

            button1.Enabled = false;
            button1.BackColor = Color.FromArgb(200, 205, 210); // Gray
            button1.ForeColor = Color.White;

            textBox1.TextChanged += textBox_TextChanged;
            textBox2.TextChanged += textBox_TextChanged;

            ValidateLogin();
        }
        private void ValidateLogin()
        {
            bool isComplete = textBox1.Text == "Daren" && textBox2.Text == "olayvar123";
            if (isComplete)
            {
                button1.Enabled = true;
                button1.BackColor = Color.FromArgb(16, 185, 129); // Emerald Green
                button1.ForeColor = Color.White;
            }
            else
            {
                button1.Enabled = false;
                button1.BackColor = Color.FromArgb(200, 205, 210); // Back to Gray
                button1.ForeColor = Color.White;
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValidateLogin();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}
