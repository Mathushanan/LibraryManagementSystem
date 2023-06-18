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
    public partial class librarianDesktop : Form
    {
        private Form activeForm;
        public librarianDesktop()
        {
            InitializeComponent();
        }

      

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
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


            librarianDashBoard obj1 = new librarianDashBoard();
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

            physicalBooks obj1 = new physicalBooks();
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

            eBooks obj1 = new eBooks();
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

            events obj1=new events();
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

            virtualGroups obj1 = new virtualGroups();
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

            borrowedDetails obj1 = new borrowedDetails();
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

            manageMembers obj1 = new manageMembers();
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
