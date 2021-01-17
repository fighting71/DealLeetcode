using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/17/2021 5:05:37 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3607/
    /// @des : 
    /// </summary>
    public class Count_Sorted_Vowel_Strings
    {

        // 1 <= n <= 50 

        [Obsolete]
        public int Optimize2(int n)
        {

            int res = 5;

            for (int i = 1; i < n; i++)
            {
                // {3} = 4 + 10 + 15 + 21 
                // 4 + 6 + 4 + 6 + 4 + 5 + 6 + 4 + 5 + 6
                // 4 + 6 * 3 + 4 * (3) + 5 * (2) + 6*(1) 
                var empty = 4 + 6 * (i) + (i + 3) * (i + 2) / 2 - 6;
                res += empty;
            }

            return res;

            int[] cache = new[] { 1, 2, 3, 4, 5 };

            if(n > 1)
            {
                //cache[1] += n - 1;
                cache[1] = 2 + n - 1;
                // 1 + 2 + 3 + 4 + 5 + 6 + 7 = (n-1)*n/2
                //cache[2] += (n - 1) * n / 2;
                cache[2] = (n - 1) * n / 2;

                // error.
                // 4 + 6 + 10 + 15 + 21 + 28 = 4 + 6*(n-1) + 4+ 5 + 6 = 4 + 6(n-1) + (n-2)*(n-1)/2  
                // 4 + 6*(n-1) + (n+2)(n+1)/2 - 6
                //cache[3] += cache[3] * n; 
                cache[3] = 4 + 6 * (n - 1) + (n + 2) * (n + 1) / 2 - 6;

                // 5 + 10 + 20 + 35 + 56 + 84
                cache[3] += cache[3] * n;
            }

            return cache[4];

        }

        // 18.40 % ?
        public int Optimize(int n)
        {
            int[] cache = new[] { 1, 2, 3, 4, 5 };

            for (int i = 1; i < n; i++)
            {
                //ShowTools.Show(cache);
                for (int j = 1; j < 5; j++)
                {
                    cache[j] += cache[j - 1];
                }
            }

            return cache[4];

        }

        // Your runtime beats 17.60 %
        public int DpSolution(int n)
        {
            int[][] dp = new int[n + 1][];

            dp[0] = new[] { 1, 2, 3, 4, 5 };

            for (int i = 1; i < n; i++)
            {
                dp[i] = new int[5];

                int num = 0;
                for (int j = 0; j < 5; j++)
                {
                    dp[i][j] = num += dp[i - 1][j];
                }

            }

            return dp[n - 1][4];

        }

        // 9%
        public int Simple(int n)
        {
            return Helper(n, 5);
        }

        private int Helper(int n, int curr)
        {
            if (n == 1) return curr;

            int res = 0;

            for (int i = 1; i <= curr; i++)
            {
                res += Helper(n - 1, i);
            }
            return res;
        }

    }
}
