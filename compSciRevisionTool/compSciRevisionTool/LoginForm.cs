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
        bool loginAuthd = false;

        public LoginForm()
        {
            InitializeComponent();
            setDesign("5");
            loginIcnBtn.BackColor = programColoursClass.ChangeColorBrightness(loginIcnBtn.BackColor, +0.5f);
        }

        private void loginIcnBtn_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            passwordInput = utils.hashPassword(passwordInputBox.Text);
            usernameInput = usernameInputBox.Text.ToLower();
            if (passwordInput != "" && usernameInput != "")
            {
                Connection.Open();
                string SQLquery = "Select * from UserTable where username= '" + usernameInput + "' and password= '" + passwordInput + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, Connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) // if an entry of this user/pass combo exits
                {
                    loginAuthd = true;
                    dr.Read(); // read the entry
                    int tempUserID = Convert.ToInt32(dr["Id"]); // reads the userId of the login attempt
                    dr.Close();
                    string queryCheck = "Select * from currentUserTable where pointing= 1";
                    SqlCommand checkCmd = new SqlCommand(queryCheck, Connection);
                    SqlDataReader drCheck = checkCmd.ExecuteReader();
                    if (drCheck.HasRows) // if this is NOT the first ever login attempt on the program then set the current user attribute as this user
                    {
                        drCheck.Close();
                        String query = "Update currentUserTable SET userID = " + tempUserID + " where pointing = 1";
                        SqlCommand cmd2 = new SqlCommand(query, Connection);
                        cmd2.ExecuteNonQuery();
                    }
                    else // if this is the first ever login attempt, create a entry for the current user
                    {
                        drCheck.Close();
                        string query = "INSERT into currentUserTable (pointing, userID) values('1', "+tempUserID+")";
                        SqlCommand cmd2 = new SqlCommand(query, Connection);
                        cmd2.ExecuteNonQuery();
                    }
                    cmd.ExecuteReader();
                }
                else // if the user/pass combo doesn't exist
                {
                    loginAuthd = false;
                }

                if (loginAuthd)
                {
                    runProgram();
                }
                else
                {
                    utils.msg("Login details incorrect.", subColour);
                }
            }
            else
            {
                utils.msg("You must enter a username and password!", subColour);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e) // registerButtonClick
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