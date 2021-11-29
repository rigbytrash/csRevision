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
    public partial class panelForQuesTable : UserControl
    {
        public panelForQuesTable(string subColour, string question, string userAnswer, string correctAnswer, int difficulty, int maxDifficulty, int correct)
        {
            InitializeComponent();
            answerLabel.Text = userAnswer;
            correctLabel.Text = correctAnswer;
            questionLabel.Text = question;
            difficultyLabel.Text = difficulty.ToString() + "/" + maxDifficulty.ToString();

            if (correct == 1)
            {
                this.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.4f); // sets bg colour
                xlabel.Text = "ツ";
                xlabel.ForeColor = Color.Green;
            }
            else
            {
                this.BackColor = programColoursClass.getcolour(subColour);
                xlabel.ForeColor = Color.Red;
            }
        }

        private void panelForQuesTable_Load(object sender, EventArgs e)
        {

        }
    }
}
