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
    public partial class QMerge : compSciRevisionTool.formDesign
    {
        private string colPassed = "";
        string[] answersArray;
        createMergeSortQ msq = new createMergeSortQ(); // creates a new instance of a merge sort class
        int maxDifficulty = 2;
        int currentDifficulty = 1;
        int consecQsCorrect = 0;

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
            progressBar1.BackColor = programColoursClass.getcolour(colPassed);

            for (int i = 0; i < maxDifficulty; i = i + 1) // adding difficulty opions
            {
                comboBox1.Items.Add((i + 1).ToString());
            }

            quesGen();
        }

        private void QMerge_Load(object sender, EventArgs e)
        {

        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e) // click for the submit button
        {
            checkAns();
        }

        private void buttonGenerateQuestion_Click(object sender, EventArgs e) // generate new question button based on the difficulty selected
        {
            quesGen();
        }

        private void testLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkAns()
        {
            if (answerBox1.Text == answersArray[1] && answerBox2.Text == answersArray[2]) // checks if the answer entered is correct
            {
                var cr = new correctIncorrect(true); // displays a correct GIF
                consecQsCorrect = consecQsCorrect + 1;
                Debug.WriteLine("CONSECQSCORRECT: " + consecQsCorrect.ToString());
                if (consecQsCorrect == 5)
                {
                    if (currentDifficulty != maxDifficulty)
                    {
                        currentDifficulty = currentDifficulty + 1;
                    }
                    else
                    {
                        Debug.WriteLine("Congrats. You have mastered this section!");
                    }
                    consecQsCorrect = 0; 
                }
                quesGen();  // generates a new question
            }
            else
            {
                var cr = new correctIncorrect(false); // displays an incorrect GIF
                consecQsCorrect = 0;
            }
            advanceProgressBar(progressBar1);
        }

        private void quesGen() // the function that calls for a new dynamic question
        {
            answerBox1.Clear(); // clears previous entered information
            answerBox2.Clear();
            answersArray = msq.generateQmerge(Int32.Parse(currentDifficulty.ToString())); // generates a new merge sort quesion - the first item is the question, 2 - answer one 3 - answer two
            labelQuestion.Text = answersArray[0]; // displays the question
            difficultyPrint.Text = "Difficulty: " + currentDifficulty.ToString() + "/" + maxDifficulty.ToString();
            testLabelOne.Text = answersArray[1] + " and " + answersArray[2];
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

            
        private void advanceProgressBar(ProgressBar pb)
        {
            float temp = (((float)(consecQsCorrect) / 5) * 100);
            pb.Value = ((int)temp);
        }
    }
}
