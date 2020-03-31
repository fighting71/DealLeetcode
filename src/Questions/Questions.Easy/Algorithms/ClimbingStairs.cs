using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2020 2:47:23 PM
    /// @source : https://leetcode.com/problems/climbing-stairs/
    /// @des : 
    /// </summary>
    public class ClimbingStairs
    {

        static int[] answer = new[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903 };

        public int Answer(int n)
        {
            return answer[n - 1];
        }

        /// <summary>
        /// Runtime: 36 ms, faster than 91.88% of C# online submissions for Climbing Stairs.
        /// Memory Usage: 14.5 MB, less than 5.88% of C# online submissions for Climbing Stairs.
        /// 
        /// 最快的估计是直接获取符合题意的所有n 然后直接返回...
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int DpSolution(int n)
        {
            if (n < 3) return n;
            int[] dp = new int[n];

            dp[0] = 1;
            dp[1] = 2;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n - 1];

        }

        // time limit
        public int RecursionSolution(int n)
        {
            if (n < 3) return n;
            return RecursionSolution(n - 1) + RecursionSolution(n - 2);
        }

    }
}
