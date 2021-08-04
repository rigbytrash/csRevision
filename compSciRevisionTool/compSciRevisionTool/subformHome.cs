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
        string colPassed;
        public subformHome(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
        }

        private void subformHome_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
        }
    }
}
