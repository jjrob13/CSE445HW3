using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StockDescriptionService.StockDataPoints;
using System.Runtime.Caching;
using System.IO;
using System.Web;

namespace StockDescriptionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //global cache variable
        ObjectCache cache = MemoryCache.Default;
        public string getStockPerformanceDescriptionForCompany(string companyName)
        {
            
            string NOT_VALID_COMPANY_NAME_ERROR_MESSAGE = "Sorry, no stock information found for " +  companyName;
            string ticker = getCompanyTicker(companyName);
            if (ticker == null)
            {
                return NOT_VALID_COMPANY_NAME_ERROR_MESSAGE;
            }

            if (cache.Contains(ticker))
            {
                return cache[ticker] as string;
            }

            //result not in cache
            string result =  createDescriptionForTicker(ticker, companyName);
            cache[ticker] = result;

            

            return result;
        }


        private string getCompanyTicker(string companyName)
        {
            //uses outside API to resolve stock ticker
            return companyName;
        }

        private string createDescriptionForTicker(string ticker, string companyName)
        {
            try
            {
                //create proxy
                StockDataPointsServiceClient stockDataServiceClient = new StockDataPointsServiceClient();

                StockDataPoints.StockDataPoints stockDataForTicker = stockDataServiceClient.GetStockDataPoints(ticker);


                //constant descriptor words whose synonyms will be used to describe stock performance.
                string AVERAGE_PERFORMANCE_DESCRIPTOR = "been average";
                string POOR_PERFORMANCE_DESCRIPTOR = "under-performed";
                string EXCELLENT_PERFORMANCE_DESCRIPTOR = "been excellent";
                string RISING_PRICE_DESCRIPTOR = "rising";
                string FALLING_PRICE_DESCRIPTOR = "falling";

                string monthlyReport = "In the last month, " + companyName + " has ";
                double fivePercentOfLastMonthStockPrice = stockDataForTicker.lastMonthPrice * .05;


                //create monthly report information
                //current price is within five percent of last month's price
                if (Math.Abs(stockDataForTicker.currentPrice - stockDataForTicker.lastMonthPrice) <= fivePercentOfLastMonthStockPrice)
                {
                    monthlyReport += getSynonym(AVERAGE_PERFORMANCE_DESCRIPTOR);
                }
                else if (stockDataForTicker.currentPrice < stockDataForTicker.lastMonthPrice)
                {
                    //stock price has gone down over 5% since last month
                    monthlyReport += getSynonym(POOR_PERFORMANCE_DESCRIPTOR);
                }
                else
                {
                    //up more than five percent
                    monthlyReport += getSynonym(EXCELLENT_PERFORMANCE_DESCRIPTOR);
                }

                //include statistics for montlhyReport
                double lastMonthPriceChange = stockDataForTicker.currentPrice - stockDataForTicker.lastMonthPrice;
                monthlyReport += " with a price change of " + (lastMonthPriceChange < 0 ? "-" : "") + "$" + Math.Abs(lastMonthPriceChange) + ", "
                    + (lastMonthPriceChange < 0 ? getSynonym(FALLING_PRICE_DESCRIPTOR) : getSynonym(RISING_PRICE_DESCRIPTOR))
                   + " from $" + stockDataForTicker.lastMonthPrice
                    + " to $" + stockDataForTicker.currentPrice + ".";


                //create yearly report
                string yearlyReport = "In the last year, " + companyName + " has ";
                double fivePercentOfLastYearStockPrice = stockDataForTicker.lastYearPrice * .05;
                if (Math.Abs(stockDataForTicker.currentPrice - stockDataForTicker.lastYearPrice) <= fivePercentOfLastYearStockPrice)
                {
                    yearlyReport += getSynonym(AVERAGE_PERFORMANCE_DESCRIPTOR);
                }
                else if (stockDataForTicker.currentPrice < stockDataForTicker.lastYearPrice)
                {
                    //stock price has gone down over 5% since last year
                    yearlyReport += getSynonym(POOR_PERFORMANCE_DESCRIPTOR);
                }
                else
                {
                    //up more than five percent
                    yearlyReport += getSynonym(EXCELLENT_PERFORMANCE_DESCRIPTOR);
                }

                //include statistics for yearlyReport
                double lastYearPriceChange = stockDataForTicker.currentPrice - stockDataForTicker.lastYearPrice;
                yearlyReport += " with a price change of " + (lastYearPriceChange < 0 ? "-" : "") + "$" + Math.Abs(lastYearPriceChange) + ", "
                    + (lastYearPriceChange < 0 ? getSynonym(FALLING_PRICE_DESCRIPTOR) : getSynonym(RISING_PRICE_DESCRIPTOR))
                   + " from $" + stockDataForTicker.lastYearPrice
                    + " to $" + stockDataForTicker.currentPrice + ".";

                return monthlyReport + " " + yearlyReport;
            }
            catch (Exception ex)
            {
                //write exception to log
                writeToLog(ex.ToString());

                string EXCEPTION_MESSAGE = "Unable to create description for " + companyName;
                return EXCEPTION_MESSAGE;
            }
        }

        private string getSynonym(string descriptor)
        {
            //calls external api to get synonym
            return descriptor;
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
    }



}
