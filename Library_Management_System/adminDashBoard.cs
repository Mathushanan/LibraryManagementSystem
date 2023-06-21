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
    
    public partial class adminDashBoard : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count=0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@librarian";
                SqlCommand countCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM virtualgroups";
                SqlCommand countCommand = new SqlCommand(query, connection);
                
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userType=@student";
                SqlCommand countCommand = new SqlCommand(query, connection);
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks";
                SqlCommand countCommand = new SqlCommand(query, connection);
               
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ebooks";
                SqlCommand countCommand = new SqlCommand(query, connection);
               
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
            SqlConnection connection = new SqlConnection(connectionString);
            int Count = 0;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM events";
                SqlCommand countCommand = new SqlCommand(query, connection);
               
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
