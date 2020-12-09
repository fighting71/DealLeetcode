using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/9/2020 2:24:54 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3559/
    /// @des : 
    /// </summary>
    public class Pairs_of_Songs_With_Total_Durations_Divisible_by_60
    {
        // 1 <= time.length <= 6 * 104
        // 1 <= time[i] <= 500
        // Your runtime beats 97.09 % of csharp submission
        // 提示很到位
        public int NumPairsDivisibleBy60(int[] time)
        {
            int[] count = new int[60];

            int res = 0;
            foreach (var item in time)
            {
                var remind = item % 60;
                res += count[(60 - remind) % 60];
                // 这里应放在最后 避免 remind==30时 加到自己
                count[remind]++;
            }
            return res;
        }
    }
}
