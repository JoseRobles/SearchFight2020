using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Application;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestSearchFightJARC
{
    [TestClass]
    public class ReportTests
    {
        private IReportHandler _reportHandler;
        private IRequestHandler _serviceTest;

        public ReportTests()
        {
            _reportHandler = new ReportHandler();
            _serviceTest = new RequestTest();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetResults_NoWords()
        {
            _reportHandler.ReportResultsByWord(null);
        }

        [TestMethod]
        public async Task TestReportByWordAsync_NotEmpty()
        {
            Assert.IsNotNull(_reportHandler.ReportResultsByWord(await _serviceTest.GetSearchResults(null)));
        }

        [TestMethod]
        public async Task TestReportByService_NotEmpty()
        {
            Assert.IsNotNull(_reportHandler.ReportResultsByService(await _serviceTest.GetSearchResults(null)));
        }

        [TestMethod]
        public async Task TestGeneralReport_NotEmpty()
        {
            Assert.IsNotNull(_reportHandler.ReportResultsGeneral(await _serviceTest.GetSearchResults(null)));
        }

        [TestMethod]
        public async Task TestReportByService_CorrectAnswer()
        {
            Assert.IsTrue(_reportHandler.ReportResultsByService(await _serviceTest.GetSearchResults(null))[0].ToString() == $"Winner in Google: php");
        }

        [TestMethod]
        public async Task TestGeneralReport_CorrectAnswer()
        {
            Assert.IsTrue(_reportHandler.ReportResultsGeneral(await _serviceTest.GetSearchResults(null))[0].ToString() == $"Total Winner: .net");
        }

    }
}
