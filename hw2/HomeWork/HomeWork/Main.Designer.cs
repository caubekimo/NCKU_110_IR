namespace HomeWork
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbRemoveStopWords = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtFolderPath.Location = new System.Drawing.Point(174, 53);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(930, 39);
            this.txtFolderPath.TabIndex = 0;
            // 
            // btnSelectFile1
            // 
            this.btnSelectFile1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectFile1.Location = new System.Drawing.Point(1109, 55);
            this.btnSelectFile1.Name = "btnSelectFile1";
            this.btnSelectFile1.Size = new System.Drawing.Size(48, 35);
            this.btnSelectFile1.TabIndex = 1;
            this.btnSelectFile1.Text = "...";
            this.btnSelectFile1.UseVisualStyleBackColor = true;
            this.btnSelectFile1.Click += new System.EventHandler(this.btnSelectFile1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Path";
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.btnCompare.Location = new System.Drawing.Point(969, 115);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(189, 66);
            this.btnCompare.TabIndex = 17;
            this.btnCompare.Text = "Get Freqs";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // cbRemoveStopWords
            // 
            this.cbRemoveStopWords.AutoSize = true;
            this.cbRemoveStopWords.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cbRemoveStopWords.Location = new System.Drawing.Point(607, 132);
            this.cbRemoveStopWords.Name = "cbRemoveStopWords";
            this.cbRemoveStopWords.Size = new System.Drawing.Size(266, 34);
            this.cbRemoveStopWords.TabIndex = 18;
            this.cbRemoveStopWords.Text = "Remove Stop Words";
            this.cbRemoveStopWords.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 788);
            this.Controls.Add(this.cbRemoveStopWords);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile1);
            this.Controls.Add(this.txtFolderPath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Content Compare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbRemoveStopWords;
    }
}