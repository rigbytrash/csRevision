﻿using System;
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
    public partial class LRpn2 : formDesignForInformationForms
    {
        private string colPassed;
        readFromTextClass rfrc;

        public LRpn2(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            rfrc = new readFromTextClass(compSciRevisionTool.LRPNresources.text2);
        }

        private void LRpn2_Load(object sender, EventArgs e)
        {
            setDesign(colPassed);
            generateTitle(rfrc.getLine(linesCount), nextButton);
            linesCount++;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            nextButtonClick(rfrc, nextButton);
        }
    }
}
