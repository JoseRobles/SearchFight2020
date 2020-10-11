using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services
{
    public class Google : BaseService, IService
    {
        public Google(): base()
        {
        }

        public async Task<long> GetResults(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Word is invalid.", nameof(word));

            string searchURL = GoogleConfiguration.apiURL.Replace("{KEY}", GoogleConfiguration.apiKey)
                .Replace("{CX}", GoogleConfiguration.CustomId)
                .Replace("{WORD}", word);

            using (var response = await base._httpClient.GetAsync(searchURL))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Search Provider is unavailable");

                var deserializedResult = JsonHelper.Deserialize<GoogleResponse>(await response.Content.ReadAsStringAsync());
                
                return deserializedResult.SearchInformation.TotalResults;
           }


        }
    }
}
