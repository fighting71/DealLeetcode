using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/6/2021 11:02:08 AM
    /// @source : https://leetcode.com/problems/russian-doll-envelopes/
    /// @des : 俄罗斯套娃，能套多少层
    ///     不允许旋转
    /// </summary>
    [Optimize]
    public class Russian_Doll_Envelopes
    {

        // envelopes[i] = int[2]  = { weight, height }

        public int Optimize(int[][] envelopes)
        {
            // bug
            //envelopes = envelopes.GroupBy(u => u[0]).Select(u => u.OrderBy(u => u[1]).First()).ToArray();

            //envelopes = envelopes.OrderBy(u => u[0]).ToArray();

            return default;
        }

        // Runtime: 448 ms, faster than 67.14% of C# online submissions for Russian Doll Envelopes.
        // Memory Usage: 30.9 MB, less than 28.57% of C# online submissions for Russian Doll Envelopes.
        public int Try(int[][] envelopes)
        {
            int len = envelopes.Length;
            envelopes = envelopes.OrderBy(u => u[0]).ToArray();

            int[] dp = new int[len];
            int res = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                dp[i] = 1;
                var item = envelopes[i];
                for (int j = i + 1; j < len; j++)
                {
                    var compare = envelopes[j];

                    if (compare[0] > item[0] && compare[1] > item[1])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
        public int Simple(int[][] envelopes)
        {
            envelopes = envelopes.OrderBy(u => u[0]).ToArray();
            return Recursion(envelopes, 0, 0, 0);
        }

        private int Recursion(int[][] arr, int i, int minW, int minH)
        {
            if (i == arr.Length) return 0;
            var item = arr[i];

            if (item[0] == minW || item[1] <= minH)
            {
                return Recursion(arr, i + 1, minW, minH);
            }
            else
            {
                return Math.Max(Recursion(arr, i + 1, minW, minH), 1 + Recursion(arr, i + 1, item[0], item[1]));
            }

        }

    }
}
