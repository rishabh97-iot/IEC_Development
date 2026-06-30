using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC.Shared.Models;
using System.IO;
using System.Text.Json;

namespace IEC.Shared.Services
{
    public class ConfigurationManagerService
    {
        private readonly string _configFile =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                         "Configuration",
                         "ProjectConfig.json");

        public ProjectConfiguration Configuration { get; private set; }

        public ConfigurationManagerService()
        {
            Load();
        }

        //-------------------------------------------------------

        public void Load()
        {
            if (!File.Exists(_configFile))
            {
                Configuration = CreateDefaultConfiguration();
                Save();
                return;
            }

            string json = File.ReadAllText(_configFile);

            Configuration =
                JsonSerializer.Deserialize<ProjectConfiguration>(json)
                ?? CreateDefaultConfiguration();
        }

        //-------------------------------------------------------

        public void Save()
        {
            string folder = Path.GetDirectoryName(_configFile)!;

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string json =
                JsonSerializer.Serialize(Configuration, options);

            File.WriteAllText(_configFile, json);
        }

        //-------------------------------------------------------

        private ProjectConfiguration CreateDefaultConfiguration()
        {
            return new ProjectConfiguration();
        }
    }
}
