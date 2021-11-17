using FontAwesome.Sharp;
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
using System.Windows.Forms.VisualStyles;
using System.Reflection;
using System.Diagnostics;
using System.Resources;

namespace compSciRevisionTool
{
    public partial class formDesign : Form
    {
        public string subColour = "1";
        public formDesign()
        {
            InitializeComponent();
            this.Size = new Size(1029, 574);
        }

        private void formDesign_Load(object sender, EventArgs e)
        {

        }

        public void hideAllLabels() // this will hide all labels on load
        {
            foreach (Label labels in this.Controls.OfType<Label>())
            {
                labels.Hide();
            }
        }

        public void setDesign(string _subColour) // makes all the features have a uniform design
        {
            subColour = _subColour;
            this.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.4f); // sets bg colour

            foreach (Button butt in this.Controls.OfType<Button>()) // sets button appearence
            {
                if (butt.GetType() == typeof(Button))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            foreach (Button butt in this.Controls.OfType<IconButton>()) // button appearence again but for icon buttons
            {
                if (butt.GetType() == typeof(IconButton))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }


            foreach (TextBox textboxes in this.Controls.OfType<TextBox>()) // sets textbox appearence
            {
                textboxes.BorderStyle = BorderStyle.None;
                textboxes.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.9f);

            }
        }
        public void advanceProgressBar(ProgressBar pb, int consecQsCorrect)
        {
            float temp = (((float)(consecQsCorrect) / 5) * 100);
            pb.Value = ((int)temp);
        }
    }
}
