using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 2:17:33 PM
    /// @source : https://leetcode.com/problems/longest-common-subsequence/
    /// @des : 
    /// </summary>
    public class Longest_Common_Subsequence
    {

        // 1 <= text1.length <= 1000
        //1 <= text2.length <= 1000
        //The input strings consist of lowercase English characters only.
        // Runtime: 76 ms, faster than 90.41% of C# online submissions for Longest Common Subsequence.
        public int Solution(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;

            int[][] dp = new int[m + 1][];
            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new int[n + 1];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        dp[i + 1][j + 1] = 1 + dp[i][j];
                    }
                    else
                    {
                        dp[i + 1][j + 1] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
                    }
                }
            }
            return dp[m][n];
        }
    }
}
