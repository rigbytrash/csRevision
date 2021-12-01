namespace compSciRevisionTool
{
    partial class Form1
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.icBtnHistory = new FontAwesome.Sharp.IconButton();
            this.icBtnHome = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelLogo = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.buttonMinMax = new System.Windows.Forms.Button();
            this.menuCollapseIcnBtn = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(102)))));
            this.panelMenu.Controls.Add(this.icBtnHistory);
            this.panelMenu.Controls.Add(this.icBtnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.MaximumSize = new System.Drawing.Size(220, 635);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 635);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // icBtnHistory
            // 
            this.icBtnHistory.BackColor = System.Drawing.Color.Transparent;
            this.icBtnHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.icBtnHistory.FlatAppearance.BorderSize = 0;
            this.icBtnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icBtnHistory.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.icBtnHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.icBtnHistory.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.icBtnHistory.IconColor = System.Drawing.Color.White;
            this.icBtnHistory.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.icBtnHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icBtnHistory.Location = new System.Drawing.Point(0, 121);
            this.icBtnHistory.MaximumSize = new System.Drawing.Size(220, 60);
            this.icBtnHistory.MinimumSize = new System.Drawing.Size(220, 60);
            this.icBtnHistory.Name = "icBtnHistory";
            this.icBtnHistory.Padding = new System.Windows.Forms.Padding(4);
            this.icBtnHistory.Size = new System.Drawing.Size(220, 60);
            this.icBtnHistory.TabIndex = 3;
            this.icBtnHistory.TabStop = false;
            this.icBtnHistory.Text = "Test History";
            this.icBtnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icBtnHistory.UseVisualStyleBackColor = false;
            this.icBtnHistory.Click += new System.EventHandler(this.icBtnHistory_Click);
            // 
            // icBtnHome
            // 
            this.icBtnHome.BackColor = System.Drawing.Color.Transparent;
            this.icBtnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.icBtnHome.FlatAppearance.BorderSize = 0;
            this.icBtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icBtnHome.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.icBtnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.icBtnHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.icBtnHome.IconColor = System.Drawing.Color.White;
            this.icBtnHome.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.icBtnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icBtnHome.Location = new System.Drawing.Point(0, 61);
            this.icBtnHome.MaximumSize = new System.Drawing.Size(220, 60);
            this.icBtnHome.MinimumSize = new System.Drawing.Size(220, 60);
            this.icBtnHome.Name = "icBtnHome";
            this.icBtnHome.Padding = new System.Windows.Forms.Padding(4);
            this.icBtnHome.Size = new System.Drawing.Size(220, 60);
            this.icBtnHome.TabIndex = 2;
            this.icBtnHome.TabStop = false;
            this.icBtnHome.Text = " Home";
            this.icBtnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icBtnHome.UseVisualStyleBackColor = false;
            this.icBtnHome.Click += new System.EventHandler(this.icBtnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.Controls.Add(this.labelLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 61);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Tag = "logoPanel";
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.BackColor = System.Drawing.Color.Transparent;
            this.labelLogo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.Aquamarine;
            this.labelLogo.Location = new System.Drawing.Point(12, 23);
            this.labelLogo.MinimumSize = new System.Drawing.Size(190, 24);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(190, 24);
            this.labelLogo.TabIndex = 0;
            this.labelLogo.Text = "CompSci Revision";
            this.labelLogo.Click += new System.EventHandler(this.labelLogo_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelName.Location = new System.Drawing.Point(751, 34);
            this.labelName.MinimumSize = new System.Drawing.Size(190, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(278, 24);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 61);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1029, 574);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(440, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(120, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "HOME";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(998, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 37);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "x";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonExpand
            // 
            this.buttonExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExpand.FlatAppearance.BorderSize = 0;
            this.buttonExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpand.Location = new System.Drawing.Point(964, 3);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(28, 37);
            this.buttonExpand.TabIndex = 2;
            this.buttonExpand.TabStop = false;
            this.buttonExpand.Text = "□";
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Visible = false;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // buttonMinMax
            // 
            this.buttonMinMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinMax.FlatAppearance.BorderSize = 0;
            this.buttonMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinMax.Location = new System.Drawing.Point(930, 3);
            this.buttonMinMax.Name = "buttonMinMax";
            this.buttonMinMax.Size = new System.Drawing.Size(28, 37);
            this.buttonMinMax.TabIndex = 3;
            this.buttonMinMax.TabStop = false;
            this.buttonMinMax.Text = "-";
            this.buttonMinMax.UseVisualStyleBackColor = true;
            this.buttonMinMax.Click += new System.EventHandler(this.buttonMinMax_Click);
            // 
            // menuCollapseIcnBtn
            // 
            this.menuCollapseIcnBtn.FlatAppearance.BorderSize = 0;
            this.menuCollapseIcnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuCollapseIcnBtn.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.menuCollapseIcnBtn.IconColor = System.Drawing.Color.Black;
            this.menuCollapseIcnBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCollapseIcnBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.menuCollapseIcnBtn.Location = new System.Drawing.Point(3, 9);
            this.menuCollapseIcnBtn.Name = "menuCollapseIcnBtn";
            this.menuCollapseIcnBtn.Size = new System.Drawing.Size(42, 43);
            this.menuCollapseIcnBtn.TabIndex = 4;
            this.menuCollapseIcnBtn.TabStop = false;
            this.menuCollapseIcnBtn.UseVisualStyleBackColor = true;
            this.menuCollapseIcnBtn.Click += new System.EventHandler(this.menuCollapseIcnBtn_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelTitleBar.Controls.Add(this.labelName);
            this.panelTitleBar.Controls.Add(this.menuCollapseIcnBtn);
            this.panelTitleBar.Controls.Add(this.buttonMinMax);
            this.panelTitleBar.Controls.Add(this.buttonExpand);
            this.panelTitleBar.Controls.Add(this.buttonClose);
            this.panelTitleBar.Controls.Add(this.labelTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1029, 61);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            this.panelTitleBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDoubleClick);
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            this.panelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 635);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton icBtnHome;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonExpand;
        private System.Windows.Forms.Button buttonMinMax;
        private FontAwesome.Sharp.IconButton menuCollapseIcnBtn;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label labelName;
        private FontAwesome.Sharp.IconButton icBtnHistory;
    }
}

