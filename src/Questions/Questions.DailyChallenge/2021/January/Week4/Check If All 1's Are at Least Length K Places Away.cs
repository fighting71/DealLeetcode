using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/25/2021 5:10:22 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3616/
    /// @des : 
    /// </summary>
    public class Check_If_All_1_s_Are_at_Least_Length_K_Places_Away
    {
        //1 <= nums.length <= 10^5
        //0 <= k <= nums.length
        //nums[i] is 0 or 1

        // Your runtime beats 82.05 %
        // over
        public bool KLengthApart(int[] nums, int k)
        {
            if (k == 0) return true;
            int prev = -k - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if (i - prev <= k) return false;
                    prev = i;
                }
            }
            return true;
        }

    }
}
