﻿namespace compSciRevisionTool
{
    partial class RegForm
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
            this.regBtn = new FontAwesome.Sharp.IconButton();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.loginIcnBtn = new FontAwesome.Sharp.IconButton();
            this.usernameInputBox = new System.Windows.Forms.TextBox();
            this.passwordInputBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // regBtn
            // 
            this.regBtn.BackColor = System.Drawing.Color.DarkSalmon;
            this.regBtn.FlatAppearance.BorderSize = 0;
            this.regBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.regBtn.IconColor = System.Drawing.Color.Black;
            this.regBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.regBtn.Location = new System.Drawing.Point(140, 233);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(76, 34);
            this.regBtn.TabIndex = 20;
            this.regBtn.Text = "register";
            this.regBtn.UseVisualStyleBackColor = false;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // labelPass
            // 
            this.labelPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(67, 172);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(113, 25);
            this.labelPass.TabIndex = 19;
            this.labelPass.Text = "Password:";
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(67, 113);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(121, 25);
            this.labelUser.TabIndex = 17;
            this.labelUser.Text = "Username:";
            // 
            // loginIcnBtn
            // 
            this.loginIcnBtn.BackColor = System.Drawing.Color.DarkSalmon;
            this.loginIcnBtn.FlatAppearance.BorderSize = 0;
            this.loginIcnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginIcnBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginIcnBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.loginIcnBtn.IconColor = System.Drawing.Color.Black;
            this.loginIcnBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loginIcnBtn.Location = new System.Drawing.Point(72, 233);
            this.loginIcnBtn.Name = "loginIcnBtn";
            this.loginIcnBtn.Size = new System.Drawing.Size(62, 34);
            this.loginIcnBtn.TabIndex = 15;
            this.loginIcnBtn.Text = "< login";
            this.loginIcnBtn.UseVisualStyleBackColor = false;
            this.loginIcnBtn.Click += new System.EventHandler(this.loginIcnBtn_Click);
            // 
            // usernameInputBox
            // 
            this.usernameInputBox.BackColor = System.Drawing.Color.IndianRed;
            this.usernameInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameInputBox.Location = new System.Drawing.Point(72, 141);
            this.usernameInputBox.Name = "usernameInputBox";
            this.usernameInputBox.Size = new System.Drawing.Size(144, 28);
            this.usernameInputBox.TabIndex = 21;
            // 
            // passwordInputBox
            // 
            this.passwordInputBox.BackColor = System.Drawing.Color.IndianRed;
            this.passwordInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInputBox.Location = new System.Drawing.Point(72, 199);
            this.passwordInputBox.Name = "passwordInputBox";
            this.passwordInputBox.PasswordChar = '*';
            this.passwordInputBox.Size = new System.Drawing.Size(144, 28);
            this.passwordInputBox.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::compSciRevisionTool.Properties.Resources.iconRed;
            this.pictureBox1.ErrorImage = global::compSciRevisionTool.Properties.Resources.icon2;
            this.pictureBox1.InitialImage = global::compSciRevisionTool.Properties.Resources.iconDes;
            this.pictureBox1.Location = new System.Drawing.Point(46, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(484, 500);
            this.Controls.Add(this.passwordInputBox);
            this.Controls.Add(this.usernameInputBox);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.loginIcnBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegForm";
            this.Text = "RegForm";
            this.Load += new System.EventHandler(this.RegForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton regBtn;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelUser;
        private FontAwesome.Sharp.IconButton loginIcnBtn;
        private System.Windows.Forms.TextBox usernameInputBox;
        private System.Windows.Forms.TextBox passwordInputBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}