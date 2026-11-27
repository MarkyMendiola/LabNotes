namespace Labnote
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            panel1 = new Panel();
            button4 = new Button();
            booklab = new Button();
            comlab = new Button();
            schedule = new Button();
            main = new Button();
            label11 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(booklab);
            panel1.Controls.Add(comlab);
            panel1.Controls.Add(schedule);
            panel1.Controls.Add(main);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 730);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(25, 692);
            button4.Name = "button4";
            button4.Size = new Size(75, 28);
            button4.TabIndex = 6;
            button4.Text = "Log out";
            button4.UseVisualStyleBackColor = true;
            // 
            // booklab
            // 
            booklab.Anchor = AnchorStyles.Left;
            booklab.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            booklab.Location = new Point(25, 392);
            booklab.Name = "booklab";
            booklab.Size = new Size(174, 31);
            booklab.TabIndex = 5;
            booklab.Text = "Book a Lab";
            booklab.UseVisualStyleBackColor = true;
            booklab.Click += booklab_Click;
            // 
            // comlab
            // 
            comlab.Anchor = AnchorStyles.Left;
            comlab.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comlab.Location = new Point(25, 340);
            comlab.Name = "comlab";
            comlab.Size = new Size(174, 30);
            comlab.TabIndex = 4;
            comlab.Text = "Computer Labs";
            comlab.UseVisualStyleBackColor = true;
            comlab.Click += button2_Click;
            // 
            // schedule
            // 
            schedule.Anchor = AnchorStyles.Left;
            schedule.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            schedule.Location = new Point(25, 281);
            schedule.Name = "schedule";
            schedule.Size = new Size(174, 34);
            schedule.TabIndex = 3;
            schedule.Text = "Schedule";
            schedule.UseVisualStyleBackColor = true;
            schedule.Click += button1_Click;
            // 
            // main
            // 
            main.Anchor = AnchorStyles.Left;
            main.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            main.Location = new Point(25, 225);
            main.Name = "main";
            main.Size = new Size(174, 33);
            main.TabIndex = 7;
            main.Text = "Main";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlText;
            label11.Location = new Point(80, 75);
            label11.Name = "label11";
            label11.Size = new Size(119, 30);
            label11.TabIndex = 3;
            label11.Text = "LABNOTES";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(293, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(894, 213);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(543, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(326, 164);
            panel3.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(209, 118);
            label10.Name = "label10";
            label10.Size = new Size(108, 25);
            label10.TabIndex = 6;
            label10.Text = "PCs Broken";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.HotTrack;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Tomato;
            label9.Location = new Point(189, 118);
            label9.Name = "label9";
            label9.Size = new Size(23, 25);
            label9.TabIndex = 5;
            label9.Text = "1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(226, 93);
            label8.Name = "label8";
            label8.Size = new Size(91, 25);
            label8.TabIndex = 4;
            label8.Text = "Comlab 1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(232, 10);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 3;
            label7.Text = "11/19/26";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(3, 118);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 2;
            label6.Text = "BSIT 2-1";
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.BackColor = SystemColors.HotTrack;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(3, 93);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(62, 25);
            label5.TabIndex = 1;
            label5.Text = "CC101";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(3, 10);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 0;
            label4.Text = "Next Class";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HighlightText;
            label2.Location = new Point(3, 89);
            label2.Name = "label2";
            label2.Size = new Size(432, 65);
            label2.TabIndex = 1;
            label2.Text = "Bill Pogi Bernaldo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(13, 64);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 0;
            label1.Text = "Welcome back,";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(293, 24);
            label3.Name = "label3";
            label3.Size = new Size(252, 40);
            label3.TabIndex = 2;
            label3.Text = "Main Dashboard";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Location = new Point(234, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 730);
            panel4.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panel5, 0, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Controls.Add(panel7, 0, 1);
            tableLayoutPanel1.Controls.Add(panel8, 2, 0);
            tableLayoutPanel1.Location = new Point(283, 339);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.Size = new Size(915, 380);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaption;
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(10, 10);
            panel5.Margin = new Padding(10);
            panel5.Name = "panel5";
            panel5.Size = new Size(284, 151);
            panel5.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveBorder;
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(314, 10);
            panel6.Margin = new Padding(10);
            panel6.Name = "panel6";
            panel6.Size = new Size(284, 151);
            panel6.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ActiveBorder;
            tableLayoutPanel1.SetColumnSpan(panel7, 2);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(10, 181);
            panel7.Margin = new Padding(10);
            panel7.Name = "panel7";
            panel7.Size = new Size(588, 189);
            panel7.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveBorder;
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(618, 10);
            panel8.Margin = new Padding(10);
            panel8.Name = "panel8";
            tableLayoutPanel1.SetRowSpan(panel8, 2);
            panel8.Size = new Size(287, 360);
            panel8.TabIndex = 3;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1210, 729);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel4);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainWindow";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private PictureBox pictureBox1;
        private Label label11;
        private Button main;
        private Button booklab;
        private Button comlab;
        private Button schedule;
        private Button button4;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
    }
}
