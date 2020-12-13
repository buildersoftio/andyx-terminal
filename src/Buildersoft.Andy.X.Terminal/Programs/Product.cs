using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Product
    {
        public static void ShowProduct(string input)
        {
            if (input.StartsWith("product add"))
            {
                Console.WriteLine("");
                Console.WriteLine("Product");
                AddProductToAndyX(input);
                Console.WriteLine("");
            }
            else if (input.StartsWith("product view"))
            {
                Console.WriteLine("");
                Console.WriteLine("Product");
                ReadProductToAndyX(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Product");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For product only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void AddProductToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.CreateProduct(url, tenantName, productName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For product only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void ReadProductToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + inputSplitted[2]);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.GetProduct(url, tenantName, productName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For product only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
    }

}
