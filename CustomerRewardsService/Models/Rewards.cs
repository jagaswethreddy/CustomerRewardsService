using System;
namespace CustomerRewardsService.Models
{
    public class Rewards
    {
       public string CustomerID { get; set; }
       public int FirstMonthRewards { get; set; }
       public int SecondMonthRewards { get; set; }
       public int ThirdMonthRewards { get; set; }
       public int TotalRewards { get; set; }
    }
}
