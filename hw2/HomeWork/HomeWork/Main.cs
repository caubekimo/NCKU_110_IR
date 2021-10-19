using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFile1.Text) || string.IsNullOrEmpty(this.txtFile2.Text))
            {
                MessageBox.Show("請選擇檔案1以及檔案2");
                return;
            }

            FileContents fc1 = this.txtFile1.Text.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)
                ? GetXmlContent(this.txtFile1.Text)
                : GetJsonContent(this.txtFile1.Text);

            FileContents fc2 = this.txtFile2.Text.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)
                ? GetXmlContent(this.txtFile2.Text)
                : GetJsonContent(this.txtFile2.Text);

            string content1 = fc1.Contents.Select(x => x.Value).Aggregate((total, next) => total + "\r\n" + next);
            string content2 = fc2.Contents.Select(x => x.Value).Aggregate((total, next) => total + "\r\n" + next);

            string resultStr = string.Empty;

            string url = @"http://127.0.0.1:5000/CompareAbstract?content1=" + content1
                + "&content2=" + content2;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resultStr = reader.ReadToEnd();
            }

            JToken compareResult = JArray.Parse(resultStr)[0];
            double ratio = (double)(compareResult["ratio"]);
            int[] longestMatch = compareResult["longestMatch"].ToObject<int[]>();

            this.lblRatio.Text = Math.Round(ratio, 2).ToString();
            this.lblLongestLength.Text = longestMatch[2].ToString();
            this.txtLongestMatchString.Text = content1.Substring(longestMatch[0], longestMatch[2]);
            this.lblLongestMatchPosition1.Text = longestMatch[0].ToString();
            this.lblLongestMatchPosition2.Text = longestMatch[1].ToString();
        }

        private FileContents GetXmlContent(string filename)
        {
            FileContents fc = new FileContents();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;

            XmlReader reader = XmlReader.Create(filename, settings);

            reader.ReadToFollowing("Title");
            fc.Contents.Add(new Content(ContentType.Title, reader.ReadElementContentAsString("Title", reader.NamespaceURI)));

            while (reader.ReadToFollowing("AbstractText"))
            {
                fc.Contents.Add(new Content(ContentType.Abstract, reader.ReadElementContentAsString("AbstractText", reader.NamespaceURI)));
            }

            return fc;
        }

        private FileContents GetJsonContent(string filename)
        {
            FileContents fc = new FileContents();

            //TempJson tempJson = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));
            string str = File.ReadAllText(filename).Replace("\uFEFF", "");
            JArray ary = JArray.Parse(str);

            foreach(var ele in ary)
            {
                fc.Contents.Add(new Content(ContentType.Abstract, ele.Value<string>("tweet_text")));
            }

            return fc;
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFile1.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.txtFile2.Text = this.openFileDialog2.FileName;
            }
        }
    }

    public class FileContents
    {
        public FileContents()
        {
            Contents = new List<Content>();
        }

        public List<Content> Contents
        {
            get; set;
        }
    }

    public class Content
    {
        public Content(ContentType type, string value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// 內容的種類，包含 Title 以及 Abstract
        /// </summary>
        public ContentType Type { get; set; }
        /// <summary>
        /// 內容的值
        /// </summary>
        public string Value { get; set; }
    }

    public enum ContentType
    {
        Title,
        Abstract
    }
}
