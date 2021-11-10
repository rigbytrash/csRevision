﻿using System;
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
    public partial class LoginForm : Form
    {
        Form mainForm;
        string passwordInput;
        string usernameInput;
        string correctHashedPword;
        bool loginAuthd = false;

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void loginIcnBtn_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(@"daString"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            passwordInput = utils.hashPassword(passwordInputBox.Text);
            usernameInput = usernameInputBox.Text;

            Connection.Open();
            string SQLquery = "Select * from UserTable where username=" + usernameInput + " and password=" + passwordInput;
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                loginAuthd = true;
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
