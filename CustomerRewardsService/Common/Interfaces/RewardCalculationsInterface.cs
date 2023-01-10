using System;
using System.Collections.Generic;
using CustomerRewardsService.Models;

namespace CustomerRewardsService.Common.Interfaces
{
    public interface IRewardCalculationsInterface
    {
        Rewards CalculateTotalRewards(List<Transaction> transactions);
        int CalculateSingelReward(decimal transactionAmount);
    }
}
