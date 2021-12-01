using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace compSciRevisionTool
{
    public partial class QFloatBinary : formDesignForQuestionForms
    {
        string[] answersArray;
        createBinaryQ bi = new createBinaryQ();

        public QFloatBinary(string _colPassed)
        {
            InitializeComponent();
            setDesign(colPassed = _colPassed);
            topicID = 3;
        }

        private void QFloatBinary_Load(object sender, EventArgs e)
        {
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
            quesGen(currentDifficulty);
        }

        private void quesGen(int difficulty) // the function that calls for a new dynamic question
        {
            answerBox1.Clear(); // clears previous entered information
            answersArray = bi.quesGen(currentDifficulty);
            labelQuestion.Text = "Mantissa: " + answersArray[1] + " Exponent: " + answersArray[2]; // displays the question
            //difficultyPrint.Text = "Difficulty: " + currentDifficulty.ToString() + "/" + maxDifficulty.ToString();
            //difficultyPrint.Text = "Difficulty: " + currentDifficulty.ToString() + "/" + maxDifficulty.ToString();
            //testLabelOne.Text = answersArray[1] + " and " + answersArray[2];
        }

        private void checkAns()
        {
            string question = "Calculate the denary equivalent of the following floating point of a number: " + "Mantissa: " + answersArray[1] + " Exponent: " + answersArray[2];
            string userAns = answerBox1.Text;
            string realAns = answersArray[0];
            if (userAns == realAns) // checks if the answer entered is correct
            {
                quesCorrect(question,userAns,realAns);
                answerBox1.Clear();
                quesGen(currentDifficulty);  // generates a new question
            }
            else
            {
                quesIncorrect(question, userAns, realAns);
            }
        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e)
        {
            checkAns();
        }

        private void answerBoxKeyDown(object sender, KeyEventArgs e)
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
