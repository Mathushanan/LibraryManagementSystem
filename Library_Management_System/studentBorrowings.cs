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
    public partial class studentBorrowings : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string userName = "";
        int userId = 0;
        public studentBorrowings(string userName)
        {
            this.userName = userName;
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchKey = searchTextBox.Text;

            if (string.IsNullOrEmpty(searchKey))
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand searchCommand = new SqlCommand("SELECT * FROM borrowings WHERE name LIKE @searchKey OR userId LIKE @searchKey OR borrowingId LIKE @searchKey AND userId=@userId", connection);
                searchCommand.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                searchCommand.Parameters.AddWithValue("@userId",userId);
                SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                borrowedDetailsDataGrid.DataSource = dataTable;
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

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT * FROM borrowings WHERE userId=@userId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                borrowedDetailsDataGrid.DataSource = dataTable;

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

        private void pendingButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT * FROM borrowings WHERE status=@status AND userId=@userId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", "Pending");
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                borrowedDetailsDataGrid.DataSource = dataTable;


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

        private void studentBorrowings_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();
                string query = "SELECT userId FROM users WHERE email=@userName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userName", userName);

                userId = Convert.ToInt32(command.ExecuteScalar());
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
                SqlCommand command = new SqlCommand("Select * From borrowings WHERE userId=@userId", connection);
                command.Parameters.AddWithValue("@userId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataTable.Columns.Remove("userId");
                dataTable.Columns.Remove("name");

                dataTable.Columns["borrowingId"].ColumnName = "Borrowing ID";
                dataTable.Columns["borrowDate"].ColumnName = "Borrow Date";
                dataTable.Columns["returnDate"].ColumnName = "Return Date";
                dataTable.Columns["status"].ColumnName = "Status";
                dataTable.Columns["isbn"].ColumnName = "ISBN";
               

                borrowedDetailsDataGrid.DataSource = dataTable;

                foreach (DataGridViewColumn column in borrowedDetailsDataGrid.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                }

                borrowedDetailsDataGrid.DefaultCellStyle = new DataGridViewCellStyle();
                borrowedDetailsDataGrid.AllowUserToAddRows = false;

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
