using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Services;

namespace Application
{
    public class RequestHandler: IRequestHandler
    {
        private IList<IService> _searchProviders;

        public RequestHandler()
        {
            _searchProviders = GetImplementedSearchProvider();
        }

        public IList<IService> GetImplementedSearchProvider()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
             .Where(x => typeof(IService).IsAssignableFrom(x) && !x.IsInterface)
             .Select(type => Activator.CreateInstance(type) as IService).ToList();
        }

        public async Task<IList<ResultsByWord>> GetSearchResults(IList<string> listOfWords)
        {
            if (listOfWords == null || listOfWords.Count() == 0)
                throw new ArgumentException("The parameter is invalid.");

            IList<ResultsByWord> results = new List<ResultsByWord>();

            foreach (IService service in _searchProviders)
            {
                foreach (string word in listOfWords)
                {
                    results.Add(new ResultsByWord
                    {
                        Service = service.ToString().Replace("Services.",""),
                        Word = word,
                        ResultCount = await service.GetResults(word)
                    });
                }
            }

            return results;
        }

        
    }
}
