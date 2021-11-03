using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class loginRegForm : Form
    {
        bool drag; // if the title bar is currently being dragged
        Point starting; //staring position before dragging
        Form currentForm = new LoginForm();
        string currentActiveWindow = "...";
        public loginRegForm()
        {
            InitializeComponent();
            currentForm.TopLevel = false;
            mainPanel.Controls.Add(currentForm);
            currentForm.Show();
        }

        private void loginRegForm_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form main = new Form1();
            main.Show();
            this.Hide();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            starting = new Point(e.X, e.Y);
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point P = PointToScreen(e.Location);
                Location = new Point(P.X - this.starting.X, P.Y - this.starting.Y);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // closes the entire program
        }

        private void buttonMinMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitleBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void controlAdded(object sender, ControlEventArgs e)
        {
            if (currentActiveWindow != "login")
            {
                currentActiveWindow = "login";
                labelTitle.Text = "login";
            }
            else
            {
                currentActiveWindow = "register";
                labelTitle.Text = "register";
            }
            
        }
    }
}
