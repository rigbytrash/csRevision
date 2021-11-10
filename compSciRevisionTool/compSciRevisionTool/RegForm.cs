using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace compSciRevisionTool
{
    public partial class RegForm : Form
    {
        string passwordInput;
        string usernameInput;

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

        private void regBtn_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            passwordInput = utils.hashPassword(passwordInputBox.Text);
            usernameInput = usernameInputBox.Text;
            if (passwordInput != "" && usernameInput != "")
            {
                Connection.Open();
                string query = "INSERT into UserTable (username, password) values('" + usernameInput + "', '" + passwordInput + "')";
                SqlCommand cmd = new SqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                Connection.Close();
                displayRegSuccessMessage();
            }
            else
            {
                MessageBox.Show("YOU MUST ENTER A USERNAME AND PASSOWRD");
            }

        }

        private void displayRegSuccessMessage()
        {

        }
    }
}
