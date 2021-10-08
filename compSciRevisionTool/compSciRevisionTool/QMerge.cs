using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class QMerge : compSciRevisionTool.formDesign
    {
        private string colPassed = "";
        private string answer01 = "";
        private string answer02 = "";
        private int step = 0;
        private string[] fourthStepFinalArray;

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
            comboBox1.Items.Add("1"); // adding difficulty opions
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("2");
            generateQmerge(); // ensures there is a question there already
        }

        private void QMerge_Load(object sender, EventArgs e)
        {
        }

        private string[] generateQmerge() // generates a merge sort question, prints the question to the screen and  sets the answer 01 & 02 variables to the correct answers
        {
            int[] numbersToCreateFrom = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rnd = new Random();
            int[] unsorted = new int[8];

            for (int i = 0; i < 8; i = i + 1)
            {
                int randomNumber = rnd.Next(0, 9);
                unsorted[i] = numbersToCreateFrom[randomNumber];
            }

            int[] sorted = mergeSort(unsorted);

            int[] mergeSort(int[] array)
            {
                int[] left;
                int[] right;
                int[] result = new int[array.Length];
                if (array.Length <= 1) // return if not possible to sort
                {
                    return array;
                }

                int midPoint = array.Length / 2;
                left = new int[midPoint];   // this sets the length of the left hand array to the midpoint, so half of the original array will fit in here

                if (array.Length % 2 == 0)  //if array has an even number of elements, the left and right array will have the same number of elements
                {
                    right = new int[midPoint]; //if array has an odd number of elements, the right array will have one more element than left

                }
                else
                {
                    right = new int[midPoint + 1];
                }

                for (int i = 0; i < midPoint; i++) // for each element in the orig. array up until the midpoint - put those values into the left hand array
                {
                    left[i] = array[i];
                }

                int y = 0;
                for (int i = midPoint; i < array.Length; i++) // adds items to the right hand side array - from the midpoint to the end of the right hand side limit
                {
                    right[y] = array[i];
                    y++;
                }
                //Recursively sort the left array
                left = mergeSort(left); // create a new mergeSort class with the left and right seperately - this is recusrsive and will keep going until the lowest array has 1 item in it
                right = mergeSort(right);
                result = merge(left, right); // calls the merge, which will sort and fit toghther;

                fourthStepFinalArray = arraysToStrings(left, right);

                return result;
            }

            int[] merge(int[] left, int[] right) // combines both sides of the mergesort array
            {
                step = step + 1;
                int resultLength = right.Length + left.Length;
                int[] result = new int[resultLength];
                int indexLeft = 0, indexRight = 0, indexResult = 0;
                //while either array still has an element
                while (indexLeft < left.Length || indexRight < right.Length)
                {
                    //if both arrays have elements  
                    if (indexLeft < left.Length && indexRight < right.Length)
                    {
                        //If item on left array is less than item on right array, add that item to the result array 
                        if (left[indexLeft] <= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        // else the item in the right array wll be added to the results array
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                    //if only the left array still has elements, add all its items to the results array
                    else if (indexLeft < left.Length)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    //if only the right array still has elements, add all its items to the results array
                    else if (indexRight < right.Length)
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                return result;
            }


            string tempStringPre = ""; // converting the pre array into a string
                        for (int i = 0; i < unsorted.Length; i = i + 1)
            {
                tempStringPre = tempStringPre + unsorted[i].ToString();
            }

            string tempStringPost = ""; // converting the post array into a string
            for (int i = 0; i < unsorted.Length; i = i + 1)
            {
                tempStringPost = tempStringPost + sorted[i].ToString();
            }

            string[] retunArray = { tempStringPre, fourthStepFinalArray[0], fourthStepFinalArray[1] }; // this is here if i want to later return the values
            labelQuestion.Text = tempStringPre;


            answer01 = retunArray[1]; // sets the answer variables - these will be compared to the user input to see if they're correct
            answer02 = retunArray[2];

            return (retunArray);
        }

        private string[] arraysToStrings(int[] left, int[] right) // returns the left and right array in the form of strings (from int to string) so they can be compared and printed to screen
        {
            string fourthLeft = "";
            for (int i = 0; i < left.Length; i = i + 1)
            {
                fourthLeft = fourthLeft + left[i].ToString();
            }

            string fourthRight = "";
            for (int i = 0; i < right.Length; i = i + 1)
            {
                fourthRight = fourthRight + right[i].ToString();
            }

            string[] returnArray = { fourthLeft, fourthRight }; 

            return (returnArray);
        }

        private void buttonSubmitAnswer_Click(object sender, EventArgs e) // click for the submit button
        {
            checkAns();
        }

        private void buttonGenerateQuestion_Click(object sender, EventArgs e) // generate new question button based on the difficulty selected
        {
            setDesign(colPassed);
            generateQmerge();
        }

        private void testLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkAns()
        {
            if (answerBox1.Text == answer01 && answerBox2.Text == answer02) // checks if the answer entered is correct
            {
                MessageBox.Show("Correct :)");
            }
            else
            {
                MessageBox.Show("Wrong :(");
            }
        }

        private void secondAnswerBoxKeyDown(object sender, KeyEventArgs e)
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
