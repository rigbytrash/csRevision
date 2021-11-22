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
        public formDesignForQuestionForms()
        {
            InitializeComponent();
        }

        private void formDesignForQuestionForms_Load(object sender, EventArgs e)
        {

        }

        private string[] quesCorrect(int topicID, int userID) // returns currentDifficulty & conseqCorrect
        {
            // grabs the conseq ques correct for a specific topic
            // adds one or ( sets it to zero and increases the current difficulty, but if the current difficulty is currently the max difficulty, then set COMPLETE to be true)
            // if complete is true:
            //

            // check to see if the entry exists
            // if so, add 1 to the value / other things
            // if not, create the first entry
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            Connection.Open();
            string SQLquery = "Select * from UserTopicsTable where userID= '" + userID + "' and topicID= '" + topicID + "'";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                int _conseqCorrect = Convert.ToInt32(dr["conseqCorrect"]);
                if (_conseqCorrect < 4)
                {
                    cmd.CommandText = "Update UserTopicsTable SET conseqCorrect= " + _conseqCorrect + 1 + " Where userID= " + userID;
                }
                else
                {

                }
                int _diff = 0;
            }
        }

        private void grabCurrentDifficulty(string topicName, string username)
        {
            // gets the current difficulty for the specific topic
        }

        public void advanceProgressBar(ProgressBar pb, int consecQsCorrect)
        {
            float temp = (((float)(consecQsCorrect) / 5) * 100);
            pb.Value = ((int)temp);
        }
    }
}
