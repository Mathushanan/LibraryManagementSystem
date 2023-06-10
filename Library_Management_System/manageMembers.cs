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
    public partial class manageMembers : Form
    {
        private string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        public manageMembers()
        {
            InitializeComponent();
        }

        private void manageMembers_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Select * From users WHERE userType=@student", connection);
                string student = "student";
                command.Parameters.AddWithValue("@student", student);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                librariansDataGrid.DataSource = dataTable;


                librariansDataGrid.DefaultCellStyle = new DataGridViewCellStyle();

                librariansDataGrid.AllowUserToAddRows = false;
                librariansDataGrid.Rows[librariansDataGrid.Rows.Count - 1].Visible = false;



                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.HeaderText = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
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
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE userType=@userType", connection);
                command.Parameters.AddWithValue("@userType", "student");
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                librariansDataGrid.DataSource = dataTable;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchKey = searchTextBox.Text;

            if (string.IsNullOrEmpty(searchKey))
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand searchCommand = new MySqlCommand("SELECT * FROM users WHERE (name LIKE @searchKey OR userId LIKE @searchKey) AND userType=@student", connection);
                searchCommand.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                searchCommand.Parameters.AddWithValue("@student","student");
                MySqlDataAdapter adapter = new MySqlDataAdapter(searchCommand);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
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
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE userType=@student";
                
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@student", "student");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
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

                        string id = row.Cells["userId"].Value.ToString();

                        MySqlConnection connection = new MySqlConnection(connectionString);
                        try
                        {
                            connection.Open();
                            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM users WHERE userId = @id", connection);
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
                    string userId = row.Cells["userId"].Value.ToString();
                    string name = row.Cells["name"].Value.ToString();
                    string email = row.Cells["email"].Value.ToString();
                    string password = row.Cells["password"].Value.ToString();
                    string userType = row.Cells["userType"].Value.ToString();

                    updateLibrarians obj1 = new updateLibrarians(userId, name, email, password, userType);
                    obj1.FormClosed += UpdateFormClosed;
                    obj1.Show();

                }
            }
        }
    }
}
