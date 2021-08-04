﻿using FontAwesome.Sharp;
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

namespace compSciRevisionTool
{
    public partial class formDesign : Form
    {

        public object lastObject;
        public int nextButtonCount = 0;
        public bool disableNextButton = false;
        public int linesCount = 1;
        int wantedpadding = 0;

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
                //labels.Hide();
            }
        }

        public void setDesign(string subColour) // makes all the features have a uniform design
        {
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
                if (butt.GetType() == typeof(Button))
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

            hideAllLabels();
        }


        // ///////////////// EVERYTHING BELOW IS FOR PAGES THAT ARE PURELY INFORMATIONAL TEXT/ IMAGE SCROLLING ////////////////////// //


        private void generateLabelUnder(object _lastObject, string toText, Button nextButton, bool disableNextButton, string type = "secondary")
        {
            lastObject = _lastObject;
            Label newLabel = new labelDesign(type);
            Controls.Add(newLabel);
            newLabel.Padding = new Padding(wantedpadding);
            newLabel.Visible = false;

            if (lastObject.GetType() == typeof(Label) || lastObject.GetType() == typeof(labelDesign))
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

            newLabel.Text = toText;
            newLabel.BringToFront();
            newLabel.Refresh();
            newLabel.Tag = "generated";
            typwriterEffectClass tw = new typwriterEffectClass((Label)newLabel,nextButton,disableNextButton);
            lastObject = newLabel;

            if (newLabel.Bottom > this.Bottom - 50)
            {
                this.AutoScroll = true;
            }

            newLabel.Show();
            newLabel.BringToFront();
            nextButton.BringToFront();
        }

        private void generatePictureBoxUnder(object _lastObject, string filepath, Button nextButton, bool disableNextButton)
        {
            lastObject = _lastObject;
            PictureBox newPictureBox = new PictureBox();
            Controls.Add(newPictureBox);
            newPictureBox.Padding = new Padding(wantedpadding);

            if (lastObject.GetType() == typeof(Label) || lastObject.GetType() == typeof(labelDesign))
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

            if (newPictureBox.Bottom > this.Bottom - 50)
            {
                this.AutoScroll = true;
            }

            newPictureBox.Show();
            newPictureBox.BringToFront();
            imageSlideAnimationClass l = new imageSlideAnimationClass(newPictureBox, nextButton, disableNextButton);
            nextButton.BringToFront();
        }

        public void generateNextItem(object _lastObject, string[] type, Button nextButton)
        {
            wantedpadding = 5;

            if (type[3] == "e")
            {
                disableNextButton = true;
            }
            switch (type[0])
            {
                case ("text"):
                    var textType = "secondary";
                    switch (type[1])
                    {
                        case ("h"):
                            textType = "title";
                            break;
                        case ("s"):
                            textType = "secondary";
                            break;
                        default:
                            textType = "secondary";
                            break;
                    }
                    generateLabelUnder(lastObject, type[2], nextButton, disableNextButton, textType);
                    break;
                case ("image"):
                    var temp2 = type[1];
                    generatePictureBoxUnder(lastObject, type[2], nextButton, disableNextButton);
                    break;
                default:
                    generateLabelUnder(lastObject, "ERROR check formDesign.cs", nextButton, disableNextButton);
                    break;
            }
        }

        public void generateTitle(string _text, Button nextButton, string animationType = "typewriter") // creates a new title, should be called on load
        {
            Label title = new labelDesign("title");
            Controls.Add(title);
            title.Text = _text;
            title.Visible = true;
            lastObject = title;

            switch (animationType)
            {
                case ("none"):
                    break;
                case ("typewriter"):
                    var tw = new typwriterEffectClass(title, nextButton, disableNextButton);
                    break;
            }
        }

        public void imageSizeStandardize(Image theImage, string wantedSize = "medium")
        {
            switch (wantedSize)
            {
                case ("medium"):

                    break;
                default:
                    break;
            }
        }

        public void nextButtonClick(readFromTextClass read, Button nextButton)
        {
            switch (nextButtonCount) // for every time the next button is clicked it creates the next item in the queue
            {
                default:
                    var temp = read.getNext(linesCount); // gets next item array which gives item type, item subtype, data, last item check and pairing check
                    generateNextItem(lastObject, temp, nextButton);
                    while (temp[4] == "r") // r indicates that the next item is paired with the current item, so the next item is shown at the same time
                    {
                        linesCount++;
                        temp = read.getNext(linesCount);
                        generateNextItem(lastObject, temp, nextButton);
                    }
                    linesCount++;
                    break;
            }

            nextButtonCount = nextButtonCount + 1;
        }
    }
}
