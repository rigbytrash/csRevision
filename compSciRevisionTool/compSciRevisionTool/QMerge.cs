using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    public partial class QMerge : compSciRevisionTool.formDesign
    {
        private string colPassed = "";
        string[] answersArray;

        public QMerge(string _colPassed)
        {
            InitializeComponent();
            colPassed = _colPassed;
            setDesign(colPassed);
            labelQuestion.ForeColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(colPassed), -0.4f); // sets dynamically generated text colour
            comboBox1.Items.Add("1"); // adding difficulty opions
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("2");
            quesGen();
        }

        private void QMerge_Load(object sender, EventArgs e)
        {

        }

        

        private void buttonSubmitAnswer_Click(object sender, EventArgs e) // click for the submit button
        {
            checkAns();
        }

        private void buttonGenerateQuestion_Click(object sender, EventArgs e) // generate new question button based on the difficulty selected
        {
            quesGen();
        }

        private void testLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkAns()
        {
            if (answerBox1.Text == answersArray[1] && answerBox2.Text == answersArray[2]) // checks if the answer entered is correct
            {
                var cr = new correctIncorrect(true);
            }
            else
            {
                var cr = new correctIncorrect(false);
            }
        }

        private void quesGen()
        {
            createMergeSortQ msq = new createMergeSortQ();
            answersArray = msq.generateQmerge(Int32.Parse(comboBox1.SelectedItem.ToString()));
            labelQuestion.Text = answersArray[0];
        }

        private void secondAnswerBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
                checkAns();
            }
        }

        private void firstAnswerBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
                checkAns();
            }
        }

       

    }
}
