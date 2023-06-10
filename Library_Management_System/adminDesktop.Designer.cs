namespace Library_Management_System
{
    partial class adminDesktop
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
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logOutButton = new System.Windows.Forms.Button();
            this.manageLibrariansButton = new System.Windows.Forms.Button();
            this.addLibrariansButton = new System.Windows.Forms.Button();
            this.dashBoardButton = new System.Windows.Forms.Button();
            this.menuHeaderPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.desktopPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuHeaderPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.desktopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.closeButton.Location = new System.Drawing.Point(1033, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(56, 56);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.minimizeButton.Location = new System.Drawing.Point(971, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(56, 56);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.menuPanel.Controls.Add(this.panel2);
            this.menuPanel.Controls.Add(this.menuHeaderPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(408, 800);
            this.menuPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logOutButton);
            this.panel2.Controls.Add(this.manageLibrariansButton);
            this.panel2.Controls.Add(this.addLibrariansButton);
            this.panel2.Controls.Add(this.dashBoardButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 528);
            this.panel2.TabIndex = 8;
            // 
            // logOutButton
            // 
            this.logOutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.logOutButton.FlatAppearance.BorderSize = 0;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.LightGray;
            this.logOutButton.Location = new System.Drawing.Point(0, 180);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(408, 60);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "LogOut";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // manageLibrariansButton
            // 
            this.manageLibrariansButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.manageLibrariansButton.FlatAppearance.BorderSize = 0;
            this.manageLibrariansButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageLibrariansButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageLibrariansButton.ForeColor = System.Drawing.Color.LightGray;
            this.manageLibrariansButton.Location = new System.Drawing.Point(0, 120);
            this.manageLibrariansButton.Name = "manageLibrariansButton";
            this.manageLibrariansButton.Size = new System.Drawing.Size(408, 60);
            this.manageLibrariansButton.TabIndex = 7;
            this.manageLibrariansButton.Text = "Manage Users";
            this.manageLibrariansButton.UseVisualStyleBackColor = true;
            this.manageLibrariansButton.Click += new System.EventHandler(this.manageLibrariansButton_Click);
            // 
            // addLibrariansButton
            // 
            this.addLibrariansButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addLibrariansButton.FlatAppearance.BorderSize = 0;
            this.addLibrariansButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addLibrariansButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLibrariansButton.ForeColor = System.Drawing.Color.LightGray;
            this.addLibrariansButton.Location = new System.Drawing.Point(0, 60);
            this.addLibrariansButton.Name = "addLibrariansButton";
            this.addLibrariansButton.Size = new System.Drawing.Size(408, 60);
            this.addLibrariansButton.TabIndex = 5;
            this.addLibrariansButton.Text = "Add Librarians";
            this.addLibrariansButton.UseVisualStyleBackColor = true;
            this.addLibrariansButton.Click += new System.EventHandler(this.addLibrariansButton_Click);
            // 
            // dashBoardButton
            // 
            this.dashBoardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashBoardButton.FlatAppearance.BorderSize = 0;
            this.dashBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashBoardButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoardButton.ForeColor = System.Drawing.Color.LightGray;
            this.dashBoardButton.Location = new System.Drawing.Point(0, 0);
            this.dashBoardButton.Name = "dashBoardButton";
            this.dashBoardButton.Size = new System.Drawing.Size(408, 60);
            this.dashBoardButton.TabIndex = 5;
            this.dashBoardButton.Text = "Dash Board";
            this.dashBoardButton.UseVisualStyleBackColor = false;
            this.dashBoardButton.Click += new System.EventHandler(this.dashBoardButton_Click);
            // 
            // menuHeaderPanel
            // 
            this.menuHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(181)))), ((int)(((byte)(74)))));
            this.menuHeaderPanel.Controls.Add(this.titleLabel);
            this.menuHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.menuHeaderPanel.Name = "menuHeaderPanel";
            this.menuHeaderPanel.Size = new System.Drawing.Size(408, 100);
            this.menuHeaderPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(405, 97);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(408, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 100);
            this.panel1.TabIndex = 3;
            // 
            // desktopPanel
            // 
            this.desktopPanel.Controls.Add(this.welcomeLabel);
            this.desktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopPanel.Location = new System.Drawing.Point(408, 100);
            this.desktopPanel.Name = "desktopPanel";
            this.desktopPanel.Size = new System.Drawing.Size(1092, 700);
            this.desktopPanel.TabIndex = 4;
            this.desktopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.desktopPanel_Paint);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(181)))), ((int)(((byte)(74)))));
            this.welcomeLabel.Location = new System.Drawing.Point(329, 259);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(432, 93);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Management_System.Properties.Resources.nsbm;
            this.pictureBox1.Location = new System.Drawing.Point(471, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // adminDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.ControlBox = false;
            this.Controls.Add(this.desktopPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashBord";
            this.menuPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuHeaderPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.desktopPanel.ResumeLayout(false);
            this.desktopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button manageLibrariansButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button dashBoardButton;
        private System.Windows.Forms.Panel menuHeaderPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel desktopPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addLibrariansButton;
        private System.Windows.Forms.Label welcomeLabel;
    }
}