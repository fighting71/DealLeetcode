using Command.Attr;
using Command.Tools;
using System;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/18/2020 11:10:24 AM
    /// @source : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
    /// @des : 
    /// </summary>
    [Favorite]
    public class BestTimeToBuyAndSellStockIII
    {


        public int Clear(int[] prices)
        {
            int len = prices.Length;
            var price = -prices[0];
            int dp_1_0 = 0, dp_1_1 = price;
            int dp_2_0 = 0, dp_2_1 = price;

            var dp = new int[len][][];

            for (int i = 1; i < len; i++)
            {
                price = prices[i];

                dp_1_0 = Math.Max(dp_1_0, dp_1_1 + price);
                dp_1_1 = Math.Max(dp_1_1, -price);
                dp_2_0 = Math.Max(dp_2_0, dp_2_1 + price);
                dp_2_1 = Math.Max(dp_2_1, dp_1_0 - price);
            }

            return dp_2_0;
        }

        public int Solution2(int[] prices)
        {
            int len = prices.Length;

            var dp = new int[len][][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[3][];
                if (i == 0)
                {
                    dp[i][0] = new int[] { 0, 0 };
                    dp[i][1] = new int[] { 0, -prices[i] };
                    dp[i][2] = new int[] { 0, -prices[i] };// *** 此处不能用0....   
                }
                else
                {
                    dp[i][0] = new int[2];
                    for (int j = 2; j >= 1; j--)
                    {
                        var arr = new int[2];
                        arr[0] = Math.Max(dp[i - 1][j][0], dp[i - 1][j][1] + prices[i]);
                        arr[1] = Math.Max(dp[i - 1][j][1], dp[i - 1][j-1][0] - prices[i]);
                        dp[i][j] = arr;
                    }
                }
            }
            return dp[len - 1][2][0];
        }

        /// <summary>
        /// Runtime: 96 ms, faster than 78.83% of C# online submissions for Best Time to Buy and Sell Stock III.
        /// Memory Usage: 25.4 MB, less than 100.00% of C# online submissions for Best Time to Buy and Sell Stock III.
        /// 
        /// 简化后：
        /// 
        /// Runtime: 92 ms, faster than 97.08% of C# online submissions for Best Time to Buy and Sell Stock III.
        /// Memory Usage: 25.5 MB, less than 100.00% of C# online submissions for Best Time to Buy and Sell Stock III.
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int Solution(int[] prices)
        {

            if (prices.Length == 0) return 0;

            int res = 0, len = prices.Length;

            // left[0] 与 right[len-1] 是无效的 故还可节省~
            int[] left = new int[len], right = new int[len]; // <-- 因为k为2，之前的思路就把prices拆两半，然后看在哪天合起来最大...

            int min = prices[0], max = prices[len - 1];

            for (int i = 1; i < len; i++)
            {
                //if(prices[i] > min)
                //{
                //    left[i] = Math.Max(prices[i] - min, left[i - 1]);
                //}
                //else
                //{
                //    left[i] = left[i - 1];
                //    min = prices[i];
                //}

                //if(max > prices[len - 1 - i])
                //{
                //    right[len - 1 - i] = Math.Max(max - prices[len - 1 - i], right[len - i]);
                //}
                //else
                //{
                //    right[len - 1 - i] = right[len - i];
                //    max = prices[len - 1 - i];
                //}

                left[i] = Math.Max(prices[i] - min, left[i - 1]);
                min = Math.Min(min, prices[i]);

                right[len - 1 - i] = Math.Max(max - prices[len - 1 - i], right[len - i]);
                max = Math.Max(max, prices[len - 1 - i]);
            }

            for (int i = 0; i < len; i++)
            //{
                //if (i < len - 2)
                //{
                //    res = Math.Max(left[i] + right[i + 1], res);
                //}
                //else
                //{
                //    res = Math.Max(left[i] + (i < len - 2 ? right[i + 1] : 0), res);
                //}
                res = Math.Max(left[i] + (i < len - 2 ? right[i + 1] : 0), res);
            //}

            return res;
        }

        private int Expalain(int[] prices)
        {

            /**
             * 
             * 总可以进行两次交易，且买入后需卖出后才能买入,求最大利润
             * 
             * 故最大利润有两种情况：
             *  只进行一次交易，此次收益最大
             *  进行两次交易，(前一次+后一次)收益最大
             *  
             * 考虑买入的特点
             *  只进行一次交易的收益为 区间[0,len-1]的收益
             *  进行两次交易，则区间为[0,n][n2,len-1] (n2>n)
             * 
             */

            if (prices.Length == 0) return 0;

            int res = 0, len = prices.Length;
            // 定义两个数组 存放收益
            //  left[i] 存放 区间[0,i]的最大收益
            //  right[i] 存放 区间[i,len-1]的最大收益
            int[] left = new int[len], right = new int[len];

            int min = prices[0], max = prices[len - 1];

            for (int i = 1; i < len; i++)
            {
                left[i] = Math.Max(prices[i] - min, left[i - 1]);
                min = Math.Min(min, prices[i]);

                right[len - 1 - i] = Math.Max(max - prices[len - 1 - i], right[len - i]);
                max = Math.Max(max, prices[len - 1 - i]);
            }

            for (int i = 0; i < len; i++)
                res = Math.Max(left[i] + (i < len - 2 ? right[i + 1] : 0), res);

            return res;
        }

        public int Try3(int[] prices)
        {

            if (prices.Length == 0) return 0;

            int res = 0, len = prices.Length;

            int[][] dp = new int[len - 1][];

            for (int i = 0; i < len - 1; i++)
            {
                dp[i] = new int[len];
            }

            for (int i = 0; i < len - 1; i++)
            {
                int min = prices[i];
                for (int j = i + 1; j < len; j++)
                {
                    dp[i][j] = Math.Max(prices[j] - min, dp[i][j - 1]);
                    min = Math.Min(min, prices[j]);
                }
            }

            ShowTools.ShowMatrix(dp);

            for (int i = 0; i < len; i++)
            {
                if (i < len - 2)
                {
                    res = Math.Max(dp[0][i] + dp[i + 1][len - 1], res);
                }
                else
                {
                    res = Math.Max(dp[0][i], res);
                }
            }

            return res;
        }

        // Memory Limit
        public int Simple(int[] prices)
        {

            if (prices.Length == 0) return 0;

            int res = 0, len = prices.Length;

            int[][] dp = new int[len - 1][];

            for (int i = 0; i < len - 1; i++)
            {
                dp[i] = new int[len];
            }

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    dp[i][j] = Math.Max(prices[j] - prices[i], dp[i][j - 1]);
                }
            }

            //ShowTools.ShowMatrix(dp);

            for (int i = 0; i < len-1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if(j < len - 2)
                    {
                        res = Math.Max(dp[i][j] + dp[j + 1][len - 1], res);
                    }
                    else
                    {
                        res = Math.Max(dp[i][j], res);
                    }
                }
            }

            return res;
        }

        // error:买入后必须先卖出再买入
        public int Try(int[] prices)
        {
            int one = 0, two = 0, len = prices.Length;

            for (int i = 0; i < len - 1; i++)
            {
                int profit = 0;
                for (int j = i + 1; j < len; j++)
                {
                    profit = Math.Max(profit, prices[j] - prices[i]);
                }

                if (profit > one)
                {
                    two = one;
                    one = profit;
                }
                else if (profit > two)
                {
                    two = profit;
                }

            }

            return one + two;
        }

    }
}
