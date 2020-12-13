using Buildersoft.Andy.X.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Web
{
    public static class ReaderRequests
    {
        public static void ListenToReader(string url, string andyUrl, string tenantName, string productName, string componentName, string bookName, string readerName, string readerType)
        {
            AndyXClient andyXClient = new AndyXClient(url)
                .Tenant(tenantName)
                .Product(productName)
                .Token(Web.Hosts.CurrentToken);

            Reader<Object> reader = new Reader<Object>(andyXClient.GetClient())
                .Component(componentName)
                .Book(bookName)
                .ReaderName(readerName)
                .ReaderType((Client.Model.ReaderTypes)Enum.Parse(typeof(Client.Model.ReaderTypes), readerType)).Build();

            reader.MessageReceived += Reader_OnReceive;

            Console.WriteLine($"[click any key to stop listening to {andyUrl}]");

            reader.StartReadingAsync();
            Console.ReadKey(true);
            reader.StopReading("Stopped by client");

        }

        private static void Reader_OnReceive(object sender, Client.Model.MessageEventArgs e)
        {
            Console.WriteLine("----- got message -----");
            Console.WriteLine(e.Data.ToString());
            Console.WriteLine();
        }
    }

}
