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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtChar.Text = string.Empty;
            this.txtWord.Text = string.Empty;
            this.txtSen.Text = string.Empty;
            this.txtSearchResult.Text = string.Empty;

            if (string.IsNullOrEmpty(this.txtFile.Text) || string.IsNullOrEmpty(this.txtPattern.Text))
            {
                MessageBox.Show("請選擇檔案並填入欲搜尋文字");
                return;
            }

            FileContents fc = this.txtFile.Text.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)
                ? GetXmlContent(this.txtFile.Text)
                : GetJsonContent(this.txtFile.Text);

            string resultStr = string.Empty;
            string url = @"http://127.0.0.1:5000/TextStat?content=" + fc.Contents.Select(x=>x.Value).Aggregate((total, next) => total + "\r\n" + next);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resultStr = reader.ReadToEnd();
            }

            JToken textStat = JArray.Parse(resultStr)[0];
            this.txtChar.Text = textStat["char"].ToString();
            this.txtWord.Text = textStat["word"].ToString();
            this.txtSen.Text = textStat["sentence"].ToString();

            //string pattern = "^" + this.txtPattern.Text + "$";
            string pattern = this.txtPattern.Text;

            foreach (var content in fc.Contents)
            {
                Regex rg = new Regex(pattern);
                MatchCollection matches = rg.Matches(content.Value);

                if (matches.Count > 0)
                {
                    string indexes = matches.Cast<Match>().Select(x => x.Index.ToString()).Aggregate((total, next) => total + ", " + next);
                    this.txtSearchResult.Text += "Pattern found in: 【" + content.Value + "】, and positions are: 【" + indexes + "】" + Environment.NewLine + Environment.NewLine;
                }
            }
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
