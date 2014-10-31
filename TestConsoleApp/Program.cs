using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "test.txt";
            string testFileToStore = "C:\\Users\\John\\Desktop\\" + fileName;
            StorageService.StorageServiceClient storageService = new StorageService.StorageServiceClient();


        }
    }
}
