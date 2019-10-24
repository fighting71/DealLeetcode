using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 11:00:31
    /// @source : https://leetcode.com/problems/triples-with-bitwise-and-equal-to-zero/
    /// @des : 
    /// </summary>
    [Obsolete("pass but not efficient")]
    public class CountTriplets
    {
        public int Solution(int[] arr)
        {
            var res = 0;

            if (arr.Length < 3) return res;

            var len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if ((arr[i] & arr[j] & arr[k]) == 0) res++;
                    }
                }
            }

            return res;
        }

        // time to long ....
        public int Simple(int[] A)
        {
            var count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0) count++;

                for (int j = i + 1; j < A.Length; j++)
                {
                    if ((A[i] & A[j]) == 0)
                    {
                        count += 6;
                    }

                    for (int k = j + 1; k < A.Length; k++)
                    {
                        if ((A[i] & A[j] & A[k]) == 0)
                        {
                            count += 6;
                        }
                    }
                }
            }

            return count;
        }

        public int OtherSolution(int[] A)
        {
            int N = 1 << 16, M = 3;
            int[][] dp = new int[M + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[N];
            }

            dp[0][N - 1] = 1;
            for (int i = 0; i < M; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    foreach (int a in A)
                    {
                        dp[i + 1][k & a] += dp[i][k];
                    }
                }
            }

            return dp[M][0];
        }
    }
}