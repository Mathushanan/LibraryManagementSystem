using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library_Management_System
{
    public partial class borrowBook : Form
    {
        string userName = "";
        string isbn = "";
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public borrowBook(string userName,string isbn)
        {
            this.userName = userName;
            this.isbn = isbn;
            InitializeComponent();
        }

        private void borrowBook_Load(object sender, EventArgs e)
        {

            string title = "";
            byte[] imageData = null;
            string author = "";
            int year = 0;
            string category = "";




            List<string> itemList = new List<string>
            {
               "Fiction",
               "Non-fiction",
               "Mystery",
               "Romance",
               "Science Fiction",
               "Fantasy",
               "Biography",
               "History",
               "Self-help",
               "Business",
               "Travel",
               "Health and Fitness",
               "Science",
               "Technology",
               "Art and Design",
               "Philosophy",
               "Psychology",
               "Religion and Spirituality",
               "Cooking and Food",
               "Children's Books"

            };

            categoryComboBox.DataSource = itemList;



            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT title,image,author,publicationYear,category FROM physicalbooks WHERE isbn=@isbn";
            try
            {
                connection.Open();
                SqlCommand getCommand = new SqlCommand(query, connection);
                getCommand.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = null;
                try
                {
                    reader = getCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        title = reader.GetString(0);
                        imageData = (byte[])reader.GetValue(1);
                        author = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            year = reader.GetInt32(3);
                        }
                        category = reader.GetString(4);

                    }

                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            try
            {
                titleTextBox.Text = title;
                authorTextBox.Text = author;
                categoryComboBox.SelectedItem = category;

                if (year > 0)
                {
                    DateTime selectedDate = new DateTime(year, 1, 1);
                    dateTimePicker1.Value = selectedDate;
                }

                isbnTextBox.Text = isbn;

                MemoryStream ms = new MemoryStream(imageData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                physicalBookImage.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dateTimePicker1.Enabled = false;
            categoryComboBox.Enabled = false;


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string userId;
        string name;
        private void borrowBooksButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int count = 0;

            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks WHERE isbn=@isbn AND status=@status";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@isbn", isbn);
                command.Parameters.AddWithValue("@status", "Available");

                count = Convert.ToInt32(command.ExecuteScalar());


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            if (count > 0)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT userId, name FROM users WHERE email = @userName";
                    SqlCommand getCommand = new SqlCommand(query, connection);
                    getCommand.Parameters.AddWithValue("@userName", userName);

                    SqlDataReader reader = getCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        userId = reader["userId"].ToString();
                        name = reader["name"].ToString();
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





                try
                {
                    string query2 = "INSERT INTO borrowings (userId,name,isbn,borrowDate,returnDate,status) VALUES (@userId,@name,@isbn,@borrowDate,@returnDate,@status)";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query2, connection);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@status", "Pending");
                    command.Parameters.AddWithValue("@isbn", isbnTextBox.Text);
                    command.Parameters.AddWithValue("@borrowDate", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@returnDate", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
                    if (command.ExecuteNonQuery() > 0)
                    {



                        try
                        {

                            string query = "UPDATE physicalbooks SET status=@status WHERE isbn=@isbn";
                            SqlCommand updateCommand = new SqlCommand(query, connection);
                            updateCommand.Parameters.AddWithValue("@status", "Borrowed");
                            updateCommand.Parameters.AddWithValue("@isbn", isbn);

                            if (Convert.ToInt32(updateCommand.ExecuteNonQuery()) > 0)
                            {
                                MessageBox.Show("Borrowing details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }





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
            else
            {
                MessageBox.Show("Boook already borrowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
