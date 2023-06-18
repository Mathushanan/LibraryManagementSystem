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
    public partial class addEvent : Form
    {
        private Image defaultImage;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public addEvent()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Image image = Image.FromFile(fileName);

                eventImage.Image = image;
            }
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string descriptionText=descriptionTextBox.Text;
            string description = descriptionText.Length > 22 ? descriptionText.Substring(0, 22) :descriptionText;
            string location = locationTextBox.Text;
            string date_time = dateTimePicker2.Value.ToString();


            if(titleTextBox.Text==""||descriptionTextBox.Text==""||locationTextBox.Text=="")
            {
                MessageBox.Show("Please fill all the fields first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (eventImage.Image == null || eventImage.Image == defaultImage)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                try
                {
                    int count = 0;
                    SqlConnection connection = new SqlConnection(connectionString);
                    string query1 = "SELECT COUNT(*) FROM events WHERE title=@title";
                    SqlCommand checkCommand = new SqlCommand(query1, connection);
                    try
                    {
                        connection.Open();
                        checkCommand.Parameters.AddWithValue("@title", title);
                        count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    }
                    finally
                    {
                        connection.Close();
                    }

                    if(count>0)
                    {
                        MessageBox.Show("The Event with the given title has already been added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        byte[] imageData;
                        MemoryStream ms = new MemoryStream();
                        try
                        {
                            eventImage.Image.Save(ms, eventImage.Image.RawFormat);
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
                            string query2 = "INSERT INTO events (title,image,description,location,date) VALUES (@title,@ImageData,@description,@location,@date)";
                            SqlCommand command = new SqlCommand(query2, connection);
                            try
                            {
                                command.Parameters.AddWithValue("@ImageData", imageData);
                                command.Parameters.AddWithValue("@title", title);
                                command.Parameters.AddWithValue("@description", description);
                                command.Parameters.AddWithValue("@location", location);
                                command.Parameters.AddWithValue("@date", date_time);

                                command.ExecuteNonQuery();
                            }
                            finally
                            {
                                connection.Close();
                                command.Dispose();
                            }


                            clearAllDeatils();
                            MessageBox.Show("Image and details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving the image and details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                
            }

            
        }

        private void addEvent_Load(object sender, EventArgs e)
        {
            defaultImage = eventImage.Image;
        }

        private void clearAllDeatils()
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            locationTextBox.Text = "";
            eventImage.Image = defaultImage;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            clearAllDeatils();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
