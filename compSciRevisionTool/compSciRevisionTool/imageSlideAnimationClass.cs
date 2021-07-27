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
        bool disableNextButton = false;
        public imageSlideAnimationClass(PictureBox _currentPictureBox, Button _nextButton, bool _disableNextButton)
        {
            currentPictureBox = _currentPictureBox;
            slideEffect(currentPictureBox);
            nextButton = _nextButton;
            disableNextButton = _disableNextButton;
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

            if (currentPictureBox.GetType() == typeof(PictureBox)) // setting the picturebox as a local object
            {
                PicBoxTempObj = (PictureBox)currentPictureBox;
            }
            currentImageWidth = PicBoxTempObj.Image.Width; // save the image's width
            PicBoxTempObj.Width = 0; // makes the image infinitely thin
            PicBoxTempObj.Show(); // show the picturebox (it may be hidden to start with)
        }

        private void slideTimerTick(object sender, EventArgs e)
        {
            if (currentImageWidth != PicBoxTempObj.Width) // if the pciturebox is not the width of the image then keep increasing the width
            {
                PicBoxTempObj.Width = PicBoxTempObj.Width + 10;
                //countForSlideEffect = countForSlideEffect + 1;
                nextButton.Hide(); // hide the button to prevent error
            }

            if (currentImageWidth == PicBoxTempObj.Width) // stop the timer if the label animation is now complete
            {
                slideInEffect = false;
                slideTimer.Stop();
                if (!disableNextButton) // does not show the next button if this is the last item in the list
                {
                    nextButton.Show();
                }
            }
        }

    }
}
