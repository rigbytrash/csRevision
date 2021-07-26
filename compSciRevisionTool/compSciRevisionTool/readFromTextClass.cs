using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    class readFromTextClass
    {
        string filepath;
        public readFromTextClass(string _filepath)
        {
            filepath = _filepath;
        }

        
        public List<string> lines = new List<string>();
        public void getText()
        {

            StreamReader sr = new StreamReader(filepath);
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
        }

        public string getLine(int index)
        {
            return (lines[index]);
        }

        public void setLabelDesign(Label theLabel, int index, string animationType)
        {
            getText();
            Label ourLabel = (Label)theLabel;
            ourLabel.MaximumSize = new Size(600, 0);
            ourLabel.AutoSize = true;
            setLabelText(ourLabel, index);
            switch (animationType)
            {
                case ("none"):
                    break;
                case ("typewriter"):
                    var tw = new typwriterEffectClass(ourLabel);
                    //tw.typewriterEffect(ourLabel);
                    break;
            }
        }

        public void setLabelText(Label theLabel, int index)
        {
            theLabel.Text = getLine(index);
        }
    }
}
