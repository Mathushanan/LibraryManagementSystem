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
    public partial class registerEvent : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mathu\\OneDrive\\Desktop\\Project\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        int eventId = 0;
        string userName="";
        public registerEvent(int eventId,string userName)
        {
            this.eventId = eventId;
            this.userName = userName;
            InitializeComponent();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerEventButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int userId = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT userId FROM users WHERE email=@userName", connection);
                command.Parameters.AddWithValue("@userName", userName);

                userId = Convert.ToInt32(command.ExecuteScalar());


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }


            try
            {
                connection.Open();

                string query1 = "SELECT COUNT(*) FROM eventregistrations WHERE eventId=@eventId AND userId=@userId";
                SqlCommand selectCommand = new SqlCommand(query1, connection);
                selectCommand.Parameters.AddWithValue("@eventId", eventId);
                selectCommand.Parameters.AddWithValue("@userId", userId);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("You have already registered to this event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "INSERT INTO eventregistrations (eventId,userId) VALUES (@eventId,@userId)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.Parameters.AddWithValue("@userId", userId);

                    if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("Registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can not regiter at the moment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerEvent_Load(object sender, EventArgs e)
        {
            string title = "";
            string description = "";
            string location = "";
            string dateTime = "";
            byte[] imageData = null;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT title,image,description,location,date FROM events WHERE eventId=@eventId";
            try
            {
                connection.Open();
                SqlCommand getCommand = new SqlCommand(query, connection);
                getCommand.Parameters.AddWithValue("@eventId", eventId);

                SqlDataReader reader = null;
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

            dateTimePicker2.Enabled = false;
            descriptionTextBox.Enabled = false;
            descriptionTextBox.BackColor=Color.White;
            titleTextBox.Enabled = false;
            titleTextBox.BackColor = Color.White;
            locationTextBox.Enabled = false;
            locationTextBox.BackColor = Color.White;

            

        }
    }
}
