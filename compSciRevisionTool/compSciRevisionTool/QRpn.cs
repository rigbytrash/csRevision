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

namespace compSciRevisionTool
{
    public partial class QRpn : formDesign // inherits design from formDesign
    {
        //declerations
        Color bgCol = programColoursClass.getcolour("2");
        string colPassed;

        string question; // output to be printed to the screen for the user to read
        string answer; // evaluated RPN is stored here to check user later
        int difficulty;
        List<string> tempRPN = new List<string>();

        public QRpn(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            comboBox1.Items.Add("1"); // adding difficulty opions (only for debugging at this point as later the difficulty will be system defined)
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
        }

        private void QRpn_Load(object sender, EventArgs e)
        {
            createRpnExpressionClass rpn = new createRpnExpressionClass();
            tempRPN = rpn.generateRpnQuestion(difficulty);
            labelQuestion.Text = tempRPN[0];
            question = tempRPN[0];
            labelTest.Text = tempRPN[1];
            answer = tempRPN[1];
        }

        private void buttonGenerateQuestion_Click(object sender, EventArgs e) // for debuging, button should make a new question
        {
            difficulty = Int32.Parse(comboBox1.SelectedItem.ToString()); // checks the slected difficulty
            this.BackColor = bgCol; // sets the background colour back to what it was
            setDesign(colPassed);
            createRpnExpressionClass rpn = new createRpnExpressionClass();
            tempRPN = rpn.generateRpnQuestion(difficulty);
            labelQuestion.Text = tempRPN[0];
            question = tempRPN[0];
            labelTest.Text = tempRPN[1];
            answer = tempRPN[1];
        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == answer) // checks if the answer entered is correct
            {
                this.BackColor = Color.Green;
            }
            else
            {
                this.BackColor = Color.Red; 
            }
        }
    }
}
