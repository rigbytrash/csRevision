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
        static string textFilepath = "C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevisionV2/compSciRevisionTool/compSciRevisionTool/Resources/learn/RPN/text.txt";
        readFromTextClass rfrc = new readFromTextClass(textFilepath);

        public LRpn(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
        }

        private void LRpn_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
            generateTitle(rfrc.getLine(linesCount), nextButton);
            linesCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nextButtonClick(rfrc,nextButton);
        }
    }
}
