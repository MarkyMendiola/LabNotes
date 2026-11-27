namespace Labnote
{
    partial class PCpage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PCtitle = new Label();
            button1 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PCtitle
            // 
            PCtitle.AutoSize = true;
            PCtitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PCtitle.Location = new Point(12, 9);
            PCtitle.Name = "PCtitle";
            PCtitle.Size = new Size(78, 40);
            PCtitle.TabIndex = 0;
            PCtitle.Text = "PC #";
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(617, 12);
            button1.Name = "button1";
            button1.Size = new Size(171, 45);
            button1.TabIndex = 1;
            button1.Text = "Report Issue";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Location = new Point(418, 206);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 232);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(418, 178);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 3;
            label1.Text = "Logs";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = SystemColors.HotTrack;
            linkLabel1.Location = new Point(684, 184);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(104, 17);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "view full history";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.MenuHighlight;
            flowLayoutPanel1.Location = new Point(12, 206);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(370, 232);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 176);
            label6.Name = "label6";
            label6.Size = new Size(174, 25);
            label6.TabIndex = 6;
            label6.Text = "Installed Softwares";
            // 
            // PCpage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(PCtitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PCpage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PCpage";
            Load += PCpage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PCtitle;
        private Button button1;
        private Panel panel1;
        private Label label1;
        private LinkLabel linkLabel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label6;
    }
}