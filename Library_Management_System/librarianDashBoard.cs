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
    public partial class librarianDashBoard : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM borrowings";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            string type = "student";
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@type";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ebooks";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM events";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM virtualgroups";
                SqlCommand checkCommand = new SqlCommand(query, connection);
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
