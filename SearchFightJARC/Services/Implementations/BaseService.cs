using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Services
{
    public class BaseService
    {
        public HttpClient _httpClient { get; }

        public BaseService()
        {
            _httpClient = new HttpClient();
        }

    }
}
