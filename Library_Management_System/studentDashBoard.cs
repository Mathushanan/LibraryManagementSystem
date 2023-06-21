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

namespace Library_Management_System
{

    public partial class studentDashBoard : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        private string userName="";
        public studentDashBoard(string userName)
        {
            this.userName = userName;
            InitializeComponent();
        }
        string userId = "";
        private void studentDashBoard_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                string query = "SELECT userId FROM users WHERE email=@userName";
                SqlCommand getCommand = new SqlCommand(query, connection);

                getCommand.Parameters.AddWithValue("@userName", userName);

                object result = getCommand.ExecuteScalar();
               
                if (result != null)
                {
                    userId = result.ToString();
                }
               

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM borrowings WHERE userId=@userId";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userId", userId);

                int count = Convert.ToInt32(command.ExecuteScalar());

                labelTotalBooksBorrowed.Text = count.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM borrowings WHERE userId=@userId AND status=@status";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@status", "Pending");

                int count = Convert.ToInt32(command.ExecuteScalar());

                labelPendingsToReturn.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM downloadcount WHERE userId=@userId";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userId", userId);
                int count = Convert.ToInt32(command.ExecuteScalar());

                labelTotalEBooksDwnloaded.Text = count.ToString();


            }catch(Exception ex)
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
