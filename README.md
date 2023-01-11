# CustomerRewardsService

This project is to calculate customer reward points based on amount spend on multiple transactions spanning 3 months, fetch transactions, rewards based on customer Id, and add transactions to customer records based on customer Id. 

`Note` : No future are ignored in reward calculations


## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/jagaswethreddy/CustomerRewardsService.git
```

- build and run the project.
- Project is configured with swagger to test the endpoints, browse 'https://localhost:5001/swagger/index.html'

## Customer Rewards Controller
### HttpGet CustomerRewrds
- this end point will provide all the rewards for all the customers. please find sample response below

'''json
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
'''



