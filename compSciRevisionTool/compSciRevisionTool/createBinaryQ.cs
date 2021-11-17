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
        private string generateBinaryWithoutPoint(int bitsWanted)
        {
            string toReturn = "";
            Random rndm = new Random();
            for (int i = 0; i < bitsWanted; i = i + 1)
            {
                toReturn = toReturn + rndm.Next(0, 2).ToString();
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

            char[] beforePointArrayR = utils.reverseLetters(beforePoint).ToCharArray();

            if (hasPoint)
            {
                char[] afterPointArray = afterPoint.ToCharArray();
                for (int i = 0; i < afterPoint.Length; i = i + 1)
                {
                    if (afterPointArray[i] == '1')
                    {
                        finalNum = finalNum + Math.Pow(2, -(i + 1));
                    }
                }
            }

            for (int i = 0; i < beforePoint.Length; i = i + 1)
            {
                if (i == beforePoint.Length - 1)
                {
                    if (beforePointArrayR[i] == '1')
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

        private double twoscomplementFloatingPointBinaryToDouble(string mantissa, string exponent)
        {
            double exponentValue = twoscomplementFixedPointBinaryToDouble(exponent);
            Debug.WriteLine("Mantissa: " + mantissa);
            Debug.WriteLine("Exponant: " + exponent);
            Debug.WriteLine("Exponant Value: " + exponentValue);

            if (exponentValue > 0)
            {
                for (int i = 0; i < exponentValue; i = i + 1)
                {
                    mantissa = mantissa + "0";
                }
            }
            else
            {
                char firstValue = mantissa[0];
                for (int i = 0; i < Math.Abs(exponentValue); i = i + 1)
                {
                    mantissa = firstValue + mantissa;
                }
            }
            Debug.WriteLine("New mantissa after adding padding: " + mantissa);
            string fixedPointBin = shiftStringItems(mantissa, '.', exponentValue);
            Debug.WriteLine("Mantissa after shift: " + fixedPointBin);
            double toReturn = twoscomplementFixedPointBinaryToDouble(fixedPointBin);

            Debug.WriteLine("Answer = " + toReturn);
            return toReturn;
        }

        private string shiftStringItems(string input, char uniqueCharToShift, double ammount)
        {
            char[] inputArray = input.ToCharArray();
            int uniqueCharIndex = 0;
            bool right = true;

            if (ammount < 1)
            {
                right = false;
            }

            for (int i = 0; i < inputArray.Length; i = i + 1)
            {
                if (inputArray[i] == uniqueCharToShift)
                {
                    uniqueCharIndex = i;
                }
            }

            if (ammount == 0)
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

        public string[] generateFixedQ(int mantissaBitsWanted)
        {
            string mantissa = insertPoint(generateBinaryWithoutPoint(mantissaBitsWanted));

            double answer = twoscomplementFixedPointBinaryToDouble(mantissa);

            string[] returnArray = {answer.ToString(), mantissa};
            return returnArray;
        }
    }
}
