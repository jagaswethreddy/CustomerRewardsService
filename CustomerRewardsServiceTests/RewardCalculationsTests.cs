using NUnit.Framework;
using CustomerRewardsService.Common.Interfaces;
using CustomerRewardsService.Common;
using CustomerRewardsService.Models;
using System.Collections.Generic;

namespace CustomerRewardsServiceTests
{
    public class RewardCalculationsTests
    {
        private IRewardCalculationsInterface mockRewardCalculation { get; set; }
        private List<Transaction> mokTransactions { get; set; }
        [SetUp]
        public void Setup()
        {
            mockRewardCalculation = new RewardCalculations();
        }

        [Test]
        public void CalculateSingelRewardUnderFifty()
        {
            int expected = 0;
            var actual = mockRewardCalculation.CalculateSingelReward(10);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateSingelRewardOverFiftyUnderHundred()
        {
            int expected = 15;
            var actual = mockRewardCalculation.CalculateSingelReward(65);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateSingelRewardOverHundred()
        {
            int expected = 90;
            var actual = mockRewardCalculation.CalculateSingelReward(120);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateTotalRewardsFirstMonth()
        {
            var expected = new Rewards { FirstMonthRewards = 90, TotalRewards = 90};
            mokTransactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionAmount = 120,
                    TransactionDate = System.DateTime.Now.AddDays(-10)
                }
            };
            var actual = mockRewardCalculation.CalculateTotalRewards(mokTransactions);
            Assert.AreEqual(expected.FirstMonthRewards, actual.FirstMonthRewards);
            Assert.AreEqual(expected.TotalRewards, actual.TotalRewards);
        }

        [Test]
        public void CalculateTotalRewardsSecondMonth()
        {
            var expected = new Rewards { SecondMonthRewards = 90, TotalRewards = 90 };
            mokTransactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionAmount = 120,
                    TransactionDate = System.DateTime.Now.AddMonths(-1).AddDays(-10)
                }
            };
            var actual = mockRewardCalculation.CalculateTotalRewards(mokTransactions);
            Assert.AreEqual(expected.SecondMonthRewards, actual.SecondMonthRewards);
            Assert.AreEqual(expected.TotalRewards, actual.TotalRewards);
        }

        [Test]
        public void CalculateTotalRewardsThirdMonth()
        {
            var expected = new Rewards { ThirdMonthRewards = 90, TotalRewards = 90 };
            mokTransactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionAmount = 120,
                    TransactionDate = System.DateTime.Now.AddMonths(-2).AddDays(-10)
                }
            };
            var actual = mockRewardCalculation.CalculateTotalRewards(mokTransactions);
            Assert.AreEqual(expected.ThirdMonthRewards, actual.ThirdMonthRewards);
            Assert.AreEqual(expected.TotalRewards, actual.TotalRewards);
        }

        [Test]
        public void CalculateTotalRewardsIgnoreOverThirdMonth()
        {
            var expected = new Rewards { ThirdMonthRewards = 90, TotalRewards = 90 };
            mokTransactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionAmount = 120,
                    TransactionDate = System.DateTime.Now.AddMonths(-2).AddDays(-10)
                },
                new Transaction()
                {
                    TransactionAmount = 120,
                    TransactionDate = System.DateTime.Now.AddMonths(-3).AddDays(-10)
                }
            };
            var actual = mockRewardCalculation.CalculateTotalRewards(mokTransactions);
            Assert.AreEqual(expected.ThirdMonthRewards, actual.ThirdMonthRewards);
            Assert.AreEqual(expected.TotalRewards, actual.TotalRewards);
        }

    }
}
