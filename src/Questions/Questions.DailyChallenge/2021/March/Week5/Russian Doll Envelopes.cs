using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 4:14:30 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3690/
    /// @des : 俄罗斯套娃
    ///     跟 <see cref="Questions.Hard.Deal2.Russian_Doll_Envelopes"/> 一样..
    /// </summary>
    public class Russian_Doll_Envelopes
    {

        // 1 <= envelopes.length <= 5000
        // envelopes[i].length == 2
        // 1 <= wi, hi <= 10^4

        // envelope [i] = [wi, hi]

        public int MaxEnvelopes(int[][] envelopes)
        {
            int[][] sort = envelopes.OrderBy(u => u[0]).ToArray();

            int len = envelopes.Length;
            int[] dp = new int[len];
            int res = 0;
            for (int i = 0; i < sort.Length; i++)
            {
                dp[i] = 1;
                var item = sort[i];

                for (int j = 0; j < i; j++)
                {
                    var prev = sort[j];
                    if (item[0] > prev[0] && item[1] > prev[1])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
                res = Math.Max(res, dp[i]);

            }
            return res;
        }

    }
}
