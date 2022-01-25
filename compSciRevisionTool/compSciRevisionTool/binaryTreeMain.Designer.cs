
namespace compSciRevisionTool
{
    partial class binaryTreeMain
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
            this.mainPanelForQ = new System.Windows.Forms.Panel();
            this.genButton = new System.Windows.Forms.Button();
            this.mainPanelForQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelForQ
            // 
            this.mainPanelForQ.Controls.Add(this.genButton);
            this.mainPanelForQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelForQ.Location = new System.Drawing.Point(0, 0);
            this.mainPanelForQ.Name = "mainPanelForQ";
            this.mainPanelForQ.Size = new System.Drawing.Size(1013, 535);
            this.mainPanelForQ.TabIndex = 0;
            this.mainPanelForQ.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanelForQ_Paint);
            // 
            // genButton
            // 
            this.genButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genButton.Location = new System.Drawing.Point(836, 477);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(156, 46);
            this.genButton.TabIndex = 0;
            this.genButton.Text = "Generate";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // binaryTreeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 535);
            this.Controls.Add(this.mainPanelForQ);
            this.Name = "binaryTreeMain";
            this.Text = "binaryTreeMain";
            this.mainPanelForQ.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelForQ;
        private System.Windows.Forms.Button genButton;
    }
}