using FontAwesome.Sharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.AccessControl;
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
        bool inmotion = false; // for dropdown menu items
        Timer epndTmr = new Timer(); // for dropdown menu items, timer has to be declared here to be accessable by the tick event
        Timer MenuepndTmr = new Timer();
        bool menuCollapsed = false;
        bool menuInmotion = false;
        Control parentPanel; // for dropdown menu items
        Button previousButton;

        public Form1()
        {
            InitializeComponent();
            this.Text = "CompSci Revision";
            this.Icon = Properties.Resources.icon;
            DisableButton(panelMain, icBtnHistory);
        }

        private void ActivateButton(object sender, string colourName) // when a button is clicked, this should be called
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender) // if currentButton is not the one that was clicked
                {
                    DisableButton(panelMenu,previousButton); // turn the button into a normal, unselected button
                    Color colour = programColoursClass.getcolour(colourName);
                    currentButton = (Button)sender; // set the button that was clicked as currentButton
                    currentButton.BackColor = colour; // change to visual proporties of selected button
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
                    panelTitleBar.BackColor = colour; // make title bar match colour
                    labelTitle.Text = currentButton.Text;
                    panelLogo.BackColor = programColoursClass.ChangeColorBrightness(colour, -0.3f); // make logo area slightly darker
                    labelLogo.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f); // make logo text slightly lighter
                    labelTitle.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f);
                    buttonClose.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f);
                    buttonMinMax.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f);
                    menuCollapseIcnBtn.IconColor = programColoursClass.ChangeColorBrightness(colour, +0.6f);
                    previousButton = currentButton;
                }
            }
        }

        private void DisableButton(Panel TparentPanel, Button prev) // returning a button to a normal one when another button is selected
        {
            prev.BackColor = programColoursClass.getcolour("1");
            prev.ForeColor = Color.Gainsboro;
            prev.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
        }

        private void openSubForm(Form subForm, object sender,string colourName) // open a windows form within the content area (right of sidebar, down of title bar)
        {                                                      // the sub form needing opening is passed into this subr
            if (currentForm != null)
            {
                currentForm.Hide (); // if there is currently a sub-form open, close it
                currentForm.SuspendLayout();
                //currentForm.Dispose();
            }

            ActivateButton(sender, colourName); // make the button active 
            currentForm = subForm; // make the passed in subr currentForm
            currentForm.BringToFront(); // making sure it looks and fits right
            currentForm.Dock = DockStyle.Fill;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.TopLevel = false; // making it not a parent form
            this.panelMain.Controls.Add(currentForm); // adding it to the collection of controls the main panel has
            currentForm.Show(); // showing, incase it was hidden
        }

        private void loadMenuItems()
        {
            var sub1 = generateSubMenu(panelMenu, "Reverse Polish Notation");
            //var sub1_01 = generateSubMenuChildButton(sub1,4, new LRpn3("8"), "How to Evaluate", "8");
            var sub1_02 = generateSubMenuChildButton(sub1,3, new LRpn("3"), "What is RPN?", "3");
            var sub1_03 = generateSubMenuChildButton(sub1,2, new LRpn2("8"), "Infix to RPN", "8");
            var sub1_04 = generateSubMenuChildButton(sub1,1, new QRpn("7"), "Test", "7");
            renderPanel(sub1, 4);
            var sub2 = generateSubMenu(panelMenu, "Merge Sort");
            var sub2_01 = generateSubMenuChildButton(sub2, 2, new LMERGE("9"), "How to Merge Sort","9");
            var sub2_02 = generateSubMenuChildButton(sub2, 1, new QMerge("7"), "Test", "7");
            renderPanel(sub2, 3);
            var sub3 = generateSubMenu(panelMenu, "Floating Binary");
            var sub3_01 = generateSubMenuChildButton(sub3, 1, new QFloatBinary("3"), "Test","3");
            renderPanel(sub3, 2);
        }

        private void Form1_Load(object sender, EventArgs e) //on form1 load
        {
            previousButton = icBtnHome;
            loadMenuItems();
            BackColor = Color.White; //set the mainbackground colour to white: this is covered by the sub-form
            panelMenu.BackColor = programColoursClass.getcolour("1"); //sets the sidebar colour to the 1 color variable

            foreach (Control subPanel in panelMenu.Controls) // on load, collapse all submenus
            {
                if (subPanel.GetType() == typeof(Panel) && subPanel.Tag.ToString() == "subMenuPanel")
                {
                    subPanel.Height = subPanel.MinimumSize.Height;
                }
            }
            labelName.Text = utils.getUsername();
            openSubForm(new subformHome("2"), icBtnHome, "2"); // on load, preselect the home button and load home
            epndTmr.Tick += new System.EventHandler(epndTmrTick); // creates a new timer tick event handler
            MenuepndTmr.Tick += new System.EventHandler(MenuepndTmrTick); // creates a new timer tick event handler
        }

        private void icBtnHome_Click(object sender, EventArgs e) // button click event for the menu bar: Home
        {
            string wantedColour = "2";
            openSubForm(new subformHome(wantedColour), sender, wantedColour);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string wantedColour = "3";
            openSubForm(new QRpn(wantedColour), sender, wantedColour);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "2");
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
            //if (WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            parentButton_Click(sender);
        }

        private void parentButton_Click(object sender)
        {
            if (inmotion)
            {

            }
            else
            {
                epndTmr.Enabled = true; // make sure the timer is enabled
                epndTmr.Interval = 25;
                IconButton topButton = (IconButton)sender;
                parentPanel = topButton.Parent; // sets the panel the parent button in as the parentPanel
                inmotion = true;

                if (topButton.IconChar == IconChar.AngleDown) // changes the icon to the right ver.
                {
                    parentButtCollapsed = true;
                    topButton.IconChar = IconChar.AngleRight;
                }
                else
                {
                    parentButtCollapsed = false;
                    topButton.IconChar = IconChar.AngleDown;
                }
            }
            
        }
                

        private void renderPanel(Panel mainPanel, int numberOfSubMenusPlusNumberOfChildButtons)
        {
            mainPanel.MaximumSize = new Size(220, numberOfSubMenusPlusNumberOfChildButtons * 60);
            List<Control> listOfControls = new List<Control>();
            List<int> positions = new List<int>();
            foreach (Control cntrl in mainPanel.Controls)
            {
                if(cntrl.Tag.ToString() != "parent")
                {
                    positions.Add(Int32.Parse(cntrl.Tag.ToString()));
                    listOfControls.Add(cntrl);
                }
            }


            for (int j = 0; j <= listOfControls.Count - 2; j++)
            {
                for (int i = 0; i <= listOfControls.Count - 2; i++)
                {
                    if (positions[i] > positions[i + 1])
                    {
                        var temp = positions[i + 1];
                        positions[i + 1] = positions[i];
                        positions[i] = temp;

                        var temp2 = listOfControls[i + 1];
                        listOfControls[i + 1] = listOfControls[i];
                        listOfControls[i] = temp2;
                    }
                }
            }

            foreach(Control cntrl in listOfControls)
            {
                mainPanel.Controls.Remove(cntrl);
                mainPanel.Controls.Add(cntrl);
            }


            foreach (Control cntrl in mainPanel.Controls)
            {
                if (cntrl.Name == "parent")
                {
                    mainPanel.Controls.Remove(cntrl);
                    mainPanel.Controls.Add(cntrl);
                }
            }
        }


        private void MenuepndTmrTick(object sender, EventArgs e) // this is created at form load
        {
            panelMenu.MinimumSize = new Size(0, 635);
            panelMenu.HorizontalScroll.Visible = false;

            if (menuCollapsed && menuInmotion) // if the menu is closed, open it and then stop the timer
            {
                panelMenu.Width = panelMenu.Width + 10;
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    MenuepndTmr.Stop();
                    menuCollapsed = false;
                    menuInmotion = false; // needed as the timer does not stop perfectly and would start doing the opposite action for a few milliseconds
                    panelMenu.HorizontalScroll.Visible = true;
                }
            }

            if (!menuCollapsed && menuInmotion) // if the menu panel is open, close it and then stop the timer
            {
                panelMenu.Width = panelMenu.Width - 10;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    MenuepndTmr.Stop();
                    menuCollapsed = true;
                    menuInmotion = false;
                    panelMenu.HorizontalScroll.Visible = true;
                }
            }
        }


        private void epndTmrTick(object sender, EventArgs e) // this is created at form load
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
            openSubForm(new QRpn("3"), sender, "3");
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            openSubForm(new LRpn("2"), sender, "2");
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            openSubForm(new testForm(), sender, "2");
        }
    
        public Panel generateSubMenu(Panel higherPanel, string parentText)
        {
            Panel newSubMenu = new Panel();
            this.Controls.Add(newSubMenu);
            newSubMenu.Parent = higherPanel;
            newSubMenu.Dock = DockStyle.Top;
            newSubMenu.BringToFront();
            newSubMenu.BorderStyle = BorderStyle.None;
            newSubMenu.Tag = "subMenuPanel";
            newSubMenu.MinimumSize = new Size(220, 60);
            newSubMenu.MaximumSize = new Size(220, 60);
            newSubMenu.Show();
            var parentBtn = generateSubMenuParentButton(newSubMenu, parentText);
            parentBtn.TabStop = false;
            //newSubMenu.ControlAdded += (s, e) => { higherPanel.MaximumSize = higherPanel.MaximumSize + newSubMenu.Size;};
            return newSubMenu;
        }

        private IconButton generateSubMenuParentButton(Panel parentPanel, string text)
        {
            IconButton newParentButton = new IconButton();
            newParentButton.Parent = parentPanel;
            parentPanel.Controls.Add(newParentButton);
            newParentButton.Dock = DockStyle.Top;
            newParentButton.Text = text;
            newParentButton.Size = new Size(220, 60);
            newParentButton.MaximumSize = newParentButton.Size;
            newParentButton.Tag = "parent";
            newParentButton.Name = "parent";
            newParentButton.FlatStyle = FlatStyle.Flat;
            newParentButton.BackColor = programColoursClass.getcolour("1");
            newParentButton.ForeColor = Color.Gainsboro;
            newParentButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            newParentButton.FlatAppearance.BorderSize = 0;
            newParentButton.IconChar = IconChar.AngleDown;
            newParentButton.ImageAlign = ContentAlignment.MiddleLeft;
            newParentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            newParentButton.TextAlign = ContentAlignment.MiddleCenter;
            newParentButton.Padding = new Padding(4);
            newParentButton.IconColor = Color.White;
            newParentButton.Show();
            newParentButton.Click += (s, e) => { parentButton_Click(newParentButton); };
            return newParentButton;
        }

        private IconButton generateSubMenuChildButton(Panel parentPanel, int unimportance, Form formToOpen, string text, string wantedColour = "2") // must have an odd number of child buttons for some reason
        {
            IconButton newChildButton = new IconButton();
            newChildButton.Parent = parentPanel;
            parentPanel.Controls.Add(newChildButton);
            newChildButton.Dock = DockStyle.Top;
            newChildButton.Text = text;
            newChildButton.Size = new Size(220, 60);
            newChildButton.MaximumSize = newChildButton.Size;
            newChildButton.Tag = unimportance.ToString();
            newChildButton.FlatStyle = FlatStyle.Flat;
            newChildButton.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour("1"),+0.3f);
            newChildButton.ForeColor = Color.Gainsboro;
            newChildButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            newChildButton.FlatAppearance.BorderSize = 0;
            newChildButton.ImageAlign = ContentAlignment.MiddleLeft;
            newChildButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            newChildButton.TextAlign = ContentAlignment.MiddleCenter;
            newChildButton.Padding = new Padding(4);
            newChildButton.IconColor = Color.White;
            parentPanel.MaximumSize = parentPanel.MaximumSize + newChildButton.Size;
            newChildButton.Click += (s, e) => { openSubForm(formToOpen, newChildButton, wantedColour); };
            newChildButton.SendToBack();
            newChildButton.TabStop = false;
            parentPanel.Controls.SetChildIndex(newChildButton, Int32.Parse(newChildButton.Tag.ToString()));


            return newChildButton;
        }



        void button_Click2(object sender, System.EventArgs e)
        {
            openSubForm(new QRpn("1"), sender, "1");
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDrop1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelLogo_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void menuCollapseIcnBtn_Click(object sender, EventArgs e)
        {
            if (menuInmotion)
            {

            }
            else
            {
                MenuepndTmr.Enabled = true; // make sure the timer is enabled
                MenuepndTmr.Interval = 25;
                menuInmotion = true;
                IconButton daButton = (IconButton)sender;

                if (daButton.IconChar == IconChar.AngleDoubleRight) // changes the icon to the right ver.
                {
                    menuCollapsed = true;
                    daButton.IconChar = IconChar.AngleDoubleLeft;
                }
                else
                {
                    menuCollapsed = false;
                    daButton.IconChar = IconChar.AngleDoubleRight;
                }
            }
        }

        private void icBtnHistory_Click(object sender, EventArgs e)
        {
            openSubForm(new questionsCorrectTableForm("4"), sender, "4");
        }
    }
}
