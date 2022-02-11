using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace compSciRevisionTool
{
    class createBinaryQ
    {
        int difficulty = 1;

        private string generateBinaryWithoutPoint(int bitsWanted)
        {
            string toReturn = "";
            Random rndm = new Random();
            for (int i = 0; i < bitsWanted; i = i + 1)
            {
                toReturn = toReturn + rndm.Next(0, 2).ToString();
            }
            if (difficulty == 1) // if the difficulty is one, just change the first digit to a 0
            {
                toReturn = '0' + toReturn.Remove(0, 1);
            }
            return toReturn;
        }

        private string insertPoint(string input)
        {
            string toReturn = input.Insert(1, ".");
            return (toReturn);
        }

        private double twoscomplementFixedPointBinaryToDouble(string binaryString)
        {
            bool hasPoint = false;
            string afterPoint = "";
            string[] parts = binaryString.Split('.');
            if (binaryString.Contains("."))
            {
                hasPoint = true;
                afterPoint = parts[1];
            }

            string beforePoint = parts[0];
            double finalNum = 0;

            char[] beforePointArrayR = utils.reverseLetters(beforePoint).ToCharArray(); // reverses the pattern of bits before the point to make it in ascending order

            if (hasPoint)
            {
                char[] afterPointArray = afterPoint.ToCharArray();
                for (int i = 0; i < afterPoint.Length; i = i + 1)
                {
                    if (afterPointArray[i] == '1')
                    {
                        finalNum = finalNum + Math.Pow(2, -(i + 1)); //two to the power of (minus i + 1), this is equal to doing 1/(2^i-1)
                    }
                }
            }

            for (int i = 0; i < beforePoint.Length; i = i + 1) // for each bit before the point (reversed), do 2^of the position if there is a bit in that place
            {
                if (i == beforePoint.Length - 1)
                {
                    if (beforePointArrayR[i] == '1') // if the first bit is a one - then it a negative value
                    {
                        finalNum = finalNum - Math.Pow(2, i);
                    }
                }
                else
                {
                    if (beforePointArrayR[i] == '1')
                    {
                        finalNum = finalNum + Math.Pow(2, i);
                    }
                }
            }
            return finalNum;
        }

        private double twoscomplementFloatingPointBinaryToDouble(string mantissa, string exponent) // evauluates the expression into a decimal value
        {
            double exponentValue = twoscomplementFixedPointBinaryToDouble(exponent);
            Debug.WriteLine("Mantissa: " + mantissa);
            Debug.WriteLine("Exponant: " + exponent);
            Debug.WriteLine("Exponant Value: " + exponentValue);

            if (exponentValue > 0) // if the expoanant is positive, then just shift the characers left by that ammount
            {
                for (int i = 0; i < exponentValue; i = i + 1)
                {
                    mantissa = mantissa + "0";
                }
            }
            else
            {
                char firstValue = mantissa[0];
                for (int i = 0; i < Math.Abs(exponentValue); i = i + 1) // for the ammount of the exponant, shift the mantissa to the right
                {                                                       // when adding padding to the front - the initial 1 or 0 is duplicated in order to keep the pos/neg sign
                    mantissa = firstValue + mantissa;
                }
            }
            Debug.WriteLine("New mantissa after adding padding: " + mantissa);
            string fixedPointBin = shiftStringItems(mantissa, '.', exponentValue); // shifts the point to be normalised, now the binary string is just fixed point
            Debug.WriteLine("Mantissa after shift: " + fixedPointBin);
            double toReturn = twoscomplementFixedPointBinaryToDouble(fixedPointBin); // returns the decimal value

            Debug.WriteLine("Answer = " + toReturn);
            return toReturn;
        }

        private string shiftStringItems(string input, char uniqueCharToShift, double ammount) // shifts a certain specified character a certain amount of places
        {
            char[] inputArray = input.ToCharArray();
            int uniqueCharIndex = 0;
            bool right = true;

            if (ammount < 1) // if it is to be moved to the left
            {
                right = false;
            }

            for (int i = 0; i < inputArray.Length; i = i + 1) // for the length of the input, keep checking for the unique character (will be a full stop)
            {
                if (inputArray[i] == uniqueCharToShift)
                {
                    uniqueCharIndex = i;
                }
            }

            if (ammount == 0) // if there is no changes to be made
            {
                return input;
            }
            else if (right)
            {
                for (int i = uniqueCharIndex; i < Math.Abs(ammount) + 1; i = i + 1)
                {
                    //swap chars
                    var tempChar = inputArray[i];
                    inputArray[i] = inputArray[i + 1];
                    inputArray[i + 1] = tempChar;
                }
            }
            else
            {
                for (int i = uniqueCharIndex; i > 1; i = i - 1)
                {
                    var tempChar = inputArray[i - 1];
                    inputArray[i - 1] = inputArray[i];
                    inputArray[i] = tempChar;
                }
            }

            String b = new String(inputArray);
            return b;
        }

        public string[] generateFloatingQ(int mantissaBitsWanted, int exponentBitsWanted)
        {
            string mantissa = insertPoint(generateBinaryWithoutPoint(mantissaBitsWanted));
            string exponent = generateBinaryWithoutPoint(exponentBitsWanted);

            double answer = twoscomplementFloatingPointBinaryToDouble(mantissa, exponent);

            string[] returnArray = {answer.ToString(), mantissa, exponent};
            return returnArray;
        }

        public string[] quesGen(int _difficulty)
        {
            difficulty = _difficulty;
            string[] toReturn = generateFloatingQ(5, 3);
            return toReturn;
        }

        public string[] generateFixedQ(int mantissaBitsWanted)
        {
            string mantissa = insertPoint(generateBinaryWithoutPoint(mantissaBitsWanted));

            double answer = twoscomplementFixedPointBinaryToDouble(mantissa);

            string[] returnArray = {answer.ToString(), mantissa};
            return returnArray;
        }
    }
}
