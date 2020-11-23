using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 3:56:43 PM
    /// @source : https://leetcode.com/problems/fibonacci-number/
    /// @des : 
    /// </summary>
    public class Fibonacci_Number
    {

        // F(0) = 0,   F(1) = 1
        // F(N) = F(N - 1) + F(N - 2), for N > 1.

        // O(2^n)
        public int Recursion(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;
            return Recursion(n - 1) + Recursion(n - 2);
        }

        // 备忘录-【自顶而下】
        // O(n)
        public int Dp(int n)
        {

            int[] dp = new int[n];

            int Helper(int num)
            {
                if (n == 0) return 0;
                if (num == 1 || num == 2) return 1;
                if (dp[num] > 0) return dp[num];
                return dp[num] = Helper(num - 1) + Helper(num - 2);
            }

            return Helper(n);
        }

        // 迭代-【自下而上】
        public int Dp2(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;
            int[] dp = new int[n + 1];
            dp[1] = dp[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        // 状态压缩
        public int Dp3(int n)
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
