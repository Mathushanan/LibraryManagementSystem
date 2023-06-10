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
    public partial class librarianDashBoard : Form
    {
        string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        public librarianDashBoard()
        {
            InitializeComponent();
        }

        private void librarianDashBoard_Load(object sender, EventArgs e)
        {
            labelTotalBooksBorrowed.Text = getBooksBorrowed().ToString();
            labelTotalEBooks.Text = getTotalEBooks().ToString();
            labelTotalEvents.Text = getActiveEvents().ToString();
            labelTotalPhysicalBooks.Text = getTotlalPhysicalBooks().ToString();
            labelTotalVirtualGroups.Text = getVirtualGroups().ToString();
            labelTotalMembers.Text = getTotalMembers().ToString();

        }

        private int getBooksBorrowed()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM borrowings";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private int getTotalMembers()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            string type = "student";
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@type";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                checkCommand.Parameters.AddWithValue("@type", type);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private int getTotlalPhysicalBooks()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private int getTotalEBooks()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ebooks";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private int getActiveEvents()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM events";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private int getVirtualGroups()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM virtualgroups";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                count = Convert.ToInt32(checkCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
    }
}
