using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace HW3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StorageService : IStorageService
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
    }
}
