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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

            AcceptButton = button1;

            button1.Enabled = false;
            button1.BackColor = Color.FromArgb(200, 205, 210);
            button1.ForeColor = Color.White;

            textBox1.TextChanged += textBox_TextChanged;
            textBox2.TextChanged += textBox_TextChanged;

            ValidateLogin();
        }

        private void ValidateLogin()
        {
            bool isComplete = !string.IsNullOrWhiteSpace(textBox1.Text)
                           && !string.IsNullOrWhiteSpace(textBox2.Text);

            button1.Enabled = isComplete;

            if (isComplete)
            {
                button1.BackColor = Color.FromArgb(16, 185, 129);
                button1.ForeColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.FromArgb(200, 205, 210);
                button1.ForeColor = Color.White;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (fullName == "" || password == "")
            {
                MessageBox.Show(
                    "Please type your full name and password.",
                    Constants.AppTitle
                );
                return;
            }

            try
            {
                if (Auth.Login(fullName, password))
                {
                    new MainWindow().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Wrong full name or password.",
                        Constants.AppTitle
                    );

                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not reach the database:\n" + ex.Message,
                    Constants.AppTitle
                );
            }
        }
    }
}