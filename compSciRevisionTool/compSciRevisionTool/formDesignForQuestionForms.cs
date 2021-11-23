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
    public partial class formDesignForQuestionForms : formDesign
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming

        public formDesignForQuestionForms()
        {
            InitializeComponent();
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
            if (_conseqCorrect < 5)
            {
                updateConseqCorrect(topicID, userID, _conseqCorrect + 1);
            }
            else
            {
                if (grabMaxDifficulty(topicID) == grabCurrentDifficulty(topicID, userID))
                {
                    returnArray[0] = "MAXED OUT DIFFICULTY";
                }
                else
                {
                    updateConseqCorrect(topicID, userID, 0);
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
            string SQLquery = "UPDATE UserTopicsTable SET conseqCorrect = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
        }

        private void updateCurrentDiffiuclty(int topicID, int userID, int newCount)
        {
            Connection.Open();
            string SQLquery = "UPDATE UserTopicsTablec SET currentDifficulty = '" + newCount + "' where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            cmd.ExecuteReader();
        }

        private int grabConseqCorrect(int topicID, int userID)
        {
            Connection.Open();
            string SQLquery = "Select * from UserTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                string query = "INSERT into UserTopicsTable (userID, topicID) values('" + userID + "', '" + topicID + "')";
                cmd.CommandText = query;
                cmd.ExecuteReader();
                cmd.CommandText = SQLquery;
                dr = cmd.ExecuteReader();
            }
            dr.Read();
            int conseqCorrect = Convert.ToInt32(dr["conseqCorrect"]);

            return conseqCorrect;
        }

        private int grabCurrentDifficulty(int topicID, int userID)
        {
            // gets the current difficulty for the specific topic
            Connection.Open();
            string SQLquery = "Select * from UserTopicsTable where topicID= '" + topicID + "' and userID= '" + userID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int currentDiff = Convert.ToInt32(dr["currentDifficulty"]);

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

            return maxDiff;
        }

        public void advanceProgressBar(ProgressBar pb, int consecQsCorrect)
        {
            float temp = (((float)(consecQsCorrect) / 5) * 100);
            pb.Value = ((int)temp);
        }
    }
}
