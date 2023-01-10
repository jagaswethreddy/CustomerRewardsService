
using System.Collections.Generic;

namespace CustomerRewardsService.Models
{
    public class CustomerTransactions
    {
        public string CustomerID { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
