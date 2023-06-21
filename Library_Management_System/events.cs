using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class events : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public events()
        {
            InitializeComponent();
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            addEvent obj1 = new addEvent();
            obj1.FormClosed += formClosed;
            obj1.Show();
        }
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
        }

        private void events_Load(object sender, EventArgs e)
        {
            LoadBookData();
        }
        private void LoadBookData()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM events", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();
                    string location = row["location"].ToString();
                    string dateTime = row["date"].ToString();
                    int eventId =Convert.ToInt32(row["eventId"]);
                    byte[] imageData = (byte[])row["image"];

                    

                    CreateProfileCard(title,description,location,dateTime, imageData,eventId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }

        }

       

        private void CreateProfileCard(string title, string description, string location, string dateTime, Byte[] imageData,int eventId)
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



            Label descriptionLabel = new Label();
            descriptionLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            descriptionLabel.Text = "Description: ";
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(10, 30);
            profileCard.Controls.Add(descriptionLabel);

            Label retrivedDescriptionLabel = new Label();
            retrivedDescriptionLabel.Text = description.ToString();
            retrivedDescriptionLabel.AutoSize = true;
            retrivedDescriptionLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedDescriptionLabel.Location = new System.Drawing.Point(descriptionLabel.Right, descriptionLabel.Top);
            profileCard.Controls.Add(retrivedDescriptionLabel);
            descriptionLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedDescriptionLabel.Font = new Font(retrivedDescriptionLabel.Font, FontStyle.Bold);
           

            Label locationLabel = new Label();
            locationLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            locationLabel.Text = "Location: ";
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(10, 50);
            profileCard.Controls.Add(locationLabel);
            Label retrivedLocationLabel = new Label();
            retrivedLocationLabel.Text = location.ToString();
            retrivedLocationLabel.AutoSize = true;
            retrivedLocationLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedLocationLabel.Location = new System.Drawing.Point(locationLabel.Right, locationLabel.Top);
            profileCard.Controls.Add(retrivedLocationLabel);
            locationLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedLocationLabel.Font = new Font(retrivedLocationLabel.Font, FontStyle.Bold);

            Label dateTimeLabel = new Label();
            dateTimeLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            dateTimeLabel.Text = "Date & Time: ";
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new System.Drawing.Point(10, 70);
            profileCard.Controls.Add(dateTimeLabel);
            Label retrivedDateTimeLabel = new Label();
            retrivedDateTimeLabel.Text = dateTime.ToString();
            retrivedDateTimeLabel.AutoSize = true;
            retrivedDateTimeLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedDateTimeLabel.Location = new System.Drawing.Point(dateTimeLabel.Right, dateTimeLabel.Top);
            profileCard.Controls.Add(retrivedDateTimeLabel);
            dateTimeLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedDateTimeLabel.Font = new Font(retrivedDateTimeLabel.Font, FontStyle.Bold);


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
            deleteButton.Tag = eventId; 
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
            updateButton.Tag = eventId;
            updateButton.Click += UpdateButton_Click;
            profileCard.Controls.Add(updateButton);


            

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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int eventId = Convert.ToInt32(deleteButton.Tag);



            DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                    connection.Open();
                    string query = "DELETE FROM events WHERE eventId = @eventId";
                    SqlCommand deleteCommand = new SqlCommand(query, connection);
                    deleteCommand.Parameters.AddWithValue("@eventId", eventId);

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
            int eventId = Convert.ToInt32(updateButton.Tag);

            updateEvents obj1 = new updateEvents(eventId);
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
                SqlCommand command = new SqlCommand("SELECT * FROM events WHERE title LIKE @searchKey OR description LIKE @searchKey OR location LIKE @searchKey OR date LIKE @searchKey", connection);
                command.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();
                    string location = row["location"].ToString();
                    string dateTime = row["date"].ToString();
                    int eventId = Convert.ToInt32(row["eventId"]);
                    byte[] imageData = (byte[])row["image"];



                    CreateProfileCard(title, description, location, dateTime, imageData, eventId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }
        }
    }
}
