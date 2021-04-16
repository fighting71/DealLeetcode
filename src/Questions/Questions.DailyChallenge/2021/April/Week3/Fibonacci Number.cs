using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/15/2021 5:39:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3709/
    /// @des : 
    /// old question.
    /// <see cref="Questions.Series.Dp.Fibonacci_Number"/>
    /// </summary>
    public class Fibonacci_Number
    {
        // 0 <= n <= 30
        // 99%
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;
            int prev = 1, curr = 1;
            for (int i = 3; i <= n; i++)
            {
                int sum = prev + curr;
                prev = curr;
                curr = sum;
            }
            return curr;
        }

    }
}
