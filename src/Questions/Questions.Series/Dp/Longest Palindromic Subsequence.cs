using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 10:53:49 AM
    /// @source : https://leetcode.com/problems/longest-palindromic-subsequence/
    /// @des : 
    /// </summary>
    public class Longest_Palindromic_Subsequence
    {
        // 1 <= s.length <= 1000
        // s consists only of lowercase English letters.

        // 104 ms, faster than 93.00% 
        // dp[开始坐标,结束坐标] = 最长回文长度
        public int Solution(string s)
        {
            int len = s.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                dp[i][i] = 1;
            }

            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if(s[i] == s[j])
                        dp[i][j] = 2 + dp[i + 1][j - 1];
                    else
                        dp[i][j] = Math.Max(dp[i][j - 1], dp[i + 1][j]);
                }
            }

            return dp[0][len - 1];

        }

        public int Solution2(string s)
        {
            int len = s.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                dp[i][i] = 1;
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = len - l; i >= 0; i--)
                {
                    int j = i + l - 1;
                    if (s[i] == s[j])
                    {
                        dp[i][j] = 2 + dp[i + 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i][j - 1], dp[i + 1][j]);
                    }
                }
            }

            return dp[0][len - 1];

        }

    }
}
