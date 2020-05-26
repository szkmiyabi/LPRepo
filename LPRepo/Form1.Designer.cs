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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openAsSettingButton = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 92);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(229, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 94);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(12, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(152, 110);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(170, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 110);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.openAsSettingButton);
            this.panel5.Location = new System.Drawing.Point(332, 110);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 110);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(12, 226);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(620, 101);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.operationStatusReport);
            this.panel7.Location = new System.Drawing.Point(17, 351);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(615, 131);
            this.panel7.TabIndex = 6;
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Location = new System.Drawing.Point(3, 18);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(604, 110);
            this.operationStatusReport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "処理状況";
            // 
            // openAsSettingButton
            // 
            this.openAsSettingButton.Location = new System.Drawing.Point(57, 21);
            this.openAsSettingButton.Name = "openAsSettingButton";
            this.openAsSettingButton.Size = new System.Drawing.Size(47, 41);
            this.openAsSettingButton.TabIndex = 0;
            this.openAsSettingButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 487);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "LPRepo";
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
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
    }
}

