namespace Library_Management_System
{
    partial class addBorrowings
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
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.addLibrariansButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.minimizeButton.Location = new System.Drawing.Point(924, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(54, 56);
            this.minimizeButton.TabIndex = 17;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.closeButton.Location = new System.Drawing.Point(984, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(54, 56);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.titleLabel.Location = new System.Drawing.Point(368, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(283, 34);
            this.titleLabel.TabIndex = 15;
            this.titleLabel.Text = "Add New Borrowing";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(50, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(928, 502);
            this.panel5.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.addLibrariansButton);
            this.panel6.Controls.Add(this.cancelButton);
            this.panel6.Location = new System.Drawing.Point(144, 350);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(644, 49);
            this.panel6.TabIndex = 11;
            // 
            // addLibrariansButton
            // 
            this.addLibrariansButton.AutoSize = true;
            this.addLibrariansButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(181)))), ((int)(((byte)(74)))));
            this.addLibrariansButton.FlatAppearance.BorderSize = 0;
            this.addLibrariansButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addLibrariansButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLibrariansButton.ForeColor = System.Drawing.Color.White;
            this.addLibrariansButton.Location = new System.Drawing.Point(7, 3);
            this.addLibrariansButton.Name = "addLibrariansButton";
            this.addLibrariansButton.Size = new System.Drawing.Size(230, 40);
            this.addLibrariansButton.TabIndex = 0;
            this.addLibrariansButton.Text = "Add";
            this.addLibrariansButton.UseVisualStyleBackColor = false;
            this.addLibrariansButton.Click += new System.EventHandler(this.addLibrariansButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(346, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(230, 40);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userIdTextBox);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Location = new System.Drawing.Point(144, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 39);
            this.panel1.TabIndex = 8;
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userIdTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.userIdTextBox.Location = new System.Drawing.Point(251, 4);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(325, 25);
            this.userIdTextBox.TabIndex = 7;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.idLabel.Location = new System.Drawing.Point(3, 6);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(77, 23);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "User ID";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.isbnTextBox);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Location = new System.Drawing.Point(144, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 40);
            this.panel2.TabIndex = 8;
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.isbnTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isbnTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.isbnTextBox.Location = new System.Drawing.Point(251, 6);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(325, 25);
            this.isbnTextBox.TabIndex = 7;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.nameLabel.Location = new System.Drawing.Point(3, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(122, 23);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Book\'s ISBN";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dateTimePicker2);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(144, 252);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(644, 40);
            this.panel7.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(251, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Returning Date";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.passwordLabel);
            this.panel3.Location = new System.Drawing.Point(144, 206);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 40);
            this.panel3.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(251, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 14;
            this.dateTimePicker1.Value = new System.DateTime(2023, 5, 28, 21, 12, 56, 0);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.passwordLabel.Location = new System.Drawing.Point(3, 6);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(209, 23);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Borrowing Date,Time";
            // 
            // addBorrowings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 649);
            this.ControlBox = false;
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addBorrowings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addBorrowings";
            this.Load += new System.EventHandler(this.addBorrowings_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button addLibrariansButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}