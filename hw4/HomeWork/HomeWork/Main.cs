﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtCorpusFilePath.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.txtModelFilePath.Text = this.openFileDialog2.FileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtModelFilePath.Text))
            {
                MessageBox.Show("請選擇檔案所在資料夾路徑");
                return;
            }

            if (string.IsNullOrEmpty(this.txtPattern.Text))
            {
                MessageBox.Show("請輸入想要尋找的字");
                return;
            }

            FileInfo fi = new FileInfo(this.txtModelFilePath.Text);

            string resultStr = string.Empty;

            string url = @"http://127.0.0.1:5000/GetEvidence?"
                + "corpus_file_path=" + this.txtCorpusFilePath.Text
                + "&model_file_path=" + this.txtModelFilePath.Text
                + "&pattern=" + this.txtPattern.Text
                + "&usesublinear=" + (this.cbUseSublinear.Checked ? 1 : 0);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Timeout = 1000000;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resultStr = reader.ReadToEnd();
                JToken searchResult = JArray.Parse(resultStr)[0];

                var source = new BindingSource();
                List<SearchResult> list = new List<SearchResult>();

                foreach (var kv in searchResult["wordWeight"])
                {
                    list.Add(new SearchResult() { Word = kv[0].ToString(), Similarity = double.Parse(kv[1].ToString()), MaxTfidf = double.Parse(kv[2].ToString()), Sentence = kv[3].ToString() });
                }

                source.DataSource = list.OrderByDescending(x => x.Similarity);
                this.dataGridView1.DataSource = source;

            }
        }
    }

    class SearchResult
    {
        public string Word { get; set; }
        public double Similarity { get; set; }
        public double MaxTfidf { get; set; }
        public string Sentence { get; set; }
    }
}
