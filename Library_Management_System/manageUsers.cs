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
    public partial class manageUsers : Form
    {
        
        public manageUsers()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        private void manageLibrarians_Load(object sender, EventArgs e)
        {
            

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand checkCommand =new SqlCommand("SELECT COUNT(*) FROM users",connection);

                if (Convert.ToInt32(checkCommand.ExecuteScalar()) > 0)
                {
                    SqlCommand command = new SqlCommand("Select * From users", connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);
                    librariansDataGrid.DataSource = dataTable;
                    librariansDataGrid.DefaultCellStyle = new DataGridViewCellStyle();

                  
                    librariansDataGrid.AllowUserToAddRows = false;

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
                else
                {
                    MessageBox.Show("Your Database is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string userId = row.Cells["userId"].Value.ToString();
                    string name = row.Cells["name"].Value.ToString();
                    string email = row.Cells["email"].Value.ToString();
                    string password = row.Cells["password"].Value.ToString();
                    string userType = row.Cells["userType"].Value.ToString();

                    updateLibrarians obj1 = new updateLibrarians(userId,name,email,password,userType);
                    obj1.FormClosed += UpdateFormClosed;
                    obj1.Show();

                    
                    
                    


                }
            }
        }
        private void UpdateFormClosed(object sender, FormClosedEventArgs e)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM users", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
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

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand searchCommand = new SqlCommand("SELECT * FROM users WHERE name LIKE @searchKey OR userId LIKE @searchKey",connection);
                searchCommand.Parameters.AddWithValue("@searchKey", "%"+searchKey+"%");
                SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
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
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT * FROM users";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                librariansDataGrid.DataSource = dataTable;

            }
            catch(Exception ex)
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
