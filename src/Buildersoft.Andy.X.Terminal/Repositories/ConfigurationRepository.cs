using Buildersoft.Andy.X.Terminal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Buildersoft.Andy.X.Terminal.Repositories
{
    public class ConfigurationRepository
    {
        public Configuration Configuration;
        public ConfigurationRepository()
        {
            LoadDataFromFileConfig();
        }

        private void LoadDataFromFileConfig()
        {
            string configDirectory = Path.GetDirectoryName(AppContext.BaseDirectory);
            if (!Directory.Exists(configDirectory))
                Directory.CreateDirectory(configDirectory);
            string configFile = Path.Combine(configDirectory, "config.json");

            if (!File.Exists(configFile))
                File.WriteAllText(configFile, Newtonsoft.Json.JsonConvert.SerializeObject(new Configuration()));

            Configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configFile));
        }

        public void AddNode(Node node)
        {
            Configuration.Nodes.Add(node);
            StoreInToFile();
        }

        public void EditNode()
        {
            StoreInToFile();
        }

        private void StoreInToFile()
        {
            string configDirectory = Path.GetDirectoryName(AppContext.BaseDirectory);
            string configFile = Path.Combine(configDirectory, "config.json");

            File.WriteAllText(configFile, Newtonsoft.Json.JsonConvert.SerializeObject(Configuration));
        }
    }
}
