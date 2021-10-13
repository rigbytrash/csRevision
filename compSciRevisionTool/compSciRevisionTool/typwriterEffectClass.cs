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
        Label currentLabel;
        Button nextButton;
        bool disableNextButton = false;
        public bool typwriterEffectInAction = true;
        public typwriterEffectClass(Label _currentLabel, Button _nextButton, bool _disableNextButton, int _interval = 25)
        {
            currentLabel = _currentLabel;
            typewriterEffect(currentLabel , _interval);
            nextButton = _nextButton;
            disableNextButton = _disableNextButton;
        }

        string CurrentLabelText;
        int countForTypwwriterEffect = 0;
        Timer typewriterTimer = new Timer();
        Label labelTempObj;

        public void typewriterEffect(Label currentLabel, int interval = 25)
        {
            typewriterTimer.Tick += new System.EventHandler(typewriterTimerTick); // creates a new tick event handler
            typwriterEffectInAction = true;
            typewriterTimer.Interval = interval; // speed of scroll (this can later be added as a perameter and switch case)
            typewriterTimer.Enabled = true;
            labelTempObj = (Label)currentLabel;
            CurrentLabelText = labelTempObj.Text; // save the label's text
            labelTempObj.Text = ""; // blank out the label
            labelTempObj.Show(); // show the label (it may be hidden to start with)
        }

        private void typewriterTimerTick(object sender, EventArgs e)
        {
            if (CurrentLabelText.Length != labelTempObj.Text.Length) // if the label is not what it was originally (what is wanted by the end)
            {
                labelTempObj.Text = labelTempObj.Text + CurrentLabelText[countForTypwwriterEffect]; // add on the text, one letter at a time
                countForTypwwriterEffect = countForTypwwriterEffect + 1;
                //nextButton.Hide(); // hide the button to prevent error
            }

            if (CurrentLabelText.Length == labelTempObj.Text.Length) // stop the timer if the label animation is now complete
            {
                if (!disableNextButton) // does not show the next button if this is the last item in the list
                {
                    //nextButton.Show();
                }
                typewriterTimer.Stop();
                typwriterEffectInAction = false;
            }
        }

    }
}
