using System.Net;
using CustomerRewardsService.Controllers;
using CustomerRewardsService.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CustomerRewardsServiceTests.ControllerTest
{
    public class TransactionsControllerTests
    {
        private MockDataSet mockDataSet { get; set; }
        private TransactionsController TransactionsController { get; set; }

        [SetUp]
        public void Setup()
        {
            mockDataSet = new MockDataSet();
            TransactionsController = new TransactionsController(mockDataSet);

        }

        [Test]
        public void TransactionsControllerGetTransactions()
        {
            var rewards = TransactionsController.GetTransactions();
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.OK, actual.StatusCode);
        }

        [Test]
        public void TransactionsControllerGetTransactionsById()
        {
            var rewards = TransactionsController.GetTransactionByCustomerId("1");
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.OK, actual.StatusCode);
        }

        [Test]
        public void TransactionsControllerGetTransactionsByIdNotFound()
        {
            var rewards = TransactionsController.GetTransactionByCustomerId("test");
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.NotFound, actual.StatusCode);
        }
    }
}
