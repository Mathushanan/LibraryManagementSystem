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
using System.IO;

namespace Library_Management_System
{
    public partial class physicalBooks : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public physicalBooks()
        {
            InitializeComponent();
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            addPhysicalBook obj1 = new addPhysicalBook();
            obj1.FormClosed += addBooksFormClosed;
            obj1.Show();
        }

        private void physicalBooks_Load(object sender, EventArgs e)
        {
            LoadBookData();
        }

        private void LoadBookData()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM physicalbooks", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string title = row["title"].ToString();
                    string isbn = row["isbn"].ToString();
                    string author = row["author"].ToString();
                    string publicationYear = row["publicationYear"].ToString();
                    string category = row["category"].ToString();
                    int bookId = Convert.ToInt32(row["bookId"]);
                    byte[] imageData = (byte[])row["image"];

                    int rating = getRating(bookId);

                    CreateProfileCard(title, isbn, author, publicationYear, category, imageData, rating);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }

        }

        private int getRating(int bookId)
        {
            int rating = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT rating FROM physicalbooks_ratings WHERE bookId=@bookId";
                SqlCommand ratingCommand = new SqlCommand(query, connection);
                ratingCommand.Parameters.AddWithValue("@bookId", bookId);
                object result = ratingCommand.ExecuteScalar();

                rating = Convert.ToInt32(result);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return rating;
        }

        private void CreateProfileCard(string title, string isbn, string author, string publicationYear, string category, Byte[] imageData, int rating)
        {


            Panel profileCard = new Panel();
            profileCard.BorderStyle = BorderStyle.Fixed3D;
            profileCard.Width = 350;
            profileCard.Height = 150;


            Label titleLabel = new Label();
            titleLabel.Text = "Title: ";
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(10, 10);
            profileCard.Controls.Add(titleLabel);
            Label retrivedTitleLabel = new Label();
            retrivedTitleLabel.Text = title.ToString();
            retrivedTitleLabel.AutoSize = true;
            retrivedTitleLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedTitleLabel.Location = new System.Drawing.Point(titleLabel.Right, titleLabel.Top);
            profileCard.Controls.Add(retrivedTitleLabel);
            titleLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedTitleLabel.Font = new Font(retrivedTitleLabel.Font, FontStyle.Bold);



            Label authorLabel = new Label();
            authorLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            authorLabel.Text = "Author: ";
            authorLabel.AutoSize = true;
            authorLabel.Location = new System.Drawing.Point(10, 30);
            profileCard.Controls.Add(authorLabel);
            Label retrivedAuthorLabel = new Label();
            retrivedAuthorLabel.Text = author.ToString();
            retrivedAuthorLabel.AutoSize = true;
            retrivedAuthorLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedAuthorLabel.Location = new System.Drawing.Point(authorLabel.Right, authorLabel.Top);
            profileCard.Controls.Add(retrivedAuthorLabel);
            authorLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedAuthorLabel.Font = new Font(retrivedAuthorLabel.Font, FontStyle.Bold);



            Label yearLabel = new Label();
            yearLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            yearLabel.Text = "Publication Year: ";
            yearLabel.AutoSize = true;
            yearLabel.Location = new System.Drawing.Point(10, 50);
            profileCard.Controls.Add(yearLabel);
            Label retrivedYearLabel = new Label();
            retrivedYearLabel.Text = publicationYear.ToString();
            retrivedYearLabel.AutoSize = true;
            retrivedYearLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedYearLabel.Location = new System.Drawing.Point(yearLabel.Right, yearLabel.Top);
            profileCard.Controls.Add(retrivedYearLabel);
            yearLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedYearLabel.Font = new Font(retrivedYearLabel.Font, FontStyle.Bold);

            Label categoryLabel = new Label();
            categoryLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            categoryLabel.Text = "Category: ";
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(10, 70);
            profileCard.Controls.Add(categoryLabel);
            Label retrivedcategoryLabel = new Label();
            retrivedcategoryLabel.Text = category.ToString();
            retrivedcategoryLabel.AutoSize = true;
            retrivedcategoryLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedcategoryLabel.Location = new System.Drawing.Point(categoryLabel.Right, categoryLabel.Top);
            profileCard.Controls.Add(retrivedcategoryLabel);
            categoryLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedcategoryLabel.Font = new Font(retrivedcategoryLabel.Font, FontStyle.Bold);

            Label isbnLabel = new Label();
            isbnLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            isbnLabel.Text = "ISBN: ";
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new System.Drawing.Point(10, 90);
            profileCard.Controls.Add(isbnLabel);
            Label retrivedIsbnLabel = new Label();
            retrivedIsbnLabel.Text = isbn.ToString();
            retrivedIsbnLabel.AutoSize = true;
            retrivedIsbnLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedIsbnLabel.Location = new System.Drawing.Point(isbnLabel.Right, isbnLabel.Top);
            profileCard.Controls.Add(retrivedIsbnLabel);
            isbnLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedIsbnLabel.Font = new Font(retrivedIsbnLabel.Font, FontStyle.Bold);


            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = ConvertByteArrayToImage(imageData);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new System.Drawing.Size(100, 100);
            pictureBox.Location = new System.Drawing.Point(profileCard.Width - pictureBox.Width - 10, 10);
            profileCard.Controls.Add(pictureBox);

            Button deleteButton = new Button();
            deleteButton.Name = "delete";
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.BackColor = Color.Red;
            deleteButton.ForeColor = Color.White;
            deleteButton.Text = "Delete";
            deleteButton.Location = new System.Drawing.Point(10, 120);
            deleteButton.Tag = isbn; // Store the ISBN as the button's Tag for identification
            deleteButton.Click += DeleteButton_Click;
            profileCard.Controls.Add(deleteButton);


            Button updateButton = new Button();
            updateButton.Name = "update";
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.BackColor = Color.Green;
            updateButton.ForeColor = Color.White;
            updateButton.Text = "Update";
            updateButton.Location = new System.Drawing.Point(90, 120);
            updateButton.Tag = isbn; // Store the ISBN as the button's Tag for identification
            updateButton.Click += UpdateButton_Click;
            profileCard.Controls.Add(updateButton);


            Label ratingLabel = new Label();
            ratingLabel.Location = new System.Drawing.Point(pictureBox.Left, pictureBox.Bottom + 10);







            int maxRating = 5;

            PictureBox[] ratingPictureBoxes = new PictureBox[maxRating];
            int starSize = 20;
            int starSpacing = 4;
            int starsTotalWidth = maxRating * starSize + (maxRating - 1) * starSpacing;

            // Calculate the starting position to center the stars horizontally under the PictureBox
            int starsStartX = pictureBox.Left + (pictureBox.Width - starsTotalWidth) / 2;
            int starsY = pictureBox.Bottom + 10; // Adjust the vertical position of the stars

            // Create and configure the rating PictureBox controls
            for (int i = 0; i < maxRating; i++)
            {
                ratingPictureBoxes[i] = new PictureBox();
                ratingPictureBoxes[i].Size = new Size(starSize, starSize);
                ratingPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ratingPictureBoxes[i].Location = new Point(starsStartX + (starSize + starSpacing) * i, starsY);

                // Set the image for the visible PictureBoxes (e.g., filled star icon) if it's within the rating
                if (i < rating)
                {
                    ratingPictureBoxes[i].Image = Image.FromFile("C:\\Users\\Mathu\\Downloads\\icons8-star-filled-48.png"); // Replace with the actual image path
                }
                else
                {
                    // Set the image for the hidden PictureBoxes (e.g., empty star icon)
                    ratingPictureBoxes[i].Image = Image.FromFile("C:\\Users\\Mathu\\Downloads\\icons8-star-48.png"); // Replace with the actual image path
                }

                // Add the PictureBox to the profileCard panel
                profileCard.Controls.Add(ratingPictureBoxes[i]);
            }

            flowLayoutPanel1.Controls.Add(profileCard);
        }
        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }

        private void addBooksFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string isbn = deleteButton.Tag.ToString();



            DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                    connection.Open();
                    string query = "DELETE FROM physicalbooks WHERE isbn = @isbn";
                    SqlCommand deleteCommand = new SqlCommand(query, connection);
                    deleteCommand.Parameters.AddWithValue("@isbn", isbn);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {


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


                flowLayoutPanel1.Controls.Clear();
                LoadBookData();

            }


        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
            string isbn = updateButton.Tag.ToString();

            updatePhysicalBooks obj1 = new updatePhysicalBooks(isbn);
            obj1.Show();
            obj1.FormClosed += UpdateFormClosed;

        }

        private void UpdateFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
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
                SqlCommand command = new SqlCommand("SELECT * FROM physicalbooks WHERE title LIKE @searchKey OR isbn LIKE @searchKey OR author LIKE @searchKey OR category LIKE @searchKey OR publicationYear LIKE @searchKey", connection);
                command.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string title = row["title"].ToString();
                    string isbn = row["isbn"].ToString();
                    string author = row["author"].ToString();
                    string publicationYear = row["publicationYear"].ToString();
                    string category = row["category"].ToString();
                    int bookId = Convert.ToInt32(row["bookId"]);
                    byte[] imageData = (byte[])row["image"];

                    int rating = getRating(bookId);

                    CreateProfileCard(title, isbn, author, publicationYear, category, imageData, rating);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            LoadBookData();
        }
    }
}
