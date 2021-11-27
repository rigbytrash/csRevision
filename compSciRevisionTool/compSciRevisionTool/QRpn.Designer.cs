namespace compSciRevisionTool
{
    partial class QRpn
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // theProgressBar
            // 
            this.theProgressBar.Location = new System.Drawing.Point(0, 512);
            this.theProgressBar.Size = new System.Drawing.Size(1013, 23);
            // 
            // diffLabel2
            // 
            this.diffLabel2.Size = new System.Drawing.Size(144, 25);
            this.diffLabel2.Text = "Difficulty: 1/3";
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(263, 148);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(138, 39);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "[/////////]";
            // 
            // labelQuesExplain
            // 
            this.labelQuesExplain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuesExplain.AutoSize = true;
            this.labelQuesExplain.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuesExplain.Location = new System.Drawing.Point(263, 95);
            this.labelQuesExplain.Name = "labelQuesExplain";
            this.labelQuesExplain.Size = new System.Drawing.Size(609, 38);
            this.labelQuesExplain.TabIndex = 7;
            this.labelQuesExplain.Text = "Evaluate the following RPN expression:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Difficulty:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // buttonGenerateQuestion
            // 
            this.buttonGenerateQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonGenerateQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateQuestion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateQuestion.Location = new System.Drawing.Point(12, 56);
            this.buttonGenerateQuestion.Name = "buttonGenerateQuestion";
            this.buttonGenerateQuestion.Size = new System.Drawing.Size(137, 35);
            this.buttonGenerateQuestion.TabIndex = 2;
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
            this.buttonSubmitAnswer.Location = new System.Drawing.Point(270, 282);
            this.buttonSubmitAnswer.Name = "buttonSubmitAnswer";
            this.buttonSubmitAnswer.Size = new System.Drawing.Size(137, 35);
            this.buttonSubmitAnswer.TabIndex = 1;
            this.buttonSubmitAnswer.Text = "Submit";
            this.buttonSubmitAnswer.UseVisualStyleBackColor = false;
            this.buttonSubmitAnswer.Click += new System.EventHandler(this.buttonSubmitAnswer_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(270, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 35);
            this.textBox1.TabIndex = 0;
            // 
            // QRpn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelQuesExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonGenerateQuestion);
            this.Controls.Add(this.buttonSubmitAnswer);
            this.Controls.Add(this.textBox1);
            this.Name = "QRpn";
            this.Text = "";
            this.Load += new System.EventHandler(this.QRpn_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.buttonSubmitAnswer, 0);
            this.Controls.SetChildIndex(this.buttonGenerateQuestion, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.labelQuesExplain, 0);
            this.Controls.SetChildIndex(this.labelQuestion, 0);
            this.Controls.SetChildIndex(this.diffLabel2, 0);
            this.Controls.SetChildIndex(this.theProgressBar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSubmitAnswer;
        private System.Windows.Forms.Button buttonGenerateQuestion;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelQuesExplain;
        private System.Windows.Forms.Label labelQuestion;
    }
}