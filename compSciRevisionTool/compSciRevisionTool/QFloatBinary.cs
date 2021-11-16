using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace compSciRevisionTool
{
    public partial class QFloatBinary : formDesign
    {
        string colPassed;
        public QFloatBinary(string _colPassed)
        {
            InitializeComponent();
            setDesign(colPassed = _colPassed);
        }

        private void QFloatBinary_Load(object sender, EventArgs e)
        {
            //Form msg3 = new messgaeBox(insertPoint(generateBinary(5)), subColour);
            ////Form msg2 = new messgaeBox(generateBinary(3), subColour);
            //Form msg4 = new messgaeBox(insertPoint(generateBinary(5)), subColour);

            string b4 = insertPoint(generateBinary(5));
            double after = twoscomplementFixedPointBinaryToDouble(b4);
            Form mss = new messgaeBox(after.ToString(), subColour);
            Form mdss = new messgaeBox(b4, subColour);

        }

        private string generateBinary(int bitsWanted)
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

        private void generateQ()
        {
            string mantissa = insertPoint(generateBinary(5));
            string exponant = insertPoint(generateBinary(3));
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
                    Debug.WriteLine("finalNum = " + finalNum.ToString());
                }
            }

            for (int i = 0; i < beforePoint.Length; i = i+ 1)
            {
                if (i == beforePoint.Length - 1)
                {
                    if (beforePointArrayR[i] == '1')
                    {
                        finalNum = finalNum - Math.Pow(2,i);
                    }
                }
                else
                {
                    if (beforePointArrayR[i] == '1')
                    {
                        finalNum = finalNum + Math.Pow(2, i);
                    }
                }
                Debug.WriteLine("finalNum = " + finalNum.ToString());
            }
            return finalNum;
        }

        private double twoscomplementFloatingPointBinaryToDouble(string mantissa, string exponent)
        {
            double exponentValue = twoscomplementFixedPointBinaryToDouble(exponent);
            char[] mantissaArray = mantissa.ToCharArray();

            for (int i = 0; i < exponentValue; i = i + 1)
            {

            }

            return 0;
        }
    }
}
