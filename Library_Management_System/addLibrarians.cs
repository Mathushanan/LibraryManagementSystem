using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class addLibrarians : Form
    {
        public addLibrarians()
        {
            InitializeComponent();
        }

        private void hiddenPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false;
        }

        private void hiddenPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            passwordTextBox.Text = "";
            confirmTextBox.Text = "";
            emailTextBox.Text = "";
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);
           

            if (string.IsNullOrWhiteSpace(idTextBox.Text) || string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(confirmTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordTextBox.Text!=confirmTextBox.Text)
            {
                MessageBox.Show("Entered password doesn't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                
                try
                {
                    int id = Convert.ToInt32(idTextBox.Text);
                    string name = nameTextBox.Text;
                    string email = emailTextBox.Text;
                    string password = passwordTextBox.Text;
                    string confirmPassword = confirmTextBox.Text;
                    string userType = "librarian";

                    connection.Open();
                    string query1 = "Select COUNT(*) FROM users WHERE email=@email";
                    MySqlCommand checkCommand = new MySqlCommand(query1, connection);
                    checkCommand.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count ==0)
                    {
                        
                        string query2 = "INSERT INTO users (userId,name,email,password,userType) VALUES (@id,@name,@email,@password,@userType)";
                        MySqlCommand cmd = new MySqlCommand(query2, connection);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@userType", userType);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Entry Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            idTextBox.Text = "";
                            nameTextBox.Text = "";
                            passwordTextBox.Text = "";
                            confirmTextBox.Text = "";
                            emailTextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username already exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }
    }
}
