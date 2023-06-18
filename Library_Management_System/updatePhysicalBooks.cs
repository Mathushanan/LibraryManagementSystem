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
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Library_Management_System
{
    public partial class updatePhysicalBooks : Form
    {
        private string isbn;



        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public updatePhysicalBooks(string isbn)
        {
            InitializeComponent();
            this.isbn = isbn;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);

                physicalBookImage.Image = image;
            }
        }

        private void updateBooksButton_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            physicalBookImage.Image.Save(ms, physicalBookImage.Image.RawFormat);
            byte[] imageData = ms.ToArray();


            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE physicalbooks SET title=@title,image=@image,author=@author,publicationYear=@publicationYear,category=@category WHERE isbn=@isbn";
            try
            {
                connection.Open();
                SqlCommand updateCommand = new SqlCommand(query, connection);
                updateCommand.Parameters.AddWithValue("@title", titleTextBox.Text);
                updateCommand.Parameters.AddWithValue("@image", imageData);
                updateCommand.Parameters.AddWithValue("@isbn", isbn);
                updateCommand.Parameters.AddWithValue("@publicationYear",dateTimePicker1.Value.Year);
                updateCommand.Parameters.AddWithValue("@category",categoryComboBox.SelectedItem);
                updateCommand.Parameters.AddWithValue("@author",authorTextBox.Text);
                
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("Entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update the entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatePhysicalBooks_Load(object sender, EventArgs e)
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
            string query = "SELECT title,image,author,isbn,publicationYear,category FROM physicalbooks WHERE isbn=@isbn";
            try
            {
                connection.Open();
                SqlCommand getCommand = new SqlCommand(query, connection);
                getCommand.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = null;
                try
                {
                    reader=getCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        title = reader.GetString(0);
                        imageData = (byte[])reader.GetValue(1);
                        author = reader.GetString(2);
                        year = reader.GetInt32(4);
                        category = reader.GetString(5);
                       
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

                DateTime selectedDate = new DateTime(year, 1, 1); 
                dateTimePicker1.Value = selectedDate;

                isbnTextBox.Text = isbn;

                MemoryStream ms = new MemoryStream(imageData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                physicalBookImage.Image = image;
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
