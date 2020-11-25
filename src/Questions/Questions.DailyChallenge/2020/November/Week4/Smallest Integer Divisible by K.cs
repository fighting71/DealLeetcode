using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/25/2020 6:43:36 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3543/
    /// @des : 
    /// </summary>
    public class Smallest_Integer_Divisible_by_K
    {

        // 1 <= K <= 105
        public int Simple(int k)
        {

            if (k % 2 == 0) return -1;

            int num = 1, res = 1;

            while (num > 0 && num % k != 0)
            {
                num = num * 10 + 1;
            }
            return num > 0 ? res : -1;

        }
    }
}
