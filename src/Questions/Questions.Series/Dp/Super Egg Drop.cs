using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/25/2020 3:00:13 PM
    /// @source : https://leetcode.com/problems/super-egg-drop/
    /// @des : 
    /// </summary>
    [Favorite("进阶很玄妙.")]
    public class Super_Egg_Drop
    {

        // 1 <= K <= 100
        // 1 <= N <= 10000

        public int SuperEggDrop(int k, int n)
        {
            memo = new Dictionary<(int, int), int>();
            return HelpWithBinarySearch(k, n);
        }
        #region 备忘录模式
        Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
        // O(k*n) * O(n)
        // dp[鸡蛋个数][楼层数]=[扔鸡蛋的最少次数]
        private int Help(int k, int n)
        {
            if (k == 1) return n;
            if (n == 0) return 0;

            var key = (k, n);
            if (memo.ContainsKey(key)) return memo[key];

            int res = int.MaxValue;

            for (int i = 1; i < n + 1; i++)
            {
                res = Math.Min(res, Math.Max(
                    Help(k, n - i), // 没碎 [i+1,n]
                    Help(k - 1, i - 1) // 碎了 k = k - 1 [1,i-1]
                    ) + 1);
            }

            return memo[key] = res;

        }

        // 带二分
        // Runtime: 760 ms, faster than 5.56% of C# online submissions for Super Egg Drop.
        // Memory Usage: 33.7 MB, less than 22.22% of C# online submissions for Super Egg Drop.
        // O(k*n) * O(logn)
        private int HelpWithBinarySearch(int k, int n)
        {
            if (k == 1) return n;
            if (n == 0) return 0;

            var key = (k, n);
            if (memo.ContainsKey(key)) return memo[key];

            int res = int.MaxValue;

            int left = 1, right = n;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                int broken = HelpWithBinarySearch(k - 1, mid - 1);
                int no_broken = HelpWithBinarySearch(k, n - mid);
                if (broken == no_broken) return memo[key] = broken + 1;
                if (no_broken > broken)
                {
                    left = mid + 1;
                    res = Math.Min(res, no_broken + 1);
                }
                else
                {
                    right = mid - 1;
                    res = Math.Min(res, broken + 1);
                }

            }

            return memo[key] = res;

        }
        #endregion

        #region 进阶
        // dp[鸡蛋个数][扔鸡蛋的次数]=[能达到的最大的层数]
        // Runtime: 40 ms, faster than 83.33% of C# online submissions for Super Egg Drop.
        // O(kn)
        public int Level2(int k, int n)
        {
            int[][] dp = new int[k + 1][];

            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n + 1];
            }
            int m = 0;
            while (dp[k][m] < n)
            {
                m++;
                for (int i = 1; i <= k; i++)
                {
                    // ***
                    // 1、无论你在哪层楼扔鸡蛋，鸡蛋只可能摔碎或者没摔碎，碎了的话就测楼下，没碎的话就测楼上。
                    // 2、无论你上楼还是下楼，总的楼层数 = 楼上的楼层数 + 楼下的楼层数 + 1（当前这层楼）。

                    dp[i][m] = dp[i - 1][m - 1] + dp[i][m - 1] + 1;
                }
            }
            return m;
        }
        #endregion

    }
}
