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
        Control nextButton;
        public readFromTextClass(string _filepath)
        {
            filepath = _filepath;
            getText();
        }

        
        public List<string> lines = new List<string>();
        public void getText()
        {

            StreamReader sr = new StreamReader(filepath);
            using (StreamReader reader = new StreamReader(filepath)) // reads the entire document and saves it to a list
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
        }

        public string getLine(int index)
        {
            return (lines[index].Remove(0, 6)); // removes the medadata and just returns the data wanted
        }

        //public void setLabelDesign(Label theLabel, int index, string animationType,Button nextButton, bool disableNextButon)
        //{
        //    getText();
        //    Label ourLabel = theLabel;
        //    ourLabel.Text = theLabel.Text;
        //    ourLabel.MaximumSize = new Size(900, 0);
        //    ourLabel.AutoSize = true;
        //    var temp = getLine(index);
        //    theLabel.Text = temp;
        //    switch (animationType)
        //    {
        //        case ("none"):
        //            break;
        //        case ("typewriter"):
        //            var tw = new typwriterEffectClass(ourLabel,nextButton, disableNextButon);
        //            //tw.typewriterEffect(ourLabel);
        //            break;
        //    }
        //}


        public string[] getNext(int index) // gets the next item from the list
        {                                       // [0] = item type  [1] = item subtype  [2] = actual item (string possibly filepath)
            string[] tempArray = new string[5]; // [3] = check if last item             [4] = check if next item and current are joint toghther
            tempArray[4] = "n";
            tempArray[3] = "p";
            if (index == lines.Count - 1) // if at the end of the list
            {
                tempArray[3] = "e"; // set the fourth element as "e", this will cause the next button is disapear for the user
            }

            switch (getTag(index)[1])
            {
                case ("t"):
                    tempArray[0] = "text";
                    tempArray[1] = getTag(index)[2];
                    tempArray[2] = getLine(index);
                    break;
                case ("i"):
                    tempArray[0] = "image";
                    tempArray[1] = getTag(index)[2];
                    tempArray[2] = getLine(index);
                    break;
                default:
                    tempArray[0] = "text";
                    tempArray[1] = "ERROR - check readFromTextClass class";
                    break;
            }
            if (index < lines.Count() - 1)
            {
                if (getTag(index)[0] == getTag(index + 1)[0])
                {
                    tempArray[4] = "r";
                    if (index + 1 == lines.Count - 1)
                    {
                        tempArray[3] = "e";
                    }
                }
            }
            return (tempArray);
        }

        private string[] getTag(int index) // [0] = 3 dig. identifier   [1] = item type letter  [2] = item subtype letter
        {
            string[] tempArray = new string[3];
            tempArray[0] = lines[index][0].ToString() + lines[index][1].ToString() + lines[index][2].ToString(); // the three digit number
            tempArray[1] = lines[index][4].ToString(); // the type indicator (i = image, etc)
            tempArray[2] = lines[index][5].ToString(); // the subtype indicator (th = text, heading - this only holds the h)
            return tempArray;
        }
    }
}
