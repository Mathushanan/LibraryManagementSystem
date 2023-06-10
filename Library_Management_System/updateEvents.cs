using MySql.Data.MySqlClient;
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
    public partial class updateEvents : Form
    {
        private int eventId = 0;
        string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        public updateEvents(int eventId)
        {
            this.eventId = eventId;
            InitializeComponent();

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

        private void updateEvents_Load(object sender, EventArgs e)
        {
            string title = "";
            string description = "";
            string location = "";
            string dateTime="";
            byte[] imageData = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT title,image,description,location,date FROM events WHERE eventId=@eventId";
            try
            {
                connection.Open();
                MySqlCommand getCommand = new MySqlCommand(query, connection);
                getCommand.Parameters.AddWithValue("@eventId", eventId);

                MySqlDataReader reader = null;
                try
                {
                    reader = getCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        title = reader.GetString(0);
                        imageData = (byte[])reader.GetValue(1);
                        description = reader.GetString(2);
                        location = reader.GetString(3);
                        dateTime = reader.GetString(4);

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
                descriptionTextBox.Text = description;
                locationTextBox.Text = location;


                DateTime selectedDate = DateTime.Parse(dateTime);
                dateTimePicker2.Value = selectedDate;

                MemoryStream ms = new MemoryStream(imageData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                eventImage.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void updateEventButton_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            eventImage.Image.Save(ms, eventImage.Image.RawFormat);
            byte[] imageData = ms.ToArray();

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand updateCommand = new MySqlCommand("UPDATE events SET title=@title,image=@image,description=@description,location=@location,date=@dateTime WHERE eventId=@eventId",connection);
                updateCommand.Parameters.AddWithValue("@title", titleTextBox.Text);
                updateCommand.Parameters.AddWithValue("@image", imageData);
                updateCommand.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                updateCommand.Parameters.AddWithValue("@location", locationTextBox.Text);
                updateCommand.Parameters.AddWithValue("@dateTime", dateTimePicker2.Text);
                updateCommand.Parameters.AddWithValue("@eventId", eventId);

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
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

                eventImage.Image = image;
            }
        }
    }
}
