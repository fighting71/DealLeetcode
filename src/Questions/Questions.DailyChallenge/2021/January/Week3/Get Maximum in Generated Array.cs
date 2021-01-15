using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/15/2021 4:11:02 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3605/
    /// @des : 
    /// </summary>
    public class Get_Maximum_in_Generated_Array
    {

        /*
         * You are given an integer n. An array nums of length n + 1 is generated in the following way:
nums[0] = 0
nums[1] = 1
nums[2 * i] = nums[i] when 2 <= 2 * i <= n
nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
Return the maximum integer in the array nums​​​.
         */

        // Your runtime beats 100.00 %
        // .. easy 
        public int GetMaximumGenerated(int n)
        {
            if (n < 2) return n;
            var arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            int res = 1;
            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0) arr[i] = arr[i / 2];
                else
                {
                    arr[i] = arr[i / 2] + arr[i / 2 + 1];
                    res = Math.Max(arr[i], res);
                }
            }
            return res;
        }
    }
}
