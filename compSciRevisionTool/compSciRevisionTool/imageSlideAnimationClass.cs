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
    class imageSlideAnimationClass
    {
        PictureBox currentPictureBox;
        Button nextButton;
        public imageSlideAnimationClass(PictureBox _currentPictureBox, Button _nextButton)
        {
            currentPictureBox = _currentPictureBox;
            slideEffect(currentPictureBox);
            nextButton = _nextButton;
        }

        int currentImageWidth;
        int countForSlideEffect = 0;
        Timer slideTimer = new Timer();
        bool slideInEffect = false;
        PictureBox PicBoxTempObj;

        public void slideEffect(PictureBox currentPictureBox)
        {
            slideTimer.Tick += new System.EventHandler(slideTimerTick); // creates a new tick event handler
            slideInEffect = true;
            slideTimer.Interval = 5; // speed of scroll (this can later be added as a perameter and switch case)
            slideTimer.Enabled = true;

            if (currentPictureBox.GetType() == typeof(PictureBox)) // setting the label as a local object
            {
                PicBoxTempObj = (PictureBox)currentPictureBox;
            }
            currentImageWidth = PicBoxTempObj.Image.Width; // save the label's text
            PicBoxTempObj.Width = 0; // blank out the label
            PicBoxTempObj.Show(); // show the label (it may be hidden to start with)
        }

        private void slideTimerTick(object sender, EventArgs e)
        {
            if (currentImageWidth != PicBoxTempObj.Width) // if the label is not what it was originally (what is wanted by the end)
            {
                PicBoxTempObj.Width = PicBoxTempObj.Width + 10;
                //countForSlideEffect = countForSlideEffect + 1;
                nextButton.Hide();
            }

            if (currentImageWidth == PicBoxTempObj.Width) // stop the timer if the label animation is now complete
            {
                slideInEffect = false;
                slideTimer.Stop();
                nextButton.Show();
            }
        }

    }
}
