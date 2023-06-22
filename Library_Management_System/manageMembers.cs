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
    public partial class manageMembers : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public manageMembers()
        {
            InitializeComponent();
        }

        private void manageMembers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * From users WHERE userType=@student", connection);
                string student = "student";
                command.Parameters.AddWithValue("@student", student);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataTable.Columns["userId"].ColumnName = "User ID";
                dataTable.Columns["name"].ColumnName = "Name";
                dataTable.Columns["email"].ColumnName = "User Name";
                dataTable.Columns["password"].ColumnName = "Password";
                dataTable.Columns["userType"].ColumnName = "User Type";




                librariansDataGrid.DataSource = dataTable;
                foreach (DataGridViewColumn column in librariansDataGrid.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                }

                librariansDataGrid.DefaultCellStyle = new DataGridViewCellStyle();

                librariansDataGrid.AllowUserToAddRows = false;



                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.HeaderText = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                librariansDataGrid.Columns.Add(deleteButtonColumn);

                deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;
                deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
                deleteButtonColumn.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                deleteButtonColumn.FlatStyle = FlatStyle.Flat;
                deleteButtonColumn.DefaultCellStyle.SelectionBackColor = Color.Red;

                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn();
                updateButtonColumn.Name = "Update";
                updateButtonColumn.Text = "Update";
                updateButtonColumn.UseColumnTextForButtonValue = true;
                updateButtonColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                librariansDataGrid.Columns.Add(updateButtonColumn);

                updateButtonColumn.DefaultCellStyle.BackColor = Color.Green;
                updateButtonColumn.DefaultCellStyle.ForeColor = Color.White;
                updateButtonColumn.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                updateButtonColumn.FlatStyle = FlatStyle.Flat;
                updateButtonColumn.DefaultCellStyle.SelectionBackColor = Color.Green;
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
        private void addMemberButton_Click(object sender, EventArgs e)
        {
            addMember obj1 = new addMember();
            obj1.Show();
            obj1.FormClosed += UpdateFormClosed;

        }
        private void UpdateFormClosed(object sender, FormClosedEventArgs e)
        {

            librariansDataGrid.DataSource = null;
            librariansDataGrid.Rows.Clear();
            librariansDataGrid.Columns.Clear();

            LoadData();
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
                SqlCommand searchCommand = new SqlCommand("SELECT * FROM users WHERE (name LIKE @searchKey OR userId LIKE @searchKey) AND userType=@student", connection);
                searchCommand.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                searchCommand.Parameters.AddWithValue("@student","student");
                SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataTable.Columns["userId"].ColumnName = "User ID";
                dataTable.Columns["name"].ColumnName = "Name";
                dataTable.Columns["email"].ColumnName = "User Name";
                dataTable.Columns["password"].ColumnName = "Password";
                dataTable.Columns["userType"].ColumnName = "User Type";

                librariansDataGrid.DataSource = dataTable;
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
            librariansDataGrid.DataSource = null;
            librariansDataGrid.Rows.Clear();
            librariansDataGrid.Columns.Clear();

            LoadData();
        }

        private void librariansDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = librariansDataGrid.Rows[e.RowIndex];


                if (e.ColumnIndex == librariansDataGrid.Columns["Delete"].Index)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        string id = row.Cells["User ID"].Value.ToString();

                        SqlConnection connection = new SqlConnection(connectionString);
                        try
                        {
                            connection.Open();
                            SqlCommand deleteCommand = new SqlCommand("DELETE FROM users WHERE userId = @id", connection);
                            deleteCommand.Parameters.AddWithValue("@id", id);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {

                                librariansDataGrid.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Entry deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete the entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                else if (e.ColumnIndex == librariansDataGrid.Columns["Update"].Index)
                {
                    string userId = row.Cells["User ID"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string email = row.Cells["User Name"].Value.ToString();
                    string password = row.Cells["Password"].Value.ToString();
                    string userType = row.Cells["User Type"].Value.ToString();

                    updateLibrarians obj1 = new updateLibrarians(userId, name, email, password, userType);
                    obj1.FormClosed += UpdateFormClosed;
                    obj1.Show();

                }
            }
        }
    }
}
