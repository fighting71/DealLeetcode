using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp.动态规划之正则表达
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 2:42:53 PM
    /// @source : https://leetcode.com/problems/regular-expression-matching/
    /// @des : 
    /// </summary>
    public class Regular_Expression_Matching
    {

        public bool OldSolution(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }
            bool[][] dp = new bool[s.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[p.Length + 1];
            }

            dp[0][0] = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '*' && dp[0][i - 1])
                {
                    dp[0][i + 1] = true;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '.')
                    {
                        dp[i + 1][j + 1] = dp[i][j];
                    }
                    else if (p[j] == s[i])
                    {
                        dp[i + 1][j + 1] = dp[i][j];
                    }
                    else if (p[j] == '*')
                    {
                        if (p[j - 1] != s[i] && p[j - 1] != '.')
                        {
                            dp[i + 1][j + 1] = dp[i + 1][j - 1];
                        }
                        else
                        {
                            dp[i + 1][j + 1] = (dp[i + 1][j] || dp[i][j + 1] || dp[i + 1][j - 1]);
                        }
                    }
                }
            }
            return dp[s.Length][p.Length];

        }
    }
}