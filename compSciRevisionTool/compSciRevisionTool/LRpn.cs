using System;
using System.Resources;
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
        static string textFilepath = compSciRevisionTool.LRPNresources.text;
        readFromTextClass rfrc;

        public LRpn(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            rfrc =  new readFromTextClass(compSciRevisionTool.LRPNresources.text);

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
