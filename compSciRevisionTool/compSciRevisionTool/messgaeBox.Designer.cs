﻿
namespace compSciRevisionTool
{
    partial class messgaeBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.dissmissButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dissmissButton
            // 
            this.dissmissButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dissmissButton.Location = new System.Drawing.Point(16, 43);
            this.dissmissButton.Name = "dissmissButton";
            this.dissmissButton.Size = new System.Drawing.Size(75, 23);
            this.dissmissButton.TabIndex = 1;
            this.dissmissButton.Text = "okay then";
            this.dissmissButton.UseVisualStyleBackColor = true;
            this.dissmissButton.Click += new System.EventHandler(this.dissmissButton_Click);
            // 
            // messgaeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 210);
            this.Controls.Add(this.dissmissButton);
            this.Controls.Add(this.label1);
            this.Name = "messgaeBox";
            this.Text = "messgaeBox";
            this.Load += new System.EventHandler(this.messgaeBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dissmissButton;
    }
}