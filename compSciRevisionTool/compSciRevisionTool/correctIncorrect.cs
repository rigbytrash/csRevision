using compSciRevisionTool.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public correctIncorrect(bool _correct)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            correct = _correct;
            var destroyTimer = new Timer();
            destroyTimer.Interval = 5000;
            destroyTimer.Tick += destroyTimerTick;
            pictureBox1.Image = Resources.iconDes;
            pictureBox1.Image = selectImage(pictureBox1, correct);
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.Size = pictureBox1.Image.Size;
            this.Size = pictureBox1.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            destroyTimer.Start();
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
