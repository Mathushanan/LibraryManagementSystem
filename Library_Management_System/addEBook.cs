using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class addEBook : Form
    {
        private Image defaultImage;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public addEBook()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addEBook_Load(object sender, EventArgs e)
        {
            defaultImage = eBookImage.Image;

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

            categoryComboBox.SelectedIndex = 0;
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Image image = Image.FromFile(fileName);

                eBookImage.Image = image;
            }
        }
        byte[] fileBytes;
        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|EPUB Files (*.epub)|*.epub|MOBI Files (*.mobi)|*.mobi|All Files (*.*)|*.*";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;


               fileBytes = File.ReadAllBytes(filePath);

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cleanAllDetails();
        }

        private void cleanAllDetails()
        {
            titleTextBox.Text = "";
            authorTextBox.Text = "";
            isbnTextBox.Text = "";
            eBookImage.Image = defaultImage;
            categoryComboBox.SelectedIndex = 0;
            fileBytes = null;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string isbn = isbnTextBox.Text;
            string year = dateTimePicker1.Value.Year.ToString();
            string category = categoryComboBox.SelectedItem.ToString();

            if (titleTextBox.Text == "" || authorTextBox.Text == "" || isbnTextBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (eBookImage.Image == null || eBookImage.Image == defaultImage)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (fileBytes == null)
            {
                MessageBox.Show("Please upload the book first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int count = 0;
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    string query2 = "SELECT COUNT(*) FROM ebooks WHERE isbn=@isbn";
                    SqlCommand checkCommand = new SqlCommand(query2, connection);

                    try
                    {
                        connection.Open();
                        checkCommand.Parameters.AddWithValue("@isbn", isbn);
                        count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (count > 0)
                {
                    MessageBox.Show("The book with the given ISBN has already been added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    byte[] imageData;
                    MemoryStream ms = new MemoryStream();
                    try
                    {
                        eBookImage.Image.Save(ms, eBookImage.Image.RawFormat);
                        imageData = ms.ToArray();
                    }
                    finally
                    {
                        ms.Close();
                        ms.Dispose();
                    }

                    try
                    {
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        string query = "INSERT INTO ebooks (title,image,author,isbn,publicationYear,category,pdf,downloadCount) VALUES (@title,@ImageData,@author,@isbn,@year,@category,@PdfData,@count)";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            command.Parameters.AddWithValue("@ImageData", imageData);
                            command.Parameters.AddWithValue("@PdfData", fileBytes);
                            command.Parameters.AddWithValue("@title", title);
                            command.Parameters.AddWithValue("@isbn", isbn);
                            command.Parameters.AddWithValue("@author", author);
                            command.Parameters.AddWithValue("@year", year);
                            command.Parameters.AddWithValue("@category", category);
                            command.Parameters.AddWithValue("@count", 0);
                            command.ExecuteNonQuery();

                        }
                        finally
                        {
                            connection.Close();
                            command.Dispose();
                        }


                        cleanAllDetails();
                        MessageBox.Show("Image,file and details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the image,file and details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



            }


        }
    }
}
