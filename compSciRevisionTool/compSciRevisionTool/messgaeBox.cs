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
    public partial class messgaeBox : formDesign
    {
        private string daMessageToDisplay = "";
        public messgaeBox(string _daMessageToDisplay)
        {
            InitializeComponent();
            setDesign("9");
            daMessageToDisplay = _daMessageToDisplay;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = daMessageToDisplay;
            this.AutoSize = true;
        }

        private void messgaeBox_Load(object sender, EventArgs e)
        {

        }

        private void dissmissButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
