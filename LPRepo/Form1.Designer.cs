namespace LPRepo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.basicAuthFlagCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createSiteInfoBookButton = new System.Windows.Forms.Button();
            this.projectIDLoadButton = new System.Windows.Forms.Button();
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pageIDListBoxSelectClearButton = new System.Windows.Forms.Button();
            this.pageIDListBoxSelectAllButton = new System.Windows.Forms.Button();
            this.doPageIDsScreenShotButton = new System.Windows.Forms.Button();
            this.doPageIDLoadFromTsvButton = new System.Windows.Forms.Button();
            this.doAsignListButton = new System.Windows.Forms.Button();
            this.doUrlTaksFormatExcelButton = new System.Windows.Forms.Button();
            this.doUrlTaksFormatTextButton = new System.Windows.Forms.Button();
            this.pageIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.debugButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.libraPlusReportFormatButton = new System.Windows.Forms.Button();
            this.openAsFolderButton = new System.Windows.Forms.Button();
            this.openAsSettingButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.createCategoryByDetailsRepotButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.basicAuthFlagCheck);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.createSiteInfoBookButton);
            this.panel1.Controls.Add(this.projectIDLoadButton);
            this.panel1.Controls.Add(this.projectIDListBox);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 166);
            this.panel1.TabIndex = 0;
            // 
            // basicAuthFlagCheck
            // 
            this.basicAuthFlagCheck.AutoSize = true;
            this.basicAuthFlagCheck.Location = new System.Drawing.Point(117, 140);
            this.basicAuthFlagCheck.Name = "basicAuthFlagCheck";
            this.basicAuthFlagCheck.Size = new System.Drawing.Size(106, 19);
            this.basicAuthFlagCheck.TabIndex = 4;
            this.basicAuthFlagCheck.Text = "Basic認証有";
            this.basicAuthFlagCheck.UseVisualStyleBackColor = true;
            this.basicAuthFlagCheck.CheckedChanged += new System.EventHandler(this.basicAuthFlagCheck_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "サイトID";
            // 
            // createSiteInfoBookButton
            // 
            this.createSiteInfoBookButton.Location = new System.Drawing.Point(42, 125);
            this.createSiteInfoBookButton.Name = "createSiteInfoBookButton";
            this.createSiteInfoBookButton.Size = new System.Drawing.Size(35, 35);
            this.createSiteInfoBookButton.TabIndex = 2;
            this.createSiteInfoBookButton.UseVisualStyleBackColor = true;
            this.createSiteInfoBookButton.Click += new System.EventHandler(this.createSiteInfoBookButton_Click);
            // 
            // projectIDLoadButton
            // 
            this.projectIDLoadButton.Location = new System.Drawing.Point(6, 125);
            this.projectIDLoadButton.Name = "projectIDLoadButton";
            this.projectIDLoadButton.Size = new System.Drawing.Size(35, 35);
            this.projectIDLoadButton.TabIndex = 1;
            this.projectIDLoadButton.UseVisualStyleBackColor = true;
            this.projectIDLoadButton.Click += new System.EventHandler(this.projectIDLoadButton_Click);
            // 
            // projectIDListBox
            // 
            this.projectIDListBox.FormattingEnabled = true;
            this.projectIDListBox.ItemHeight = 14;
            this.projectIDListBox.Location = new System.Drawing.Point(6, 17);
            this.projectIDListBox.Name = "projectIDListBox";
            this.projectIDListBox.ScrollAlwaysVisible = true;
            this.projectIDListBox.Size = new System.Drawing.Size(217, 102);
            this.projectIDListBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.createCategoryByDetailsRepotButton);
            this.panel2.Controls.Add(this.pageIDListBoxSelectClearButton);
            this.panel2.Controls.Add(this.pageIDListBoxSelectAllButton);
            this.panel2.Controls.Add(this.doPageIDsScreenShotButton);
            this.panel2.Controls.Add(this.doPageIDLoadFromTsvButton);
            this.panel2.Controls.Add(this.doAsignListButton);
            this.panel2.Controls.Add(this.doUrlTaksFormatExcelButton);
            this.panel2.Controls.Add(this.doUrlTaksFormatTextButton);
            this.panel2.Controls.Add(this.pageIDLoadButton);
            this.panel2.Controls.Add(this.pageIDListBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(255, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 168);
            this.panel2.TabIndex = 1;
            // 
            // pageIDListBoxSelectClearButton
            // 
            this.pageIDListBoxSelectClearButton.Location = new System.Drawing.Point(437, 126);
            this.pageIDListBoxSelectClearButton.Name = "pageIDListBoxSelectClearButton";
            this.pageIDListBoxSelectClearButton.Size = new System.Drawing.Size(35, 35);
            this.pageIDListBoxSelectClearButton.TabIndex = 12;
            this.pageIDListBoxSelectClearButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectClearButton.Click += new System.EventHandler(this.pageIDListBoxSelectClearButton_Click);
            // 
            // pageIDListBoxSelectAllButton
            // 
            this.pageIDListBoxSelectAllButton.Location = new System.Drawing.Point(402, 126);
            this.pageIDListBoxSelectAllButton.Name = "pageIDListBoxSelectAllButton";
            this.pageIDListBoxSelectAllButton.Size = new System.Drawing.Size(35, 35);
            this.pageIDListBoxSelectAllButton.TabIndex = 11;
            this.pageIDListBoxSelectAllButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectAllButton.Click += new System.EventHandler(this.pageIDListBoxSelectAllButton_Click);
            // 
            // doPageIDsScreenShotButton
            // 
            this.doPageIDsScreenShotButton.Location = new System.Drawing.Point(274, 127);
            this.doPageIDsScreenShotButton.Name = "doPageIDsScreenShotButton";
            this.doPageIDsScreenShotButton.Size = new System.Drawing.Size(35, 35);
            this.doPageIDsScreenShotButton.TabIndex = 10;
            this.doPageIDsScreenShotButton.UseVisualStyleBackColor = true;
            this.doPageIDsScreenShotButton.Click += new System.EventHandler(this.doPageIDsScreenShotButton_Click);
            // 
            // doPageIDLoadFromTsvButton
            // 
            this.doPageIDLoadFromTsvButton.Location = new System.Drawing.Point(50, 127);
            this.doPageIDLoadFromTsvButton.Name = "doPageIDLoadFromTsvButton";
            this.doPageIDLoadFromTsvButton.Size = new System.Drawing.Size(35, 35);
            this.doPageIDLoadFromTsvButton.TabIndex = 9;
            this.doPageIDLoadFromTsvButton.UseVisualStyleBackColor = true;
            this.doPageIDLoadFromTsvButton.Click += new System.EventHandler(this.doPageIDLoadFromTsvButton_Click);
            // 
            // doAsignListButton
            // 
            this.doAsignListButton.Location = new System.Drawing.Point(186, 127);
            this.doAsignListButton.Name = "doAsignListButton";
            this.doAsignListButton.Size = new System.Drawing.Size(35, 35);
            this.doAsignListButton.TabIndex = 8;
            this.doAsignListButton.UseVisualStyleBackColor = true;
            this.doAsignListButton.Click += new System.EventHandler(this.doAsignListButton_Click);
            // 
            // doUrlTaksFormatExcelButton
            // 
            this.doUrlTaksFormatExcelButton.Location = new System.Drawing.Point(116, 127);
            this.doUrlTaksFormatExcelButton.Name = "doUrlTaksFormatExcelButton";
            this.doUrlTaksFormatExcelButton.Size = new System.Drawing.Size(35, 35);
            this.doUrlTaksFormatExcelButton.TabIndex = 7;
            this.doUrlTaksFormatExcelButton.UseVisualStyleBackColor = true;
            this.doUrlTaksFormatExcelButton.Click += new System.EventHandler(this.doUrlTaksFormatExcelButton_Click);
            // 
            // doUrlTaksFormatTextButton
            // 
            this.doUrlTaksFormatTextButton.Location = new System.Drawing.Point(151, 127);
            this.doUrlTaksFormatTextButton.Name = "doUrlTaksFormatTextButton";
            this.doUrlTaksFormatTextButton.Size = new System.Drawing.Size(35, 35);
            this.doUrlTaksFormatTextButton.TabIndex = 6;
            this.doUrlTaksFormatTextButton.UseVisualStyleBackColor = true;
            this.doUrlTaksFormatTextButton.Click += new System.EventHandler(this.doUrlTaksFormatTextButton_Click);
            // 
            // pageIDLoadButton
            // 
            this.pageIDLoadButton.Location = new System.Drawing.Point(15, 127);
            this.pageIDLoadButton.Name = "pageIDLoadButton";
            this.pageIDLoadButton.Size = new System.Drawing.Size(35, 35);
            this.pageIDLoadButton.TabIndex = 5;
            this.pageIDLoadButton.UseVisualStyleBackColor = true;
            this.pageIDLoadButton.Click += new System.EventHandler(this.pageIDLoadButton_Click);
            // 
            // pageIDListBox
            // 
            this.pageIDListBox.FormattingEnabled = true;
            this.pageIDListBox.ItemHeight = 14;
            this.pageIDListBox.Location = new System.Drawing.Point(15, 19);
            this.pageIDListBox.Name = "pageIDListBox";
            this.pageIDListBox.ScrollAlwaysVisible = true;
            this.pageIDListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.pageIDListBox.Size = new System.Drawing.Size(457, 102);
            this.pageIDListBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "ページID";
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(680, 17);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(35, 35);
            this.debugButton.TabIndex = 0;
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.libraPlusReportFormatButton);
            this.panel5.Controls.Add(this.openAsFolderButton);
            this.panel5.Controls.Add(this.debugButton);
            this.panel5.Controls.Add(this.openAsSettingButton);
            this.panel5.Location = new System.Drawing.Point(12, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(725, 70);
            this.panel5.TabIndex = 4;
            // 
            // libraPlusReportFormatButton
            // 
            this.libraPlusReportFormatButton.Location = new System.Drawing.Point(8, 17);
            this.libraPlusReportFormatButton.Name = "libraPlusReportFormatButton";
            this.libraPlusReportFormatButton.Size = new System.Drawing.Size(35, 35);
            this.libraPlusReportFormatButton.TabIndex = 2;
            this.libraPlusReportFormatButton.UseVisualStyleBackColor = true;
            this.libraPlusReportFormatButton.Click += new System.EventHandler(this.libraPlusReportFormatButton_Click);
            // 
            // openAsFolderButton
            // 
            this.openAsFolderButton.Location = new System.Drawing.Point(623, 17);
            this.openAsFolderButton.Name = "openAsFolderButton";
            this.openAsFolderButton.Size = new System.Drawing.Size(35, 35);
            this.openAsFolderButton.TabIndex = 1;
            this.openAsFolderButton.UseVisualStyleBackColor = true;
            this.openAsFolderButton.Click += new System.EventHandler(this.openAsFolderButton_Click);
            // 
            // openAsSettingButton
            // 
            this.openAsSettingButton.Location = new System.Drawing.Point(582, 17);
            this.openAsSettingButton.Name = "openAsSettingButton";
            this.openAsSettingButton.Size = new System.Drawing.Size(35, 35);
            this.openAsSettingButton.TabIndex = 0;
            this.openAsSettingButton.UseVisualStyleBackColor = true;
            this.openAsSettingButton.Click += new System.EventHandler(this.openAsSettingButton_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.operationStatusReport);
            this.panel7.Location = new System.Drawing.Point(14, 262);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(717, 153);
            this.panel7.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "処理状況";
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Location = new System.Drawing.Point(3, 22);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(704, 128);
            this.operationStatusReport.TabIndex = 0;
            // 
            // createCategoryByDetailsRepotButton
            // 
            this.createCategoryByDetailsRepotButton.Location = new System.Drawing.Point(315, 127);
            this.createCategoryByDetailsRepotButton.Name = "createCategoryByDetailsRepotButton";
            this.createCategoryByDetailsRepotButton.Size = new System.Drawing.Size(35, 35);
            this.createCategoryByDetailsRepotButton.TabIndex = 13;
            this.createCategoryByDetailsRepotButton.UseVisualStyleBackColor = true;
            this.createCategoryByDetailsRepotButton.Click += new System.EventHandler(this.createCategoryByDetailsRepotButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 442);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LPRepo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox operationStatusReport;
        private System.Windows.Forms.Button openAsSettingButton;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.ListBox projectIDListBox;
        private System.Windows.Forms.Button projectIDLoadButton;
        private System.Windows.Forms.Button createSiteInfoBookButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pageIDLoadButton;
        private System.Windows.Forms.ListBox pageIDListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button doUrlTaksFormatTextButton;
        private System.Windows.Forms.Button doUrlTaksFormatExcelButton;
        private System.Windows.Forms.Button doAsignListButton;
        private System.Windows.Forms.Button openAsFolderButton;
        private System.Windows.Forms.CheckBox basicAuthFlagCheck;
        private System.Windows.Forms.Button doPageIDLoadFromTsvButton;
        private System.Windows.Forms.Button doPageIDsScreenShotButton;
        private System.Windows.Forms.Button pageIDListBoxSelectClearButton;
        private System.Windows.Forms.Button pageIDListBoxSelectAllButton;
        private System.Windows.Forms.Button libraPlusReportFormatButton;
        private System.Windows.Forms.Button createCategoryByDetailsRepotButton;
    }
}

