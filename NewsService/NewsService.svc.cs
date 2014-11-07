using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace NewsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NewsService : INewsService
    {

        public string[] getNews(string newsTopic)
        {

            try
            {
                //external rest API for news
                string baseApiURL = "http://reddit.com/r/news/search.json?restrict_sr=on&q=";

                string apiCallURL = baseApiURL + Uri.EscapeDataString(newsTopic);

                writeToLog("APICall: " + apiCallURL);
                //call rest api
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiCallURL);

                //get response
                WebResponse response = request.GetResponse();

                //read response
                StreamReader responseReader = new StreamReader(response.GetResponseStream());

                //read all of the desired json objects
                JsonTextReader reader = new JsonTextReader(responseReader);

                ArrayList result = new ArrayList();

                //read through the json and add all source_urls to the result array
                while (reader.Read())
                {
                    if (reader.Value != null && reader.Value.Equals("url"))
                    {
                        //consume the source_url tag, moving to the actual data
                        //for example, if the json looks like 'source_url' : 'www.helloworld.com'
                        //reader.Read() has to be called once more to get to advance to the key
                        reader.Read();
                        
                        //add the actual value to the array
                        result.Add(reader.Value.ToString());

                    }
                }

                reader.Close();
                responseReader.Close();

                //return the array of news urls
                return (string[])result.ToArray(typeof(string));
            }
            catch (Exception ex)
            {
                writeToLog(ex.ToString());
                return null;
            }
        }


        private void writeToLog(string infoToWrite)
        {
            string UPLOAD_PATH = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); // Get path from server root to current

            StreamWriter outputStreamWriter;

            string logPath = UPLOAD_PATH + "\\log.txt";


            //if the directory is not found, create it
            if (!Directory.Exists(UPLOAD_PATH))
            {
                Directory.CreateDirectory(UPLOAD_PATH);
            }

            //if the log is not created, create it.
            if (!File.Exists(logPath))
                outputStreamWriter = File.CreateText(logPath);
            else
                outputStreamWriter = File.AppendText(logPath);




            //write current time to log and string passed to log
            outputStreamWriter.WriteLine(DateTime.Now.ToString());
            outputStreamWriter.WriteLine(infoToWrite);

            outputStreamWriter.Close();
        }

    }
}
