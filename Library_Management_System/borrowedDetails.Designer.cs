namespace Library_Management_System
{
    partial class borrowedDetails
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.newBorrowingButton = new System.Windows.Forms.Button();
            this.pendingButton = new System.Windows.Forms.Button();
            this.viewAllButton = new System.Windows.Forms.Button();
            this.borrowedDetailsDataGrid = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borrowedDetailsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchButton);
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.newBorrowingButton);
            this.panel2.Controls.Add(this.pendingButton);
            this.panel2.Controls.Add(this.viewAllButton);
            this.panel2.Location = new System.Drawing.Point(12, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 75);
            this.panel2.TabIndex = 5;
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(181)))), ((int)(((byte)(74)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(302, 16);
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
            this.searchTextBox.Location = new System.Drawing.Point(15, 16);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(281, 37);
            this.searchTextBox.TabIndex = 0;
            // 
            // newBorrowingButton
            // 
            this.newBorrowingButton.AutoSize = true;
            this.newBorrowingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(196)))), ((int)(((byte)(227)))));
            this.newBorrowingButton.FlatAppearance.BorderSize = 0;
            this.newBorrowingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newBorrowingButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBorrowingButton.ForeColor = System.Drawing.Color.White;
            this.newBorrowingButton.Location = new System.Drawing.Point(683, 16);
            this.newBorrowingButton.Name = "newBorrowingButton";
            this.newBorrowingButton.Size = new System.Drawing.Size(179, 38);
            this.newBorrowingButton.TabIndex = 3;
            this.newBorrowingButton.Text = "New Borrowing";
            this.newBorrowingButton.UseVisualStyleBackColor = false;
            this.newBorrowingButton.Click += new System.EventHandler(this.newBorrowingButton_Click);
            // 
            // pendingButton
            // 
            this.pendingButton.AutoSize = true;
            this.pendingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(63)))));
            this.pendingButton.FlatAppearance.BorderSize = 0;
            this.pendingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pendingButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingButton.ForeColor = System.Drawing.Color.White;
            this.pendingButton.Location = new System.Drawing.Point(868, 16);
            this.pendingButton.Name = "pendingButton";
            this.pendingButton.Size = new System.Drawing.Size(179, 38);
            this.pendingButton.TabIndex = 3;
            this.pendingButton.Text = "Pendings";
            this.pendingButton.UseVisualStyleBackColor = false;
            this.pendingButton.Click += new System.EventHandler(this.pendingButton_Click);
            // 
            // viewAllButton
            // 
            this.viewAllButton.AutoSize = true;
            this.viewAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.viewAllButton.FlatAppearance.BorderSize = 0;
            this.viewAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAllButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAllButton.ForeColor = System.Drawing.Color.White;
            this.viewAllButton.Location = new System.Drawing.Point(498, 16);
            this.viewAllButton.Name = "viewAllButton";
            this.viewAllButton.Size = new System.Drawing.Size(179, 38);
            this.viewAllButton.TabIndex = 3;
            this.viewAllButton.Text = "View All";
            this.viewAllButton.UseVisualStyleBackColor = false;
            this.viewAllButton.Click += new System.EventHandler(this.viewAllButton_Click);
            // 
            // borrowedDetailsDataGrid
            // 
            this.borrowedDetailsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.borrowedDetailsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.borrowedDetailsDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.borrowedDetailsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.borrowedDetailsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.borrowedDetailsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.borrowedDetailsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.borrowedDetailsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.borrowedDetailsDataGrid.Location = new System.Drawing.Point(12, 162);
            this.borrowedDetailsDataGrid.Name = "borrowedDetailsDataGrid";
            this.borrowedDetailsDataGrid.ReadOnly = true;
            this.borrowedDetailsDataGrid.RowHeadersVisible = false;
            this.borrowedDetailsDataGrid.RowHeadersWidth = 51;
            this.borrowedDetailsDataGrid.RowTemplate.Height = 24;
            this.borrowedDetailsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.borrowedDetailsDataGrid.Size = new System.Drawing.Size(1050, 479);
            this.borrowedDetailsDataGrid.TabIndex = 6;
            this.borrowedDetailsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.borrowedDetailsDataGrid_CellContentClick);
            // 
            // borrowedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 653);
            this.Controls.Add(this.borrowedDetailsDataGrid);
            this.Controls.Add(this.panel2);
            this.Name = "borrowedDetails";
            this.Text = "borrowedDetails";
            this.Load += new System.EventHandler(this.borrowedDetails_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borrowedDetailsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button viewAllButton;
        private System.Windows.Forms.DataGridView borrowedDetailsDataGrid;
        private System.Windows.Forms.Button newBorrowingButton;
        private System.Windows.Forms.Button pendingButton;
    }
}