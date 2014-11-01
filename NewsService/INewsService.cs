using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {
        /*
         * Usage:
         * pass any any topic and get a string of urls that link to news for that topic
         */
        [OperationContract]
        [WebGet(UriTemplate = "/search/{newsTopic}", ResponseFormat=WebMessageFormat.Json)]
        string[] getNews(string newsTopic);

    }


}
