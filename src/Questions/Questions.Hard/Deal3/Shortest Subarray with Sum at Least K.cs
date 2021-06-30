using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/30/2021 5:31:08 PM
    /// @source : https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/
    /// @des : 
    /// </summary>
    public class Shortest_Subarray_with_Sum_at_Least_K
    {

        // todo : try solution

        // 1 <= nums.length <= 50000
        //-10^5 <= nums[i] <= 10^5
        //1 <= k <= 10^9

        public int Simple(int[] nums, int k)
        {
            int res = 0;
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                int sum = 0;
                for (int j = i; j < len; j++)
                {
                    sum += nums[j];

                    if (sum >= k)
                    {
                        res++;
                    }

                }
            }
            return res == 0 ? -1 : res;
        }

    }
}
