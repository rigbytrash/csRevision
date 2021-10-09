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
            timeNeeded = 2000;
            this.ShowInTaskbar = false;
            correct = _correct;
            pictureBox1.Image = correctGIFs._1;
            pictureBox1.Image = selectImage(pictureBox1, correct);
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.Size = pictureBox1.Image.Size;
            this.Size = pictureBox1.Size;
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

        private Image selectImage(PictureBox thePicturebox, bool correct)
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
                //FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
                //int frameCount = image.GetFrameCount(dimension);
                //PropertyItem item = image.GetPropertyItem(0x5100);
                //timeNeeded = ((item.Value[0] + item.Value[1] * 256) * 10) * frameCount;
                //MessageBox.Show(timeNeeded.ToString());
                return image;
            }
        }

        private void destroyTimerTick(object sender, EventArgs e)
        {
            var sendingTimer = (Timer)sender;

            sendingTimer.Dispose();
            this.Dispose();
        }
    }
}
