using System;
using System.Collections.Generic;
using System.Linq;
using CustomerRewardsService.Common.Interfaces;
using CustomerRewardsService.Models;

namespace CustomerRewardsService.Common
{
    public class RewardCalculations : IRewardCalculationsInterface
    {
        /// <summary>
        /// Calculate total rewards for single transaction
        /// </summary>
        /// <param name="transactionAmount"></param>
        /// <returns></returns>
        public int CalculateSingelReward(decimal transactionAmount)
        {
            if(transactionAmount <= 50)
            {
                return 0;
            }
            else if(transactionAmount > 50 && transactionAmount <= 100)
            {
                return (int)Math.Abs(transactionAmount - 50);
            }
            else
            {
                return (int)(2 * Math.Abs(transactionAmount - 100) + 50);
            }
        }

        /// <summary>
        /// Calculate total rewards from past 90 days
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public Rewards CalculateTotalRewards(List<Transaction> transactions)
        {
            var rewards = new Rewards() { FirstMonthRewards = 0, SecondMonthRewards = 0, ThirdMonthRewards = 0, TotalRewards = 0 };
            var totalValidTransactions = transactions.Where(x => (x.TransactionDate - DateTime.Now).TotalDays <= 90
            && x.TransactionDate <= DateTime.Now).Select(x => x);
            if(totalValidTransactions != null && totalValidTransactions.Any())
            {
                //filter transaction from past 30 day
                var firstMonthTransactions = transactions.Where(x => (DateTime.Now - x.TransactionDate).TotalDays <= 30)
                    .Select(x => x.TransactionAmount);
                if(firstMonthTransactions!= null && firstMonthTransactions.Any())
                {
                    foreach(var amount in firstMonthTransactions)
                    {
                        rewards.FirstMonthRewards += CalculateSingelReward(amount);
                    }
                }
                //filter transaction detween past 30 to 60 days
                var secondMonthTransactions = transactions.Where(x => (DateTime.Now - x.TransactionDate).TotalDays > 30
                && (DateTime.Now - x.TransactionDate).TotalDays <= 60).Select(x => x.TransactionAmount);
                if (secondMonthTransactions != null && secondMonthTransactions.Any())
                {
                    foreach (var amount in secondMonthTransactions)
                    {
                        rewards.SecondMonthRewards += CalculateSingelReward(amount);
                    }
                }

                //filter transaction detween past 60 to 90 days
                var thirdMonthTransactions = transactions.Where(x => (DateTime.Now - x.TransactionDate).TotalDays > 60
                && (DateTime.Now - x.TransactionDate).TotalDays <= 90).Select(x => x.TransactionAmount);
                if (thirdMonthTransactions != null && thirdMonthTransactions.Any())
                {
                    foreach (var amount in thirdMonthTransactions)
                    {
                        rewards.ThirdMonthRewards += CalculateSingelReward(amount);
                    }
                }
            }
            //total rewards combining first, second, third months
            rewards.TotalRewards = rewards.FirstMonthRewards + rewards.SecondMonthRewards + rewards.ThirdMonthRewards;
            return rewards;
        }
    }
}
