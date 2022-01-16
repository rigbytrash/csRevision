using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace compSciRevisionTool
{
    class createMergeSortQ
    {
        private string answer01 = "";
        private string answer02 = "";
        private int step = 0;
        private string[] fourthStepFinalArray;
        int difficulty;

        public string[] generateQmerge(int _difficulty) // generates a merge sort question, prints the question to the screen and  sets the answer 01 & 02 variables to the correct answers
        {
            difficulty = _difficulty;
            Random rnd = new Random();
            int[] unsorted = new int[8];

            switch (difficulty)
            {
                case 1:
                    for (int i = 0; i < 8; i = i + 1) // fill the unsorted array with 8 numbers (0 to 9)
                    {
                        int randomNumber = rnd.Next(0, 10);
                        unsorted[i] = randomNumber;
                    }
                    break;

                case 2:
                    for (int i = 0; i < 5; i = i + 1) // fill the unsorted array with 8 numbers (65 to 90 & 97 to 122)
                    {                                           // this is because these are the ascii int values for the alphabet lower and uppercase
                        int randomNumber = rnd.Next(65, 91);    // later, these numbers are converted into their character alternative
                        unsorted[i] = randomNumber;
                    }
                    for (int i = 5; i < 8; i = i + 1)
                    {
                        int randomNumber = rnd.Next(97, 123);
                        unsorted[i] = randomNumber;
                    }
                    
                    Random rndToShuffle = new Random();
                    int[] tempShuffleArray = unsorted.OrderBy(x => rndToShuffle.Next()).ToArray(); // shuffles the letter ints as the cases are split on either side
                    unsorted = tempShuffleArray;
                    break;

                default:
                    for (int i = 0; i < unsorted.Length; i = i + 1) // creates a pattern i can detect as an error (default should never happen)
                    {
                        unsorted[i] = i;
                    }
                    break;
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

                fourthStepFinalArray = arraysToStrings(left, right); // stored to later be returned to the original call

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
                        //if item on left array is less than item on right array, add that item to the result array 
                        if (left[indexLeft] <= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        //else the item in the right array wll be added to the results array
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

            string tempStringPre = ""; // for converting the pre array into a string
            string tempStringPost = ""; // for converting the post array into a string

            switch (difficulty)
            {
                case 1: // difficulty one just turns the arrays into strings and returns them
                    for (int i = 0; i < unsorted.Length; i = i + 1)
                    {
                        tempStringPre = tempStringPre + unsorted[i].ToString();
                    }

                    for (int i = 0; i < unsorted.Length; i = i + 1)
                    {
                        tempStringPost = tempStringPost + sorted[i].ToString();
                    }
                    break;

                case 2: // difficulty two turns each ascii int (e.g. 65) into its character and then creates an array
                    for (int i = 0; i < unsorted.Length; i = i + 1)
                    {
                        tempStringPre = tempStringPre + ((char)unsorted[i]).ToString();
                    }

                    for (int i = 0; i < unsorted.Length; i = i + 1)
                    {
                        tempStringPost = tempStringPost + ((char)sorted[i]).ToString();
                    }
                    break;

                default: // creates a pattern i can detect as an error (default should never happen)
                    tempStringPost = "0000";
                    tempStringPre = "0000";
                    break;
            }

           

            string[] retunArray = { tempStringPre, fourthStepFinalArray[0], fourthStepFinalArray[1] }; // this returns the question and the two answer parts
            return (retunArray);
        }

        private string[] arraysToStrings(int[] left, int[] right) // returns the left and right array in the form of strings (from int to string) so they can be compared and printed to screen
        {
            string fourthLeft = "";
            string fourthRight = "";

            switch (difficulty) // the following code will be called upon on every step but the last step will override and will take in the two arrays before that were combined
            {                       // then the code will turn them into two seperate strings and return them
                case 1:
                    for (int i = 0; i < left.Length; i = i + 1)
                    {
                        fourthLeft = fourthLeft + left[i].ToString();
                    }

                    for (int i = 0; i < right.Length; i = i + 1)
                    {
                        fourthRight = fourthRight + right[i].ToString();
                    }
                    break;

                case 2:
                    for (int i = 0; i < left.Length; i = i + 1)
                    {
                        fourthLeft = fourthLeft + ((char)left[i]).ToString();
                    }

                    for (int i = 0; i < right.Length; i = i + 1)
                    {
                        fourthRight = fourthRight + ((char)right[i]).ToString();
                    }
                    break;

                default: // creates a pattern i can detect as an error (default should never happen)
                    fourthLeft = "0000";
                    fourthRight = "0000";
                    break;

            }

            string[] returnArray = { fourthLeft, fourthRight };
            return (returnArray);
        }


    }
}
