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
        private string colPassed;
        private string answer = "";

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            setDesign(_colPassed);
        }

        private void QMerge_Load(object sender, EventArgs e)
        {
            answer = generateQmerge()[1];
        }

        private string[] generateQmerge()
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
                result = merge(left, right); // calls the merge, which will sort and fit toghther
                return result;
            }

            int[] merge(int[] left, int[] right) // combines both sides of the mergesort array
            {
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

            string tempStringPre = "";
            for (int i = 0; i < unsorted.Length; i = i + 1)
            {
                tempStringPre = tempStringPre + unsorted[i].ToString();
            }

            string tempStringPost = "";
            for (int i = 0; i < unsorted.Length; i = i + 1)
            {
                tempStringPost = tempStringPost + sorted[i].ToString();
            }

            string[] retunArray = { tempStringPre, tempStringPost };

            //MessageBox.Show("Before: " + tempStringPre);
            //MessageBox.Show("After: " + tempStringPost);

            labelQuestion.Text = tempStringPre;

            return (retunArray);
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

        private void buttonGenerateQuestion_Click(object sender, EventArgs e)
        {
            answer = generateQmerge()[1];
        }
    }
}
