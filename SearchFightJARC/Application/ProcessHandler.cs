using System;
using System.Collections.Generic;
using Domain;
using System.Threading.Tasks;

namespace Application
{
    public static class ProcessHandler
    {
        public static async Task<IList<ResultsByWord>> RunProcess(IList<string> words)
        {
            IRequestHandler requestHandler = new RequestHandler();
            IReportHandler reportHandler = new ReportHandler();

            List<string> finalReport = new List<string>();
            IList<ResultsByWord> searchResult = await requestHandler.GetSearchResults(words);
            finalReport.AddRange(reportHandler.ReportResultsByWord(searchResult));
            finalReport.AddRange(reportHandler.ReportResultsByService(searchResult));
            finalReport.AddRange(reportHandler.ReportResultsGeneral(searchResult));           
            reportHandler.PrintResults(finalReport);

            return searchResult;
        }

    }
}
