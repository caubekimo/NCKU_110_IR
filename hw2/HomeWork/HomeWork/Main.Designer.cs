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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRatio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLongestMatchString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLongestMatchPosition1 = new System.Windows.Forms.Label();
            this.lblLongestMatchPosition2 = new System.Windows.Forms.Label();
            this.lblLongestLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFile1
            // 
            this.txtFile1.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtFile1.Location = new System.Drawing.Point(117, 53);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.ReadOnly = true;
            this.txtFile1.Size = new System.Drawing.Size(987, 39);
            this.txtFile1.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(72, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "File 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "File 2";
            // 
            // txtFile2
            // 
            this.txtFile2.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtFile2.Location = new System.Drawing.Point(115, 128);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.ReadOnly = true;
            this.txtFile2.Size = new System.Drawing.Size(987, 39);
            this.txtFile2.TabIndex = 4;
            // 
            // btnSelectFile2
            // 
            this.btnSelectFile2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectFile2.Location = new System.Drawing.Point(1108, 128);
            this.btnSelectFile2.Name = "btnSelectFile2";
            this.btnSelectFile2.Size = new System.Drawing.Size(48, 35);
            this.btnSelectFile2.TabIndex = 16;
            this.btnSelectFile2.Text = "...";
            this.btnSelectFile2.UseVisualStyleBackColor = true;
            this.btnSelectFile2.Click += new System.EventHandler(this.btnSelectFile2_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.btnCompare.Location = new System.Drawing.Point(968, 201);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(189, 66);
            this.btnCompare.TabIndex = 17;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "相似度";
            // 
            // lblRatio
            // 
            this.lblRatio.AutoSize = true;
            this.lblRatio.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblRatio.Location = new System.Drawing.Point(109, 212);
            this.lblRatio.Name = "lblRatio";
            this.lblRatio.Size = new System.Drawing.Size(31, 34);
            this.lblRatio.TabIndex = 19;
            this.lblRatio.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label4.Location = new System.Drawing.Point(15, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "最長相似字串長度";
            // 
            // txtLongestMatchString
            // 
            this.txtLongestMatchString.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtLongestMatchString.Location = new System.Drawing.Point(17, 295);
            this.txtLongestMatchString.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLongestMatchString.Multiline = true;
            this.txtLongestMatchString.Name = "txtLongestMatchString";
            this.txtLongestMatchString.Size = new System.Drawing.Size(1139, 164);
            this.txtLongestMatchString.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label5.Location = new System.Drawing.Point(15, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 30);
            this.label5.TabIndex = 22;
            this.label5.Text = "最長相似字串出現位置 in File 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label6.Location = new System.Drawing.Point(591, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 30);
            this.label6.TabIndex = 23;
            this.label6.Text = "最長相似字串出現位置 in File 2";
            // 
            // lblLongestMatchPosition1
            // 
            this.lblLongestMatchPosition1.AutoSize = true;
            this.lblLongestMatchPosition1.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblLongestMatchPosition1.Location = new System.Drawing.Point(15, 535);
            this.lblLongestMatchPosition1.Name = "lblLongestMatchPosition1";
            this.lblLongestMatchPosition1.Size = new System.Drawing.Size(43, 30);
            this.lblLongestMatchPosition1.TabIndex = 24;
            this.lblLongestMatchPosition1.Text = "---";
            // 
            // lblLongestMatchPosition2
            // 
            this.lblLongestMatchPosition2.AutoSize = true;
            this.lblLongestMatchPosition2.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblLongestMatchPosition2.Location = new System.Drawing.Point(591, 535);
            this.lblLongestMatchPosition2.Name = "lblLongestMatchPosition2";
            this.lblLongestMatchPosition2.Size = new System.Drawing.Size(43, 30);
            this.lblLongestMatchPosition2.TabIndex = 25;
            this.lblLongestMatchPosition2.Text = "---";
            // 
            // lblLongestLength
            // 
            this.lblLongestLength.AutoSize = true;
            this.lblLongestLength.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblLongestLength.Location = new System.Drawing.Point(265, 258);
            this.lblLongestLength.Name = "lblLongestLength";
            this.lblLongestLength.Size = new System.Drawing.Size(31, 34);
            this.lblLongestLength.TabIndex = 26;
            this.lblLongestLength.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 597);
            this.Controls.Add(this.lblLongestLength);
            this.Controls.Add(this.lblLongestMatchPosition2);
            this.Controls.Add(this.lblLongestMatchPosition1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLongestMatchString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRatio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnSelectFile2);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile1);
            this.Controls.Add(this.txtFile1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Content Compare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLongestMatchString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLongestMatchPosition1;
        private System.Windows.Forms.Label lblLongestMatchPosition2;
        private System.Windows.Forms.Label lblLongestLength;
    }
}