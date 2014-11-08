using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StockChartService.ChartMakerService;
using System.Runtime.Caching;
using StockChartService.StockDataPoints;
namespace StockChartService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //global cache object
        ObjectCache cache = MemoryCache.Default;

        public string getStockChartURL(string companyName)
        {
            string stockTicker = getStockTickerForCompanyName(companyName);

            if (stockTicker == null)
            {
                return null;
            }

            if (cache.Contains(companyName))
            {
                return cache[companyName] as string;
            }

            string apiCall = getChartAPICall(stockTicker);

            cache[companyName] = apiCall;

            return apiCall;
        }

        private string getStockTickerForCompanyName(string companyName)
        {
            //returns stock ticker if company name is valid, else it returns null
            return companyName;
        }

        private string getChartAPICall(string stockTicker){
            //create service proxies
            StockDataPointsServiceClient stockDataClient = new StockDataPointsServiceClient();
            StockDataPoints.StockDataPoints pointsToPlot = stockDataClient.GetStockDataPoints(stockTicker);
            
            StringBuilder result = new StringBuilder();
            result.Append("http://www.gxchart.com/service/Drawchart.aspx?type=LINE&Categories=Values:");

            //append x values (dates) to the url
            for(int i = 0; i < pointsToPlot.DataPoints.Length; i++){
                if(pointsToPlot.DataPoints[i] == null)
                    break;
                if(i != 0)
                    result.Append(",");

                result.Append(pointsToPlot.DataPoints[i].date.ToShortDateString());
            }

            result.Append("&Series1=Values:stock price:");
            //append y values (prices) to the url
            for(int i = 0; i < pointsToPlot.DataPoints.Length; i++){
                if(pointsToPlot.DataPoints[i] == null)
                    break;
                if(i != 0)
                    result.Append(",");
                result.Append(pointsToPlot.DataPoints[i].price);
            }


            result.Append("&title=Stock Price&width=500&height=310&domtitle=Date&rantitle=Amounts in USD&bgc1=88,125,88&bgc2=243,243,243&gbgc1=240,255,210&gbgc2=50,50,80&shadow=1&border=1&values=1&legend=left");

            return result.ToString();
        }
    }
}
