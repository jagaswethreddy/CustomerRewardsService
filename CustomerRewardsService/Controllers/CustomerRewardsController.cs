
using System;
using System.Collections.Generic;
using CustomerRewardsService.Common.Interfaces;
using CustomerRewardsService.Data;
using CustomerRewardsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRewardsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerRewardsController : ControllerBase
    {
        public MockDataSet _MockDataSet { get; set; }
        public IRewardCalculationsInterface _rewardCalculationsInterface { get; set; }

        /// <summary>
        /// Customer Reward controller
        /// </summary>
        /// <param name="mockDataSet"></param>
        /// <param name="rewardCalculationsInterface"></param>
        public CustomerRewardsController(MockDataSet mockDataSet, IRewardCalculationsInterface rewardCalculationsInterface)
        {
            _MockDataSet = mockDataSet;
            _rewardCalculationsInterface = rewardCalculationsInterface;
        }
        /// <summary>
        /// Get All rewards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllRewards()
        {
            try
            {
                var table = _MockDataSet.transactionTable;
                var rewards = new List<Rewards>();
                foreach (var x in table)
                {
                    Rewards reward = _rewardCalculationsInterface.CalculateTotalRewards(x.Value);
                    reward.CustomerID = x.Key;
                    rewards.Add(reward);
                }
                return Ok(rewards);
            }
            catch(Exception ex)
            {
                return  BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get rewards based on customer ID
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetRewardsById(string id)
        {
            try
            {
                var table = _MockDataSet.transactionTable;
                var reward = new Rewards();
                if (table.ContainsKey(id))
                {
                    reward = _rewardCalculationsInterface.CalculateTotalRewards(table[id]);
                    reward.CustomerID = id;
                }
                else
                {
                    return NotFound($"No records found for customer ID : {id}");
                }
                return Ok(reward);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
