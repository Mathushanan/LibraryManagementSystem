namespace Library_Management_System
{
    partial class manageMembers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.librariansDataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.addMemberButton = new System.Windows.Forms.Button();
            this.viewAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.librariansDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // librariansDataGrid
            // 
            this.librariansDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.librariansDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.librariansDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.librariansDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.librariansDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.librariansDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.librariansDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.librariansDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.librariansDataGrid.Location = new System.Drawing.Point(12, 186);
            this.librariansDataGrid.Name = "librariansDataGrid";
            this.librariansDataGrid.ReadOnly = true;
            this.librariansDataGrid.RowHeadersVisible = false;
            this.librariansDataGrid.RowHeadersWidth = 51;
            this.librariansDataGrid.RowTemplate.Height = 24;
            this.librariansDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.librariansDataGrid.Size = new System.Drawing.Size(1050, 440);
            this.librariansDataGrid.TabIndex = 5;
            this.librariansDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.librariansDataGrid_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.addMemberButton);
            this.panel2.Controls.Add(this.viewAllButton);
            this.panel2.Location = new System.Drawing.Point(33, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 106);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 95);
            this.panel1.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(181)))), ((int)(((byte)(74)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(290, 31);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(179, 38);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.searchTextBox.Location = new System.Drawing.Point(3, 31);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(281, 37);
            this.searchTextBox.TabIndex = 0;
            // 
            // addMemberButton
            // 
            this.addMemberButton.AutoSize = true;
            this.addMemberButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(196)))), ((int)(((byte)(227)))));
            this.addMemberButton.FlatAppearance.BorderSize = 0;
            this.addMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMemberButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMemberButton.ForeColor = System.Drawing.Color.White;
            this.addMemberButton.Location = new System.Drawing.Point(797, 33);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(179, 38);
            this.addMemberButton.TabIndex = 3;
            this.addMemberButton.Text = "Add Member";
            this.addMemberButton.UseVisualStyleBackColor = false;
            this.addMemberButton.Click += new System.EventHandler(this.addMemberButton_Click);
            // 
            // viewAllButton
            // 
            this.viewAllButton.AutoSize = true;
            this.viewAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.viewAllButton.FlatAppearance.BorderSize = 0;
            this.viewAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAllButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAllButton.ForeColor = System.Drawing.Color.White;
            this.viewAllButton.Location = new System.Drawing.Point(550, 34);
            this.viewAllButton.Name = "viewAllButton";
            this.viewAllButton.Size = new System.Drawing.Size(179, 38);
            this.viewAllButton.TabIndex = 3;
            this.viewAllButton.Text = "View All";
            this.viewAllButton.UseVisualStyleBackColor = false;
            this.viewAllButton.Click += new System.EventHandler(this.viewAllButton_Click);
            // 
            // manageMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.librariansDataGrid);
            this.Name = "manageMembers";
            this.Text = "manageMembers";
            this.Load += new System.EventHandler(this.manageMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.librariansDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView librariansDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.Button viewAllButton;
    }
}