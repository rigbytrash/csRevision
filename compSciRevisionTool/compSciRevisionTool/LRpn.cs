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

        readFromTextClass rfrc = new readFromTextClass("C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevision/compSciRevisionTool/compSciRevisionTool/LRpnText.txt");
        int linesCount = 0;

        private void LRpn_Load(object sender, EventArgs e)
        {
            setDesign(programColoursClass.getcolour("secondary"));
            //r.setLabelDesign(label1, linesCount,"typewriter",nextButton, disableNextButton); // title text
            generateTitle(rfrc.getLine(linesCount), nextButton);
            //lastObject = label1;
            linesCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (nextButtonCount) // for every time the next button is clicked it creates the next item in the queue
            {
                default:
                    generateNextItem(lastObject, rfrc.getNext(linesCount), nextButton);
                    linesCount++;
                    break;
            }
            nextButtonCount = nextButtonCount + 1;
        }
    }
}
