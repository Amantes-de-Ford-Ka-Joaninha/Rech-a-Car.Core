using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace ConfigurationManager
{
    public class AppConfigManager
    {
        protected static string pathAppConfig = @$"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\appsettings.json";

        protected static void Save(JObject newAppConfig)
        {
            File.WriteAllText(pathAppConfig, JsonConvert.SerializeObject(newAppConfig));
        }
        public static JObject AppConfig => JObject.Parse(File.ReadAllText(pathAppConfig));
    }
}