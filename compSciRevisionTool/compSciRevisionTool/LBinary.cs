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
    public partial class LBinary : formDesignForInformationForms
    {
        public LBinary(string _colPassed)
        {
            InitializeComponent();
            setDesign(_colPassed);
        }

        private void LBinary_Load(object sender, EventArgs e)
        {
            setVid();
            webBrowser1.Hide();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Show();
        }

        private void setVid()
        {
            string txtLink = "https://www.youtube.com/watch?v=L8OYx1I8qNg";
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='1013' height='535' frameborder='0' allowfullscreen></iframe>";
            html += "</body></html>";
            this.webBrowser1.DocumentText = string.Format(html, txtLink.Split('=')[1]);
        }

        private void changedVisiblity(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                webBrowser1.Navigate("about:blank");
            }
            else
            {
                webBrowser1.Hide();
                setVid();
            }
        }
    }
}
