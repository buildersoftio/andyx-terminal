using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Reader
    {
        public static void StartReading(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];
                string bookName = tenantAndProduct[3];
                string readerName = tenantAndProduct[4];
                string readerType = tenantAndProduct[5];

                string andyxUrl = $"andyx-persistent://{tenantName}/{productName}/{componentName}/{bookName}/readers/{readerName}/{readerType}";
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Book : " + bookName);
                Console.WriteLine("Reader : " + readerName);
                Console.WriteLine("Reading Type : " + readerType);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X RealTime Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Console.WriteLine("");
                Web.ReaderRequests.ListenToReader(url, andyxUrl, tenantName, productName, componentName, bookName, readerName, readerType);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'reader' only one function is allowed 'listen'");
                Console.WriteLine("");
            }
        }
    }

}
