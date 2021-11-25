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
using System.Diagnostics;

namespace compSciRevisionTool
{
    public partial class LoginForm : formDesign
    {
        Form mainForm;
        string passwordInput;
        string usernameInput;
        string correctHashedPword;
        bool loginAuthd = false;

        public LoginForm()
        {
            InitializeComponent();
            setDesign("5");
            loginIcnBtn.BackColor = programColoursClass.ChangeColorBrightness(loginIcnBtn.BackColor, +0.5f);
        }

        private void loginIcnBtn_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            passwordInput = utils.hashPassword(passwordInputBox.Text);
            usernameInput = usernameInputBox.Text;
            if (passwordInput != "" && usernameInput != "")
            {
                Connection.Open();
                string SQLquery = "Select * from UserTable where username= '" + usernameInput + "' and password= '" + passwordInput + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, Connection);
                SqlDataReader dr = cmd.ExecuteReader();
                int tempUserID = Convert.ToInt32(dr["userID"]);
                if (dr.HasRows)
                {
                    loginAuthd = true;
                    dr.Close();
                    string queryCheck = "Select * from currentUserTable where Id= 1";
                    SqlCommand checkCmd = new SqlCommand(queryCheck, Connection);
                    SqlDataReader drCheck = checkCmd.ExecuteReader();
                    if (drCheck.HasRows)
                    {
                        String query = "Update currentUserTable SET userID = " + tempUserID + " where Id = 1";
                        SqlCommand cmd2 = new SqlCommand(query, Connection);
                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        string query = "INSERT into currentUserTable (userID) values("+userID+")";
                        SqlCommand cmd2 = new SqlCommand(query, Connection);
                        cmd2.ExecuteNonQuery();
                    }
                    cmd.ExecuteReader();
                }
                else
                {
                    loginAuthd = false;
                }

                if (loginAuthd)
                {
                    runProgram();
                }
            }
            else
            {
                Form mb = new messgaeBox("You must enter a username and password!", subColour);
                mb.Show();
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void runProgram()
        {
            Parent.Parent.Hide();
            mainForm = new Form1();
            mainForm.Show();
        }

        private void bypassBtn_Click(object sender, EventArgs e)
        {
            runProgram();
        }
    }
}
