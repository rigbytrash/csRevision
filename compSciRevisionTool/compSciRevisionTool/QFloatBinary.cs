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
            Form msg3 = new messgaeBox(insertPoint(generateBinary(5)), subColour);
            Form msg3 = new messgaeBox(insertPoint(generateBinary(3)), subColour);
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

        private int twosComplimentFloaingBinaryToDecimal(string binaryString)
        {
            string[] parts = binaryString.Split('.');
            string beforePoint = parts[0];
            string afterPoint = parts[1];

            return 0;
        }
    }
}
