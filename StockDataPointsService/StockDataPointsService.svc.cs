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
using System.Runtime.Caching;

namespace StockDataPointsService
{
    
    public class StockDataPointsService : IStockDataPointsService
    {
        //global cache variable
        ObjectCache cache = MemoryCache.Default;
        
        public StockDataPoints GetStockDataPoints(string stockTicker)
        {
            StockDataPoints result;

            //stock information is in cache
            if (cache.Contains(stockTicker))
            {
                result = cache[stockTicker] as StockDataPoints;
            }
            else
            {
                //stock information needs to be created and put in cache
                //generate the result with api call and parsing
                result = createResultForTicker(stockTicker);

                //store result in the cache
                storeObjectInCache(stockTicker, result);
            }

            return result;
            
        }


        private void writeToLog(string infoToWrite)
        {
            StreamWriter outputStreamWriter;
            string BASE_PATH = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data"); // Get path from server root to current

            string logPath = BASE_PATH + "\\log.txt";


            //if the directory is not found, create it
            if (!Directory.Exists(BASE_PATH))
            {
                Directory.CreateDirectory(BASE_PATH);
            }

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

        //get object from cache
        private StockDataPoints getObjectFromCache(string ticker)
        {
            StockDataPoints result = cache[ticker] as StockDataPoints;
            return result;
        }

        private void storeObjectInCache(string ticker, StockDataPoints objectToWrite)
        {
            cache[ticker] = objectToWrite;
        }



        //used if object is not in the cache and needs to be created.
        //returns the stock datapoints for a given stock ticker
        private StockDataPoints createResultForTicker(string stockTicker)
        {
            //number of data points to request from api
            int NUM_DATA_POINTS = 12;

            string BASE_API = "http://www.quandl.com/api/v1/datasets/WIKI/";

            string API_PARAMS = ".csv?collapse=monthly&rows=" + NUM_DATA_POINTS + "&sort_order=desc&column=4";

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
                for (int i = 0; i < NUM_DATA_POINTS; i++)
                {
                    //if there is nothing else to read, break
                    if (fieldParser.EndOfData)
                        break;


                    string[] dataFields = fieldParser.ReadFields();

                    //add new element to dataPointsBuffer
                    dataPointsBuffer[i] = new StockDataPoint(DateTime.Parse(dataFields[0]), Double.Parse(dataFields[1]));

                }

                //create result object
                //StockDataPoints(ticker, currentPrice, lastMonthPrice, lastYearPrice)
                StockDataPoints result = new StockDataPoints(stockTicker, dataPointsBuffer[0].price, dataPointsBuffer[2].price, dataPointsBuffer[11].price);

                //add data points to result
                result.DataPoints = dataPointsBuffer;

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
    }
}
