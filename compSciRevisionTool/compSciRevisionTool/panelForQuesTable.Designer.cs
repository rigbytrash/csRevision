﻿
namespace compSciRevisionTool
{
    partial class panelForQuesTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.quesHeader = new System.Windows.Forms.Label();
            this.ansHeader = new System.Windows.Forms.Label();
            this.correctAnsHeader = new System.Windows.Forms.Label();
            this.difficultyHeader = new System.Windows.Forms.Label();
            this.correctLabel = new System.Windows.Forms.Label();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.xlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoEllipsis = true;
            this.questionLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(314, 23);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(647, 125);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "questionLabel";
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(132, 100);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(162, 30);
            this.answerLabel.TabIndex = 1;
            this.answerLabel.Text = "answerLabel";
            // 
            // quesHeader
            // 
            this.quesHeader.AutoSize = true;
            this.quesHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quesHeader.Location = new System.Drawing.Point(315, 4);
            this.quesHeader.Name = "quesHeader";
            this.quesHeader.Size = new System.Drawing.Size(80, 19);
            this.quesHeader.TabIndex = 2;
            this.quesHeader.Text = "Question";
            // 
            // ansHeader
            // 
            this.ansHeader.AutoSize = true;
            this.ansHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansHeader.Location = new System.Drawing.Point(133, 81);
            this.ansHeader.Name = "ansHeader";
            this.ansHeader.Size = new System.Drawing.Size(103, 19);
            this.ansHeader.TabIndex = 3;
            this.ansHeader.Text = "Your Answer";
            // 
            // correctAnsHeader
            // 
            this.correctAnsHeader.AutoSize = true;
            this.correctAnsHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctAnsHeader.Location = new System.Drawing.Point(133, 4);
            this.correctAnsHeader.Name = "correctAnsHeader";
            this.correctAnsHeader.Size = new System.Drawing.Size(131, 19);
            this.correctAnsHeader.TabIndex = 7;
            this.correctAnsHeader.Text = "Correct Answer";
            // 
            // difficultyHeader
            // 
            this.difficultyHeader.AutoSize = true;
            this.difficultyHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyHeader.Location = new System.Drawing.Point(14, 81);
            this.difficultyHeader.Name = "difficultyHeader";
            this.difficultyHeader.Size = new System.Drawing.Size(79, 19);
            this.difficultyHeader.TabIndex = 6;
            this.difficultyHeader.Text = "Difficulty";
            // 
            // correctLabel
            // 
            this.correctLabel.AutoSize = true;
            this.correctLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctLabel.Location = new System.Drawing.Point(132, 23);
            this.correctLabel.Name = "correctLabel";
            this.correctLabel.Size = new System.Drawing.Size(136, 30);
            this.correctLabel.TabIndex = 5;
            this.correctLabel.Text = "cAnsLabel";
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.Location = new System.Drawing.Point(13, 100);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(86, 30);
            this.difficultyLabel.TabIndex = 4;
            this.difficultyLabel.Text = "label4";
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Font = new System.Drawing.Font("Verdana Pro Cond Black", 25F, System.Drawing.FontStyle.Bold);
            this.xlabel.ForeColor = System.Drawing.Color.Red;
            this.xlabel.Location = new System.Drawing.Point(32, 23);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(38, 41);
            this.xlabel.TabIndex = 8;
            this.xlabel.Text = "X";
            // 
            // panelForQuesTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.xlabel);
            this.Controls.Add(this.correctAnsHeader);
            this.Controls.Add(this.difficultyHeader);
            this.Controls.Add(this.correctLabel);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.ansHeader);
            this.Controls.Add(this.quesHeader);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.questionLabel);
            this.Name = "panelForQuesTable";
            this.Size = new System.Drawing.Size(990, 151);
            this.Load += new System.EventHandler(this.panelForQuesTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label quesHeader;
        private System.Windows.Forms.Label ansHeader;
        private System.Windows.Forms.Label correctAnsHeader;
        private System.Windows.Forms.Label difficultyHeader;
        private System.Windows.Forms.Label correctLabel;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Label xlabel;
    }
}
