using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BingConfiguration
    {
        public static string apiURL = BaseConfiguration.GetValueFromAppConfig("BingUrl");
        public static string apiKey = BaseConfiguration.GetValueFromAppConfig("BingApiKey");
    }
}
