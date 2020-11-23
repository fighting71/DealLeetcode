using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 4:10:26 PM
    /// @source : https://leetcode.com/problems/coin-change/
    /// @des : 
    /// </summary>
    public class Coin_Change
    {

        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            for (int i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if (i - coin < 0) continue;
                    dp[i] = Math.Min(dp[i - coin] + 1, dp[i]);
                }
            }
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }

        #region bug old
        public int Old(int[] coins, int amount)
        {
            Array.Sort(coins);

            var res = Helper(coins.Length - 1, coins, amount, 0);
            return res == int.MaxValue ? -1 : res;
        }

        private int Helper(int i, int[] arr, int amount, int count)
        {
            if (amount == 0) return count;

            if (i == -1) return int.MaxValue;

            var skip = Helper(i - 1, arr, amount, count);

            if (arr[i] <= amount)
            {
                count += amount / arr[i]; // *** 此处的错误就是用÷来求解...
                amount = amount % arr[i];
            }

            return Math.Min(skip, Helper(i - 1, arr, amount, count));
        }
        #endregion

    }
}
