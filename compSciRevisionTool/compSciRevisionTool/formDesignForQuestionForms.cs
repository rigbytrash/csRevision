using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void quesCorrect(string topicName, string username)
        {
            // grabs the conseq ques correct for a specific topic
            // adds one or ( sets it to zero and increases the current difficulty, but if the current difficulty is currently the max difficulty, then set COMPLETE to be true)
            // if complete is true:
            //
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
