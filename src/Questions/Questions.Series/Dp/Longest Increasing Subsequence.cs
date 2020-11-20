using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 3:31:16 PM
    /// @source : https://leetcode.com/problems/longest-increasing-subsequence/
    /// @des : 
    /// </summary>
    public class Longest_Increasing_Subsequence
    {

        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int[] dp = new int[nums.Length];

            var count = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        if (dp[i] > count) count = dp[i];
                    }
                }
            }

            return count;
        }

    }
}
