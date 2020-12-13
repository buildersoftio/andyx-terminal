using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Book
    {
        public static void ShowBook(string input)
        {
            if (input.StartsWith("book add"))
            {
                Console.WriteLine("");
                Console.WriteLine("Book");
                AddBookToAndyX(input);
                Console.WriteLine("");
            }
            else if (input.StartsWith("book view"))
            {
                Console.WriteLine("");
                Console.WriteLine("Book");
                ReadBookToAndyX(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Book");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'book' only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void AddBookToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];
                string bookName = tenantAndProduct[3];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Book : " + bookName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.CreateBook(url, tenantName, productName, componentName, bookName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'book' only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void ReadBookToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];
                string bookName = tenantAndProduct[3];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.GetBook(url, tenantName, productName, componentName, bookName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'book' only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
    }

}
