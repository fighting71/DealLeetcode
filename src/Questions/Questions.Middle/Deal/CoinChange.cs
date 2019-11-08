using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/5 15:25:00
    /// @source : https://leetcode.com/problems/coin-change/
    /// @des : 
    /// </summary>
    [Obsolete]
    public class CoinChange
    {
        #region otherSolution

        // source : https://leetcode.com/problems/coin-change/discuss/77368/*Java*-Both-iterative-and-recursive-solutions-with-explanations
        public int OtherSolution(int[] coins, int amount)
        {
            if (amount < 1) return 0;
            return Helper(coins, amount, new int[amount]);
        }

        private int Helper(int[] coins, int rem, int[] dp)// rem: remaining coins after the last step; count[rem]: minimum number of coins to sum up to rem
        {
            if (rem < 0) return -1; // not valid
            if (rem == 0) return 0; // completed
            if (dp[rem - 1] != 0) return dp[rem - 1]; // already computed, so reuse
            int min = int.MaxValue;
            foreach (int coin in coins)
            {
                int res = Helper(coins, rem - coin, dp);
                if (res >= 0 && res < min)
                    min = 1 + res;
            }

            dp[rem - 1] = (min == int.MaxValue) ? -1 : min;
            return dp[rem - 1];
        }

        #endregion

        public int Solution(int[] coins, int amount)
        {
            // N = {n1,n2...nk} 
            // is exists n1*a + n2*b + ... + nk*c = amount ?
            // ax = b x=b/a
            // ax + by = c   b=a*k  ax + aky = c  (x+ky) = c/a

            return -1;
        }

        public int Try(int[] coins, int amount)
        {
            Array.Sort(coins);

            var res = Helper(coins.Length - 1, coins, amount, 0);
            return res == int.MaxValue ? -1 : res;
        }

        private int Helper(int i, int[] arr, int amount, int count)
        {
            if (i == -1) return int.MaxValue;

            if (amount % arr[i] == 0) return count + amount / arr[i];

            // bug time limit
            // 对比 otherSolution 此处缺少dp...
            for (int j = amount / arr[i]; j >= 0; j++)
            {
                var res = Helper(i - 1, arr, amount - (j * arr[i]), j);
                if (res != int.MaxValue) return res;
            }

            return int.MaxValue;

            // bug 7 8  30  29
            //var skip = Helper(i - 1, arr, amount, count);

            //if (arr[i] <= amount)
            //{
            //    count += amount / arr[i];
            //    amount = amount % arr[i];
            //}

            //return Math.Min(skip, Helper(i - 1, arr, amount, count));
        }
    }
}