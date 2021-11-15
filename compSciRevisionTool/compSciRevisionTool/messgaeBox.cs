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
        string colourWanted = "4";
        public messgaeBox(string _daMessageToDisplay, string _subcolour = "4")
        {
            InitializeComponent();
            colourWanted = _subcolour;
            setDesign(colourWanted);
            daMessageToDisplay = _daMessageToDisplay;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = daMessageToDisplay;
            label1.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colourWanted), -0.1f);
            dissmissButton.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colourWanted), +0.5f);
            dissmissButton.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colourWanted), -0.2f);
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
