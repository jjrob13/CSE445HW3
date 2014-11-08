using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Web;
using System.Xml;

namespace StockTickerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       
        public string GetTicker(string CompanyName)
        {
            //Preparing the url for the GET request from user input.
            //  http://d.yimg.com/autoc.finance.yahoo.com/autoc?query=<INSERTQUERYHERE>&callback=YAHOO.Finance.SymbolSuggest.ssCallback
            string front = "http://d.yimg.com/autoc.finance.yahoo.com/autoc?query=";
            string back = "&callback=YAHOO.Finance.SymbolSuggest.ssCallback";
            string url = front + CompanyName + back;

            ServiceReference1.ServiceClient myClient = new ServiceReference1.ServiceClient();
            string webpage = myClient.GetWebContent(url);

            int first = webpage.IndexOf("\"symbol\"");
            int second = webpage.IndexOf("\"name\"");
            string ticker_symbol = webpage.Substring(first + 10, second - first - 12);

            return ticker_symbol;



        }

    }
}
