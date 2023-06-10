using MySql.Data.MySqlClient;
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
    
    public partial class adminDashBoard : Form
    {
        string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        
        public adminDashBoard()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashBoard_Load(object sender, EventArgs e)
        {
            
            
          


            labelTotalLibrarians.Text = getLibrariansCount().ToString();
            labelTotalMembers.Text = getMembersCount().ToString();
            labelTotalPhysicalBooks.Text = getPhysicalBooksCount().ToString();
            labelTotalEBooks.Text = geteBooksCount().ToString();
            labelTotalEvents.Text = getEventsCount().ToString();
            labelTotalVirtualGroups.Text = getVirtualGroupsCount().ToString();

        }
        private int getLibrariansCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count=0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@librarian";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
                countCommand.Parameters.AddWithValue("@librarian", "librarian");
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
        private int getVirtualGroupsCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM virtualgroups";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
                
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
        private int getMembersCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@student";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
                countCommand.Parameters.AddWithValue("@student", "student");
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
        private int getPhysicalBooksCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
               
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
        private int geteBooksCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ebooks";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
               
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
        private int getEventsCount()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM events";
                MySqlCommand countCommand = new MySqlCommand(query, connection);
               
                Count = Convert.ToInt32(countCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return Count;
        }
    }
    
}
