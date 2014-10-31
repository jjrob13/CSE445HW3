using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Collections;

namespace HW3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StorageService : IHW3Services
    {
        //courtesy of fileservice from lecture notes.
        string UPLOAD_PATH = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); // Get path from server root to current

        public FileUploadResponse uploadFile(FileUpload uploadedFile)
        {
            try
            {

                //cast inputStream to file stream

                //create unique file path
                string filePath = UPLOAD_PATH + "\\" + DateTime.Now.ToFileTimeUtc() + uploadedFile.nameOfFile;

                writeToLog("FilePath: " + filePath);
                //if the directory is not found, create it
                if (!Directory.Exists(UPLOAD_PATH))
                {
                    Directory.CreateDirectory(UPLOAD_PATH);
                }

                FileStream fileStream = File.Create(filePath);

                //create buffer for reading data
                int bufferSize = 2048;
                byte[] buffer = new byte[bufferSize];

                //read the first piece of data
                int bytesRead = uploadedFile.uploadedFileDataStream.Read(buffer, 0, buffer.Length);

                //while there is still data to be read, continue to read data using the buffer and write it to the local file.
                while (bytesRead > 0)
                {
                    //write buffer to file
                    fileStream.Write(buffer, 0, bufferSize);

                    //continue reading from uploadedfile
                    bytesRead = uploadedFile.uploadedFileDataStream.Read(buffer, 0, bufferSize);
                }

                fileStream.Close();
                //when the file is finished being read, return the complete path to the file.
                return new FileUploadResponse {FileURL = filePath};
            }
            catch (Exception ex)
            {

                writeToLog(ex.ToString());
                return new FileUploadResponse { FileURL = null};
            }

        }

        private void writeToLog(string infoToWrite)
        {
            StreamWriter outputStreamWriter;

            string logPath = UPLOAD_PATH + "\\log.txt";

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


        public string[] getNews(string newsTopic)
        {
            //external rest API for news
            string feedzillaBaseApi = "http://api.feedzilla.com/v1/categories/26/articles/search.json?q=";

            string feedzillaApiCall = feedzillaBaseApi + Uri.EscapeDataString(newsTopic);

            //call rest api
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(feedzillaApiCall);

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
                if(reader.Value != null && reader.ValueType.Equals("source_url")){
                    //consume the source_url tag, moving to the actual data
                    //for example, if the json looks like 'source_url' : 'www.helloworld.com'
                    //reader.Read() has to be called once more to get to advance to the key
                    reader.Read();

                    //add the actual value to the array
                    result.Add(reader.Value);
                }
            }

            reader.Close();
            responseReader.Close();

            writeToLog(result.ToString());

            return (string[])result.ToArray();
        }

    }
}
