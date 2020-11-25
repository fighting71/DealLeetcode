using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/25/2020 6:22:34 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class House_Robber
    {
        public int Solution(int[] nums)
        {
            int len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];
            if (len == 2) return Math.Max(nums[0], nums[1]);
            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            dp[1] = nums[1];

            for (int i = 2; i < len; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[len - 1];
        }

        // Runtime: 84 ms, faster than 90.98% of C# online submissions for House Robber.
        // Memory Usage: 24.3 MB, less than 95.19% of C# online submissions for House Robber.
        public int Clear(int[] nums)
        {
            int len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];
            if (len == 2) return Math.Max(nums[0], nums[1]);

            int first = nums[0], second = Math.Max(first, nums[1]), old;

            for (int i = 2; i < len; i++)
            {
                old = second;
                second = Math.Max(first + nums[i], second);
                first = old;
            }
            return second;
        }
    }
}
