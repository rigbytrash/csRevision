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
    public partial class LRpn : formDesign
    {
        public LRpn(Color colPassed)
        {
            InitializeComponent();
        }

        private void LRpn_Load(object sender, EventArgs e)
        {
            hideAllLabels();
            var tn = new typwriterEffectClass();
            tn.typewriterEffect(label1);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tt = new typwriterEffectClass();
            tt.typewriterEffect(label2);
        }
    }
}
