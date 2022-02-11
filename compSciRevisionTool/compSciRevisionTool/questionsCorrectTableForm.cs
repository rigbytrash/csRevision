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
    public partial class questionsCorrectTableForm : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
        string subColour;

        public questionsCorrectTableForm(string _subColour)
        {
            InitializeComponent();
            subColour = _subColour;
            customSetDesign(subColour);
            this.mainPanel.AutoScroll = true;
            usernameLabel.Text = utils.getUsername();
        }

        private void questionsCorrectTableForm_Load(object sender, EventArgs e)
        {
            populateCombo();
        }

        private void populateCombo() // adds all the different topics to the combobox for the user to select from
        {
            Connection.Open();
            string SQLquery = "Select * from TopicsTable";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read()) // add each topic after reading it
                {
                        string toAdd = (dr["topicTitle"].ToString()); 
                        comboBox1.Items.Add(toAdd);
                }
                comboBox1.SelectedIndex = 0;
                generateItems(1);
            }
            Connection.Close();
        }

        private void goNextButton_Click(object sender, EventArgs e)
        {
            removeCurrentItems();
            string topicName = comboBox1.SelectedItem.ToString();
            Connection.Open();
            string SQLquery = "Select * from TopicsTable where topicTitle= '" + topicName + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) // grabs the topic ID of selected topic in the combobox
            {
                while (dr.Read())
                {
                    int topicID = Convert.ToInt32(dr["Id"]);
                    generateItems(topicID);
                }
            }
            Connection.Close();
            panel1.BringToFront();
            Controls.Add(panel1);
        }

        private void generateItems(int topicID) //grabs all the past questions done by the specific user and displays them using a custom panel
        {
            string SQLquery = "Select * from CompletedQuestionsTable where userID= '" + utils.getUserID() + "'" + " and topicID= '" + topicID + "'";
            SqlCommand cmd2 = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    string userAnswer = (dr2["answerGiven"].ToString());
                    string realAnswer = (dr2["answer"].ToString());
                    string question = (dr2["question"].ToString());
                    int maxDiff = Convert.ToInt32(dr2["maxDifficulty"]);
                    int diff = Convert.ToInt32(dr2["difficulty"]);
                    int correct = Convert.ToInt32(dr2["correct"]);
                    Control temp = new panelForQuesTable(subColour, question, userAnswer, realAnswer, diff, maxDiff, correct);
                    this.mainPanel.Controls.Add(temp);
                    temp.Dock = DockStyle.Top;
                    temp.Show();
                }
            }
            dr2.Close();
        }

        private void removeCurrentItems() //When a different topic is selected, all the information displayed to the user needs to be deleted first
        {
            foreach (Control cntrl in this.mainPanel.Controls)
            {
                if (cntrl.GetType() == typeof(panelForQuesTable))
                {
                    cntrl.Hide();
                    cntrl.Dispose();
                }
            }

            foreach (Control cntrl in this.mainPanel.Controls)
            {
                if (cntrl.GetType() == typeof(panelForQuesTable))
                {
                    removeCurrentItems();
                }
            }
        }

        private void customSetDesign(string subColour) 
        {
            this.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.4f); // sets bg colour
            panel1.BackColor = programColoursClass.getcolour(subColour);
            goNextButton.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.4f);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void changedVisibilty(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                removeCurrentItems();
            }
        }
    }
}
