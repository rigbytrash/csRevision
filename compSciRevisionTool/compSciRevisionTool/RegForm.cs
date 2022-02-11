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
    public partial class RegForm : formDesign
    {
        string passwordInput;
        string usernameInput;

        public RegForm()
        {
            InitializeComponent();
            setDesign("6");
            regBtn.BackColor = programColoursClass.ChangeColorBrightness(regBtn.BackColor,+0.5f);
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
            if(!utils.regulateStringInput(passwordInput = passwordInputBox.Text,8,10,0,1,1)) // if the password does not meet the requirements
            {
                displayRegSuccessFailMessage(false);
            }
            else // if passowrd requirements are met
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
                passwordInput = utils.hashPassword(passwordInputBox.Text);
                usernameInput = usernameInputBox.Text;
                Connection.Open();
                string SQLquery = "Select * from UserTable where username= '" + usernameInput + "'";
                SqlCommand cmdCheckExist = new SqlCommand(SQLquery, Connection);
                SqlDataReader dr = cmdCheckExist.ExecuteReader();
                if (!dr.HasRows) // if the username does not already exist
                {
                    dr.Close();
                    if (passwordInput != "" && usernameInput != "")
                    {
                        string query = "INSERT into UserTable (username, password) values('" + usernameInput.ToLower() + "', '" + passwordInput + "')";
                        SqlCommand cmd = new SqlCommand(query, Connection);
                        cmd.ExecuteNonQuery();
                        Connection.Close();
                        displayRegSuccessFailMessage(true);
                        loginIcnBtn_Click(sender, e);
                    }
                    else // if the username or password entered were blank
                    {
                        displayRegSuccessFailMessage(false);
                    }
                }
                else // if the username is taken
                {
                    dr.Close();
                    Form mb = new messgaeBox("Username '" + usernameInput + "' is taken", subColour);
                }
            }
        }

        private void displayRegSuccessFailMessage(bool complete)
        {
            if (complete)
            {
                Form mb = new messgaeBox("Complete", subColour);
                mb.Show();
            }
            else
            {
                Form mb = new messgaeBox("Password must have a length between  8 and 10 and have 1 special character and 1 number.", subColour);
                mb.Show();
            }

        }
    }
}
