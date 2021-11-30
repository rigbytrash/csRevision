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
    public partial class LMERGE : formDesignForInformationForms
    {
        private string colPassed;
        static string textFilepath = compSciRevisionTool.LMergeResources.text;
        readFromTextClass rfrc;

        public LMERGE(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            rfrc = new readFromTextClass(compSciRevisionTool.LMergeResources.text);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            nextButtonClick(rfrc, nextButton);
        }

        private void LMERGE_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
            generateTitle(rfrc.getLine(linesCount), nextButton);
            linesCount++;
        }
    }
}
