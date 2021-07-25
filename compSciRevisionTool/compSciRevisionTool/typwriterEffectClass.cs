using FontAwesome.Sharp;
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
    class typwriterEffectClass // currently when creating an instance of this class, you will have to hide the label first (on load): otherwise the text will be visible before the animation
    {
        string CurrentLabelText;
        int countForTypwwriterEffect = 0;
        Timer typewriterTimer = new Timer();
        bool typwriterEffectInAction = false;
        Label labelTempObj;

        public void typewriterEffect(object currentLabel)
        {
            typewriterTimer.Tick += new System.EventHandler(typewriterTimerTick); // creates a new tick event handler
            typwriterEffectInAction = true;
            typewriterTimer.Interval = 25; // speed of scroll (this can later be added as a perameter and switch case)
            typewriterTimer.Enabled = true;

            if (currentLabel.GetType() == typeof(Label)) // setting the label as a local object
            {
                labelTempObj = (Label)currentLabel;
            }
            CurrentLabelText = labelTempObj.Text; // save the label's text
            labelTempObj.Text = ""; // blank out the label
            labelTempObj.Show(); // show the label (it may be hidden to start with)
        }

        private void typewriterTimerTick(object sender, EventArgs e)
        {
            if (CurrentLabelText != labelTempObj.Text) // if the label is not what it was originally (what is wanted by the end)
            {
                labelTempObj.Text = labelTempObj.Text + CurrentLabelText[countForTypwwriterEffect]; // add om the text, one letter at a time
                countForTypwwriterEffect = countForTypwwriterEffect + 1;     
            }

            if (CurrentLabelText == labelTempObj.Text) // stop the timer if the label animation is now complete
            {
                typwriterEffectInAction = false;
                typewriterTimer.Stop();
            }
        }

    }
}
