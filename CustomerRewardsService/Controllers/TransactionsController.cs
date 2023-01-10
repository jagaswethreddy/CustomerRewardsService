using System;
using System.Collections.Generic;
using System.Linq;
using CustomerRewardsService.Common.Interfaces;
using CustomerRewardsService.Data;
using CustomerRewardsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRewardsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        public MockDataSet _MockDataSet { get; set; }
        
        /// <summary>
        /// Transaction Controller
        /// </summary>
        /// <param name="mockDataSet"></param>
        /// <param name="rewardCalculationsInterface"></param>
        public TransactionsController(MockDataSet mockDataSet)
        {
            _MockDataSet = mockDataSet;
        }

        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                var result = new List<CustomerTransactions>();
                foreach (var transaction in _MockDataSet.transactionTable)
                {
                    result.Add(new CustomerTransactions() { CustomerID = transaction.Key, Transactions = transaction.Value });
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Transaction By Customer Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetTransactionByCustomerId(string id)
        {
            if (_MockDataSet.transactionTable.ContainsKey(id))
            {
                return Ok(_MockDataSet.transactionTable[id]);
            }
            return NotFound($"No Transactions for customer ID : {id}");
        }

        /// <summary>
        /// Post a transaction for customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult PostTransaction(string id,Transaction transaction)
        {
            try
            {
                if (_MockDataSet.transactionTable.ContainsKey(id))
                {
                    _MockDataSet.transactionTable[id].Add(transaction);
                }
                else
                {
                    _MockDataSet.transactionTable.TryAdd(id, new List<Transaction>() { transaction });
                }

                return Ok(new CustomerTransactions() { CustomerID = id, Transactions = _MockDataSet.transactionTable[id] });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
