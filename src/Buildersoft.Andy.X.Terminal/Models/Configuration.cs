using System;
using System.Collections.Generic;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Models
{
    public class Configuration
    {
        public List<Node> Nodes { get; set; }

        public Configuration()
        {
            Nodes = new List<Node>();
        }
    }

    public class Node
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tenant { get; set; }
        public string Token { get; set; }
    }
}
