using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/4/2021 2:59:21 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3659/
    /// @des : 
    /// </summary>
    public class Missing_Number
    {

        // n == nums.length
        //1 <= n <= 10^4
        //0 <= nums[i] <= n
        //All the numbers of nums are unique.

        // Your runtime beats 68.77 %
        // 告辞~
        public int MissingNumber(int[] nums)
        {
            int len = nums.Length;
            int sum = (len * (len + 1)) / 2; // 1+2+...n = (n+1)*n/2

            foreach (var item in nums)
            {
                sum -= item;
            }
            return sum;
        }

    }
}
