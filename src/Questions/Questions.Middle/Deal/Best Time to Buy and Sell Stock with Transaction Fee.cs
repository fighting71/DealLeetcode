using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 6:44:32 PM
    /// @source : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/
    /// @thinking: https://github.com/labuladong/fucking-algorithm/blob/master/%E5%8A%A8%E6%80%81%E8%A7%84%E5%88%92%E7%B3%BB%E5%88%97/%E5%9B%A2%E7%81%AD%E8%82%A1%E7%A5%A8%E9%97%AE%E9%A2%98.md
    /// @des : 
    /// </summary>
    public class Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
    {

        // Runtime: 220 ms, faster than 22.22% of C# online submissions for Best Time to Buy and Sell Stock with Transaction Fee.
        // Memory Usage: 45.9 MB, less than 5.56% of C# online submissions for Best Time to Buy and Sell Stock with Transaction Fee.
        // nb 
        public int MaxProfit(int[] prices, int fee)
        {
            var len = prices.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[2];
                if(i == 0)
                {
                    dp[i][0] = 0;
                    dp[i][1] = -prices[i];
                }
                else
                {
                    dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i] - fee);
                    dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
                }
            }

            return dp[len - 1][0];
        }

        // Runtime: 196 ms, faster than 87.04% of C# online submissions for Best Time to Buy and Sell Stock with Transaction Fee.
        // Memory Usage: 44.1 MB, less than 74.07% of C# online submissions for Best Time to Buy and Sell Stock with Transaction Fee.
        // 太强了!!!!
        public int Clear(int[] prices, int fee)
        {
            var len = prices.Length;

            int first = 0, sencond = -prices[0];

            for (int i = 1; i < len; i++)
            {
                first = Math.Max(first, sencond + prices[i] - fee);
                sencond = Math.Max(sencond, first - prices[i]);
            }

            return first;
        }

    }
}
