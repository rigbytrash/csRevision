using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compSciRevisionTool
{
    class programColoursClass
    {
        private static List<string> colourListNames = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" }; // the names of the colours in the colourList
        private static List<string> colourList = new List<string>() { "#051433", "#0ABAB5", "#A3C1AD", "#6395EC", "#4766FF", "#191971", "#281E5D", "#0E4D94" }; // a list of colours that can be used throughout the program




        public static Color getcolour(string colourName) // will return the color value of the colour name specified
        {
            for (int i = 0; i < colourListNames.Count(); i = i + 1)
            {
                if (colourName == colourListNames[i]) // if the colour they ask for is in the list
                {
                    return (ColorTranslator.FromHtml(colourList[i])); // return the corresponding color value
                }
            }
            return (Color.OrangeRed); // if their value is not found, then return orange red
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor) // correctionFactor must be between -1 & 1
        {                                                                              // neg. values return darker colors       
            float red = (float)color.R;                                                // this sub will darken/lighen any color value             
            float green = (float)color.G; //speperating out rgb values
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }
}

