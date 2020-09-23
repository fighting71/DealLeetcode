using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 3:48:45 PM
    /// @source : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
    /// @des : 
    /// </summary>
    public class Best_Time_to_Buy_and_Sell_Stock_IV
    {

        //Runtime: 104 ms, faster than 52.13% of C# online submissions for Best Time to Buy and Sell Stock IV.
        //Memory Usage: 25.1 MB, less than 32.98% of C# online submissions for Best Time to Buy and Sell Stock IV.
        public int DpSolution(int k, int[] prices)
        {
            if (k == 0) return 0;
            int len = prices.Length;

            if (k >= len)
            {
                int sum = 0;

                for (int i = 1; i < len; i++)
                {
                    if (prices[i] > prices[i - 1]) sum += prices[i] - prices[i - 1];
                }
                return sum;
            }

            int[][] dp = new int[len + 1][];
            for (int i = 0; i < len + 1; i++)
            {
                dp[i] = new int[k];
            }

            for (int i = len - 2; i >= 0; i--)
            {
                for (int h = 0; h < k; h++)
                {
                    dp[i][h] = dp[i + 1][h];
                }
                for (int j = i + 1; j < len; j++)
                {
                    if (prices[i] > prices[j]) break;

                    int sell = prices[j] - prices[i];
                    dp[i][0] = Math.Max(dp[i][0], sell);
                    for (int h = 1; h < k; h++)
                    {
                        dp[i][h] = Math.Max(dp[i][h], sell + dp[j + 1][h - 1]);
                    }
                }

                for (int h = 2; h < k; h++)
                {
                    dp[i][h] = Math.Max(dp[i][h], dp[i][h - 1]);
                }

            }

            //ShowTools.ShowMatrix(dp);

            return dp[0][k - 1];
        }

        // 差不多
        // TODO:进一步优化
        public int Optimize(int k, int[] prices)
        {
            if (k == 0) return 0;
            int len = prices.Length;

            if (k >= len)
            {
                int sum = 0;
                for (int i = 1; i < len; i++)
                {
                    int sell = prices[i] - prices[i - 1];
                    if (sell > 0) sum += sell;
                }
                return sum;
            }

            int[][] dp = new int[len + 1][];
            for (int i = 0; i < len + 1; i++)
                dp[i] = new int[k];

            for (int i = len - 2; i >= 0; i--)
            {
                for (int h = 0; h < k; h++)
                    dp[i][h] = dp[i + 1][h];

                for (int j = i + 1; j < len; j++)
                {
                    if (prices[i] > prices[j]) break;

                    int sell = prices[j] - prices[i];
                    dp[i][0] = Math.Max(dp[i][0], sell);
                    for (int h = 1; h < k; h++)
                        dp[i][h] = Math.Max(dp[i][h], sell + dp[j + 1][h - 1]);
                }

            }

            return dp[0][k - 1];
        }

        /// <summary>
        /// 递归解法
        /// </summary>
        /// <param name="k"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int Recursive(int k, int[] prices)
        {
            return Help(k, prices, 0, 1);
        }

        private int Help(int k, int[] prices, int own, int index)
        {
            if (k == 0 || index >= prices.Length) return 0;
            if (prices[index] <= prices[own])
            {
                return Help(k, prices, index, index + 1);
            }

            return Math.Max(
                prices[index] - prices[own] + Help(k - 1, prices, index + 1, index + 2),// sell
                Help(k, prices, own, index + 1)// no sell
            );

        }

    }
}
