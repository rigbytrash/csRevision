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
        private string colPassed;
        public LRpn(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
        }
        static string textFilepath = "C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevision/compSciRevisionTool/compSciRevisionTool/Resources/learn/RPN/text.txt";
        readFromTextClass rfrc = new readFromTextClass(textFilepath);

        private void LRpn_Load(object sender, EventArgs e)
        {
            setDesign(programColoursClass.getcolour(colPassed));
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
                    var temp = rfrc.getNext(linesCount); // gets next item array which gives item type, item subtype, data, last item check and pairing check
                    generateNextItem(lastObject,temp, nextButton);
                    while (temp[4] == "r") // r indicates that the next item is paired with the current item, so the next item is shown at the same time
                    {
                        linesCount++;
                        temp = rfrc.getNext(linesCount);
                        generateNextItem(lastObject, temp, nextButton);
                    }
                    linesCount++;
                    break;
            }
            nextButtonCount = nextButtonCount + 1;
        }
    }
}
