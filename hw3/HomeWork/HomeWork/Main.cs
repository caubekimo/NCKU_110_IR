using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                this.txtTrainingFilePath.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnWord2Vector_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTrainingFilePath.Text))
            {
                MessageBox.Show("請選擇檔案所在資料夾路徑");
                return;
            }

            FileInfo fi = new FileInfo(this.txtTrainingFilePath.Text);

            string resultStr = string.Empty;

            string url = @"http://127.0.0.1:5000/Word2Vector?file_path="
                + this.txtTrainingFilePath.Text
                + "&use_sg=" + (this.cbUseSG.Checked ? "1" : "0")
                + "&save_to_model=" + Path.Combine(fi.DirectoryName, fi.Name.Replace(fi.Extension, "") + "_" + (this.cbUseSG.Checked ? "sg" : "CBOW") + ".bin")
                + "&save_to_fig=" + Path.Combine(fi.DirectoryName, fi.Name.Replace(fi.Extension, "") + "_" + (this.cbUseSG.Checked ? "sg" : "CBOW") + ".svg");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Timeout = 1000000;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resultStr = reader.ReadToEnd();
            }

            MessageBox.Show(resultStr);
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

            string url = @"http://127.0.0.1:5000/SimilarWord?model_file_path="
                + this.txtModelFilePath.Text
                + "&pattern=" + this.txtPattern.Text;

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

                foreach (var kv in searchResult["res"])
                {
                    list.Add(new SearchResult() { Word = kv[0].ToString(), Similarity = double.Parse(kv[1].ToString()) });
                }

                source.DataSource = list;
                this.dataGridView1.DataSource = source;

            }
        }
    }

    class SearchResult
    {
        public string Word { get; set; }
        public double Similarity { get; set; }
    }
}
