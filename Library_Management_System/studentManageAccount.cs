using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class studentManageAccount : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string userName = "";
        public studentManageAccount(string userName)
        {
            this.userName = userName;
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(confirmTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordTextBox.Text != confirmTextBox.Text)
            {
                MessageBox.Show("Confirm password does not match with password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    string password = passwordTextBox.Text;

                    SqlCommand updateCommand = new SqlCommand("UPDATE users SET  password=@password WHERE userId=@userid", connection);

                    updateCommand.Parameters.AddWithValue("@userId", userId);
                    updateCommand.Parameters.AddWithValue("@password", password);


                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("Password updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
        int userId = 0;
        private void studentManageAccount_Load(object sender, EventArgs e)
        {
            
            string name = "";
            string email = "";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT userId,name,email FROM users WHERE email=@userName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userName", userName);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();

                adapter.Fill(table);

                DataRow row = table.Rows[0];

                userId = Convert.ToInt32(row["userId"]);
                name = row["name"].ToString();
                email = row["email"].ToString();




            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            idTextBox.Text = userId.ToString();
            nameTextBox.Text = name;
            emailTextBox.Text = email;


        }
    }
}
