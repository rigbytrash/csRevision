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
    public partial class LRpn3 : formDesign
    {
        private string colPassed;
        List<string> rpnExpressionList = new List<string>();
        List<string> rpnExpressionListGrab = new List<string>();
        List<string> rpnExpressionListStack = new List<string>();
        createRpnExpressionClass rpn = new createRpnExpressionClass();

        public LRpn3(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
        }

        private void LRpn3_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
            rpnExpressionListGrab = rpn.generateRpnQuestion(3);
            rpnExpressionList = rpnExpressionListGrab[0].Split(' ').ToList();
            MessageBox.Show(rpnExpressionListGrab[0]);
            toName();
        }

        private void toName()
        {
            for (int i = 0; i < rpnExpressionList.Count; i = i + 1) // loop for the len of the statement
            {
                if (rpnExpressionList[i] == "+" || rpnExpressionList[i] == "-" || rpnExpressionList[i] == "*" || rpnExpressionList[i] == "/" || rpnExpressionList[i] == "^")
                { // if operator
                    
                    int op1 = Int32.Parse(rpnExpressionListStack[rpnExpressionListStack.Count - 1]); // pop the last two items
                    rpnExpressionListStack.RemoveAt(rpnExpressionListStack.Count - 1);
                    int op2 = Int32.Parse(rpnExpressionListStack[rpnExpressionListStack.Count - 1]);
                    rpnExpressionListStack.RemoveAt(rpnExpressionListStack.Count - 1);
                    int subResult = 0;
                    char symbol = rpnExpressionList[i].ToCharArray()[0];
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
                    rpnExpressionList.Add(subResult.ToString()); // push the result to the stack
                }
                else
                {
                    rpnExpressionListStack.Add(rpnExpressionList[i]); // just push if its a number
                }
            }

            MessageBox.Show(rpnExpressionList[0]);
        }
    }
}
