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
    public partial class studentDesktop : Form
    {
        private string userName="";
        public studentDesktop(string userName)
        {
            this.userName = userName;
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
        private Form activeForm;
        private void openChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.desktopPanel.Controls.Add(childForm);
            this.desktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void dashBoardButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Dash Board";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");


            studentDashBoard obj1 = new studentDashBoard(userName);
            openChildForm(obj1, sender);
        }

        private void physicalBooksButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Physical Books";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");

            studentPhysicalBooks obj1 = new studentPhysicalBooks(userName);
            openChildForm(obj1, sender);
        }

        private void eBooksButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "E-Books";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");

            studentEbooks obj1 = new studentEbooks(userName);
            openChildForm(obj1, sender);
        }

        private void eventsButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Events";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");

            studentEvents obj1 = new studentEvents();
            openChildForm(obj1, sender);
        }

        private void virtualGroupsButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Virtual Groups";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");

            studentVirtualGroups obj1 = new studentVirtualGroups();
            openChildForm(obj1, sender);
        }

        private void borrowedDetailsButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Borrowings";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#39b54a");
            membersButton.BackColor = ColorTranslator.FromHtml("#19589D");

            studentBorrowings obj1 = new studentBorrowings();
            openChildForm(obj1, sender);
        }

        private void membersButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Members";
            dashBoardButton.BackColor = ColorTranslator.FromHtml("#19589D");
            physicalBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eBooksButton.BackColor = ColorTranslator.FromHtml("#19589D");
            eventsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            virtualGroupsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            borrowedDetailsButton.BackColor = ColorTranslator.FromHtml("#19589D");
            membersButton.BackColor = ColorTranslator.FromHtml("#39b54a");

            studentManageAccount obj1 = new studentManageAccount();
            openChildForm(obj1, sender);
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            login obj1 = new login();
            this.Close();
            obj1.Show();
        }
    }
}
