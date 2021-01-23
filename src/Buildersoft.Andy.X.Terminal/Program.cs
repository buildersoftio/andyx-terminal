using Buildersoft.Andy.X.Terminal.Programs;
using Buildersoft.Andy.X.Terminal.Repositories;
using System;

namespace Buildersoft.Andy.X.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Buildersoft Andy X Terminal");
            Console.WriteLine("(c) 2021 Buildersoft. All rights reserved.");
            Console.Title = "Buildersoft Andy X Terminal";

            var configurationRepo = new ConfigurationRepository();
            while (true)
            {
                Console.Write($"andyx [{Web.Hosts.CurrentNodeName}] >> ");
                string input = Console.ReadLine();
                if (input.StartsWith("help"))
                    Help.ShowHelp();

                else if (input.StartsWith("about"))
                    Help.ShowAbout();

                else if (input.StartsWith("tenant"))
                    Tenant.ShowTenant(input);

                else if (input.StartsWith("product"))
                    Product.ShowProduct(input);

                else if (input.StartsWith("component"))
                    Component.ShowComponent(input);

                else if (input.StartsWith("book"))
                    Book.ShowBook(input);

                else if (input.StartsWith("schema"))
                    Schema.ShowSchema(input);

                else if (input.StartsWith("reader"))
                    Reader.StartReading(input);

                else if (input.StartsWith("node"))
                    Node.ShowNodes(input, configurationRepo);

                else if (input.StartsWith("clear") || input == "cls")
                    Console.Clear();

                else if (input.StartsWith("exit"))
                    Environment.Exit(0);
                else
                {
                    if (input != "")
                        Console.WriteLine($"'{input}' is not recognized as a function. \nTry 'help' to learn the functions.\n");
                }
            }
        }
    }
}
