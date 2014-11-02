using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using HW3Tests.StockDataPointsService;
namespace HW3Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void StorageService()
        {
            string fileName = "test.txt";
            string testFileToStore = "C:\\\\Users\\John\\Desktop\\" + fileName;
            StorageService1.StorageServiceClient storageService = new StorageService1.StorageServiceClient();


            FileStream fs = File.Open(testFileToStore, FileMode.OpenOrCreate);

            string resultPath = storageService.uploadFile(fileName, fs);

            Assert.IsNotNull(resultPath);

            Console.WriteLine(resultPath);


        }

        //[TestMethod]
        public void NewsService()
        {
            string searchTerm = "Arizona State University";

            string restURL = "http://localhost:51741/NewsService.svc/search/";

            string fullSearchURL = restURL + searchTerm;

        }


        [TestMethod]
        public void GetStockDataPointsService()
        {
            string STOCK_TICKER = "AAPL";
            StockDataPointsServiceClient stockDataClient = new StockDataPointsServiceClient();

            StockDataPoints result = stockDataClient.GetStockDataPoints(STOCK_TICKER);

            
            Assert.IsNotNull(result);

            
        }
    }
}
