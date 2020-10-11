using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public class ReportHandler: IReportHandler
    {
        public IList<string> ReportResultsByWord(IList<ResultsByWord> resultsByWords)
        {
            if (resultsByWords == null || resultsByWords.Count == 0)
                throw new ArgumentException("There are no results");

            return resultsByWords.GroupBy(item => item.Word)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.Service}: {item.ResultCount}"))}")
                .ToList();
        }

        public IList<string> ReportResultsByService(IList<ResultsByWord> resultsByWords)
        {
            if (resultsByWords == null || resultsByWords.Count == 0)
                throw new ArgumentException("There are no results");

            return resultsByWords.GroupBy(results => results.Service).SelectMany(a => a.Where(b => b.ResultCount == a.Max(c => c.ResultCount))).Select(item => $"Winner in {item.Service}: {item.Word}").ToList();
        }

        public IList<string> ReportResultsGeneral(IList<ResultsByWord> resultsByWords)
        {
            if (resultsByWords == null || resultsByWords.Count == 0)
                throw new ArgumentException("There are no results");

            return resultsByWords.OrderByDescending(item => item.ResultCount).Take(1).Select(item => $"Total Winner: {item.Word}").ToList();
        }

        public void PrintResults(IList<string> reportLines)
        {
            foreach (string line in reportLines)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }

    }
}
