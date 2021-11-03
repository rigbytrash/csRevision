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
    public partial class LoginForm : Form
    {
        Form mainForm;
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void loginIcnBtn_Click(object sender, EventArgs e)
        {
            Parent.Parent.Hide();
            mainForm = new Form1();
            mainForm.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form regForm = new RegForm();
            regForm.TopLevel = false;
            Parent.Controls.Add(regForm);
            Parent.Controls[1].Show();
            this.Dispose();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
