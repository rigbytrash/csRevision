
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonGenerateQuestion = new System.Windows.Forms.Button();
            this.buttonSubmitAnswer = new System.Windows.Forms.Button();
            this.answerBox1 = new System.Windows.Forms.TextBox();
            this.testLabel1 = new System.Windows.Forms.Label();
            this.testLabel2 = new System.Windows.Forms.Label();
            this.answerBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(263, 146);
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
            this.labelQuesExplain.Location = new System.Drawing.Point(263, 93);
            this.labelQuesExplain.Name = "labelQuesExplain";
            this.labelQuesExplain.Size = new System.Drawing.Size(561, 38);
            this.labelQuesExplain.TabIndex = 15;
            this.labelQuesExplain.Text = "Use merge sort to sort the following:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Difficulty:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // buttonGenerateQuestion
            // 
            this.buttonGenerateQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonGenerateQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateQuestion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateQuestion.Location = new System.Drawing.Point(12, 54);
            this.buttonGenerateQuestion.Name = "buttonGenerateQuestion";
            this.buttonGenerateQuestion.Size = new System.Drawing.Size(137, 35);
            this.buttonGenerateQuestion.TabIndex = 10;
            this.buttonGenerateQuestion.Text = "Generate";
            this.buttonGenerateQuestion.UseVisualStyleBackColor = false;
            this.buttonGenerateQuestion.Click += new System.EventHandler(this.buttonGenerateQuestion_Click);
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
            this.buttonSubmitAnswer.TabIndex = 9;
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
            this.answerBox1.TabIndex = 8;
            // 
            // testLabel1
            // 
            this.testLabel1.AutoSize = true;
            this.testLabel1.Location = new System.Drawing.Point(717, 260);
            this.testLabel1.Name = "testLabel1";
            this.testLabel1.Size = new System.Drawing.Size(56, 13);
            this.testLabel1.TabIndex = 16;
            this.testLabel1.Text = "testLabel1";
            this.testLabel1.UseMnemonic = false;
            // 
            // testLabel2
            // 
            this.testLabel2.AutoSize = true;
            this.testLabel2.Location = new System.Drawing.Point(801, 260);
            this.testLabel2.Name = "testLabel2";
            this.testLabel2.Size = new System.Drawing.Size(56, 13);
            this.testLabel2.TabIndex = 17;
            this.testLabel2.Text = "testLabel2";
            this.testLabel2.UseMnemonic = false;
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
            this.answerBox2.TabIndex = 18;
            // 
            // QMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.answerBox2);
            this.Controls.Add(this.testLabel2);
            this.Controls.Add(this.testLabel1);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelQuesExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonGenerateQuestion);
            this.Controls.Add(this.buttonSubmitAnswer);
            this.Controls.Add(this.answerBox1);
            this.Name = "QMerge";
            this.Load += new System.EventHandler(this.QMerge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelQuesExplain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonGenerateQuestion;
        private System.Windows.Forms.Button buttonSubmitAnswer;
        private System.Windows.Forms.TextBox answerBox1;
        private System.Windows.Forms.Label testLabel1;
        private System.Windows.Forms.Label testLabel2;
        private System.Windows.Forms.TextBox answerBox2;
    }
}
