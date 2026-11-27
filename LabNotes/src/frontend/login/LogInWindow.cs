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
    // The login screen. The app opens this first (see Frontend.Start in main.cs).
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AcceptButton = btnLogin;   // pressing Enter does the same as clicking "Log in"
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string password = txtPassword.Text;

            if (fullName == "" || password == "")
            {
                MessageBox.Show("Please type your full name and password.", Constants.AppTitle);
                return;
            }

            try
            {
                if (Auth.Login(fullName, password))
                {
                    new MainWindow().Show();   // open the dashboard
                    this.Hide();               // keep this form hidden behind it
                }
                else
                {
                    MessageBox.Show("Wrong full name or password.", Constants.AppTitle);
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reach the database:\n" + ex.Message, Constants.AppTitle);
            }
        }
    }
}
