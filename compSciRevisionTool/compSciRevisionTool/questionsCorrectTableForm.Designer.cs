
namespace compSciRevisionTool
{
    partial class questionsCorrectTableForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.goNextButton = new System.Windows.Forms.Button();
            this.topicHeader = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.goNextButton);
            this.panel1.Controls.Add(this.topicHeader);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(10000, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 50);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // goNextButton
            // 
            this.goNextButton.FlatAppearance.BorderSize = 0;
            this.goNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goNextButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goNextButton.Location = new System.Drawing.Point(149, 23);
            this.goNextButton.Name = "goNextButton";
            this.goNextButton.Size = new System.Drawing.Size(84, 23);
            this.goNextButton.TabIndex = 2;
            this.goNextButton.Text = "Go Next";
            this.goNextButton.UseVisualStyleBackColor = true;
            this.goNextButton.Click += new System.EventHandler(this.goNextButton_Click);
            // 
            // topicHeader
            // 
            this.topicHeader.AutoSize = true;
            this.topicHeader.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicHeader.Location = new System.Drawing.Point(4, 4);
            this.topicHeader.Name = "topicHeader";
            this.topicHeader.Size = new System.Drawing.Size(48, 18);
            this.topicHeader.TabIndex = 1;
            this.topicHeader.Text = "Topic";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 50);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1017, 489);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.VisibleChanged += new System.EventHandler(this.changedVisibilty);
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(582, 29);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(432, 18);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "thenameoftheuser";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // questionsCorrectTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 539);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "questionsCorrectTableForm";
            this.Text = "questionsCorrectTableForm";
            this.Load += new System.EventHandler(this.questionsCorrectTableForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label topicHeader;
        private System.Windows.Forms.Button goNextButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label usernameLabel;
    }
}