using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace compSciRevisionTool
{
    public partial class QRpn : formDesignForQuestionForms
    {
        string question; // output to be printed to the screen for the user to read
        string answer; // evaluated RPN is stored here to check user later
        List<string> tempRPN = new List<string>();
        createRpnExpressionClass rpn = new createRpnExpressionClass();

        public QRpn(string _colPassed)
        {
            InitializeComponent();
            topicID = 1;
            colPassed = _colPassed;
            setDesign(colPassed);
        }

        private void QRpn_Load(object sender, EventArgs e)
        {
            quesGen();
        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e)
        {
            checkAns();
        }

        private void checkAns()
        {
            if (textBox1.Text == answer) // checks if the answer entered is correct
            {
                quesCorrect(question, textBox1.Text, answer);
                textBox1.Clear();
                quesGen();

            }
            else
            {
                quesIncorrect(question, textBox1.Text, answer);
            }
        }

        private void quesGen()
        {
            tempRPN = rpn.generateRpnQuestion(currentDifficulty);
            labelQuestion.Text = tempRPN[0];
            question = tempRPN[0];
            answer = tempRPN[1];
            Debug.WriteLine(answer);
        }

        private void answerboxKeyDown(object sender, KeyEventArgs e)
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
