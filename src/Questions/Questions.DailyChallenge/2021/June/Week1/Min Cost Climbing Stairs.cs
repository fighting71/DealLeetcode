using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/7/2021 5:03:32 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3770/
    /// @des : 
    /// </summary>
    public class Min_Cost_Climbing_Stairs
    {

        // Constraints:

        //2 <= cost.length <= 1000
        //0 <= cost[i] <= 999
        // Your runtime beats 26.81 %
        // gc
        public int Optimize(int[] cost)
        {
            int first = cost[0], second = cost[1], curr;

            for (int i = 2; i < cost.Length; i++)
            {
                curr = cost[i] + Math.Min(first, second);
                first = second;
                second = curr;
            }
            return Math.Min(first, second);

        }

        // Your runtime beats 7.66 %
        // ,,,,
        public int MinCostClimbingStairs(int[] cost)
        {
            int len = cost.Length;
            int[] dp = new int[len];

            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i < len; i++)
            {
                dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
            }

            return Math.Min(dp[len - 1], dp[len - 2]);

        }
    }
}
