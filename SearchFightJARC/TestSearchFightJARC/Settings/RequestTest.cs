using System;
using System.Collections.Generic;
using Domain;
using Application;
using System.Threading.Tasks;

namespace TestSearchFightJARC
{
    public class RequestTest: IRequestHandler
    {

        public async Task<IList<ResultsByWord>> GetSearchResults(IList<string> listOfWords)
        {
            IList<ResultsByWord> listResults = new List<ResultsByWord>
            {
                new ResultsByWord { Word = ".net", Service = "Google", ResultCount = 2500000 },
                new ResultsByWord { Word = "java", Service = "Google", ResultCount = 170000 },
                new ResultsByWord { Word = "php", Service = "Google", ResultCount = 16000000 },
                new ResultsByWord { Word = ".net", Service = "Bing", ResultCount = 999920000 },
                new ResultsByWord { Word = "java", Service = "Bing", ResultCount = 190000 },
                new ResultsByWord { Word = "php", Service = "Bing", ResultCount = 990000 }
            };

            return await Task.FromResult(listResults);
        }
    }
}
