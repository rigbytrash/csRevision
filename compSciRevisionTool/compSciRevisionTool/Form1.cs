using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class Form1 : Form
    {
        private Button currentButton; // the menu button that is currently selected
        private Form currentForm; // the current sub form in use
        bool drag; // if the title bar is currently being dragged
        Point starting; //staring position before dragging
        bool temp;
        bool parentButtCollapsed = true; // for dropdown menu items
        bool inmotion = true; // for dropdown menu items
        Timer epndTmr = new Timer(); // for dropdown menu items, timer has to be declared here to be accessable by the tick event

        public Form1()
        {
            InitializeComponent();
        }

        private void ActivateButton(object sender, string colourName) // when a button is clicked, this should be called
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender) // if currentButton is not the one that was clicked
                {
                    DisableButton(); // turn the button into a normal, unselected button
                    Color colour = programColoursClass.getcolour(colourName);
                    currentButton = (Button)sender; // set the button that was clicked as currentButton
                    currentButton.BackColor = colour; // change to visual proporties of selected button
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
                    panelTitleBar.BackColor = colour; // make title bar match colour
                    labelTitle.Text = currentButton.Text;
                    panelLogo.BackColor = programColoursClass.ChangeColorBrightness(colour, -0.3f); // make logo area slightly darker
                    labelLogo.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f); // make logo text slightly lighter
                }
            }
        }

        private void DisableButton() // returning a button to a normal one when another button is selected
        {
            foreach (Control previousButton in panelMenu.Controls) // for each object in the sidebar
            {
                if (previousButton.GetType() == typeof(IconButton)) // if the object is an IconButton, return it to the regular style
                {
                    previousButton.BackColor = programColoursClass.getcolour("base");
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
                }
            }
            
            foreach (Control subPanel in panelMenu.Controls)
            {
                if (subPanel.GetType() == typeof(Panel) && subPanel.Tag.ToString() == "subMenuPanel")
                {
                    foreach (Control previousButton in subPanel.Controls) // for each object in the sidebar
                    {
                        if (previousButton.GetType() == typeof(IconButton)) // if the object is an IconButton, return it to the regular style
                        {
                            previousButton.BackColor = programColoursClass.getcolour("base");
                            previousButton.ForeColor = Color.Gainsboro;
                            previousButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
                        }
                    }
                }
            }
        }


        private void openSubForm(Form subForm, object sender,string colourName) // open a windows form within the content area (right of sidebar, down of title bar)
        {                                                      // the sub form needing opening is passed into this subr
            if (currentForm != null)
            {
                currentForm.Close(); // if there is currently a sub-form open, close it
            }
            ActivateButton(sender, colourName); // make the button active 
            currentForm = subForm; // make the passed in subr currentForm
            subForm.BringToFront(); // making sure it looks and fits right
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.TopLevel = false; // making it not a parent form
            this.panelMain.Controls.Add(subForm); // adding it to the collection of controls the main panel has
            subForm.Show(); // showing, incase it was hidden
        }

        private void Form1_Load(object sender, EventArgs e) //on form1 load
        {
            BackColor = Color.White; //set the mainbackground colour to white: this is covered by the sub-form
            panelMenu.BackColor = programColoursClass.getcolour("base"); //sets the sidebar colour to the base color variable
            foreach (Control subPanel in panelMenu.Controls)
            {
                if (subPanel.GetType() == typeof(Panel) && subPanel.Tag.ToString() == "subMenuPanel")
                {
                    subPanel.Height = subPanel.MinimumSize.Height;
                }
            }
        }

        private void icBtnHome_Click(object sender, EventArgs e) // button click event for the menu bar: Home
        {
            //ActivateButton(sender);
            string wantedColour = "secondary";
            openSubForm(new subformHome(programColoursClass.getcolour(wantedColour)), sender, wantedColour);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string wantedColour = "3";
            openSubForm(new QRpn(programColoursClass.getcolour(wantedColour)), sender, wantedColour);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "secondary");
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e) // x button in the top right
        {
            Application.Exit(); // closes the entire program
        }

        private void buttonExpand_Click(object sender, EventArgs e) // maximize button
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonMinMax_Click(object sender, EventArgs e) // minimize button
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e) // move the window to where it is dragged
        {
            if (drag)
            {
                Point P = PointToScreen(e.Location);
                Location = new Point(P.X - this.starting.X, P.Y - this.starting.Y);
            }
        }

        private void panelTitleBar_MouseDoubleClick(object sender, MouseEventArgs e) // if the titlebar is double-clicked, then maximise and vice verca
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            parentButton_Click(sender);
        }

        private void parentButton_Click(object sender)
        {
            epndTmr.Enabled = true; // make sure the timer is enabled
            //epndTmr.Start();
            epndTmr.Interval = 25;
            IconButton topButton = (IconButton)sender;
            Control parentPanel = topButton.Parent; // sets the panel the parent button in as the parentPanel
            if (!inmotion)
            {
                epndTmr.Tick -= new System.EventHandler((a, b) => epndTmrTick(a, b, parentPanel)); // BUG: too many ticks are being created and this isnt destoying them, seemingly - but RAM usage doesn't support my opinion
                //MessageBox.Show("REMOVED");
            }
            epndTmr.Tick += new System.EventHandler((a, b) => epndTmrTick(a, b, parentPanel)); // creates a new timer tick event handler
            inmotion = true;

            if (topButton.IconChar == IconChar.AngleDown) // changes the icon to the right ver.
            {
                topButton.IconChar = IconChar.AngleRight;
            }
            else
            {
                topButton.IconChar = IconChar.AngleDown;
            }
        }
                

        private void epndTmrTick(object sender, EventArgs e, Control parentPanel)
        {
            if (parentButtCollapsed && inmotion) // if the menu is closed, open it and then stop the timer
            {
                parentPanel.Height = parentPanel.Height + 10;
                if (parentPanel.Height == parentPanel.MaximumSize.Height)
                {
                    epndTmr.Stop();
                    parentButtCollapsed = false;
                    inmotion = false; // needed as the timer does not stop perfectly and would start doing the opposite action for a few milliseconds
                }
            }
            if (!parentButtCollapsed && inmotion) // if the menu is open, close it and then stop the timer
            {
                parentPanel.Height = parentPanel.Height - 10;
                if (parentPanel.Height == parentPanel.MinimumSize.Height)
                {
                    epndTmr.Stop();
                    parentButtCollapsed = true;
                    inmotion = false;
                }
            }
        }

        private void iconButtonSubDrop1_Click(object sender, EventArgs e)
        {
            openSubForm(new QRpn(programColoursClass.getcolour("3")), sender, "3");
        }
    }
}
