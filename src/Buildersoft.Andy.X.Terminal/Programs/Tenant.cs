using Buildersoft.Andy.X.Terminal.Repositories;
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
            else if (input.StartsWith("tenant authorize"))
            {
                Console.WriteLine("");
                Console.WriteLine("Tenant");
                AuthorizeTenant(input);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Tenant");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("Tenant accepts functions like 'add', 'view', 'authorize'");
                Console.WriteLine("");
            }
        }

        private static void AuthorizeTenant(string input)
        {
            string[] inputSplitted = input.Split(" ");
            if (inputSplitted.Length > 2)
            {
                string tenantName = inputSplitted[2];
                if (tenantName == Web.Hosts.CurrentTenant)
                {
                    string url = $"https://{Web.Hosts.CurrentHostUrl}/api/v1/Tenants/{tenantName}/access_token";


                    Console.WriteLine($"Tenant: {tenantName}");
                    Console.Write("Tenant id: ");
                    string tenantId = Console.ReadLine();
                    Console.Write("Security key: ");
                    string securityKey = Console.ReadLine();

                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("Requesting token");
                    Web.HttpRequests.AuthorizeTenant(url, tenantName, tenantId, securityKey);
                }
                else
                {
                    Console.WriteLine($"Your command: {input}");
                    Console.WriteLine("You cannot authorize other tenants, create a node for that specific tenant and try again.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("Tenant accepts functions like 'add', 'view', 'authorize'");
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
                Console.WriteLine("Tenant accepts functions like 'add', 'view', 'authorize'");
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
                Console.WriteLine("Tenant accepts functions like 'add', 'view', 'authorize'");
                Console.WriteLine("");
            }
        }
    }
}
