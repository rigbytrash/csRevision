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
            quesGen();
        }

        private void quesGen() // the function that calls for a new dynamic question
        {
            answerBox1.Clear(); // clears previous entered information
            answersArray = bi.generateFloatingQ(5, 3);
            labelQuestion.Text = "Mantissa: " + answersArray[1] + " Exponent: " + answersArray[2]; // displays the question
            //difficultyPrint.Text = "Difficulty: " + currentDifficulty.ToString() + "/" + maxDifficulty.ToString();
            //difficultyPrint.Text = "Difficulty: " + currentDifficulty.ToString() + "/" + maxDifficulty.ToString();
            //testLabelOne.Text = answersArray[1] + " and " + answersArray[2];
        }

        private void checkAns()
        {
            if (answerBox1.Text == answersArray[0]) // checks if the answer entered is correct
            {
                quesCorrect(3);
                var cr = new correctIncorrect(true); // displays a correct GIF
                quesGen();  // generates a new question
            }
            else
            {
                var cr = new correctIncorrect(false); // displays an incorrect GIF
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
