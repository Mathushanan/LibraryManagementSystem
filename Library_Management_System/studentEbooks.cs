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
using Library_Management_System.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class studentEbooks : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string userName="";
        public studentEbooks(string userName)
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
                SqlCommand command = new SqlCommand("SELECT * FROM ebooks WHERE title LIKE @searchKey OR isbn LIKE @searchKey OR author LIKE @searchKey OR category LIKE @searchKey OR publicationYear LIKE @searchKey", connection);
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
                    int downloadCount = Convert.ToInt32(row["downloadCount"]);

                    int rating = getRating(bookId);

                    CreateProfileCard(title, isbn, author, publicationYear, category, imageData, rating, downloadCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }
        }

        private void studentEbooks_Load(object sender, EventArgs e)
        {
            LoadBookData();
        }

        private void LoadBookData()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ebooks", connection);
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
                    int downloadCount = Convert.ToInt32(row["downloadCount"]);
                    byte[] imageData = (byte[])row["image"];

                    int rating = getRating(bookId);

                    CreateProfileCard(title, isbn, author, publicationYear, category, imageData, rating, downloadCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }

        }

        private int getRating(int bookId)
        {
            int totalRating = 0;
            int totalCount = 0;

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query1 = "SELECT SUM(rating) FROM ebooks_ratings WHERE bookId=@bookId";
                SqlCommand sumCommand = new SqlCommand(query1, connection);
                sumCommand.Parameters.AddWithValue("@bookId", bookId);
                object result1 = sumCommand.ExecuteScalar();
                totalRating = Convert.ToInt32(result1);

                string query2 = "SELECT COUNT(rating) FROM ebooks_ratings WHERE bookId=@bookId";
                SqlCommand countCommand = new SqlCommand(query2, connection);
                countCommand.Parameters.AddWithValue("@bookId", bookId);
                object result2 = countCommand.ExecuteScalar();
                totalCount = Convert.ToInt32(result2);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return totalRating / totalCount;
        }

        private void CreateProfileCard(string title, string isbn, string author, string publicationYear, string category, Byte[] imageData, int rating, int downloadCount)
        {


            Panel profileCard = new Panel();
            profileCard.BorderStyle = BorderStyle.Fixed3D;
            profileCard.Width = 350;
            profileCard.Height = 160;


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

            Label downloadLabel = new Label();
            downloadLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            downloadLabel.Text = "Downloaded Count: ";
            downloadLabel.AutoSize = true;
            downloadLabel.Location = new System.Drawing.Point(10, 110);
            profileCard.Controls.Add(downloadLabel);
            Label retrivedDownloadLabel = new Label();
            retrivedDownloadLabel.Text = downloadCount.ToString();
            retrivedDownloadLabel.AutoSize = true;
            retrivedDownloadLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedDownloadLabel.Location = new System.Drawing.Point(downloadLabel.Right, downloadLabel.Top);
            profileCard.Controls.Add(retrivedDownloadLabel);
            downloadLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedDownloadLabel.Font = new Font(retrivedDownloadLabel.Font, FontStyle.Bold);



            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = ConvertByteArrayToImage(imageData);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new System.Drawing.Size(100, 100);
            pictureBox.Location = new System.Drawing.Point(profileCard.Width - pictureBox.Width - 10, 10);
            profileCard.Controls.Add(pictureBox);

            Button downloadButton = new Button();
            downloadButton.Name = "download";
            downloadButton.FlatStyle = FlatStyle.Flat;
            downloadButton.FlatAppearance.BorderSize = 0;
            downloadButton.BackColor = ColorTranslator.FromHtml("#007BFF");
            downloadButton.ForeColor = Color.White;
            downloadButton.Text = "Download";
            downloadButton.Location = new System.Drawing.Point(10, 130);
            downloadButton.Tag = isbn; 
            downloadButton.Click += DownloadButton_Click;
            profileCard.Controls.Add(downloadButton);


            Button rateButton = new Button();
            rateButton.Name = "rate";
            rateButton.FlatStyle = FlatStyle.Flat;
            rateButton.FlatAppearance.BorderSize = 0;
            rateButton.BackColor = ColorTranslator.FromHtml("#DAA520");
            rateButton.ForeColor = Color.White;
            rateButton.Text = "Rate";
            rateButton.Location = new System.Drawing.Point(90, 130);
            rateButton.Tag = isbn; 
            rateButton.Click += RateButton_Click;
            profileCard.Controls.Add(rateButton);


            Label ratingLabel = new Label();
            ratingLabel.Location = new System.Drawing.Point(pictureBox.Left, pictureBox.Bottom + 10);


            int maxRating = 5;

            PictureBox[] ratingPictureBoxes = new PictureBox[maxRating];
            int starSize = 20;
            int starSpacing = 4;
            int starsTotalWidth = maxRating * starSize + (maxRating - 1) * starSpacing;
            int starsStartX = pictureBox.Left + (pictureBox.Width - starsTotalWidth) / 2;
            int starsY = pictureBox.Bottom + 10; 

            
            for (int i = 0; i < maxRating; i++)
            {
                ratingPictureBoxes[i] = new PictureBox();
                ratingPictureBoxes[i].Size = new Size(starSize, starSize);
                ratingPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ratingPictureBoxes[i].Location = new Point(starsStartX + (starSize + starSpacing) * i, starsY);

               
                if (i < rating)
                {
                    ratingPictureBoxes[i].Image = Resources.filled_star;
                }
                else
                {
                    
                    ratingPictureBoxes[i].Image = Resources.blank_star;
                }

            
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

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            
            Button downloadButton = (Button)sender;
            string isbn = downloadButton.Tag.ToString();
            byte[] pdfData = null;
            SqlConnection connection = new SqlConnection(connectionString);
            string bookName="";

            try
            {
                connection.Open();
                SqlCommand retriveCommand = new SqlCommand("SELECT pdf FROM ebooks WHERE isbn=@isbn", connection);
                retriveCommand.Parameters.AddWithValue("@isbn", isbn);

                pdfData=(byte[])retriveCommand.ExecuteScalar();


                SqlCommand command = new SqlCommand("SELECT title FROM ebooks WHERE isbn=@isbn",connection);
                command.Parameters.AddWithValue("@isbn", isbn);

                bookName = command.ExecuteScalar().ToString();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Download Book";
            saveFileDialog.FileName = bookName+".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                
                File.WriteAllBytes(filePath, pdfData);

                int count = 0;
                try
                {
                    connection.Open();
                    string query = "SELECT downloadCount FROM ebooks WHERE isbn=@isbn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@isbn", isbn);

                    count = Convert.ToInt32(command.ExecuteScalar());


                    string query2 = "SELECT bookId FROM ebooks WHERE isbn=@isbn";
                    SqlCommand selectCommand = new SqlCommand(query2, connection);
                    selectCommand.Parameters.AddWithValue("@isbn", isbn);

                    int bookId = Convert.ToInt32(selectCommand.ExecuteScalar());

                    string query3 = "SELECT userId FROM users WHERE email=@userName";
                    SqlCommand selectCommand1 = new SqlCommand(query3, connection);
                    selectCommand1.Parameters.AddWithValue("@userName", userName);

                    int userId=Convert.ToInt32(selectCommand1.ExecuteScalar());

                    string query4 = "INSERT INTO downloadcount (userId,ebookId) VALUES (@userId,@bookId)";
                    SqlCommand insertCommand = new SqlCommand(query4, connection);
                    insertCommand.Parameters.AddWithValue("@userId", userId);
                    insertCommand.Parameters.AddWithValue("@bookId",bookId);

                    string query1 = "UPDATE ebooks SET downloadCount=@count WHERE isbn=@isbn";
                    SqlCommand updateCommand = new SqlCommand(query1, connection);
                    updateCommand.Parameters.AddWithValue("@count", count+1);
                    updateCommand.Parameters.AddWithValue("@isbn", isbn);


                    if (Convert.ToInt32(updateCommand.ExecuteNonQuery()) > 0 && Convert.ToInt32(insertCommand.ExecuteNonQuery())>0)
                    {
                        MessageBox.Show("Book downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to download!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

            }

            flowLayoutPanel1.Controls.Clear();
                LoadBookData();

        }

        private void RateButton_Click(object sender, EventArgs e)
        {
            Button rateButton = (Button)sender;
            string isbn = rateButton.Tag.ToString();

            eBookRating obj1 = new eBookRating(userName, isbn);
            obj1.Show();
            obj1.FormClosed += UpdateFormClosed;

        }

        private void UpdateFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            LoadBookData();
        }
    }
}
