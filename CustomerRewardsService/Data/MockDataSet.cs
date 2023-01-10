using System;
using System.Collections.Generic;
using CustomerRewardsService.Models;

namespace CustomerRewardsService.Data
{
    public class MockDataSet
    {
        public List<CustomerTransactions> transactions { get; set; }
        public IDictionary<string, List<Transaction>> transactionTable { get; set; }
        public MockDataSet()
        {
            transactions = BuildMockTransactions();
            transactionTable = new Dictionary<string, List<Transaction>>();
            BuildDataTable();
        }

        private List<CustomerTransactions> BuildMockTransactions()
        {
            return new List<CustomerTransactions>()
            {
                new CustomerTransactions(){CustomerID = "1",
                   Transactions = new List<Transaction>(){
                       new Transaction() { TransactionAmount = 51, TransactionDate = new DateTime(2022, 12, 31) },
                       new Transaction() { TransactionAmount = 101, TransactionDate = new DateTime(2023, 01, 7)},
                       new Transaction() { TransactionAmount = 5, TransactionDate = new DateTime(2022, 12, 15)},
                       new Transaction() { TransactionAmount = 120, TransactionDate = new DateTime(2022, 11, 16) },
                       new Transaction() { TransactionAmount = 80, TransactionDate = new DateTime(2021, 12, 31) },
                   }
                },
                 new CustomerTransactions(){CustomerID = "2",
                   Transactions = new List<Transaction>(){
                       new Transaction() { TransactionAmount = 51, TransactionDate = new DateTime(2022, 12, 31)},
                       new Transaction() { TransactionAmount = 131, TransactionDate = new DateTime(2022, 12, 31)},
                       new Transaction() { TransactionAmount = 10, TransactionDate = new DateTime(2023, 01, 05)}
                   }
                },
                 new CustomerTransactions(){CustomerID = "3",
                   Transactions = new List<Transaction>(){
                       new Transaction() { TransactionAmount = 78, TransactionDate = new DateTime(2022, 12, 31)},
                       new Transaction() { TransactionAmount = 100, TransactionDate = new DateTime(2022, 11, 10)}
                   }
                },
                 new CustomerTransactions(){CustomerID = "4",
                   Transactions = new List<Transaction>(){
                       new Transaction() { TransactionAmount = 120, TransactionDate = new DateTime(2022, 12, 31)}
                   }
                },
                 new CustomerTransactions(){CustomerID = "5",
                   Transactions = new List<Transaction>(){
                       new Transaction() { TransactionAmount = 145, TransactionDate = new DateTime(2022, 12, 31)}
                   }
                }

            };
        }

        private void BuildDataTable()
        {
            foreach(var transaction in transactions)
            {
                if (!transactionTable.ContainsKey(transaction.CustomerID))
                {
                    transactionTable.TryAdd(transaction.CustomerID, transaction.Transactions);
                }
            }
        }
    }
}
