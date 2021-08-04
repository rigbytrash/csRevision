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
        List<char> operators = new List<char> { '+', '-', '*', '/', '^'}; // the possible operators
        List<int> operands = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // numbers to be used for adding and subtracting to keep it simple
        static Random rnd = new Random(); // used for generating random numbers
        string question; // output to be printed to the screen for the user to read
        List<string> questionList = new List<string>(); // list to store the question as it is being made
        string answer; // evaluated RPN is stored here to check user later
        Stack<string> questionStack = new Stack<string>(); // stack is used to evaluate RPN
        int upperbound = 10; // default upperbound for max value 
        int difficulty;
        string[] tempRPN;
        string colPassed;

        public QRpn(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
        }

        private void QRpn_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
            comboBox1.Items.Add("1"); // adding difficulty opions (only for debugging at this point as later the difficulty will be system defined)
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            difficulty = Int32.Parse(comboBox1.SelectedItem.ToString());
            tempRPN = generateRpnQuestion(difficulty);
            labelQuestion.Text = tempRPN[0];
            labelTest.Text = tempRPN[1];

        }

        private string[] generateRpnQuestion(int difficulty) // generates an RPN statement; takes in the difficulty
        {

            int len = 2; // the default length of a statement (len 2 gives a len of 4)

            switch (difficulty)
            {
                case 1: // difficulty 1
                    upperbound = 10; // max number is 10 (9)
                    operators[3] = '+'; // swaps all / for +
                    operators[4] = '-'; // swaps all ^ for -
                    len = 1; // limits len
                    break;
                case 2:
                    upperbound = 15;
                    operators[3] = '/';
                    operators[4] = '-';
                    len = 1;
                    break;
                case 3:
                    upperbound = 25;
                    operators[3] = '/';
                    operators[4] = '^';
                    len = 2;
                    break;
            }

            question = ""; // clears question output from last time
            questionList.Clear(); // clears question adding list from last time
            int opSelectRandom; // used for stroing random int to select array pos

            for (int k = 0; k < len; k = k + 1) // changes the ammount of runs depeding on switch statement erlier
            {
                for (int j = 0; j < 2; j = j + 1)
                {
                    opSelectRandom = rnd.Next(0, 5);  // creates a number between 0 and 4
                    if (operators[opSelectRandom] == '/') // if the operator is divide make the second number a factor of the first so it devides well
                    {
                        int numSelectRandom = rnd.Next(1, 10);
                        int numSelectRandom2 = rnd.Next(1, 10);
                        int num3 = numSelectRandom * numSelectRandom2;
                        questionList.Add(num3.ToString());
                        questionList.Add(numSelectRandom2.ToString());
                    }
                    else // all other oeprands
                    {
                        for (int i = 0; i < 2; i = i + 1)
                        {
                            int numSelectRandom = rnd.Next(1, 10);  // creates a number between 1 and 9
                            questionList.Add(operands[numSelectRandom].ToString()); // randomly select 2 numbers and add to the question
                        }
                    }

                    questionList.Add(operators[opSelectRandom].ToString()); // add an operator to combine to sub-statements
                }
                opSelectRandom = rnd.Next(0, 3);  // creates a number between 0 and 2
                questionList.Add(operators[opSelectRandom].ToString());
            }

            if (len == 2)
            {
                int randomno = rnd.Next(0, 3);
                questionList.Add(operators[randomno].ToString());
            }
            
            // ////////////////////////////// below is to evaluate the RPN statement ///////////////////////////////////// //

            for (int i = 0; i < questionList.Count; i = i + 1) // loop for the len of the statement
            {
                if (questionList[i] == "+" || questionList[i] == "-" || questionList[i] == "*" || questionList[i] == "/" || questionList[i] == "^")
                { // if operator
                    int op1 = Int32.Parse(questionStack.Pop()); // pop the last two items
                    int op2 = Int32.Parse(questionStack.Pop());
                    int subResult = 0;
                    char symbol = questionList[i].ToCharArray()[0];
                    switch (symbol) // preform the oepration on the two numbers
                    {
                        case '+':
                            subResult = op2 + op1;
                            break;
                        case '-':
                            subResult = op2 - op1;
                            break;
                        case '*':
                            subResult = op2 * op1;
                            break;
                        case '/':
                            subResult = op2 / op1;
                            break;
                        case '^':
                            subResult = Convert.ToInt32(Math.Pow(op2, op1));
                            break;
                    }
                    questionStack.Push(subResult.ToString()); // push the result to the stack
                }
                else
                {
                    questionStack.Push(questionList[i]); // just push if its a number
                }

            }
            question = string.Join(" ", questionList); // combine the statement toghether to be printed
            answer = questionStack.Pop(); // pop the final item and set it as the answer
            string[] toReturn = { question, answer };
            return (toReturn); // returns a string array 1. question 2. answer
        } 

        private void buttonGenerateQuestion_Click(object sender, EventArgs e) // for debuging, button should make a new question
        {
            difficulty = Int32.Parse(comboBox1.SelectedItem.ToString()); // checks the slected difficulty
            this.BackColor = bgCol; // sets the background colour back to what it was
            setDesign(colPassed);
            tempRPN = generateRpnQuestion(difficulty);
            labelQuestion.Text = tempRPN[0];
            labelTest.Text = tempRPN[1];
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
