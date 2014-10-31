using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HW3
{
    [ServiceContract]
    public interface IStorageService
    {

        /*
         Usage:
         * uploadFile(string nameOfFileToBeUploaded, Stream fileStream)
         * 
         * This program takes a file and stores it locally on the server.
         */
        [OperationContract]
        FileUploadResponse uploadFile(FileUpload uploadedFile);


    }



    //The idea to use message contract instead of data contract courtesy of: http://bartwullems.blogspot.com/2011/01/streaming-files-over-wcf.html
    [MessageContract]
    public class FileUpload
    {
        [MessageHeader(MustUnderstand = true)]
        public string nameOfFile;

        [MessageBodyMember(Order = 1)]
        public Stream uploadedFileDataStream;
    }


    [MessageContract]
    public class FileUploadResponse
    {
        [MessageBodyMember(Order = 1)]
        public string FileURL { get; set; }
    }
}
