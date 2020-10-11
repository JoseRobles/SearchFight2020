using System.Configuration;

namespace Services
{
    public class BaseConfiguration
    {
        public static string GetValueFromAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
