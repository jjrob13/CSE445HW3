using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockDataPointsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStockDataPointsService
    {

        [OperationContract]
        StockDataPoints GetStockDataPoints(string stockTicker);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class StockDataPoints
    {
        [DataMember]
        public double currentPrice { get; set; }

        [DataMember]
        public double lastMonthPrice { get; set; }

        [DataMember]
        public double lastYearPrice { get; set; }

        [DataMember]
        public string stockTicker { get; set; }

        [DataMember]
        public StockDataPoint[] DataPoints
        {
            get { return dataPointsArray; }
            set { dataPointsArray = value; }
        }

        private StockDataPoint [] dataPointsArray;

        public StockDataPoints(string stockTicker, double currentPrice, double lastQuarterPrice, double lastYearPrice)
        {
            this.stockTicker = stockTicker; this.currentPrice = currentPrice; this.lastMonthPrice = lastQuarterPrice;
            this.lastYearPrice = lastYearPrice;
        }

        public override string ToString()
        {
            return "stockTicker: " + stockTicker + "currentPrice: " + currentPrice + "; lastQuarterPrice: " + lastMonthPrice +
                "; lastYearPrice: " + lastYearPrice;
        }


    }


    [DataContract]
     public class StockDataPoint
        {
            [DataMember]
            public DateTime date { get; set; }

            [DataMember]
            public double price{get; set;}

            public StockDataPoint(DateTime date, double price)
            {
                this.date = date;
                this.price = price;

            }
    }
}
