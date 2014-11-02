using Microsoft.VisualBasic.FileIO;
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

namespace StockDataPointsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StockDataPointsService : IStockDataPointsService
    {
        public StockDataPoints GetStockDataPoints(string stockTicker)
        {
            //number of data points to request from api
            int NUM_DATA_POINTS = 5;

            string BASE_API = "http://www.quandl.com/api/v1/datasets/WIKI/";

            string API_PARAMS = ".csv?collapse=quarterly&rows=" + NUM_DATA_POINTS + "&sort_order=desc&column=4";

            string FULL_API_URL = BASE_API + Uri.EscapeDataString(stockTicker.ToUpper()) + API_PARAMS;

            //maximum number of data points that will be loaded into memory for a given service call

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FULL_API_URL);
                WebResponse response = request.GetResponse();

                //parse csv file
                TextFieldParser fieldParser = new TextFieldParser(response.GetResponseStream());
                fieldParser.TextFieldType = FieldType.Delimited;
                fieldParser.SetDelimiters(",");


                //buffer to store data points
                StockDataPoint[] dataPointsBuffer = new StockDataPoint[NUM_DATA_POINTS];

                //consume headers of csv file (eg. "Date", "Price")
                fieldParser.ReadFields();

                //read the file
                for (int i = 0; i < NUM_DATA_POINTS; i++ )
                {
                    //if there is nothing else to read, break
                    if (fieldParser.EndOfData)
                        break;


                    string[] dataFields = fieldParser.ReadFields();

                    //add new element to dataPointsBuffer
                    dataPointsBuffer[i] = new StockDataPoint(DateTime.Parse(dataFields[0]), Double.Parse(dataFields[1]));

                }

                //create result object
                StockDataPoints result = new StockDataPoints(stockTicker, dataPointsBuffer[0].price, dataPointsBuffer[1].price, dataPointsBuffer[4].price);

                return result;
            }
            //invalid API Call
            catch (Exception ex)
            {
                //write exception to log and return null
                writeToLog(ex.ToString());

                return null;
            }
        }


        private void writeToLog(string infoToWrite)
        {
            StreamWriter outputStreamWriter;
            string BASE_PATH = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); // Get path from server root to current

            string logPath = BASE_PATH + "\\log.txt";

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

        class StockDataPoint
        {
            public DateTime date { get; set; }
            public double price{get; set;}

            public StockDataPoint(DateTime date, double price)
            {
                this.date = date;
                this.price = price;

            }
        }
    }
}
