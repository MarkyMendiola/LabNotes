namespace Labnote
{
    partial class Booklab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booklab));
            panel1 = new Panel();
            button6 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            main = new Button();
            label11 = new Label();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            panelCard = new Panel();
            label3 = new Label();
            panelHeaderLine = new Panel();
            tableTop = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            lblLab = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            label5 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            label7 = new Label();
            label8 = new Label();
            panel6 = new Panel();
            panel7 = new Panel();
            label9 = new Label();
            label10 = new Label();
            panel8 = new Panel();
            panel9 = new Panel();
            label12 = new Label();
            label13 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            label14 = new Label();
            label15 = new Label();
            panel12 = new Panel();
            tableBottom = new TableLayoutPanel();
            lblSubject = new Label();
            lblSection = new Label();
            lblSoftware = new Label();
            txtSubject = new TextBox();
            txtSection = new TextBox();
            comboSoftware = new ComboBox();
            panelFooterLine = new Panel();
            button7 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelCard.SuspendLayout();
            tableTop.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            tableBottom.SuspendLayout();
            SuspendLayout();
            //
            // panel1  (the side menu)
            //
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(main);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 768);
            panel1.TabIndex = 9;
            //
            // button6  (Log out)
            //
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(25, 728);
            button6.Name = "button6";
            button6.Size = new Size(75, 28);
            button6.TabIndex = 8;
            button6.Text = "Log out";
            button6.UseVisualStyleBackColor = true;
            //
            // button3  (Book a Lab)
            //
            button3.Anchor = AnchorStyles.Left;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(25, 390);
            button3.Name = "button3";
            button3.Size = new Size(174, 31);
            button3.TabIndex = 5;
            button3.Text = "Book a Lab";
            button3.UseVisualStyleBackColor = true;
            //
            // button2  (Computer Labs)
            //
            button2.Anchor = AnchorStyles.Left;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(25, 338);
            button2.Name = "button2";
            button2.Size = new Size(174, 30);
            button2.TabIndex = 4;
            button2.Text = "Computer Labs";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            //
            // button1  (Schedule)
            //
            button1.Anchor = AnchorStyles.Left;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(25, 279);
            button1.Name = "button1";
            button1.Size = new Size(174, 34);
            button1.TabIndex = 3;
            button1.Text = "Schedule";
            button1.UseVisualStyleBackColor = true;
            //
            // main  (Main)
            //
            main.Anchor = AnchorStyles.Left;
            main.BackColor = SystemColors.ControlLightLight;
            main.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            main.ForeColor = SystemColors.ControlText;
            main.Location = new Point(25, 226);
            main.Name = "main";
            main.Size = new Size(174, 30);
            main.TabIndex = 2;
            main.Text = "Main";
            main.UseVisualStyleBackColor = false;
            main.Click += main_Click;
            //
            // label11  (LABNOTES)
            //
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlText;
            label11.Location = new Point(80, 75);
            label11.Name = "label11";
            label11.Size = new Size(119, 30);
            label11.TabIndex = 1;
            label11.Text = "LABNOTES";
            //
            // pictureBox1  (logo)
            //
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // panel4  (gray divider)
            //
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Location = new Point(236, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 768);
            panel4.TabIndex = 12;
            //
            // panelCard  (the white card: stretches in all four directions)
            //
            panelCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCard.BackColor = SystemColors.ControlLightLight;
            panelCard.Controls.Add(label3);
            panelCard.Controls.Add(panelHeaderLine);
            panelCard.Controls.Add(tableTop);
            panelCard.Controls.Add(lblLab);
            panelCard.Controls.Add(flowLayoutPanel1);
            panelCard.Controls.Add(tableBottom);
            panelCard.Controls.Add(panelFooterLine);
            panelCard.Controls.Add(button7);
            panelCard.Location = new Point(266, 60);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(940, 640);
            panelCard.TabIndex = 22;
            //
            // label3  (title)
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 20);
            label3.Name = "label3";
            label3.Size = new Size(173, 37);
            label3.TabIndex = 13;
            label3.Text = "Book a Lab";
            //
            // panelHeaderLine  (stretches sideways with the card)
            //
            panelHeaderLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeaderLine.BackColor = Color.Gainsboro;
            panelHeaderLine.Location = new Point(0, 80);
            panelHeaderLine.Name = "panelHeaderLine";
            panelHeaderLine.Size = new Size(940, 1);
            panelHeaderLine.TabIndex = 23;
            //
            // tableTop  (Date / Start / End: three equal columns that share the card width)
            //
            tableTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableTop.ColumnCount = 3;
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableTop.Controls.Add(label1, 0, 0);
            tableTop.Controls.Add(label2, 1, 0);
            tableTop.Controls.Add(label4, 2, 0);
            tableTop.Controls.Add(comboBox1, 0, 1);
            tableTop.Controls.Add(comboBox2, 1, 1);
            tableTop.Controls.Add(comboBox3, 2, 1);
            tableTop.Location = new Point(24, 100);
            tableTop.Name = "tableTop";
            tableTop.RowCount = 2;
            tableTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableTop.Size = new Size(892, 66);
            tableTop.TabIndex = 30;
            //
            // label1  (Date)
            //
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 19);
            label1.TabIndex = 0;
            label1.Text = "Date";
            //
            // label2  (Start)
            //
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 19);
            label2.TabIndex = 1;
            label2.Text = "Start";
            //
            // label4  (End)
            //
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Name = "label4";
            label4.Size = new Size(33, 19);
            label4.TabIndex = 2;
            label4.Text = "End";
            //
            // comboBox1  (Date)
            //
            comboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Margin = new Padding(0, 3, 14, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(283, 29);
            comboBox1.TabIndex = 3;
            //
            // comboBox2  (Start)
            //
            comboBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Margin = new Padding(0, 3, 14, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(283, 29);
            comboBox2.TabIndex = 4;
            //
            // comboBox3  (End)
            //
            comboBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox3.FormattingEnabled = true;
            comboBox3.Margin = new Padding(0, 3, 0, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(283, 29);
            comboBox3.TabIndex = 5;
            //
            // lblLab
            //
            lblLab.AutoSize = true;
            lblLab.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLab.Location = new Point(24, 184);
            lblLab.Name = "lblLab";
            lblLab.Size = new Size(87, 19);
            lblLab.TabIndex = 24;
            lblLab.Text = "Computer Lab";
            //
            // flowLayoutPanel1  (the five lab cards)
            //
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = SystemColors.ControlLightLight;
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(panel7);
            flowLayoutPanel1.Controls.Add(panel9);
            flowLayoutPanel1.Controls.Add(panel11);
            flowLayoutPanel1.Location = new Point(24, 210);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(892, 165);
            flowLayoutPanel1.TabIndex = 15;
            //
            // panel2  (lab card 1: 160 wide, the name label is the same width as the card)
            //
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(panel3);
            panel2.Margin = new Padding(0, 0, 16, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(160, 145);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            //
            // label5  (lab name: fits inside the card and wraps to a second line if it is long)
            //
            label5.AutoSize = false;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(0, 30);
            label5.Name = "label5";
            label5.Size = new Size(160, 55);
            label5.TabIndex = 16;
            label5.Text = "Comlab 1";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label6  (status: wide enough for "Available")
            //
            label6.AutoSize = false;
            label6.BackColor = Color.PaleGreen;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 100);
            label6.Name = "label6";
            label6.Size = new Size(100, 26);
            label6.TabIndex = 17;
            label6.Text = "Available";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel3  (color chip)
            //
            panel3.BackColor = Color.LightGreen;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(160, 8);
            panel3.TabIndex = 18;
            //
            // panel5  (lab card 2)
            //
            panel5.BackColor = SystemColors.MenuHighlight;
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(panel6);
            panel5.Margin = new Padding(0, 0, 16, 20);
            panel5.Name = "panel5";
            panel5.Size = new Size(160, 145);
            panel5.TabIndex = 17;
            //
            // label7
            //
            label7.AutoSize = false;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(0, 30);
            label7.Name = "label7";
            label7.Size = new Size(160, 55);
            label7.TabIndex = 16;
            label7.Text = "Comlab 2";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label8
            //
            label8.AutoSize = false;
            label8.BackColor = Color.PaleGreen;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(30, 100);
            label8.Name = "label8";
            label8.Size = new Size(100, 26);
            label8.TabIndex = 17;
            label8.Text = "Available";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel6
            //
            panel6.BackColor = Color.LightGreen;
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(160, 8);
            panel6.TabIndex = 18;
            //
            // panel7  (lab card 3)
            //
            panel7.BackColor = SystemColors.MenuHighlight;
            panel7.Controls.Add(label9);
            panel7.Controls.Add(label10);
            panel7.Controls.Add(panel8);
            panel7.Margin = new Padding(0, 0, 16, 20);
            panel7.Name = "panel7";
            panel7.Size = new Size(160, 145);
            panel7.TabIndex = 17;
            //
            // label9
            //
            label9.AutoSize = false;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(0, 30);
            label9.Name = "label9";
            label9.Size = new Size(160, 55);
            label9.TabIndex = 16;
            label9.Text = "Comlab 3";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label10
            //
            label10.AutoSize = false;
            label10.BackColor = Color.Salmon;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(30, 100);
            label10.Name = "label10";
            label10.Size = new Size(100, 26);
            label10.TabIndex = 17;
            label10.Text = "In Use";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel8
            //
            panel8.BackColor = Color.Salmon;
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(160, 8);
            panel8.TabIndex = 18;
            //
            // panel9  (lab card 4)
            //
            panel9.BackColor = SystemColors.MenuHighlight;
            panel9.Controls.Add(label12);
            panel9.Controls.Add(label13);
            panel9.Controls.Add(panel10);
            panel9.Margin = new Padding(0, 0, 16, 20);
            panel9.Name = "panel9";
            panel9.Size = new Size(160, 145);
            panel9.TabIndex = 17;
            //
            // label12
            //
            label12.AutoSize = false;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(0, 30);
            label12.Name = "label12";
            label12.Size = new Size(160, 55);
            label12.TabIndex = 16;
            label12.Text = "Comlab 4";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label13
            //
            label13.AutoSize = false;
            label13.BackColor = Color.Salmon;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(30, 100);
            label13.Name = "label13";
            label13.Size = new Size(100, 26);
            label13.TabIndex = 17;
            label13.Text = "In Use";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel10
            //
            panel10.BackColor = Color.Salmon;
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(160, 8);
            panel10.TabIndex = 18;
            //
            // panel11  (lab card 5)
            //
            panel11.BackColor = SystemColors.MenuHighlight;
            panel11.Controls.Add(label14);
            panel11.Controls.Add(label15);
            panel11.Controls.Add(panel12);
            panel11.Margin = new Padding(0, 0, 16, 20);
            panel11.Name = "panel11";
            panel11.Size = new Size(160, 145);
            panel11.TabIndex = 17;
            //
            // label14
            //
            label14.AutoSize = false;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ControlLightLight;
            label14.Location = new Point(0, 30);
            label14.Name = "label14";
            label14.Size = new Size(160, 55);
            label14.TabIndex = 16;
            label14.Text = "Comlab 5";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label15
            //
            label15.AutoSize = false;
            label15.BackColor = Color.PaleGreen;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(30, 100);
            label15.Name = "label15";
            label15.Size = new Size(100, 26);
            label15.TabIndex = 17;
            label15.Text = "Available";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panel12
            //
            panel12.BackColor = Color.LightGreen;
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(160, 8);
            panel12.TabIndex = 18;
            //
            // tableBottom  (Class name / Section / Needs software: same three-column layout)
            //
            tableBottom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableBottom.ColumnCount = 3;
            tableBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableBottom.Controls.Add(lblSubject, 0, 0);
            tableBottom.Controls.Add(lblSection, 1, 0);
            tableBottom.Controls.Add(lblSoftware, 2, 0);
            tableBottom.Controls.Add(txtSubject, 0, 1);
            tableBottom.Controls.Add(txtSection, 1, 1);
            tableBottom.Controls.Add(comboSoftware, 2, 1);
            tableBottom.Location = new Point(24, 394);
            tableBottom.Name = "tableBottom";
            tableBottom.RowCount = 2;
            tableBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableBottom.Size = new Size(892, 66);
            tableBottom.TabIndex = 31;
            //
            // lblSubject
            //
            lblSubject.Anchor = AnchorStyles.Left;
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(80, 19);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Class name";
            //
            // lblSection
            //
            lblSection.Anchor = AnchorStyles.Left;
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(56, 19);
            lblSection.TabIndex = 1;
            lblSection.Text = "Section";
            //
            // lblSoftware
            //
            lblSoftware.Anchor = AnchorStyles.Left;
            lblSoftware.AutoSize = true;
            lblSoftware.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoftware.Name = "lblSoftware";
            lblSoftware.Size = new Size(104, 19);
            lblSoftware.TabIndex = 2;
            lblSoftware.Text = "Needs software";
            //
            // txtSubject
            //
            txtSubject.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSubject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSubject.Margin = new Padding(0, 3, 14, 3);
            txtSubject.MaxLength = 50;
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "e.g. CC102";
            txtSubject.Size = new Size(283, 29);
            txtSubject.TabIndex = 3;
            //
            // txtSection
            //
            txtSection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSection.Margin = new Padding(0, 3, 14, 3);
            txtSection.MaxLength = 10;
            txtSection.Name = "txtSection";
            txtSection.PlaceholderText = "e.g. BSIT 1-1";
            txtSection.Size = new Size(283, 29);
            txtSection.TabIndex = 4;
            //
            // comboSoftware  (dropdown of the software the labs have)
            //
            comboSoftware.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboSoftware.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSoftware.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboSoftware.FormattingEnabled = true;
            comboSoftware.Margin = new Padding(0, 3, 0, 3);
            comboSoftware.Name = "comboSoftware";
            comboSoftware.Size = new Size(283, 29);
            comboSoftware.TabIndex = 5;
            //
            // panelFooterLine  (sticks to the bottom of the card and stretches sideways)
            //
            panelFooterLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooterLine.BackColor = Color.Gainsboro;
            panelFooterLine.Location = new Point(0, 552);
            panelFooterLine.Name = "panelFooterLine";
            panelFooterLine.Size = new Size(940, 1);
            panelFooterLine.TabIndex = 27;
            //
            // button7  (Add booking: sticks to the bottom right corner of the card)
            //
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button7.BackColor = SystemColors.MenuHighlight;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(738, 574);
            button7.Name = "button7";
            button7.Size = new Size(178, 44);
            button7.TabIndex = 17;
            button7.Text = "Add booking";
            button7.UseVisualStyleBackColor = false;
            //
            // Booklab
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panelCard);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Booklab";
            Size = new Size(1228, 768);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            tableTop.ResumeLayout(false);
            tableTop.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel11.ResumeLayout(false);
            tableBottom.ResumeLayout(false);
            tableBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button main;
        private Label label11;
        private PictureBox pictureBox1;
        private Button button6;
        private Panel panel4;
        private Panel panelCard;
        private Panel panelHeaderLine;
        private Panel panelFooterLine;
        private TableLayoutPanel tableTop;
        private TableLayoutPanel tableBottom;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label lblLab;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Label label6;
        private Label label5;
        private Panel panel3;
        private Panel panel5;
        private Label label7;
        private Label label8;
        private Panel panel6;
        private Panel panel7;
        private Label label9;
        private Label label10;
        private Panel panel8;
        private Panel panel9;
        private Label label12;
        private Label label13;
        private Panel panel10;
        private Panel panel11;
        private Label label14;
        private Label label15;
        private Panel panel12;
        private Button button7;
        private Label lblSubject;
        private TextBox txtSubject;
        private Label lblSection;
        private TextBox txtSection;
        private Label lblSoftware;
        private ComboBox comboSoftware;
    }
}
