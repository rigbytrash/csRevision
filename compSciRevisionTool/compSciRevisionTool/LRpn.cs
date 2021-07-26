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
        readFromTextClass r = new readFromTextClass("C:/Users/Hamza Siddique/source/repos/rigbytrash/csRevision/compSciRevisionTool/compSciRevisionTool/LRpnText.txt");

        public LRpn(Color colPassed)
        {
            InitializeComponent();
        }

        private void LRpn_Load(object sender, EventArgs e)
        {
            hideAllLabels();
            r.setLabelDesign(label1, 0,"typewriter");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.setLabelDesign(label2,1,"typewriter");
        }
    }
}
