using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SynonymWebService
{
 
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/getSynonyms/{input}/{type}")]
        TextMessage getSynonyms(string input, string type);

        //[OperationContract]
        //string getSynonyms(string keyword);
    }

    [DataContract]
    public class TextMessage
    {
        [DataMember]
        public string Message { get; set; }
    }
}
