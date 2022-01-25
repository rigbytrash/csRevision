using compSciRevisionTool.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class correctIncorrect : Form
    {
        private bool correct;
        int timeNeeded;

        public correctIncorrect(bool _correct)
        {
            InitializeComponent();
            timeNeeded = 2000; // this is how ling the form should exist for (time to live)
            this.ShowInTaskbar = false;
            correct = _correct;
            pictureBox1.Image = correctGIFs._1; // defualt image - in case of image getting error
            pictureBox1.Image = selectImage(pictureBox1, correct);
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.Size = pictureBox1.Image.Size;
            this.Size = pictureBox1.Size; // sets the size of the form to the size of the picture box in order to fit different image sizes
            this.StartPosition = FormStartPosition.CenterScreen;

            var destroyTimer = new Timer();
            destroyTimer.Interval = timeNeeded;
            destroyTimer.Tick += destroyTimerTick;
            destroyTimer.Start();

            this.Show();
        }

        private void correctIncorrect_Load(object sender, EventArgs e)
        {
            
        }

        private Image selectImage(PictureBox thePicturebox, bool correct) // grabs the correct image by random chance
        {
            if (correct)
            {
                var tempResourceManager = correctGIFs.ResourceManager;
                Random rNum = new Random();
                var i = rNum.Next(1, 7);
                var image = (Bitmap)tempResourceManager.GetObject(i.ToString());
                return image;
            }
            else
            {
                var tempResourceManager = incorrectGIFs.ResourceManager; 
                Random rNum = new Random();
                var i = rNum.Next(1, 7);
                var image = (Bitmap)tempResourceManager.GetObject(i.ToString());
                return image;
            }
        }

        private void destroyTimerTick(object sender, EventArgs e)
        {
            var sendingTimer = (Timer)sender;

            sendingTimer.Dispose(); //disposed to clear it from the memory as it not needed
            this.Dispose();
        }
    }
}
