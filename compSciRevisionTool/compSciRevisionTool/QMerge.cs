using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class QMerge : compSciRevisionTool.formDesign
    {
        private string colPassed = "";
        string[] answersArray;
        createMergeSortQ msq = new createMergeSortQ(); // creates a new instance of a merge sort class

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
            comboBox1.Items.Add("1"); // adding difficulty opions
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("2");
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
                quesGen();  // generates a new question
            }
            else
            {
                var cr = new correctIncorrect(false); // displays an incorrect GIF
            }
        }

        private void quesGen() // the function that calls for a new dynamic question
        {
            answerBox1.Clear(); // clears previous entered information
            answerBox2.Clear();
            answersArray = msq.generateQmerge(Int32.Parse(comboBox1.SelectedItem.ToString())); // generates a new merge sort quesion - the first item is the question, 2 - answer one 3 - answer two
            labelQuestion.Text = answersArray[0]; // displays the question

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




    }
}
