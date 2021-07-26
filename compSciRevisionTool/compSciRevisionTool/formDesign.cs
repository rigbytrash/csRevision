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

namespace compSciRevisionTool
{
    public partial class formDesign : Form
    {
        public object lastObject;
        public int nextButtonCount = 0;


        public formDesign()
        {
            InitializeComponent();
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


        public void setDesign(Color subColour) // makes all the features have a uniform design
        {
            this.BackColor = programColoursClass.ChangeColorBrightness(subColour, +0.4f); // sets bg colour

            foreach (Button butt in this.Controls.OfType<Button>()) // sets button appearence
            {
                if (butt.GetType() == typeof(Button))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(subColour, +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            foreach (Button butt in this.Controls.OfType<IconButton>()) // button appearence again but for icon buttons
            {
                if (butt.GetType() == typeof(Button))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(subColour, +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            } 

            foreach (TextBox textboxes in this.Controls.OfType<TextBox>()) // sets textbox appearence
            {
                textboxes.BorderStyle = BorderStyle.None;
                textboxes.BackColor = programColoursClass.ChangeColorBrightness(subColour, +0.9f);
                
            }
        }

        public void generateLabelUnder(object _lastObject, string toText, Button nextButton)
        {
            lastObject = _lastObject;
            Label newLabel = new Label();
            Controls.Add(newLabel);
            newLabel.Visible = false;
            newLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newLabel.ForeColor = Color.Black;
            newLabel.MaximumSize = new Size(900, 0);
            newLabel.AutoSize = true;
            if (lastObject.GetType() == typeof(Label))
            {
                Label prev = (Label)lastObject;
                newLabel.Location = prev.Location;
                newLabel.Top = prev.Bottom + 15;
            }
            else if (lastObject.GetType() == typeof(PictureBox))
            {
                PictureBox prev = (PictureBox)lastObject;
                newLabel.Location = prev.Location;
                newLabel.Top = prev.Bottom + 15;
            }
            //MessageBox.Show(toText);
            newLabel.Text = toText;
            newLabel.BringToFront();
            newLabel.Refresh();
            newLabel.Tag = "generated";
            typwriterEffectClass tw = new typwriterEffectClass(newLabel,nextButton);
            lastObject = newLabel;
            if (newLabel.Bottom > nextButton.Top)
            {
                foreach (Control contr in this.Controls)
                {
                    contr.Hide();
                }
                newLabel.Top = 10;
            }
            newLabel.Show();
            newLabel.BringToFront();
            nextButton.BringToFront();
            
        }

        public void generatePictureBoxUnder(object _lastObject, string filepath, Button nextButton)
        {
            lastObject = _lastObject;
            PictureBox newPictureBox = new PictureBox();
            Controls.Add(newPictureBox);
            if (lastObject.GetType() == typeof(Label))
            {
                Label prev = (Label)lastObject;
                newPictureBox.Location = prev.Location;
                newPictureBox.Top = prev.Bottom + 15;
            }
            else if (lastObject.GetType() == typeof(PictureBox))
            {
                PictureBox prev = (PictureBox)lastObject;
                newPictureBox.Location = prev.Location;
                newPictureBox.Top = prev.Bottom + 15;
            }

            

            newPictureBox.Image = Image.FromFile(filepath);
            newPictureBox.Size = Image.FromFile(filepath).Size;

            newPictureBox.BringToFront();
            newPictureBox.Refresh();
            newPictureBox.Tag = "generated";
            lastObject = newPictureBox;
            if (newPictureBox.Bottom > nextButton.Top)
            {
                foreach (Control contr in this.Controls)
                {
                    contr.Hide();
                }
                newPictureBox.Top = 10;
            }
            newPictureBox.Show();
            newPictureBox.BringToFront();
            imageSlideAnimationClass l = new imageSlideAnimationClass(newPictureBox, nextButton);
            nextButton.BringToFront();

        }
    }
}
