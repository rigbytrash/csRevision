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
        private Form currentForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    DisableButton();
                    Color colour = programColoursClass.getcolour("secondary");
                    currentButton = (Button)sender;
                    currentButton.BackColor = colour;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = colour;
                    labelTitle.Text = currentButton.Text;
                    panelLogo.BackColor = programColoursClass.ChangeColorBrightness(colour, -0.3f);
                    labelLogo.ForeColor = programColoursClass.ChangeColorBrightness(colour, +0.6f);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panelMenu.Controls)
            {
                if (previousButton.GetType() == typeof(IconButton))
                {
                    previousButton.BackColor = programColoursClass.getcolour("base");
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void openSubForm(Form subForm, object sender)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            ActivateButton(sender);
            currentForm = subForm;
            subForm.BringToFront();
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.TopLevel = false;
            this.panelMain.Controls.Add(subForm);
            subForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            panelMenu.BackColor = programColoursClass.getcolour("base");
            //BackColor = programColoursClass.getcolour("base");
        }

        private void icBtnHome_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            openSubForm(new subformHome(), sender);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonExpand_Click(object sender, EventArgs e)
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

        private void buttonMinMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
