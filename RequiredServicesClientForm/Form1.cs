using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
namespace RequiredServicesClientForm
{
    public partial class Form1 : Form
    {
        StorageService.StorageServiceClient storageService = new StorageService.StorageServiceClient();
        string NEWS_REST_API = "http://localhost:51741/NewsService.svc/search/";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void storageServiceUploadButton_Click(object sender, EventArgs e)
        {
            string inputFilePath = this.storageServiceInputField.Text;
            string inputFileName = Path.GetFileName(this.storageServiceInputField.Text);
            if (File.Exists(inputFilePath))
            {
                storageServiceOutputField.Text = storageService.uploadFile(inputFileName, File.Open(inputFilePath, FileMode.Open));
            }
        }

        private void newsServiceSearchButton_Click(object sender, EventArgs e)
        {
            if (!newsServiceSearchField.Text.Equals(""))
            {
                //clear any previous urls
                newsServiceURLs.Clear();

                string searchKeyword = Uri.EscapeDataString(newsServiceSearchField.Text);
                string fullApiUrl = NEWS_REST_API + searchKeyword;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullApiUrl);
                WebResponse response = request.GetResponse();
                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                JsonTextReader reader = new JsonTextReader(responseReader);

                //read all resulting urls and add them to the text list
                while(reader.Read()){
                    newsServiceURLs.Items.Add(new ListViewItem((string)reader.Value));
                }

            }
        }

        private void newsServiceURLs_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void newsServiceURLs_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            MouseEventArgs ev = (MouseEventArgs)e;
            ListViewHitTestInfo hit = newsServiceURLs.HitTest(ev.Location);

            if (hit.Item != null)
            {
                Process.Start(hit.Item.Text);
            }
        }

        private void newsServiceURLs_MouseDoubleClick(object sender, EventArgs e)
        {

        }

        private void storageServiceInputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void newsServiceSearchField_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
