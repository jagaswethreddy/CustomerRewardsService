using System.Collections.Generic;
using System.Net;
using CustomerRewardsService.Common.Interfaces;
using CustomerRewardsService.Controllers;
using CustomerRewardsService.Data;
using CustomerRewardsService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CustomerRewardsServiceTests.ControllerTest
{
    public class CustomerRewardsControllerTests
    {
        private Mock<IRewardCalculationsInterface> mockRewardCalculation { get; set; }
        private MockDataSet mockDataSet { get; set; }
        private CustomerRewardsController CustomerRewardsController { get; set; }

        [SetUp]
        public void Setup()
        {
            mockRewardCalculation = new Mock<IRewardCalculationsInterface>();
            mockRewardCalculation.Setup(x => x.CalculateTotalRewards(It.IsAny<List<Transaction>>())).Returns(new Rewards());
            var mockTable = new Dictionary<string, List<Transaction>>();
            mockTable.Add("2", new List<Transaction>() {
                new Transaction() { TransactionAmount = 10, TransactionDate = System.DateTime.Today } });
            mockDataSet = new MockDataSet();
            CustomerRewardsController = new CustomerRewardsController(mockDataSet, mockRewardCalculation.Object);

        }

        [Test]
        public void CalculateControllerGetAllRewards()
        {
            var rewards = CustomerRewardsController.GetAllRewards();
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.OK, actual.StatusCode);
        }

        [Test]
        public void CalculateControllerGetAllRewardsBadRequest()
        {
            mockRewardCalculation.Setup(x => x.CalculateTotalRewards(It.IsAny<List<Transaction>>())).
                Throws(new System.Exception("Test Exception"));
            CustomerRewardsController = new CustomerRewardsController(mockDataSet, mockRewardCalculation.Object);
            var rewards = CustomerRewardsController.GetAllRewards();
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, actual.StatusCode);
        }

        [Test]
        public void CalculateControllerGetRewardsById()
        {
            var rewards = CustomerRewardsController.GetRewardsById("1");
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.OK, actual.StatusCode);
        }

        [Test]
        public void CalculateControllerGetRewardsByIdBadRequest()
        {
            mockRewardCalculation.Setup(x => x.CalculateTotalRewards(It.IsAny<List<Transaction>>())).
                Throws(new System.Exception("Test Exception"));
            CustomerRewardsController = new CustomerRewardsController(mockDataSet, mockRewardCalculation.Object);
            var rewards = CustomerRewardsController.GetRewardsById("1");
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, actual.StatusCode);
        }

        [Test]
        public void CalculateControllerGetRewardsByIdNotFound()
        {
            var rewards = CustomerRewardsController.GetRewardsById("test");
            var actual = rewards as ObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual((int)HttpStatusCode.NotFound, actual.StatusCode);
        }
    }
}
