using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Component
    {
        public static void ShowComponent(string input)
        {
            if (input.StartsWith("component add"))
            {
                Console.WriteLine("");
                Console.WriteLine("Component");
                AddComponentToAndyX(input);
                Console.WriteLine("");
            }
            else if (input.StartsWith("component view"))
            {
                Console.WriteLine("");
                Console.WriteLine("Component");
                ReadComponentToAndyX(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Component");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For component only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void AddComponentToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.CreateComponent(url, tenantName, productName, componentName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For component only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void ReadComponentToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string[] tenantAndProduct = inputSplitted[2].Split('/');
                string tenantName = tenantAndProduct[0];
                string productName = tenantAndProduct[1];
                string componentName = tenantAndProduct[2];

                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName;
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + tenantName + "/products/" + productName + "/components/" + componentName;

                Console.WriteLine("Tenant : " + tenantName);
                Console.WriteLine("Product : " + productName);
                Console.WriteLine("Component : " + componentName);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.GetComponent(url, tenantName, productName, componentName);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For component only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
    }

}
