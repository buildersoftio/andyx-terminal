using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Tenant
    {
        public static void ShowTenant(string input)
        {
            if (input.StartsWith("tenant add"))
            {
                Console.WriteLine("");
                Console.WriteLine("Tenant");
                AddTenantToAndyX(input);
                Console.WriteLine("");
            }
            else if (input.StartsWith("tenant view"))
            {
                Console.WriteLine("");
                Console.WriteLine("Tenant");
                ReadTenantToAndyX(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Tenant");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For tenant only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }

        private static void AddTenantToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + inputSplitted[2];
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + inputSplitted[2];

                Console.WriteLine("Tenant : " + inputSplitted[2]);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.CreateTenant(url, inputSplitted[2]);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For tenant only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
        private static void ReadTenantToAndyX(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string andyxUrl = "andyx://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + inputSplitted[2];
                string host = Web.Hosts.CurrentHostUrl;
                string url = "https://" + Web.Hosts.CurrentHostUrl + "/api/v1/Tenants/" + inputSplitted[2];

                Console.WriteLine("Tenant : " + inputSplitted[2]);
                Console.WriteLine("Host : " + host);
                Console.WriteLine("API Version : BuilderSoft Andy X Api Preview");
                Console.WriteLine("Url : " + andyxUrl);
                Web.HttpRequests.GetTenant(url, inputSplitted[2]);
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For tenant only two functions are allowed 'add' and 'view'");
                Console.WriteLine("");
            }
        }
    }
}
