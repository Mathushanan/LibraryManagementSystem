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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class login : Form
    {
        public login()
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernameTextBox_MouseEnter(object sender, EventArgs e)
        {
            usernameTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.BorderStyle = BorderStyle.None;
        }

        private void usernameTextBox_MouseLeave(object sender, EventArgs e)
        {
            usernameTextBox.BorderStyle = BorderStyle.None;
            
        }

        private void passwordTextbox_MouseEnter(object sender, EventArgs e)
        {
            usernameTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void passwordTextbox_MouseLeave(object sender, EventArgs e)
        {
            
            passwordTextBox.BorderStyle = BorderStyle.None;
        }
        private void openStudentDashBoard()
        {
            MessageBox.Show("student opened!");
        }
        private void openLibrarianDashBoard()
        {
            librarianDesktop obj1 = new librarianDesktop();
            this.Hide();
            obj1.Show();
        }
        private void openAdminDashBoard()
        {
            adminDesktop obj1 = new adminDesktop();
            this.Hide();
            obj1.Show();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {

                MessageBox.Show("Please input Username and Password. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (userName == "@admin" && password == "@admin@")
            {
                openAdminDashBoard();
                
            }
            else if(validateUser(userName,password)=="student")
            {
                openStudentDashBoard();
            }
            else if(validateUser(userName, password) == "librarian")
            {
                openLibrarianDashBoard();
   
            }
            else
            {
                MessageBox.Show("Wrong Username OR Password. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string validateUser(string userName,string password)
        {
            
            string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {

                connection.Open();
                string query = "SELECT userType FROM users WHERE email = @userName AND password = @password";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                checkCommand.Parameters.AddWithValue("@userName", userName);
                checkCommand.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("userType");
                    }
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

            
            return  null;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void forgotButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact the librarian to reset your password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
