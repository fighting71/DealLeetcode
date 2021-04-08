using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 4:02:37 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3698/
    /// @des : 
    /// </summary>
    public class Minimum_Operations_to_Make_Array_Equal
    {

        /*
         * 
         * 2*i+1
         * i -> n
         *  =>  2*(0+1+2+...n-1) + 1 * n 
         *  =>  2*((n-1) * (n)/2) + n
         *  =>  n * n
         *  
         * x => 2 * x + 1 < n
         *   => x = x < (n - 1) /2
         *  
         */

        public int Solution2(int n)
        {
            int res = 0;
            var max = (n - 1) / 2 + (n - 1 % 2 == 0 ? 0 : 1);
            for (int i = 0; i < max; i++)
            {
                res += n - (2 * i + 1);
            }

            return res;
        }

        // Your runtime beats 94.59 %
        public int Simple(int n)
        {
            int res = 0;

            for (int i = 0; i < n; i++)
            {
                var diff = 2 * i + 1 - n;
                if (diff < 0) res += -diff;
                else break;
            }

            return res;
        }
    }
}
