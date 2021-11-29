using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace compSciRevisionTool
{
    public partial class QMerge : formDesignForQuestionForms
    {
        string[] answersArray;
        createMergeSortQ msq = new createMergeSortQ(); // creates a new instance of a merge sort class

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            topicID = 2;
            colPassed = _colPassed;
            setDesign(colPassed);
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
        }

        private void QMerge_Load(object sender, EventArgs e)
        {
            quesGen();
        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e) // click for the submit button
        {
            checkAns();
        }

        private void testLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkAns()
        {
            string combinedUserAns = answerBox1.Text + " " + answerBox2.Text;
            string combinedRealAns = answersArray[1] + " " + answersArray[2];
            string question = "Use merge sort to sort the following: " + labelQuestion.Text + " and give the left and right array during the second to last step";
            if (answerBox1.Text == answersArray[1] && answerBox2.Text == answersArray[2]) // checks if the answer entered is correct
            {
                quesCorrect(question, combinedUserAns, combinedRealAns);
                quesGen();
            }
            else
            {
                quesIncorrect(question, combinedUserAns, combinedRealAns);
            }
        }

        private void quesGen() // the function that calls for a new dynamic question
        {
            answerBox1.Clear(); // clears previous entered information
            answerBox2.Clear();
            answersArray = msq.generateQmerge(currentDifficulty); // generates a new merge sort quesion - the first item is the question, 2 - answer one 3 - answer two
            labelQuestion.Text = answersArray[0]; // displays the question
            Debug.WriteLine(answersArray[1] + " and " + answersArray[2]);
        }

        private void secondAnswerBoxKeyDown(object sender, KeyEventArgs e) //
        {
            enterPress(sender, e);
        }

        private void firstAnswerBoxKeyDown(object sender, KeyEventArgs e)
        {
            enterPress(sender, e);
        }

        private void enterPress(object sender, KeyEventArgs e) // if this is called and it was the enter key that was pressed then submit the answer
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
                checkAns();
            }
        }         
    }
}
