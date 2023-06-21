using Library_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class physicalBookRating : Form
    {
        
        
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\LibraryManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string isbn = "";
        string userName = "";

        public physicalBookRating(string userName,string isbn)
        {
            this.isbn = isbn;
            this.userName = userName;
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
        int rating = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.pink_star;

            pictureBox2.Image = Resources.green_star;
            pictureBox3.Image = Resources.green_star;
            pictureBox4.Image = Resources.green_star;
            pictureBox5.Image = Resources.green_star;

            rating = 1;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.pink_star;
            pictureBox2.Image = Resources.pink_star;

            pictureBox3.Image = Resources.green_star;
            pictureBox4.Image = Resources.green_star;
            pictureBox5.Image = Resources.green_star;

            rating = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.pink_star;
            pictureBox2.Image = Resources.pink_star;
            pictureBox3.Image = Resources.pink_star;

            pictureBox4.Image = Resources.green_star;
            pictureBox5.Image = Resources.green_star;

            rating = 3;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.pink_star;
            pictureBox2.Image = Resources.pink_star;
            pictureBox3.Image = Resources.pink_star;
            pictureBox4.Image = Resources.pink_star;

            pictureBox5.Image = Resources.green_star;

            rating = 4;


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.pink_star;
            pictureBox2.Image = Resources.pink_star;
            pictureBox3.Image = Resources.pink_star;
            pictureBox4.Image = Resources.pink_star;
            pictureBox5.Image = Resources.pink_star;

            rating = 5;

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int bookId = 0;
            int userId = 0;

            try
            {
                connection.Open();
                string query1 = "SELECT userId FROM users WHERE email=@userName";
                string query2 = "SELECT bookId FROM physicalbooks WHERE isbn=@isbn";

                SqlCommand userCommand = new SqlCommand(query1, connection);
                userCommand.Parameters.AddWithValue("@userName", userName);
                userId=Convert.ToInt32(userCommand.ExecuteScalar());

                SqlCommand bookCommand = new SqlCommand(query2, connection);
                bookCommand.Parameters.AddWithValue("@isbn",isbn);
                bookId = Convert.ToInt32(bookCommand.ExecuteScalar());



            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            int selectCount = 0;

            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM physicalbooks_ratings WHERE userId=@userId AND bookId=@bookId";

                SqlCommand selectCommand = new SqlCommand(query, connection);
                selectCommand.Parameters.AddWithValue("@userId", userId);
                selectCommand.Parameters.AddWithValue("@bookId", bookId);

                selectCount = Convert.ToInt32(selectCommand.ExecuteScalar());

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            if (selectCount > 0)
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE physicalbooks_ratings SET rating=@rating WHERE userId=@userId AND bookId=@bookId ";
                    SqlCommand updateCommand = new SqlCommand(query, connection);
                    updateCommand.Parameters.AddWithValue("@rating", rating);
                    updateCommand.Parameters.AddWithValue("@userId", userId);
                    updateCommand.Parameters.AddWithValue("@bookId", bookId);

                    if (Convert.ToInt32(updateCommand.ExecuteNonQuery())>0)
                    {
                        MessageBox.Show("Book rated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO physicalbooks_ratings (userId,bookId,rating) VALUES (@userId,@bookId,@rating)";
                    SqlCommand insertCommand = new SqlCommand(query, connection);
                    insertCommand.Parameters.AddWithValue("userId", userId);
                    insertCommand.Parameters.AddWithValue("bookId", bookId);
                    insertCommand.Parameters.AddWithValue("rating", rating);

                    int count = Convert.ToInt32(insertCommand.ExecuteNonQuery());

                    if (count > 0)
                    {
                        MessageBox.Show("Book rated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occured while rating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }


            
        }
    }
}
