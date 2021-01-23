using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Schema
    {
        public static void ShowSchema(string input)
        {
            if (input.StartsWith("schema view"))
            {
                Console.WriteLine("");
                Console.WriteLine("Book");
                ReadSchemaFromAndyX(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Schema");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'schema' only a function is allowed 'view'");
                Console.WriteLine("");
            }
        }

        private static void ReadSchemaFromAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];
                string bookName = tenantAndProduct[3];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName + "/schema";
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName + "/books/" + bookName + "/schema";

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.GetSchema(url, tenantName, productName, componentName, bookName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'schema' only a functions is allowed 'view'");
                Console.WriteLine("");
            }
        }
    }
}
