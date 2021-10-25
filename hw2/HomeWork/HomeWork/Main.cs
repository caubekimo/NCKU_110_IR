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

            this.chart1.Series["Title"].Points.Clear();
            this.chart1.Series["Abstract"].Points.Clear();

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

            JToken calResult = JArray.Parse(resultStr)[0];

            foreach (var dist in calResult["titleFdist"])
            {
                string[] keyValue = dist.ToString().Split(new string[] { ": " }, StringSplitOptions.None);

                if (int.Parse(keyValue[1]) >= (this.cbRemoveStopWords.Checked ? 500 : 1000))
                    this.chart1.Series["Title"].Points.AddXY(keyValue[0].Replace("\"", ""), int.Parse(keyValue[1]));
            }

            foreach (var dist in calResult["absFdist"])
            {
                string[] keyValue = dist.ToString().Split(new string[] { ": " }, StringSplitOptions.None);

                if (int.Parse(keyValue[1]) >= (this.cbRemoveStopWords.Checked ? 4000 : 10000))
                    this.chart1.Series["Abstract"].Points.AddXY(keyValue[0].Replace("\"", ""), int.Parse(keyValue[1]));
            }

            //this.chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
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
