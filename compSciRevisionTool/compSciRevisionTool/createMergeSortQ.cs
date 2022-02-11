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

            int[] mergeSort(int[] inputArray)
            {
                if (inputArray.Length <= 1) // return if not possible to sort
                {
                    return inputArray;
                }

                int arrayLen = inputArray.Length;
                int midPoint = arrayLen / 2;
                int[] leftSide = new int[midPoint];   // this sets the length of the left hand array to the midpoint, so half of the original array will fit in here
                int[] rightSide;
                int[] result = new int[arrayLen];

                if (arrayLen % 2 == 0)  // if even ammount of elements, right side array and left side array will have the same ammount of elements
                {
                    rightSide = new int[leftSide.Length]; 
                }
                else
                {
                    rightSide = new int[leftSide.Length + 1]; // if odd ammount of numbers, right side array has one more element than left
                }

                for (int i = 0; i < inputArray.Length; i = i + 1) // splits the elements of the array into two sides
                {
                    if (i <= midPoint - 1)
                    {
                        leftSide[i] = inputArray[i];
                    }
                    else
                    {
                        rightSide[i - midPoint] = inputArray[i];
                    }
                }

                leftSide = mergeSort(leftSide); // uses the mergeSort class with the left and right seperately - this is recusrsive and will keep going until the lowest array has 1 item in it
                rightSide = mergeSort(rightSide); // when an array one len 1 is entered, it is returned as itself
                result = mergeArraysSorted(leftSide, rightSide); // calls the merge, which will sort and fit toghther each array

                fourthStepFinalArray = arraysToStrings(leftSide, rightSide); // stored to later be returned to the original call

                return result;
            }

            int[] mergeArraysSorted(int[] leftSide, int[] rightSide) // combines both sides of the mergesort array
            {
                step = step + 1;
                int[] result = new int[rightSide.Length + leftSide.Length];
                int resultIndex = 0;
                int leftSideIndex = 0;
                int rightSideIndex = 0;

                while (leftSideIndex < leftSide.Length || rightSideIndex < rightSide.Length) // while either side still has elements not visited
                { 
                    if (leftSideIndex <= leftSide.Length - 1 && rightSideIndex <= rightSide.Length - 1) // if both have elements
                    {
                        if (leftSide[leftSideIndex] <= rightSide[rightSideIndex])   // if item in left array <= on right array item, add item to the result array and increment left and result counter
                        {                                                   // if the elements are the same, it does not matter which one enters the final array first
                            result[resultIndex] = leftSide[leftSideIndex];
                            leftSideIndex = leftSideIndex + 1;
                        }
                        else //otherwise add the right item to the result array
                        {
                            result[resultIndex] = rightSide[rightSideIndex];
                            rightSideIndex = rightSideIndex + 1;
                        }
                    }
                    else if (leftSideIndex < leftSide.Length) // if only the left array has elements, dump them into the result array
                    {
                        result[resultIndex] = leftSide[leftSideIndex];
                        leftSideIndex = leftSideIndex + 1;
                    }
                    else if (rightSideIndex < rightSide.Length) //if only the right array has elements, dump them into the result array
                    {
                        result[resultIndex] = rightSide[rightSideIndex];
                        rightSideIndex = rightSideIndex + 1;
                    }

                    resultIndex = resultIndex + 1;
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
