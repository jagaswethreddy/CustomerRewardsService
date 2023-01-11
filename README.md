# CustomerRewardsService

This project is to calculate customer reward points based on amount spend on multiple transactions spanning 3 months, fetch transactions, rewards based on customer Id, and add transactions to customer records based on customer Id. 

`Note` : No future are ignored in reward calculations
`Note` : MockDataSet.cs file holds initial mock transactions to demonstrate required goals


## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/jagaswethreddy/CustomerRewardsService.git
```

- build and run the project.
- Project is configured with swagger to test the endpoints, browse 'https://localhost:5001/swagger/index.html'

## Customer Rewards Controller
### HttpGet CustomerRewrds
- This end point will provide all the rewards for all the customers. please find sample response below

```json
[
  {
    "customerID": "4",
    "firstMonthRewards": 90,
    "secondMonthRewards": 0,
    "thirdMonthRewards": 0,
    "totalRewards": 90
  },
  {
    "customerID": "5",
    "firstMonthRewards": 140,
    "secondMonthRewards": 0,
    "thirdMonthRewards": 0,
    "totalRewards": 140
  }
]
```

### HttpGet CustomerRewrds by Id

- This enpoint will respond with rewrds for individual cutomer based on curomer Id, required parameter is customer Id

```json
{
  "customerID": "2",
  "firstMonthRewards": 113,
  "secondMonthRewards": 0,
  "thirdMonthRewards": 0,
  "totalRewards": 113
}
```

## Transactions Controller

- This controller is responsible for fetching all transaction records, transactions based on customer id , and posting new transactions towards customer based on customer Id

### HttpGet Transactions

- This endpoint provide all the transactions recorded. Sample repsonse shown as below

```json
[  
 {
    "customerID": "5",
    "transactions": [
      {
        "transactionAmount": 145,
        "transactionDate": "2022-12-31T00:00:00"
      }
    ]
  }
]
```

### HttpGet Transactions by id

- This endpoint provide the transactions for individual customer based on customer Id. Sample repsonse shown as below

```json
[  
 {
    "customerID": "5",
    "transactions": [
      {
        "transactionAmount": 145,
        "transactionDate": "2022-12-31T00:00:00"
      }
    ]
  }
]
```

### HttpPost Transactions by id

- This endpoint is to post transactions on cusotmer records based on customer Id. Input parameters required are Customer Id and Transaction 

#### Sample transaction 
```json
{
  "transactionAmount": 120,
  "transactionDate": "2023-01-11T03:35:51.673Z"
}
```




