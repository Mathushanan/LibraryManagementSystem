using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class addBorrowings : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public addBorrowings()
        {
            InitializeComponent();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {
            bool isBookIdValid = false;
            if (string.IsNullOrWhiteSpace(isbnTextBox.Text) || string.IsNullOrWhiteSpace(userIdTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string name = null;
                int count = 0;
                try
                {
                    
                    string query1 = "SELECT name FROM users WHERE userId=@userId AND userType=@userType ";
                    string query2 = "SELECT COUNT(*) FROM physicalbooks WHERE isbn=@isbn";
                    string query3 = "SELECT COUNT(*) FROM physicalbooks WHERE isbn=@isbn AND status=@status";

                    connection.Open();

                   
                    SqlCommand command = new SqlCommand(query2, connection);
                    command.Parameters.AddWithValue("@isbn", isbnTextBox.Text);

                    SqlCommand validateCommand = new SqlCommand(query3, connection);
                    validateCommand.Parameters.AddWithValue("@isbn", isbnTextBox.Text);
                    validateCommand.Parameters.AddWithValue("@status", "Available");
                    
                    count=Convert.ToInt32(validateCommand.ExecuteScalar());

                    SqlCommand getCommand = new SqlCommand(query1, connection);
                    getCommand.Parameters.AddWithValue("@userId", userIdTextBox.Text);
                    getCommand.Parameters.AddWithValue("@userType", "student");

                    SqlDataReader reader = null;

                    try
                    {
                        reader = getCommand.ExecuteReader();
                        if (reader.Read())
                        {

                            name = reader.GetString(0);
                            
                        }

                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }

                    }

                    if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    {
                        isBookIdValid = true;
                    }
                    else
                    {
                        isBookIdValid = false;
                    }




                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }


                if (name == null)
                {
                    MessageBox.Show("Member haven't registered yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (isBookIdValid==false)
                {
                    MessageBox.Show("Invalid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (count<1)
                {
                    MessageBox.Show("Book already borrowed!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string query2 = "INSERT INTO borrowings (userId,name,isbn,borrowDate,returnDate,status) VALUES (@userId,@name,@isbn,@borrowDate,@returnDate,@status)";
                        connection.Open();
                        SqlCommand command = new SqlCommand(query2, connection);
                        command.Parameters.AddWithValue("@userId", userIdTextBox.Text);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@status","Pending");
                        command.Parameters.AddWithValue("@isbn", isbnTextBox.Text);
                        command.Parameters.AddWithValue("@borrowDate", dateTimePicker1.Value.ToString());
                        command.Parameters.AddWithValue("@returnDate", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
                        if (command.ExecuteNonQuery() > 0)
                        {


                            try
                            {

                                string query = "UPDATE physicalbooks SET status=@status WHERE isbn=@isbn";
                                SqlCommand updateCommand = new SqlCommand(query, connection);
                                updateCommand.Parameters.AddWithValue("@status", "Borrowed");
                                updateCommand.Parameters.AddWithValue("@isbn", isbnTextBox.Text);

                                if (Convert.ToInt32(updateCommand.ExecuteNonQuery()) > 0)
                                {
                                    MessageBox.Show("Borrowing details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                            userIdTextBox.Text = "";
                            isbnTextBox.Text = "";
                            dateTimePicker2.Value = DateTime.Now;
                            dateTimePicker1.Value = DateTime.Now;
                            
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

               
            
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            userIdTextBox.Text = "";
            isbnTextBox.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void addBorrowings_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
