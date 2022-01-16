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
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
        public ProgressBar theProgressBar = new ProgressBar();
        public Label diffLabel2 = new labelDesign();
        public Label conseqLabel = new labelDesign();
        public int topicID = 1;
        public int userID = utils.getUserID();
        bool finished;
        private bool _finished
        {
            get
            {
                Connection.Open();
                string SQLquery = "Select * from NewUsersTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, Connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    int completeInt = Convert.ToInt32(dr["complete"]);
                    Connection.Close();
                    if (completeInt == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Connection.Close();
                }
                return false;
            }
            set
            {
                int newInt = 1;
                if (value == false)
                {
                    newInt = 0;
                }
                Connection.Open();
                string SQLquery = "UPDATE NewUsersTopicsTable SET complete= '" + newInt + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, Connection);
                cmd.ExecuteReader();
                Connection.Close();
            }
        }

        public formDesignForQuestionForms()
        {
            InitializeComponent();
            this.Controls.Add(theProgressBar);
            this.theProgressBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.theProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.theProgressBar.ForeColor = System.Drawing.Color.Transparent;
            this.theProgressBar.Location = new System.Drawing.Point(0, 512);
            this.theProgressBar.Name = "progressBar1";
            this.theProgressBar.Size = new System.Drawing.Size(1013, 23);
            theProgressBar.BringToFront();

            this.Controls.Add(diffLabel2);
            this.diffLabel2.AutoSize = true;
            this.diffLabel2.BackColor = System.Drawing.Color.Transparent;
            this.diffLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diffLabel2.Location = new System.Drawing.Point(12, 520);
            this.diffLabel2.Name = "difficultyPrint";
            this.diffLabel2.Size = new System.Drawing.Size(53, 25);
            this.diffLabel2.Text = "DIFF";

            this.Controls.Add(conseqLabel);
            //this.conseqLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            //this.conseqLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.conseqLabel.AutoSize = true;
            this.conseqLabel.BackColor = System.Drawing.Color.Transparent;
            this.conseqLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conseqLabel.Location = new System.Drawing.Point(12, 490);
            this.conseqLabel.Name = "difficultyPrint";
            this.conseqLabel.Size = new System.Drawing.Size(53, 25);
            this.conseqLabel.Text = "Conseq";

            conseqLabel.Show();
            diffLabel2.Show();
            theProgressBar.Show();
        }

        private void formDesignForQuestionForms_Load(object sender, EventArgs e)
        {
            finished = _finished;
            advanceProgressBar();

            if (finished)
            {
                hideDisp();
            }
        }

        public void quesCorrect(string question, string userAnswer, string realAnswer) // to be called when the user gets a question right
        {
            // grabs the conseq ques correct for a specific topic
            // adds one or ( sets it to zero and increases the current difficulty, but if the current difficulty is currently the max difficulty, then set COMPLETE to be true)
            // if complete is true:
            //

            // check to see if the entry exists
            // if so, add 1 to the value / other things
            // if not, create the first entry
            var cr = new correctIncorrect(true); // displays a correct GIF
            int _conseqCorrect = conseqCorrect;
            if (_conseqCorrect < 4)
            {
                updateConseqCorrect(topicID, userID, _conseqCorrect + 1);
            }
            else
            {
                if (maxDifficulty == currentDifficulty && !finished)
                {
                    Debug.WriteLine("MAXED");
                    utils.msg("Congrats. You have mastered this section!", subColour);
                    updateConseqCorrect(topicID, userID, 5);
                    hideDisp();
                    _finished = true;
                }
                else if (!finished)
                {
                    updateConseqCorrect(topicID, userID, 0);
                    updateCurrentDiffiuclty(topicID, userID, currentDifficulty + 1);
                }
                else if (maxDifficulty == currentDifficulty && finished && conseqCorrect > 4)
                {

                }
                else { }
            }
            advanceProgressBar();
            insertQuestionAttempt(question, userAnswer, realAnswer, 1);
        }

        private void hideDisp()
        {
            theProgressBar.Hide();
            diffLabel2.Hide();
            conseqLabel.Hide();
        }

        public void quesIncorrect(string question, string userAnswer, string realAnswer)
        {
            var cr = new correctIncorrect(false); // displays an incorrect GIF
            updateConseqCorrect(topicID, userID,0);
            advanceProgressBar();
            insertQuestionAttempt(question, userAnswer, realAnswer, 0);
        }

        private void updateConseqCorrect(int topicID, int userID, int newCount)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            Connection.Open();
            string SQLquery = "UPDATE NewUsersTopicsTable SET conseqCorrect = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
            Connection.Close();
        }

        private void updateCurrentDiffiuclty(int topicID, int userID, int newCount)
        {
            Connection.Open();
            string SQLquery = "UPDATE NewUsersTopicsTable SET currentDifficulty = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
            Connection.Close();
            Debug.WriteLine("updated current diff to " + newCount);
        }

        private int conseqCorrect
        {
            get
            {
                Connection.Open();
                string SQLquery = "Select * from NewUsersTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, Connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    dr.Close();
                    string query = "INSERT into NewUsersTopicsTable (userID, topicID) values('" + userID + "', '" + topicID + "')";
                    SqlCommand cmd2 = new SqlCommand(query, Connection);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    cmd.CommandText = SQLquery;
                    dr2.Close();
                    dr = cmd.ExecuteReader();
                }
                dr.Read();
                int conseqCorrect = Convert.ToInt32(dr["conseqCorrect"]);
                Connection.Close();
                Debug.WriteLine("THE USERS CONSEQ CORRECT IS: " + conseqCorrect);
                return conseqCorrect;
            }
        }

        private int grabCurrentDifficulty()
        {
            // gets the current difficulty for the specific topic
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            Connection.Open();
            string SQLquery = "Select * from NewUsersTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int currentDiff = Convert.ToInt32(dr["currentDifficulty"]);
            Debug.WriteLine("THE USERS CURRENT DIFF = " + currentDiff);
            Connection.Close();
            return currentDiff;
        }

        public int currentDifficulty   // property
        {
            get { return grabCurrentDifficulty(); }   // get method
            set { updateCurrentDiffiuclty(topicID,userID,value); }  // set method
        }

        public int maxDifficulty
        {
            get
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
            set { }
        }

        public void advanceProgressBar()
        {
            float temp = (((float)(conseqCorrect) / 5) * 100);
            theProgressBar.Value = ((int)temp);
            diffLabel2.Text = "Difficulty: " + currentDifficulty + "/" + maxDifficulty;
            conseqLabel.Text = "Consecutive questions correct: " + conseqCorrect + "/5";
        }

        private void insertQuestionAttempt(string question, string userAnswer, string realAnswer, int correct)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            Connection.Open();
            string query = "INSERT into CompletedQuestionsTable (userID, topicID, difficulty, maxDifficulty, question, answer, answerGiven, correct) values('" + userID + "', '" + topicID + "', '" + currentDifficulty + "', '" + maxDifficulty + "', '" + question + "', '" + realAnswer + "', '" + userAnswer + "', '" + correct + "')";
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void buttonGenerateQuestion_Click(object sender, EventArgs e)
        {

        }
    }
}
