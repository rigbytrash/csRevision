﻿
namespace compSciRevisionTool
{
    partial class QMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelQuesExplain = new System.Windows.Forms.Label();
            this.buttonSubmitAnswer = new System.Windows.Forms.Button();
            this.answerBox1 = new System.Windows.Forms.TextBox();
            this.answerBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theProgressBar
            // 
            this.theProgressBar.Location = new System.Drawing.Point(0, 512);
            this.theProgressBar.Size = new System.Drawing.Size(1013, 23);
            this.theProgressBar.Value = 60;
            // 
            // diffLabel2
            // 
            this.diffLabel2.Size = new System.Drawing.Size(144, 25);
            this.diffLabel2.Text = "Difficulty: 1/3";
            // 
            // conseqLabel
            // 
            this.conseqLabel.Size = new System.Drawing.Size(363, 25);
            this.conseqLabel.Text = "Consecutive questions correct: 3/5";
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelQuestion.Location = new System.Drawing.Point(263, 102);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(138, 39);
            this.labelQuestion.TabIndex = 11;
            this.labelQuestion.Text = "[/////////]";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelQuesExplain
            // 
            this.labelQuesExplain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuesExplain.AutoSize = true;
            this.labelQuesExplain.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuesExplain.Location = new System.Drawing.Point(263, 54);
            this.labelQuesExplain.Name = "labelQuesExplain";
            this.labelQuesExplain.Size = new System.Drawing.Size(561, 38);
            this.labelQuesExplain.TabIndex = 15;
            this.labelQuesExplain.Text = "Use merge sort to sort the following:";
            // 
            // buttonSubmitAnswer
            // 
            this.buttonSubmitAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSubmitAnswer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSubmitAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonSubmitAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitAnswer.Location = new System.Drawing.Point(270, 280);
            this.buttonSubmitAnswer.Name = "buttonSubmitAnswer";
            this.buttonSubmitAnswer.Size = new System.Drawing.Size(137, 35);
            this.buttonSubmitAnswer.TabIndex = 3;
            this.buttonSubmitAnswer.Text = "Submit";
            this.buttonSubmitAnswer.UseVisualStyleBackColor = false;
            this.buttonSubmitAnswer.Click += new System.EventHandler(this.buttonSubmitAnswer_Click);
            // 
            // answerBox1
            // 
            this.answerBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.answerBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.answerBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerBox1.Location = new System.Drawing.Point(270, 239);
            this.answerBox1.Name = "answerBox1";
            this.answerBox1.Size = new System.Drawing.Size(158, 35);
            this.answerBox1.TabIndex = 0;
            this.answerBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.firstAnswerBoxKeyDown);
            // 
            // answerBox2
            // 
            this.answerBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.answerBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.answerBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerBox2.Location = new System.Drawing.Point(434, 239);
            this.answerBox2.Name = "answerBox2";
            this.answerBox2.Size = new System.Drawing.Size(158, 35);
            this.answerBox2.TabIndex = 1;
            this.answerBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondAnswerBoxKeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(605, 72);
            this.label2.TabIndex = 19;
            this.label2.Text = "and give the left and right array during the\r\nsecond to last step";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // QMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answerBox2);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelQuesExplain);
            this.Controls.Add(this.buttonSubmitAnswer);
            this.Controls.Add(this.answerBox1);
            this.Name = "QMerge";
            this.Load += new System.EventHandler(this.QMerge_Load);
            this.Controls.SetChildIndex(this.conseqLabel, 0);
            this.Controls.SetChildIndex(this.answerBox1, 0);
            this.Controls.SetChildIndex(this.buttonSubmitAnswer, 0);
            this.Controls.SetChildIndex(this.labelQuesExplain, 0);
            this.Controls.SetChildIndex(this.labelQuestion, 0);
            this.Controls.SetChildIndex(this.answerBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.diffLabel2, 0);
            this.Controls.SetChildIndex(this.theProgressBar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelQuesExplain;
        private System.Windows.Forms.Button buttonSubmitAnswer;
        private System.Windows.Forms.TextBox answerBox1;
        private System.Windows.Forms.TextBox answerBox2;
        private System.Windows.Forms.Label label2;
    }
}
