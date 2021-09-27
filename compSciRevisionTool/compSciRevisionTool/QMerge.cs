using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class QMerge : compSciRevisionTool.formDesign
    {
        public QMerge()
        {
            InitializeComponent();
        }

        private void QMerge_Load(object sender, EventArgs e)
        {
            generateQmerge();
        }

        private void generateQmerge()
        {
            int[] numbersToCreateFrom = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rnd = new Random();
            List<string> finalString = new List<string>();

            for (int i = 0; i < 9; i = i + 1)
            {
                int randomNumber = rnd.Next(0, 9);
                finalString.Add(numbersToCreateFrom[randomNumber].ToString());
                MessageBox.Show(finalString[i]);
            }
        }
    }
}
