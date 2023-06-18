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

namespace Library_Management_System
{
    public partial class updateEbooks : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        private string isbn = "";
        public updateEbooks(string isbn)
        {
            this.isbn = isbn;
            InitializeComponent();
        }
        byte[] bookPdf = null;
        private void updateEbooks_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
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

            try
            {
                connection.Open();
                SqlCommand retriveCommand = new SqlCommand("SELECT title,image,author,publicationYear,category,pdf FROM ebooks WHERE isbn=@isbn", connection);
                retriveCommand.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = null;
                try
                {
                    reader = retriveCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        title = reader.GetString(0);
                        imageData = (byte[])reader.GetValue(1);
                        author = reader.GetString(2);
                        year = Convert.ToInt32(reader.GetInt32(3));
                        category = reader.GetString(4);
                        bookPdf= (byte[])reader.GetValue(5);


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
                authorTextBox.Text =author;
                isbnTextBox.Text = isbn;
                categoryComboBox.SelectedItem = category;

                DateTime selectedDate = new DateTime(year, 1, 1);
                dateTimePicker1.Value = selectedDate;

                MemoryStream ms = new MemoryStream(imageData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                eBookImage.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|EPUB Files (*.epub)|*.epub|MOBI Files (*.mobi)|*.mobi|All Files (*.*)|*.*";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;


                bookPdf = File.ReadAllBytes(filePath);

            }
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);

                eBookImage.Image = image;
            }
        }

        private void updateBooksButton_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            eBookImage.Image.Save(ms, eBookImage.Image.RawFormat);
            byte[] imageData = ms.ToArray();

            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string category = categoryComboBox.SelectedItem.ToString();
            string year = dateTimePicker1.Value.Year.ToString();




            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand updateCommand = new SqlCommand("UPDATE ebooks SET title=@title,image=@image,author=@author,publicationYear=@year,category=@category,pdf=@pdf WHERE isbn=@isbn", connection);
                updateCommand.Parameters.AddWithValue("@title", title);
                updateCommand.Parameters.AddWithValue("@image", imageData);
                updateCommand.Parameters.AddWithValue("@author", author);
                updateCommand.Parameters.AddWithValue("@category",category );
                updateCommand.Parameters.AddWithValue("@year", year);
                updateCommand.Parameters.AddWithValue("@pdf",bookPdf);
                updateCommand.Parameters.AddWithValue("@isbn", isbn);

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
    }
}
