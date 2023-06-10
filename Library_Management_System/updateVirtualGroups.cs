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
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class updateVirtualGroups : Form
    {
        private string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        int groupId = 0;
        public updateVirtualGroups(int groupId)
        {
            this.groupId=groupId;
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

        private void updateVirtualGroups_Load(object sender, EventArgs e)
        {
            string name = "";
            string description = "";
            string dateTime = "";
            byte[] imageData = null;
            string url = "";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT name,description,url,image,dateTime FROM virtualGroups WHERE groupId=@groupId";
            try
            {
                connection.Open();
                MySqlCommand getCommand = new MySqlCommand(query, connection);
                getCommand.Parameters.AddWithValue("@groupId", groupId);

                MySqlDataReader reader = null;
                try
                {
                    reader = getCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        name = reader.GetString(0);
                        description = reader.GetString(1);
                        url = reader.GetString(2);
                        imageData = (byte[])reader.GetValue(3);
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
                nameTextBox.Text = name;
                descriptionTextBox.Text = description;
                urlTextBox.Text = url;
                dateTimePicker2.Value= DateTime.Parse(dateTime);

                MemoryStream ms = new MemoryStream(imageData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                virtualGroupImage.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                virtualGroupImage.Image = image;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBooksButton_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            virtualGroupImage.Image.Save(ms,virtualGroupImage.Image.RawFormat);
            byte[] imageData = ms.ToArray();


            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "UPDATE virtualgroups SET description=@description,url=@url,image=@image WHERE groupId=@groupId";
            try
            {
                connection.Open();
                MySqlCommand updateCommand = new MySqlCommand(query, connection);
                
                updateCommand.Parameters.AddWithValue("@image", imageData);
                updateCommand.Parameters.AddWithValue("@description",descriptionTextBox.Text);
                updateCommand.Parameters.AddWithValue("@url", urlTextBox.Text);
                updateCommand.Parameters.AddWithValue("@groupId", groupId);
               

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
