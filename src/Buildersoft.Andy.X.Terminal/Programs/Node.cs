using Buildersoft.Andy.X.Terminal.Repositories;
using Buildersoft.Andy.X.Terminal.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Programs
{
    public static class Node
    {
        public static void ShowNodes(string input, ConfigurationRepository configurationRepo)
        {
            if (input.StartsWith("node list"))
            {
                Console.WriteLine("Nodes registered are in the list below");
                int i = 0;
                foreach (var node in configurationRepo.Configuration.Nodes)
                {
                    Console.WriteLine($"[{i}] >> Name [{node.Name}]; Tenant [{node.Tenant}]; Url [{node.Url}]");
                    i++;
                }

                Console.Write("\nDo you want to connect to a node (y/N): ");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("Select index of the node above: ");
                    int indexSelected = Convert.ToInt32(Console.ReadLine());
                    if (indexSelected < configurationRepo.Configuration.Nodes.Count)
                    {
                        Hosts.CurrentNodeName = configurationRepo.Configuration.Nodes[indexSelected].Name;
                        Hosts.CurrentHostUrl = configurationRepo.Configuration.Nodes[indexSelected].Url;
                        Hosts.CurrentToken = configurationRepo.Configuration.Nodes[indexSelected].Token;
                        Hosts.CurrentTenant = configurationRepo.Configuration.Nodes[indexSelected].Tenant;
                    }
                }
            }
            else if (input.StartsWith("node select"))
            {
                string[] inputSplitted = input.Split(" ");
                if (inputSplitted.Length > 2)
                {
                    int selectedIndex = Convert.ToInt32(inputSplitted[2]);
                    if (selectedIndex < configurationRepo.Configuration.Nodes.Count)
                    {
                        Hosts.CurrentNodeName = configurationRepo.Configuration.Nodes[selectedIndex].Name;
                        Hosts.CurrentHostUrl = configurationRepo.Configuration.Nodes[selectedIndex].Url;
                        Hosts.CurrentToken = configurationRepo.Configuration.Nodes[selectedIndex].Token;
                        Hosts.CurrentTenant = configurationRepo.Configuration.Nodes[selectedIndex].Tenant;
                    }
                }
                else
                    Console.WriteLine("\nThere is no node registered with this index\n");
            }
            else if (input.StartsWith("node edit"))
            {
                Console.WriteLine("Nodes registered are in the list below");
                int i = 0;
                foreach (var node in configurationRepo.Configuration.Nodes)
                {
                    Console.WriteLine($"[{i}] >> Name [{node.Name}]; Tenant [{node.Tenant}]; Url [{node.Url}]");
                    i++;
                }
                Console.Write("\nSelect index of node you want to update: ");
                int selectedIndex = Convert.ToInt32(Console.ReadLine());
                if (selectedIndex < configurationRepo.Configuration.Nodes.Count)
                {
                    Console.WriteLine($"Name: [read-only] {configurationRepo.Configuration.Nodes[selectedIndex].Name}");
                    Console.WriteLine($"Url: [read-only] {configurationRepo.Configuration.Nodes[selectedIndex].Url}");
                    Console.WriteLine($"Tenant: [read-only] {configurationRepo.Configuration.Nodes[selectedIndex].Tenant}");

                    Console.Write("Token: ");
                    configurationRepo.Configuration.Nodes[selectedIndex].Token = Console.ReadLine();

                    configurationRepo.EditNode();
                    Console.WriteLine("Node has been updated, please re-select it!");
                }
                else
                {
                    Console.WriteLine($"Node with index {selectedIndex} does not exists");
                }
            }
            else if (input.StartsWith("node delete"))
            {
                Console.WriteLine("Nodes registered are in the list below");
                int i = 0;
                foreach (var node in configurationRepo.Configuration.Nodes)
                {
                    Console.WriteLine($"[{i}] >> Name [{node.Name}]; Tenant [{node.Tenant}]; Url [{node.Url}]");
                    i++;
                }
                Console.Write("\nSelect index of node you want to delete: ");
                int selectedIndex = Convert.ToInt32(Console.ReadLine());
                if (selectedIndex < configurationRepo.Configuration.Nodes.Count)
                {
                    Console.Write($"Do you want to delete {configurationRepo.Configuration.Nodes[selectedIndex].Name}? (y/N): ");
                    if (Console.ReadLine() == "y")
                    {
                        configurationRepo.DeleteNode(configurationRepo.Configuration.Nodes[selectedIndex]);
                        Console.WriteLine("\nNode has been remove");
                    }
                }
            }
            else if (input.StartsWith("node add"))
            {
                Models.Node node = new Models.Node();
                Console.WriteLine("");
                Console.WriteLine("Write node properties");

                Console.Write("Name: ");
                node.Name = Console.ReadLine();
                Console.Write("Url: https://");
                node.Url = Console.ReadLine();
                Console.Write("Tenant: ");
                node.Tenant = Console.ReadLine();
                Console.Write("Token: ");
                node.Token = Console.ReadLine();

                configurationRepo.AddNode(node);
                Console.WriteLine($"Node {node.Name} has been registered");
            }
            else if (input.StartsWith("node detail"))
            {
                Console.WriteLine("");
                Console.WriteLine("Node you are connected to is:");
                Console.WriteLine($"Node name: {Web.Hosts.CurrentNodeName}");
                Console.WriteLine($"Node url: {Web.Hosts.CurrentHostUrl}");
                Console.WriteLine($"Node token: {Web.Hosts.CurrentToken}");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Node");
                Console.WriteLine("");

                Console.WriteLine($"Your command: {input}");
                Console.WriteLine("For 'node' only these functions are allowed 'list', 'edit', 'add', 'delete', 'select' and 'detail'");
                Console.WriteLine("");
            }
        }
    }
}
