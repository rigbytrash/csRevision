using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace compSciRevisionTool
{
    public class readFromTextClass
    {
        string theText;
        public List<string> lines = new List<string>();

        public readFromTextClass(string _text)
        {
            theText = _text;
            getText();
        }

        public void getText()
        {
            List<string> words = theText.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList(); // grabs all the lines from the text file and separates them their lines
            foreach (var line in words) lines.Add(line);
        }

        public string getLine(int index)
        {
            return (lines[index].Remove(0, 6)); // removes the medadata and just returns the data wanted
        }

        public string[] getNext(int index) // gets the next item from the list
        {                                       // [0] = item type  [1] = item subtype  [2] = actual item (string possibly filepath)
            string[] tempArray = new string[5]; // [3] = check if last item             [4] = check if next item and current are joint toghther
            tempArray[4] = "n";
            tempArray[3] = "p";

            if (index == lines.Count - 1) // if at the end of the list
            {
                tempArray[3] = "e"; // set the fourth element as "e", this will cause the next button to disapear for the user
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
                if (getTag(index)[0] == getTag(index + 1)[0]) // if this line and the next are paired toghether
                {
                    tempArray[4] = "r"; // set tag 4 to r to indicated "paired with next item"
                    if (index + 1 == lines.Count - 1) // if the next line that will be printed at the same time is also the last line, change tag 3 to "e" to show its the end
                    {
                        tempArray[3] = "e";
                    }
                }
            }

            return (tempArray);
        }

        private string[] getTag(int index) // [0] = 3 dig. identifier   [1] = item type letter  [2] = item subtype letter
        { // gets all the metadata tags from each line and returns them
            string[] tempArray = new string[3];
            tempArray[0] = lines[index][0].ToString() + lines[index][1].ToString() + lines[index][2].ToString(); // the three digit number
            tempArray[1] = lines[index][4].ToString(); // the type indicator (i = image, etc)
            tempArray[2] = lines[index][5].ToString(); // the subtype indicator (th = text, heading - this only holds the h)
            return tempArray;
        }
    }
}
