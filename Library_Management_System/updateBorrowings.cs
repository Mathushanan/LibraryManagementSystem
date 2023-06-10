using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class updateBorrowings : Form
    {
        string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        string borrowingId;
        string userId;
        string name;
        string isbn;
        string borrowDate;
        string returnDate;
        string status;
        public updateBorrowings(string borrowingId, string userId, string name, string isbn, string borrowDate,string  returnDate, string status)
        {
            this.borrowingId = borrowingId;
            this.isbn = isbn;
            this.borrowDate = borrowDate;
            this.userId = userId;
            this.name = name;  
            this.returnDate = returnDate;   
            this.status = status;
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void updateBorrowings_Load(object sender, EventArgs e)
        {
            borrowingIdTextBox.Text = borrowingId;
            userIdTextBox.Text = userId;
            nameTextBox.Text = name;
            isbnTextBox.Text = isbn;

            dateTimePicker1.Value = DateTime.Parse(borrowDate);
            dateTimePicker2.Value = DateTime.Parse(returnDate);
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;

            List<string> itemList = new List<string>
            {
               "Pending",
               "Returned"
            };

            statusComboBox.DataSource = itemList;
            statusComboBox.SelectedItem = status;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string newStatus = statusComboBox.SelectedItem.ToString();

            if (status == "Pending" && newStatus == "Returned")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    MySqlCommand updateCommand = new MySqlCommand("UPDATE borrowings SET status=@status WHERE borrowingId=@borrowingId",connection);
                    updateCommand.Parameters.AddWithValue("@status", "Returned");
                    updateCommand.Parameters.AddWithValue("@borrowingId", borrowingId);

                    if (updateCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            else
            {
                this.Close();
            }

        }
    }
}
