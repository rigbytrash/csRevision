using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class LRpn : formDesign
    {
        
        public LRpn(Color colPassed)
        {
            InitializeComponent();
        }

        readFromTextClass r = new readFromTextClass("C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevision/compSciRevisionTool/compSciRevisionTool/LRpnText.txt");
        int linesCount = 0;

        private void LRpn_Load(object sender, EventArgs e)
        {
            setDesign(programColoursClass.getcolour("secondary"));
            hideAllLabels();
            r.setLabelDesign(label1, linesCount,"typewriter",nextButton);
            linesCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (nextButtonCount)
            {
                case (0):
                    r.setLabelDesign(label2, linesCount, "typewriter",nextButton);
                    lastObject = label2;
                    linesCount++;
                    break;
                case (1):
                    generateLabelUnder(lastObject, r.getLine(linesCount), nextButton);
                    linesCount++;
                    generateLabelUnder(lastObject, r.getLine(linesCount), nextButton);
                    linesCount++;
                    nextButtonCount++;
                    break;
                case (2):
                    generatePictureBoxUnder(lastObject, "C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevision/compSciRevisionTool/testBitmap.bmp", nextButton);
                    linesCount++;
                    break;
                default:
                    generateLabelUnder(lastObject, r.getLine(linesCount),nextButton);
                    linesCount++;
                    break;
            }
            nextButtonCount = nextButtonCount + 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            generateLabelUnder(lastObject, r.getLine(2),nextButton);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            lastObject = label1;
            

        }
    }
}
