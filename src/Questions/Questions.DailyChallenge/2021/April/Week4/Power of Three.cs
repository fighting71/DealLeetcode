using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/27/2021 4:23:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3722/
    /// @des : 
    /// </summary>
    public class Power_of_Three
    {

        // -2^31 <= n <= 2^31 - 1

        // Follow up: Could you solve it without loops/recursion?

        // ... 离谱
        public bool OtheSolution(int n)
        {
            // 1162261467 is 3^19,  3^20 is bigger than int  
            return (n > 0 && 1162261467 % n == 0);
        }

        // Your runtime beats 87.73 %
        public bool Try(int n)
        {
            if (n < 1) return false;
            n = Math.Abs(n);

            int e = 1;
            while (e > 0)
            {
                if (e == n) return true;
                if (n % e != 0) return false;
                e *= 3;
            }

            return false;

        }
        public bool IsPowerOfThree(int n)
        {
            if (n == 0) return false;
            if (n % 3 != 0) return false;
            return n == 3 || IsPowerOfThree(n / 3);
        }
    }
}
