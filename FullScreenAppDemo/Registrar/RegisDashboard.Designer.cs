﻿namespace FullScreenAppDemo
{
    partial class RegisDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBTN = new Guna.UI.WinForms.GunaButton();
            this.MinimizedBTN = new Guna.UI.WinForms.GunaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.DeanBTN = new Guna.UI.WinForms.GunaButton();
            this.StudentBTN = new Guna.UI.WinForms.GunaButton();
            this.InstructorBTN = new Guna.UI.WinForms.GunaButton();
            this.DashboardBTN = new Guna.UI.WinForms.GunaButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DashboardPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.CloseBTN);
            this.panel1.Controls.Add(this.MinimizedBTN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 52);
            this.panel1.TabIndex = 5;
            // 
            // CloseBTN
            // 
            this.CloseBTN.AnimationHoverSpeed = 0.07F;
            this.CloseBTN.AnimationSpeed = 0.03F;
            this.CloseBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CloseBTN.BorderColor = System.Drawing.Color.Black;
            this.CloseBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.CloseBTN.FocusedColor = System.Drawing.Color.Empty;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Image = ((System.Drawing.Image)(resources.GetObject("CloseBTN.Image")));
            this.CloseBTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CloseBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.CloseBTN.Location = new System.Drawing.Point(1320, 8);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.OnHoverBaseColor = System.Drawing.Color.Red;
            this.CloseBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.CloseBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.CloseBTN.OnHoverImage = null;
            this.CloseBTN.OnPressedColor = System.Drawing.Color.Black;
            this.CloseBTN.Size = new System.Drawing.Size(42, 38);
            this.CloseBTN.TabIndex = 4;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // MinimizedBTN
            // 
            this.MinimizedBTN.AnimationHoverSpeed = 0.07F;
            this.MinimizedBTN.AnimationSpeed = 0.03F;
            this.MinimizedBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.MinimizedBTN.BorderColor = System.Drawing.Color.Black;
            this.MinimizedBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.MinimizedBTN.FocusedColor = System.Drawing.Color.Empty;
            this.MinimizedBTN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimizedBTN.ForeColor = System.Drawing.Color.Gray;
            this.MinimizedBTN.Image = ((System.Drawing.Image)(resources.GetObject("MinimizedBTN.Image")));
            this.MinimizedBTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MinimizedBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.MinimizedBTN.Location = new System.Drawing.Point(1272, 8);
            this.MinimizedBTN.Name = "MinimizedBTN";
            this.MinimizedBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.MinimizedBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.MinimizedBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.MinimizedBTN.OnHoverImage = null;
            this.MinimizedBTN.OnPressedColor = System.Drawing.Color.Black;
            this.MinimizedBTN.Size = new System.Drawing.Size(42, 38);
            this.MinimizedBTN.TabIndex = 3;
            this.MinimizedBTN.Click += new System.EventHandler(this.MinimizedBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(60, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Break Tasks Down Into Small Steps";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gold;
            this.label18.Location = new System.Drawing.Point(574, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(331, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "STUDENT PORTAL GRADE VIEWER SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(60, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CRMC STUDENT PORTAL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.gunaButton1);
            this.panel2.Controls.Add(this.DeanBTN);
            this.panel2.Controls.Add(this.StudentBTN);
            this.panel2.Controls.Add(this.InstructorBTN);
            this.panel2.Controls.Add(this.DashboardBTN);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 736);
            this.panel2.TabIndex = 5;
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.gunaButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gunaButton1.ForeColor = System.Drawing.Color.Gray;
            this.gunaButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaButton1.Image")));
            this.gunaButton1.ImageOffsetX = 5;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(10, 411);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("gunaButton1.OnHoverImage")));
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 20;
            this.gunaButton1.Size = new System.Drawing.Size(177, 45);
            this.gunaButton1.TabIndex = 12;
            this.gunaButton1.Text = "Subject";
            this.gunaButton1.TextOffsetX = 10;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // DeanBTN
            // 
            this.DeanBTN.AnimationHoverSpeed = 0.07F;
            this.DeanBTN.AnimationSpeed = 0.03F;
            this.DeanBTN.BackColor = System.Drawing.Color.Transparent;
            this.DeanBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DeanBTN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.DeanBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DeanBTN.FocusedColor = System.Drawing.Color.Empty;
            this.DeanBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.DeanBTN.ForeColor = System.Drawing.Color.Gray;
            this.DeanBTN.Image = ((System.Drawing.Image)(resources.GetObject("DeanBTN.Image")));
            this.DeanBTN.ImageOffsetX = 5;
            this.DeanBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.DeanBTN.Location = new System.Drawing.Point(10, 353);
            this.DeanBTN.Name = "DeanBTN";
            this.DeanBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.DeanBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.DeanBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.DeanBTN.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("DeanBTN.OnHoverImage")));
            this.DeanBTN.OnPressedColor = System.Drawing.Color.Black;
            this.DeanBTN.Radius = 20;
            this.DeanBTN.Size = new System.Drawing.Size(177, 45);
            this.DeanBTN.TabIndex = 11;
            this.DeanBTN.Text = "Dean";
            this.DeanBTN.TextOffsetX = 10;
            this.DeanBTN.Click += new System.EventHandler(this.DeanBTN_Click);
            // 
            // StudentBTN
            // 
            this.StudentBTN.AnimationHoverSpeed = 0.07F;
            this.StudentBTN.AnimationSpeed = 0.03F;
            this.StudentBTN.BackColor = System.Drawing.Color.Transparent;
            this.StudentBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.StudentBTN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.StudentBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.StudentBTN.FocusedColor = System.Drawing.Color.Empty;
            this.StudentBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.StudentBTN.ForeColor = System.Drawing.Color.Gray;
            this.StudentBTN.Image = ((System.Drawing.Image)(resources.GetObject("StudentBTN.Image")));
            this.StudentBTN.ImageOffsetX = 5;
            this.StudentBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.StudentBTN.Location = new System.Drawing.Point(10, 234);
            this.StudentBTN.Name = "StudentBTN";
            this.StudentBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.StudentBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.StudentBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.StudentBTN.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("StudentBTN.OnHoverImage")));
            this.StudentBTN.OnPressedColor = System.Drawing.Color.Black;
            this.StudentBTN.Radius = 20;
            this.StudentBTN.Size = new System.Drawing.Size(177, 45);
            this.StudentBTN.TabIndex = 10;
            this.StudentBTN.Text = "Student";
            this.StudentBTN.TextOffsetX = 10;
            this.StudentBTN.Click += new System.EventHandler(this.StudentBTN_Click);
            // 
            // InstructorBTN
            // 
            this.InstructorBTN.AnimationHoverSpeed = 0.07F;
            this.InstructorBTN.AnimationSpeed = 0.03F;
            this.InstructorBTN.BackColor = System.Drawing.Color.Transparent;
            this.InstructorBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.InstructorBTN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.InstructorBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.InstructorBTN.FocusedColor = System.Drawing.Color.Empty;
            this.InstructorBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.InstructorBTN.ForeColor = System.Drawing.Color.Gray;
            this.InstructorBTN.Image = ((System.Drawing.Image)(resources.GetObject("InstructorBTN.Image")));
            this.InstructorBTN.ImageOffsetX = 5;
            this.InstructorBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.InstructorBTN.Location = new System.Drawing.Point(10, 293);
            this.InstructorBTN.Name = "InstructorBTN";
            this.InstructorBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.InstructorBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.InstructorBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.InstructorBTN.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("InstructorBTN.OnHoverImage")));
            this.InstructorBTN.OnPressedColor = System.Drawing.Color.Black;
            this.InstructorBTN.Radius = 20;
            this.InstructorBTN.Size = new System.Drawing.Size(177, 45);
            this.InstructorBTN.TabIndex = 8;
            this.InstructorBTN.Text = "Instructor";
            this.InstructorBTN.TextOffsetX = 10;
            this.InstructorBTN.Click += new System.EventHandler(this.InstructorBTN_Click);
            // 
            // DashboardBTN
            // 
            this.DashboardBTN.AnimationHoverSpeed = 0.07F;
            this.DashboardBTN.AnimationSpeed = 0.03F;
            this.DashboardBTN.BackColor = System.Drawing.Color.Transparent;
            this.DashboardBTN.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DashboardBTN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.DashboardBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DashboardBTN.FocusedColor = System.Drawing.Color.Empty;
            this.DashboardBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.DashboardBTN.ForeColor = System.Drawing.Color.Gray;
            this.DashboardBTN.Image = ((System.Drawing.Image)(resources.GetObject("DashboardBTN.Image")));
            this.DashboardBTN.ImageOffsetX = 5;
            this.DashboardBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.DashboardBTN.Location = new System.Drawing.Point(10, 177);
            this.DashboardBTN.Name = "DashboardBTN";
            this.DashboardBTN.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.DashboardBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.DashboardBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.DashboardBTN.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("DashboardBTN.OnHoverImage")));
            this.DashboardBTN.OnPressedColor = System.Drawing.Color.Black;
            this.DashboardBTN.Radius = 20;
            this.DashboardBTN.Size = new System.Drawing.Size(177, 45);
            this.DashboardBTN.TabIndex = 7;
            this.DashboardBTN.Text = "Dashboard";
            this.DashboardBTN.TextOffsetX = 10;
            this.DashboardBTN.Click += new System.EventHandler(this.DashboardBTN_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gunaCirclePictureBox1);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(195, 138);
            this.panel4.TabIndex = 6;
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.ErrorImage = null;
            this.gunaCirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaCirclePictureBox1.Image")));
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(63, 17);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(58, 58);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaCirclePictureBox1.TabIndex = 3;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(76, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Admin";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Registrar\'s Office";
            // 
            // DashboardPanel
            // 
            this.DashboardPanel.Location = new System.Drawing.Point(193, 52);
            this.DashboardPanel.Name = "DashboardPanel";
            this.DashboardPanel.Size = new System.Drawing.Size(1175, 736);
            this.DashboardPanel.TabIndex = 6;
            // 
            // RegisDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 788);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DashboardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisDashboard";
            this.Text = "RegisDashboard";
            this.Load += new System.EventHandler(this.RegisDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaButton DashboardBTN;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton StudentBTN;
        private Guna.UI.WinForms.GunaButton InstructorBTN;
        private Guna.UI.WinForms.GunaButton DeanBTN;
        private Guna.UI.WinForms.GunaButton CloseBTN;
        private Guna.UI.WinForms.GunaButton MinimizedBTN;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        public System.Windows.Forms.Panel DashboardPanel;
    }
}