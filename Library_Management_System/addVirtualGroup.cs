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
    public partial class addVirtualGroup : Form
    {
        string connectionString = "server=localhost;database=libraryManagementSystem;uid=root;password=;";
        private Image defaultImage;
        public addVirtualGroup()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Image image = Image.FromFile(fileName);

                virtualGroupImage.Image = image;
            }
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            string groupLink = groupLinkTextBox.Text;
            string dateTime = dateTimePicker2.Value.ToString();

            if(nameTextBox.Text==""||groupLinkTextBox.Text==""||descriptionTextBox.Text=="")
            {
                MessageBox.Show("Please fill all the fields first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (virtualGroupImage.Image == null || virtualGroupImage.Image == defaultImage)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                try
                {
                    int count = 0;
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    string query1 = "SELECT COUNT(*) FROM virtualgroups WHERE name=@name";
                    MySqlCommand checkcommand = new MySqlCommand(query1, connection);

                    try
                    {
                        connection.Open();
                        checkcommand.Parameters.AddWithValue("@name", name);
                        count = Convert.ToInt32(checkcommand.ExecuteScalar());

                    }
                    finally
                    {
                        connection.Close();
                    }

                    if(count>0)
                    {
                        MessageBox.Show("The group with the given name has already been added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        byte[] imageData;
                        MemoryStream ms = new MemoryStream();
                        try
                        {
                            virtualGroupImage.Image.Save(ms, virtualGroupImage.Image.RawFormat);
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
                            string query2 = "INSERT INTO virtualgroups (name,description,url,image,dateTime) VALUES (@name,@description,@groupLink,@ImageData,@dateTime)";
                            MySqlCommand command = new MySqlCommand(query2, connection);
                            try
                            {
                                command.Parameters.AddWithValue("@ImageData", imageData);
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@description", description);
                                command.Parameters.AddWithValue("@groupLink", groupLink);
                                command.Parameters.AddWithValue("@dateTime", dateTime);
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

        private void addVirtualGroup_Load(object sender, EventArgs e)
        {
            defaultImage = virtualGroupImage.Image;
            dateTimePicker2.Enabled = false;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void clearAllDeatils()
        {
            nameTextBox.Text = "";
            descriptionTextBox.Text = "";
            groupLinkTextBox.Text = "";
            virtualGroupImage.Image = defaultImage;
            
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
