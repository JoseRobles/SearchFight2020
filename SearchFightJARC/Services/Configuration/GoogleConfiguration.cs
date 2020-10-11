using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GoogleConfiguration
    {
        public static string apiURL = BaseConfiguration.GetValueFromAppConfig("GoogleUrl");
        public static string apiKey = BaseConfiguration.GetValueFromAppConfig("GoogleApiKey");
        public static string CustomId = BaseConfiguration.GetValueFromAppConfig("GoogleCustomSearchID");
    }
}
