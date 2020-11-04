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
            this.label2 = new System.Windows.Forms.Label();
            this.createSiteInfoBookButton = new System.Windows.Forms.Button();
            this.projectIDLoadButton = new System.Windows.Forms.Button();
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pageIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.debugButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.openAsSettingButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.doUrlTaksFormatTextButton = new System.Windows.Forms.Button();
            this.doUrlTaksFormatExcelButton = new System.Windows.Forms.Button();
            this.doAsignListButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.createSiteInfoBookButton);
            this.panel1.Controls.Add(this.projectIDLoadButton);
            this.panel1.Controls.Add(this.projectIDListBox);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 154);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "サイトID";
            // 
            // createSiteInfoBookButton
            // 
            this.createSiteInfoBookButton.Location = new System.Drawing.Point(188, 116);
            this.createSiteInfoBookButton.Name = "createSiteInfoBookButton";
            this.createSiteInfoBookButton.Size = new System.Drawing.Size(35, 35);
            this.createSiteInfoBookButton.TabIndex = 2;
            this.createSiteInfoBookButton.UseVisualStyleBackColor = true;
            this.createSiteInfoBookButton.Click += new System.EventHandler(this.createSiteInfoBookButton_Click);
            // 
            // projectIDLoadButton
            // 
            this.projectIDLoadButton.Location = new System.Drawing.Point(6, 116);
            this.projectIDLoadButton.Name = "projectIDLoadButton";
            this.projectIDLoadButton.Size = new System.Drawing.Size(35, 35);
            this.projectIDLoadButton.TabIndex = 1;
            this.projectIDLoadButton.UseVisualStyleBackColor = true;
            this.projectIDLoadButton.Click += new System.EventHandler(this.projectIDLoadButton_Click);
            // 
            // projectIDListBox
            // 
            this.projectIDListBox.FormattingEnabled = true;
            this.projectIDListBox.Location = new System.Drawing.Point(6, 16);
            this.projectIDListBox.Name = "projectIDListBox";
            this.projectIDListBox.ScrollAlwaysVisible = true;
            this.projectIDListBox.Size = new System.Drawing.Size(217, 95);
            this.projectIDListBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.doAsignListButton);
            this.panel2.Controls.Add(this.doUrlTaksFormatExcelButton);
            this.panel2.Controls.Add(this.doUrlTaksFormatTextButton);
            this.panel2.Controls.Add(this.pageIDLoadButton);
            this.panel2.Controls.Add(this.pageIDListBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(255, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 156);
            this.panel2.TabIndex = 1;
            // 
            // pageIDLoadButton
            // 
            this.pageIDLoadButton.Location = new System.Drawing.Point(15, 118);
            this.pageIDLoadButton.Name = "pageIDLoadButton";
            this.pageIDLoadButton.Size = new System.Drawing.Size(39, 35);
            this.pageIDLoadButton.TabIndex = 5;
            this.pageIDLoadButton.UseVisualStyleBackColor = true;
            this.pageIDLoadButton.Click += new System.EventHandler(this.pageIDLoadButton_Click);
            // 
            // pageIDListBox
            // 
            this.pageIDListBox.FormattingEnabled = true;
            this.pageIDListBox.Location = new System.Drawing.Point(15, 18);
            this.pageIDListBox.Name = "pageIDListBox";
            this.pageIDListBox.ScrollAlwaysVisible = true;
            this.pageIDListBox.Size = new System.Drawing.Size(457, 95);
            this.pageIDListBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ページID";
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(71, 26);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(40, 36);
            this.debugButton.TabIndex = 0;
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(14, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 65);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(198, 173);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 65);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.debugButton);
            this.panel5.Controls.Add(this.openAsSettingButton);
            this.panel5.Location = new System.Drawing.Point(387, 173);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 65);
            this.panel5.TabIndex = 4;
            // 
            // openAsSettingButton
            // 
            this.openAsSettingButton.Location = new System.Drawing.Point(28, 27);
            this.openAsSettingButton.Name = "openAsSettingButton";
            this.openAsSettingButton.Size = new System.Drawing.Size(37, 35);
            this.openAsSettingButton.TabIndex = 0;
            this.openAsSettingButton.UseVisualStyleBackColor = true;
            this.openAsSettingButton.Click += new System.EventHandler(this.openAsSettingButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Location = new System.Drawing.Point(14, 245);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(723, 129);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.operationStatusReport);
            this.panel7.Location = new System.Drawing.Point(20, 380);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(717, 142);
            this.panel7.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "処理状況";
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Location = new System.Drawing.Point(3, 20);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(704, 119);
            this.operationStatusReport.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 126);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 99);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // doUrlTaksFormatTextButton
            // 
            this.doUrlTaksFormatTextButton.Location = new System.Drawing.Point(59, 119);
            this.doUrlTaksFormatTextButton.Name = "doUrlTaksFormatTextButton";
            this.doUrlTaksFormatTextButton.Size = new System.Drawing.Size(66, 33);
            this.doUrlTaksFormatTextButton.TabIndex = 6;
            this.doUrlTaksFormatTextButton.Text = "TSV保存";
            this.doUrlTaksFormatTextButton.UseVisualStyleBackColor = true;
            this.doUrlTaksFormatTextButton.Click += new System.EventHandler(this.doUrlTaksFormatTextButton_Click);
            // 
            // doUrlTaksFormatExcelButton
            // 
            this.doUrlTaksFormatExcelButton.Location = new System.Drawing.Point(132, 119);
            this.doUrlTaksFormatExcelButton.Name = "doUrlTaksFormatExcelButton";
            this.doUrlTaksFormatExcelButton.Size = new System.Drawing.Size(41, 34);
            this.doUrlTaksFormatExcelButton.TabIndex = 7;
            this.doUrlTaksFormatExcelButton.UseVisualStyleBackColor = true;
            this.doUrlTaksFormatExcelButton.Click += new System.EventHandler(this.doUrlTaksFormatExcelButton_Click);
            // 
            // doAsignListButton
            // 
            this.doAsignListButton.Location = new System.Drawing.Point(179, 118);
            this.doAsignListButton.Name = "doAsignListButton";
            this.doAsignListButton.Size = new System.Drawing.Size(75, 34);
            this.doAsignListButton.TabIndex = 8;
            this.doAsignListButton.Text = "割当表";
            this.doAsignListButton.UseVisualStyleBackColor = true;
            this.doAsignListButton.Click += new System.EventHandler(this.doAsignListButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 533);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
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
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button doUrlTaksFormatTextButton;
        private System.Windows.Forms.Button doUrlTaksFormatExcelButton;
        private System.Windows.Forms.Button doAsignListButton;
    }
}

