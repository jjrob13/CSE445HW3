using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockDescriptionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStockDescriptionService
    {

        [OperationContract]
        [WebGet(UriTemplate="/description?company={companyName}", ResponseFormat=WebMessageFormat.Json)]
        string getStockPerformanceDescriptionForCompany(string companyName);

        // TODO: Add your service operations here
    }

}
