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
    public partial class binaryTreeMain : Form
    {
        Form currentForm;
        public binaryTreeMain()
        {
            InitializeComponent();
            goNext();
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            goNext();   
        }

        private void goNext()
        {
            if (currentForm != null)
            {
                currentForm.Hide();
                mainPanelForQ.Controls.Remove(currentForm);
            }
            currentForm = new QbinaryTree();
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            mainPanelForQ.Controls.Add(currentForm);
            currentForm.Show();
        }
    }
}
