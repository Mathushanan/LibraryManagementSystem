using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class adminDesktop : Form
    {
        private Form activeForm;
        
        public adminDesktop()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void openChildForm(Form childForm,object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel =false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.desktopPanel.Controls.Add(childForm);
            this.desktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void desktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashBoardButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Dash Board";
            dashBoardButton.BackColor=ColorTranslator.FromHtml("#39b54a");
            addLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
            manageLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
           

            openChildForm(new adminDashBoard(), sender);
        }

        private void addLibrariansButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Add Librarians";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            addLibrariansButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            manageLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
            

            openChildForm(new addLibrarians(), sender);
        }

        private void manageLibrariansButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Manage Librarians";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            addLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
            manageLibrariansButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            

            openChildForm(new manageUsers(), sender);
        }
    
        private void logOutButton_Click(object sender, EventArgs e)
        {
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            addLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
            manageLibrariansButton.BackColor = ColorTranslator.FromHtml("#19589D");
            logOutButton.BackColor= ColorTranslator.FromHtml("#39b54a");
            login obj1 = new login();

            this.Close();
            obj1.Show();
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
