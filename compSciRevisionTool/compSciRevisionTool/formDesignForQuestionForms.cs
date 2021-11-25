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
    public partial class formDesignForQuestionForms : formDesign
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
        public ProgressBar theProgressBar = new ProgressBar();
        public Label diffLabel2 = new labelDesign();
        public int currentDifficulty = 1;
        public int topicID = 1;
        public int userID = 1; // need to grab the correct one
        public int maxDifficulty = 1;

        public formDesignForQuestionForms()
        {
            InitializeComponent();
            this.theProgressBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.theProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.theProgressBar.ForeColor = System.Drawing.Color.Transparent;
            this.theProgressBar.Location = new System.Drawing.Point(0, 512);
            this.theProgressBar.Name = "progressBar1";
            this.theProgressBar.Size = new System.Drawing.Size(1013, 23);
            theProgressBar.Show();

            this.diffLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.diffLabel2.AutoSize = true;
            this.diffLabel2.BackColor = System.Drawing.Color.Transparent;
            this.diffLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diffLabel2.Location = new System.Drawing.Point(12, 484);
            this.diffLabel2.Name = "difficultyPrint";
            this.diffLabel2.Size = new System.Drawing.Size(53, 25);
            this.diffLabel2.Text = "DIFF";
            diffLabel2.Show();

            theProgressBar.Show();
        }

        private void formDesignForQuestionForms_Load(object sender, EventArgs e)
        {

        }

        public string[] quesCorrect(int topicID, int userID) // returns currentDifficulty & conseqCorrect
        {
            // grabs the conseq ques correct for a specific topic
            // adds one or ( sets it to zero and increases the current difficulty, but if the current difficulty is currently the max difficulty, then set COMPLETE to be true)
            // if complete is true:
            //

            // check to see if the entry exists
            // if so, add 1 to the value / other things
            // if not, create the first entry

            string[] returnArray = new string[2];
            int _conseqCorrect = grabConseqCorrect(topicID, userID);
            if (_conseqCorrect < 4)
            {
                updateConseqCorrect(topicID, userID, _conseqCorrect + 1);
            }
            else
            {
                if (grabMaxDifficulty(topicID) == grabCurrentDifficulty(topicID, userID))
                {
                    returnArray[0] = "MAXED OUT DIFFICULTY";
                    Debug.WriteLine("MAXED");
                    utils.msg("Congrats. You have mastered this section!", subColour);
                    theProgressBar.Hide();
                }
                else
                {
                    updateConseqCorrect(topicID, userID, 1);
                    updateCurrentDiffiuclty(topicID, userID, grabCurrentDifficulty(topicID, userID) + 1);
                }
            }
            returnArray[0] = grabCurrentDifficulty(topicID, userID).ToString();
            returnArray[1] = grabConseqCorrect(topicID, userID).ToString();
            return returnArray;
        }

        private void updateConseqCorrect(int topicID, int userID, int newCount)
        {
            Connection.Open();
            string SQLquery = "UPDATE UsersTopicsTable SET conseqCorrect = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
            Connection.Close();
        }

        private void updateCurrentDiffiuclty(int topicID, int userID, int newCount)
        {
            Connection.Open();
            string SQLquery = "UPDATE UsersTopicsTable SET currentDifficulty = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
            Connection.Close();
        }

        private int grabConseqCorrect(int topicID, int userID)
        {
            Connection.Open();
            string SQLquery = "Select * from UsersTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                dr.Close();
                string query = "INSERT into UsersTopicsTable (userID, topicID) values('" + userID + "', '" + topicID + "')";
                SqlCommand cmd2 = new SqlCommand(query, Connection);
                SqlDataReader dr2 =  cmd2.ExecuteReader();
                cmd.CommandText = SQLquery;
                dr2.Close();
                dr = cmd.ExecuteReader();
            }
            dr.Read();
            int conseqCorrect = Convert.ToInt32(dr["conseqCorrect"]);
            Connection.Close();
            return conseqCorrect;
        }

        private int grabCurrentDifficulty(int topicID, int userID)
        {
            // gets the current difficulty for the specific topic
            Connection.Open();
            string SQLquery = "Select * from UsersTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int currentDiff = Convert.ToInt32(dr["currentDifficulty"]);
            Connection.Close();
            return currentDiff;
        }

        private int grabMaxDifficulty(int topicID)
        {
            Connection.Open();
            string SQLquery = "Select * from TopicsTable where ID= '" + topicID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int maxDiff = Convert.ToInt32(dr["maxDifficulty"]);
            Connection.Close();
            return maxDiff;
        }

        public void advanceProgressBar(ProgressBar pb, int consecQsCorrect)
        {
            float temp = (((float)(consecQsCorrect) / 5) * 100);
            pb.Value = ((int)temp);

            diffLabel2.Text = "Current Difficulty = " + grabCurrentDifficulty(topicID,userID) + "/" + grabMaxDifficulty(topicID);
        }
    }
}
