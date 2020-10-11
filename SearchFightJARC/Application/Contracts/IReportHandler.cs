using System;
using System.Collections.Generic;
using Domain;

namespace Application
{
    public interface IReportHandler
    {
        IList<string> ReportResultsByWord(IList<ResultsByWord> resultsByWords);
        IList<string> ReportResultsByService(IList<ResultsByWord> resultsByWords);
        IList<string> ReportResultsGeneral(IList<ResultsByWord> resultsbyWords);
        void PrintResults(IList<string> reportLines);
    }
}
