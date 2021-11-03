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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void loginIcnBtn_Click(object sender, EventArgs e)
        {
            Form loginForm = new LoginForm();
            loginForm.TopLevel = false;
            Parent.Controls.Add(loginForm);
            Parent.Controls[1].Show();
            this.Dispose();
        }
    }
}
