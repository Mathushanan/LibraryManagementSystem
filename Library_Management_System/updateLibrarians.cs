using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library_Management_System
{
    public partial class updateLibrarians : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public updateLibrarians(string id, string name, string email, string password, string userType)
        {
            InitializeComponent();
            nameTextBox.Text = name;
            idTextBox.Text = id;
            emailTextBox.Text = email;
            passwordTextBox.Text = password;
            userTypeTextbox.Text = userType;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);




            try
            {
                connection.Open();
                string name = nameTextBox.Text;
                string userId = idTextBox.Text;
                string email = emailTextBox.Text;
                string password = passwordTextBox.Text;
                
                SqlCommand updateCommand = new SqlCommand("UPDATE users SET name=@name, email=@email, password=@password WHERE userId=@id", connection);

                updateCommand.Parameters.AddWithValue("id", userId);
                updateCommand.Parameters.AddWithValue("name", name);
                updateCommand.Parameters.AddWithValue("email", email);
                updateCommand.Parameters.AddWithValue("password", password);
               

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("Entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update the entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }

}

