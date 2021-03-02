using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/2/2021 5:37:19 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3658/
    /// @des : 
    /// </summary>
    public class Set_Mismatch
    {
        //2 <= nums.length <= 10^4
        //1 <= nums[i] <= 10^4
        // Your runtime beats 76.25 %
        // ... 一点优化的想法都不给
        public int[] Simple(int[] nums)
        {
            int same = 0, lost = 0;
            ISet<int> set = new HashSet<int>();

            foreach (var num in nums)
            {
                if (set.Contains(num)) same = num;
                else set.Add(num);
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                if (!set.Contains(i))
                {
                    lost = i;
                    break;
                }
            }
            return new[] { same, lost };
        }

    }
}
