using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace HW3Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StorageService()
        {
            string fileName = "test.txt";
            string testFileToStore = "C:\\\\Users\\John\\Desktop\\" + fileName;
            Console.WriteLine(testFileToStore);
            StorageService1.StorageServiceClient storageService = new StorageService1.StorageServiceClient();


            FileStream fs = File.Open(testFileToStore, FileMode.OpenOrCreate);

            string resultPath = storageService.uploadFile(fileName, fs);

            Assert.IsNotNull(resultPath);

            Console.WriteLine(resultPath);


        }
    }
}
