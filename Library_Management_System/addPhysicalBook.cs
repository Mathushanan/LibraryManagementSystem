using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System
{
    public partial class addPhysicalBook : Form
    {
        private Image defaultImage;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public addPhysicalBook()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPhysicalBook_Load(object sender, EventArgs e)
        {
            defaultImage = physicalBookImage.Image;

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

                physicalBookImage.Image = image;
            }
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {

            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string isbn = isbnTextBox.Text;
            int year = dateTimePicker1.Value.Year;
            string category = categoryComboBox.SelectedItem.ToString();




            if (titleTextBox.Text == "" || authorTextBox.Text == "" || isbnTextBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (physicalBookImage.Image == null || physicalBookImage.Image == defaultImage)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                
                
                try
                {
                    int count= 0;
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query1 = "SELECT COUNT(*) FROM physicalbooks WHERE isbn=@isbn ";
                    SqlCommand checkCommand = new SqlCommand(query1, connection);
                    try
                    {
                        checkCommand.Parameters.AddWithValue("@isbn", isbn);
                        count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    }
                    finally
                    {
                        connection.Close();
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
                            physicalBookImage.Image.Save(ms, physicalBookImage.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                        finally
                        {
                            ms.Close();
                            ms.Dispose();
                        }

                        try
                        {
                            
                            connection.Open();
                            string query2 = "INSERT INTO physicalbooks (title,image,author,isbn,publicationYear,category,status) VALUES (@title,@ImageData,@author,@isbn,@year,@category,@status)";
                            SqlCommand command = new SqlCommand(query2, connection);
                            try
                            {
                                command.Parameters.AddWithValue("@ImageData", imageData);
                                command.Parameters.AddWithValue("@title", title);
                                command.Parameters.AddWithValue("@status", "Available");
                                command.Parameters.AddWithValue("@author", author);
                                command.Parameters.AddWithValue("@isbn", isbn);
                                command.Parameters.AddWithValue("@year", year);
                                command.Parameters.AddWithValue("@category", category);
                                command.ExecuteNonQuery();
                            }
                            finally
                            {
                                connection.Close();
                                command.Dispose();
                            }

                            cleanAllDetails();
                            MessageBox.Show("Image and details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving the image and details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
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
            categoryComboBox.SelectedIndex = 0;

            physicalBookImage.Image = defaultImage;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
