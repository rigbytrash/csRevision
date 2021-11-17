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
    public partial class QFloatBinary : formDesign
    {
        private string colPassed = "";
        string[] answersArray;
        int maxDifficulty = 2;
        int currentDifficulty = 1;
        int consecQsCorrect = 0;
        createBinaryQ bi = new createBinaryQ();

        public QFloatBinary(string _colPassed)
        {
            InitializeComponent();
            setDesign(colPassed = _colPassed);
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
            //testLabelOne.Text = answersArray[1] + " and " + answersArray[2];
        }

        private void checkAns()
        {
            if (answerBox1.Text == answersArray[0]) // checks if the answer entered is correct
            {
                var cr = new correctIncorrect(true); // displays a correct GIF
                consecQsCorrect = consecQsCorrect + 1;
                if (consecQsCorrect == 5)
                {
                    if (currentDifficulty != maxDifficulty)
                    {
                        currentDifficulty = currentDifficulty + 1;
                    }
                    else
                    {
                        utils.msg("Congrats. You have mastered this section!", subColour);
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
            //advanceProgressBar(progressBar1);
        }
    }
}
