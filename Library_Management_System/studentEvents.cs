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

namespace Library_Management_System
{

    public partial class studentEvents : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string userName = "";
        public studentEvents(string userName)
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

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            LoadBookData();
        }

        private void studentEvents_Load(object sender, EventArgs e)
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



        private void CreateProfileCard(string title, string description, string location, string dateTime, Byte[] imageData, int eventId)
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


            Button registerButton = new Button();
            registerButton.Name = "register";
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.BackColor = ColorTranslator.FromHtml("#007BFF");
            registerButton.ForeColor = Color.White;
            registerButton.Width = 100;
            registerButton.Text = "Register";  
            registerButton.Tag = eventId; 
            registerButton.Click += RegisterButton_Click;
            profileCard.Controls.Add(registerButton);
            registerButton.AutoSize = true;
            registerButton.Anchor = AnchorStyles.None;
            registerButton.Location = new System.Drawing.Point((profileCard.Width - registerButton.Width) / 2, 120);





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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
            int eventId = Convert.ToInt32(updateButton.Tag);

            registerEvent obj1 = new registerEvent(eventId,userName);
            obj1.Show();
            obj1.FormClosed += RegisterFormClosed;

        }

        private void RegisterFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
        }

    }
}
