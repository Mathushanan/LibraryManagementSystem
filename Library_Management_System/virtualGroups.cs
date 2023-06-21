using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace Library_Management_System
{
    public partial class virtualGroups : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        int groupId = 0;
        public virtualGroups()
        {
            InitializeComponent();
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            addVirtualGroup obj1 = new addVirtualGroup();
            obj1.FormClosed += addBooksFormClosed;
            obj1.Show();
        }

        private void addgroupsFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBookData();
        }

        private void virtualGroups_Load(object sender, EventArgs e)
        {
            LoadBookData();
        }
        private void LoadBookData()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM virtualgroups", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    
                    string name = row["name"].ToString();
                    string description = row["description"].ToString();
                    string url = row["url"].ToString();                  
                    byte[] imageData = (byte[])row["image"];
                    groupId = Convert.ToInt32(row["groupId"]);
                    string dateTime = row["dateTime"].ToString();


                    CreateProfileCard(name,description,url, imageData,dateTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
            }

        }

        

        private void CreateProfileCard(string name, string description, string url, Byte[] imageData,string dateTime)
        {


            Panel profileCard = new Panel();
            profileCard.BorderStyle = BorderStyle.Fixed3D;
            profileCard.Width = 350;
            profileCard.Height = 150;


            Label nameLabel = new Label();
            nameLabel.Text = "Name: ";
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);
            nameLabel.Location = new System.Drawing.Point(10, 10);
            profileCard.Controls.Add(nameLabel);
            Label retrivedNameLabel = new Label();
            retrivedNameLabel.Text = name.ToString();
            retrivedNameLabel.AutoSize = true;
            retrivedNameLabel.ForeColor = ColorTranslator.FromHtml("#39b54a");
            retrivedNameLabel.Location = new System.Drawing.Point(nameLabel.Right, nameLabel.Top);
            profileCard.Controls.Add(retrivedNameLabel);
            nameLabel.ForeColor = ColorTranslator.FromHtml("#19589d");
            retrivedNameLabel.Font = new Font(retrivedNameLabel.Font, FontStyle.Bold);

            Label descriptionLabel = new Label();
            descriptionLabel.Font = new Font(descriptionLabel.Font, FontStyle.Bold);
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

            Label dateTimeLabel = new Label();
            dateTimeLabel.Font = new Font(dateTimeLabel.Font, FontStyle.Bold);
            dateTimeLabel.Text = "Created on: ";
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new System.Drawing.Point(10, 50);
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
            deleteButton.Tag = groupId; 
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
            updateButton.Tag = groupId;
            updateButton.Click += UpdateButton_Click;
            profileCard.Controls.Add(updateButton);

            Button joinButton = new Button();
            joinButton.Name = "join";
            joinButton.FlatStyle = FlatStyle.Flat;
            joinButton.FlatAppearance.BorderSize = 0;
            joinButton.BackColor = ColorTranslator.FromHtml("#8dc63f");
            joinButton.ForeColor = Color.White;
            joinButton.Text = "Join";
            joinButton.Location = new System.Drawing.Point(170, 120);
            joinButton.Tag = groupId;
            joinButton.Click += joinButton_Click;
            profileCard.Controls.Add(joinButton);

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
                    string query = "DELETE FROM virtualgroups WHERE groupId = @groupId";
                    SqlCommand deleteCommand = new SqlCommand(query, connection);
                    deleteCommand.Parameters.AddWithValue("@groupId", groupId);

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
            int bookId = Convert.ToInt32(updateButton.Tag);

            updateVirtualGroups obj1 = new updateVirtualGroups(bookId);
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
                SqlCommand command = new SqlCommand("SELECT * FROM virtualgroups WHERE name LIKE @searchKey OR description LIKE @searchKey", connection);
                command.Parameters.AddWithValue("@searchKey", "%" + searchKey + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row["name"].ToString();
                    string description = row["description"].ToString();
                    string url = row["url"].ToString();
                    byte[] imageData = (byte[])row["image"];
                    string dateTime = row["dateTime"].ToString();


                    CreateProfileCard(name, description, url, imageData,dateTime);
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
        }

        private void joinButton_Click(object sender, EventArgs e)
        {

            Button joinButton = (Button)sender;
            int groupId = Convert.ToInt32(joinButton.Tag);
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand retrieveCommand = new SqlCommand("SELECT url FROM virtualgroups WHERE groupId=@groupId", connection);
                retrieveCommand.Parameters.AddWithValue("@groupId", groupId);
                object result = retrieveCommand.ExecuteScalar();

                if (result != null)
                {
                    string groupLink = result.ToString();

                    try
                    {
                        Process.Start(groupLink);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening WhatsApp group: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Group link not found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Group data "+ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
