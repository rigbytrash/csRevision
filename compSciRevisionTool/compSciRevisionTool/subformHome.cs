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
    public partial class subformHome : formDesign
    {
        Color bgCol = programColoursClass.getcolour("secondary");

        public subformHome(Color colPassed)
        {
            InitializeComponent();
            bgCol = colPassed;
        }

        private void subformHome_Load(object sender, EventArgs e)
        {
            setDesign(bgCol);
        }
    }
}
