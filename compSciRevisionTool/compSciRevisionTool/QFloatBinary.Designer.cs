namespace compSciRevisionTool
{
    partial class QFloatBinary
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
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelQuestion.Location = new System.Drawing.Point(263, 177);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(138, 39);
            this.labelQuestion.TabIndex = 22;
            this.labelQuestion.Text = "[/////////]";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelQuesExplain
            // 
            this.labelQuesExplain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuesExplain.AutoSize = true;
            this.labelQuesExplain.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuesExplain.Location = new System.Drawing.Point(263, 49);
            this.labelQuesExplain.Name = "labelQuesExplain";
            this.labelQuesExplain.Size = new System.Drawing.Size(624, 114);
            this.labelQuesExplain.TabIndex = 23;
            this.labelQuesExplain.Text = "Calculate the denary equivalent of the \r\nfollowing floating point representation\r" +
    "\nof a number:";
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
            this.buttonSubmitAnswer.TabIndex = 21;
            this.buttonSubmitAnswer.Text = "Submit";
            this.buttonSubmitAnswer.UseVisualStyleBackColor = false;
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
            this.answerBox1.TabIndex = 20;
            // 
            // QFloatBinary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelQuesExplain);
            this.Controls.Add(this.buttonSubmitAnswer);
            this.Controls.Add(this.answerBox1);
            this.Name = "QFloatBinary";
            this.Text = "QFloatBinary";
            this.Load += new System.EventHandler(this.QFloatBinary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelQuesExplain;
        private System.Windows.Forms.Button buttonSubmitAnswer;
        private System.Windows.Forms.TextBox answerBox1;
    }
}