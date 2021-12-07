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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCorpusFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.txtModelFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbUseSublinear = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCorpusFilePath
            // 
            this.txtCorpusFilePath.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtCorpusFilePath.Location = new System.Drawing.Point(238, 53);
            this.txtCorpusFilePath.Name = "txtCorpusFilePath";
            this.txtCorpusFilePath.ReadOnly = true;
            this.txtCorpusFilePath.Size = new System.Drawing.Size(914, 39);
            this.txtCorpusFilePath.TabIndex = 0;
            // 
            // btnSelectFile1
            // 
            this.btnSelectFile1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectFile1.Location = new System.Drawing.Point(1171, 54);
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
            this.label1.Size = new System.Drawing.Size(196, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Corpus File Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 21;
            this.label2.Text = "Model File Path";
            // 
            // btnSelectFile2
            // 
            this.btnSelectFile2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectFile2.Location = new System.Drawing.Point(1171, 124);
            this.btnSelectFile2.Name = "btnSelectFile2";
            this.btnSelectFile2.Size = new System.Drawing.Size(48, 35);
            this.btnSelectFile2.TabIndex = 20;
            this.btnSelectFile2.Text = "...";
            this.btnSelectFile2.UseVisualStyleBackColor = true;
            this.btnSelectFile2.Click += new System.EventHandler(this.btnSelectFile2_Click);
            // 
            // txtModelFilePath
            // 
            this.txtModelFilePath.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtModelFilePath.Location = new System.Drawing.Point(238, 123);
            this.txtModelFilePath.Name = "txtModelFilePath";
            this.txtModelFilePath.ReadOnly = true;
            this.txtModelFilePath.Size = new System.Drawing.Size(914, 39);
            this.txtModelFilePath.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 30);
            this.label3.TabIndex = 22;
            this.label3.Text = "Word to Search";
            // 
            // txtPattern
            // 
            this.txtPattern.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtPattern.Location = new System.Drawing.Point(238, 199);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(773, 39);
            this.txtPattern.TabIndex = 23;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.btnSearch.Location = new System.Drawing.Point(1030, 180);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(189, 66);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(17, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1740, 726);
            this.dataGridView1.TabIndex = 25;
            // 
            // cbUseSublinear
            // 
            this.cbUseSublinear.AutoSize = true;
            this.cbUseSublinear.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cbUseSublinear.Location = new System.Drawing.Point(684, 245);
            this.cbUseSublinear.Name = "cbUseSublinear";
            this.cbUseSublinear.Size = new System.Drawing.Size(315, 34);
            this.cbUseSublinear.TabIndex = 26;
            this.cbUseSublinear.Text = "replace tf with 1 + log(tf)";
            this.cbUseSublinear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1769, 1023);
            this.Controls.Add(this.cbUseSublinear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFile2);
            this.Controls.Add(this.txtModelFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile1);
            this.Controls.Add(this.txtCorpusFilePath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word to Vector";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCorpusFilePath;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.TextBox txtModelFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbUseSublinear;
    }
}