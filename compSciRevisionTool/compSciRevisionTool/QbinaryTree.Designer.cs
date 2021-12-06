
namespace compSciRevisionTool
{
    partial class QbinaryTree
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
            this.bgPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // theProgressBar
            // 
            this.theProgressBar.Location = new System.Drawing.Point(0, 278);
            this.theProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.theProgressBar.Size = new System.Drawing.Size(533, 15);
            this.theProgressBar.Value = 100;
            // 
            // diffLabel2
            // 
            this.diffLabel2.Location = new System.Drawing.Point(8, 338);
            this.diffLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.diffLabel2.MaximumSize = new System.Drawing.Size(600, 0);
            this.diffLabel2.Size = new System.Drawing.Size(144, 25);
            this.diffLabel2.Text = "Difficulty: 3/3";
            // 
            // conseqLabel
            // 
            this.conseqLabel.Location = new System.Drawing.Point(8, 318);
            this.conseqLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.conseqLabel.MaximumSize = new System.Drawing.Size(600, 0);
            this.conseqLabel.Size = new System.Drawing.Size(363, 25);
            this.conseqLabel.Text = "Consecutive questions correct: 5/5";
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.label4);
            this.bgPanel.Controls.Add(this.label5);
            this.bgPanel.Controls.Add(this.label6);
            this.bgPanel.Controls.Add(this.label3);
            this.bgPanel.Controls.Add(this.label2);
            this.bgPanel.Controls.Add(this.label1);
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(1013, 535);
            this.bgPanel.TabIndex = 3;
            this.bgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bgPanel_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(230, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 32);
            this.label6.TabIndex = 3;
            this.label6.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // QbinaryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.bgPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QbinaryTree";
            this.Text = "QbinaryTree";
            this.Load += new System.EventHandler(this.QbinaryTree_Load);
            this.Controls.SetChildIndex(this.conseqLabel, 0);
            this.Controls.SetChildIndex(this.diffLabel2, 0);
            this.Controls.SetChildIndex(this.theProgressBar, 0);
            this.Controls.SetChildIndex(this.bgPanel, 0);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}