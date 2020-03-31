using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 11:58:32 AM
    /// @source : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    /// @des : 
    /// </summary>
    public class BestTimeToBuyAndSellStockII
    {

        /// <summary>
        /// Runtime: 88 ms, faster than 94.50% of C# online submissions for Best Time to Buy and Sell Stock II.
        /// Memory Usage: 25.1 MB, less than 11.11% of C# online submissions for Best Time to Buy and Sell Stock II.
        /// 
        /// unbelieverable...
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int OtherSolution(int[] prices)
        {

            var total = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1]) total += prices[i] - prices[i - 1];// ???
            }
            return total;

        }

        /// <summary>
        /// Runtime: 828 ms, faster than 6.44% of C# online submissions for Best Time to Buy and Sell Stock II.
        /// Memory Usage: 25.3 MB, less than 11.11% of C# online submissions for Best Time to Buy and Sell Stock II.
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int Solution(int[] prices)
        {
            if (prices.Length < 2) return 0;
            //int res = 0,n = prices.Length;
            int n = prices.Length;

            var dp = new int[n];

            for (int i = 1; i < n; i++)
            {
                dp[i] = dp[i - 1];
                for (int j = 0; j < i; j++)
                {
                    if(prices[i] > prices[j])
                    {
                        dp[i] = Math.Max(dp[i], prices[i] - prices[j] + (j > 0 ? dp[j - 1] : 0));
                    }
                }
                //res = Math.Max(res, dp[i]);
            }

            return dp[n - 1];
            //return res;
        }

        // bug
        public int Solution2(int[] prices)
        {

            int n = prices.Length;

            var dp = new int[n + 1];

            for (int i = 1; i < n; i++)
            {
                dp[i + 1] = dp[i];
                dp[i] = dp[i - 1];
                for (int j = 0; j < i; j++)
                {
                    if (prices[i] > prices[j])
                    {
                        dp[i] = Math.Max(dp[i], prices[i] - prices[j] + (j > 0 ? dp[j - 1] : 0));
                    }
                }
            }

            return dp[n];
        }

    }
}
