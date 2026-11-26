using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labnote
{
    public partial class PCpage : Form
    {

        private string _pcName;
        private string _labName;

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

        private void PCpage_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
