using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/3/2020 11:23:40 AM
    /// @source : https://leetcode.com/problems/jump-game-ii/submissions/
    /// @des : 
    /// </summary>
    [Obsolete("")]
    public class JumpII
    {


        // TODO: 贪心算法
        public int Try2(int[] nums)
        {

            if (nums.Length == 1) return 0;

            for (int i = 0; i < nums.Length; i++)
            {

            }

            return 0;
        }

        // Time Limit
        public int Try(int[] nums)
        {
            int n = nums.Length;

            if (n == 1) return 0;
            if (nums[0] >= n - 1) return 1;
            int[] dp = new int[n];

            dp[0] = 1;

            for (int i = 1; i < n; i++)
            {
                dp[i] = int.MaxValue;

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] + j >= i)
                    {
                        dp[i] = Math.Min(dp[j] + 1, dp[i]);
                    }
                }
                if (nums[i] + i >= n - 1) return dp[i];
            }

            return dp[n - 1];
        }

        public int Simple(int[] nums)
        {
            return Helper(nums, 0, int.MaxValue);
        }

        private int Helper(int[] nums,int i,int step)
        {
            for (int j = i + 1; j <= i + nums[i]; j++)
            {
                step = Math.Min(step, Helper(nums, j, step == int.MaxValue ? step : step + 1));
            }

            return step;
        }

    }
}
