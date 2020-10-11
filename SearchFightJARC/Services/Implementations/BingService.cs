using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services
{
    public class Bing : BaseService, IService
    {
        public Bing() : base()
        {
        }

        public async Task<long> GetResults(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Word is invalid.", nameof(word));

            base._httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", BingConfiguration.apiKey);
            string searchURL = BingConfiguration.apiURL.Replace("{WORD}", word);

            using (var response = await base._httpClient.GetAsync(searchURL))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Search Provider is unavailable");
                var deserializedResult = JsonHelper.Deserialize<BingResponse>(await response.Content.ReadAsStringAsync());

                return deserializedResult.WebPages.TotalEstimatedMatches;
            }
        }
    }
}
