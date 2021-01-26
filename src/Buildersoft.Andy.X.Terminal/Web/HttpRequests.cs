using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Web
{
    public static class HttpRequests
    {
        public static void CreateTenant(string url, string tenantName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            Console.WriteLine("Adding tenant...");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, null).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine();
                Console.WriteLine($"'{tenantName}' is registered as tenant");
                Console.WriteLine();

                Console.WriteLine($"Details of tenant are below");
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void GetTenant(string url, string tenantName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine($"Details of tenant:");
                Console.WriteLine();
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"This tenant '{tenantName}' does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void AuthorizeTenant(string url, string tenantName, string tenantId, string securityKey)
        {
            HttpClient client = new HttpClient();
            string bodyJson = "{\"tenantId\": \"" + tenantId + "\", \"securityKey\": \"" + securityKey + "\"}";
            var body = new StringContent(bodyJson, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = client.PostAsync(url, body).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);
                Console.WriteLine($"Details of Tenant authorization are below");
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Failed to create token for {tenantName}, please check tenantId and securityKey");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }

        }


        public static void CreateProduct(string url, string tenantName, string productName)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            Console.WriteLine("Adding product...");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, null).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine();
                Console.WriteLine($"'{productName}' is registered as product in {tenantName} tenant");
                Console.WriteLine();

                Console.WriteLine($"Details of product are below");
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Tenant {tenantName} does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void GetProduct(string url, string tenantName, string productName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine($"Details of product:");
                Console.WriteLine();
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"This product '{productName}' does not exists in {tenantName} tenant");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }

        public static void CreateComponent(string url, string tenantName, string productName, string componentName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            Console.WriteLine("Adding component...");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, null).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine();
                Console.WriteLine($"'{componentName}' is registered as component in {productName} product");
                Console.WriteLine();

                Console.WriteLine($"Details of component are below");
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Tenant {tenantName} or product {productName} does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void GetComponent(string url, string tenantName, string productName, string componentName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine($"Details of component:");
                Console.WriteLine();
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"This component '{componentName}' does not exists in '{productName}' product");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void CreateBook(string url, string tenantName, string productName, string componentName, string bookName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            Console.WriteLine("Adding book...");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, null).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);

                Console.WriteLine();
                Console.WriteLine($"'{bookName}' is registered as book in {componentName} component");
                Console.WriteLine();

                Console.WriteLine($"Details of book are below");
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Tenant '{tenantName}' or product '{productName}' or component '{componentName}' does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void GetBook(string url, string tenantName, string productName, string componentName, string bookName)
        {


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);
                Console.WriteLine($"Details of book:");
                Console.WriteLine();
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Tenant '{tenantName}' or product '{productName}' or component '{componentName}' does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }
        public static void GetSchema(string url, string tenantName, string productName, string componentName, string bookName)
        {


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-andy-x-tenant-Authorization", $"Bearer {Hosts.CurrentToken}");
            client.DefaultRequestHeaders.Add("x-andy-x-tenant", tenantName);

            HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonContent = JObject.Parse(content);
                Console.WriteLine($"Schema of {bookName}:");
                Console.WriteLine();
                Console.WriteLine(jsonContent);
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Tenant '{tenantName}' or product '{productName}' or component '{componentName}' does not exists");
                Console.WriteLine("# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #");
                Console.WriteLine();
            }
        }

    }

}
