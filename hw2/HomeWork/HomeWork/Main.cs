using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFolderPath.Text))
            {
                MessageBox.Show("請選擇檔案所在資料夾路徑");
                return;
            }

            string resultStr = string.Empty;

            string url = @"http://127.0.0.1:5000/GetWordFreq?folder_path="
                + this.txtFolderPath.Text
                //+ this.txtFolderPath.Text.Replace("\\", "/")
                + "&remove_stop_words=" + (this.cbRemoveStopWords.Checked ? "1" : "0");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resultStr = reader.ReadToEnd();
            }

            JToken compareResult = JArray.Parse(resultStr)[0];
            //double ratio = (double)(compareResult["ratio"]);
            //int[] longestMatch = compareResult["longestMatch"].ToObject<int[]>();

            //this.lblRatio.Text = Math.Round(ratio, 2).ToString();
            //this.lblLongestLength.Text = longestMatch[2].ToString();
            //this.txtLongestMatchString.Text = content1.Substring(longestMatch[0], longestMatch[2]);
            //this.lblLongestMatchPosition1.Text = longestMatch[0].ToString();
            //this.lblLongestMatchPosition2.Text = longestMatch[1].ToString();
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFolderPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
