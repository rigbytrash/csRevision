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
    public partial class stackPlayground : formDesign
    {
        string[] theStack = new string[7];
        int pointer = 0;
        bool isFull = false;

        public stackPlayground(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            fillEmpty();
            update();
        }

        private void fillEmpty()
        {
            for (int i = 0; i < theStack.Length; i = i + 1)
            {
                theStack[i] = "Empty";
            }
        }

        //bool isFull
        //{
        //    get
        //    {
        //        return false;
        //        if (pointer == theStack.Length)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        
        bool isEmpty
        {
            get
            {
                if (pointer == 0)
                {
                    return true;
                }
                return false;
            }
        }

        private void push(string value)
        {
            if (isFull)
            {
                utils.msg("The stack is full",colPassed);
            }
            else
            {
                theStack[pointer] = value;
                if (pointer == theStack.Length - 1)
                {
                    isFull = true;
                }
                else
                {
                    pointer++;
                }
            }
        }

        private void pop()
        {
            if (isEmpty)
            {
                utils.msg("The stack is empty",colPassed);
            }
            else
            {
                if (isFull)
                {
                    utils.msg("' " + theStack[pointer] + "' was popped",colPassed);
                    theStack[pointer] = "Empty";
                    isFull = false;
                }
                else
                {
                    pointer = pointer - 1;
                    utils.msg("' " + theStack[pointer] + "' was popped", colPassed);
                    theStack[pointer] = "Empty";
                }
            }
        }

        private void peek()
        {
            if (isEmpty)
            {
                utils.msg("The stack is empty", colPassed);
            }
            else if (isFull)
            {
                utils.msg("'" + theStack[theStack.Length - 1] + "' was the last entry...", colPassed);
            }
            else
            {
                utils.msg("'" + theStack[pointer - 1] + "' was the last entry...", colPassed);
            }
        }


        private void update()
        {

            pos0.Text = theStack[0];
            pos1.Text = theStack[1];
            pos2.Text = theStack[2];
            pos3.Text = theStack[3];
            pos4.Text = theStack[4];
            pos5.Text = theStack[5];
            pos6.Text = theStack[6];
            pointerLabel.Text = "Stack Pointer: " + pointer.ToString();
        }


        private void stackPlayground_Load(object sender, EventArgs e)
        {
            arrayLengthLabel.Text = "Array Length: " + (theStack.Length).ToString();
        }

        private void pushButton_Click(object sender, EventArgs e)
        {
            push(inputTextBox.Text);
            update();
        }

        private void popButton_Click(object sender, EventArgs e)
        {
            pop();
            update();
        }

        private void peekButton_Click(object sender, EventArgs e)
        {
            peek();
        }
    }
}
