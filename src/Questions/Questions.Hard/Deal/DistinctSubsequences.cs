using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/17/2020 3:20:44 PM
    /// @source : https://leetcode.com/problems/distinct-subsequences/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class DistinctSubsequences
    {

        /// <summary>
        /// Runtime: 84 ms, faster than 38.46% of C# online submissions for Distinct Subsequences.
        /// Memory Usage: 25 MB, less than 100.00% of C# online submissions for Distinct Subsequences.
        /// 
        /// 差点以为慢死了...
        /// 
        /// Runtime: 76 ms, faster than 88.46% of C# online submissions for Distinct Subsequences.
        /// Memory Usage: 25.1 MB, less than 100.00% of C# online submissions for Distinct Subsequences.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int DPSolution(string s, string t)
        {

            int n = s.Length, m = t.Length;

            if (n < m) return 0;
            if (n == m) return s == t ? 1 : 0;

            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
                dp[i] = new int[m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m && j <= i; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (dp[i - 1][j] != 0 || dp[i - 1][j - 1] != 0)
                            dp[i][j] = dp[i - 1][j] + (s[i] != t[j] ? 0 : Math.Max(1, dp[i - 1][j - 1]));
                    }
                    else if (i > 0)
                        dp[i][j] = dp[i - 1][j] + (s[i] != t[j] ? 0 : 1);
                    else
                        dp[i][j] = s[i] != t[j] ? 0 : 1;
                }

            ShowTools.ShowMatrix(dp);

            return dp[n - 1][m - 1];

        }

        /// <summary>
        /// Runtime: 72 ms, faster than 96.15% of C# online submissions for Distinct Subsequences.
        /// Memory Usage: 24.5 MB, less than 100.00% of C# online submissions for Distinct Subsequences.
        /// 
        /// heihei 我好了~
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int DPSolution3(string s, string t)
        {

            int n = s.Length, m = t.Length;

            if (n < m) return 0;
            if (n == m) return s == t ? 1 : 0;

            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
                dp[i] = new int[Math.Min(i + 1, m)];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m && j <= i; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        var num = 0;
                        if ((i - 1 >= j && (num = dp[i - 1][j]) != 0) || dp[i - 1][j - 1] != 0)
                            dp[i][j] = num + (s[i] != t[j] ? 0 : Math.Max(1, dp[i - 1][j - 1]));
                    }
                    else if (i > 0)
                        dp[i][j] = dp[i - 1][j] + (s[i] != t[j] ? 0 : 1);
                    else
                        dp[i][j] = s[i] != t[j] ? 0 : 1;
                }

            ShowTools.ShowMatrix(dp);

            return dp[n - 1][m - 1];

        }

        /// <summary>
        /// Runtime: 80 ms, faster than 67.31% of C# online submissions for Distinct Subsequences.
        /// Memory Usage: 24.9 MB, less than 100.00% of C# online submissions for Distinct Subsequences.
        /// 
        /// 占用更多空间，速度稍慢
        /// 优势：好看一点...
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int DPSolution2(string s, string t)
        {

            int n = s.Length, m = t.Length;

            if (n < m) return 0;
            if (n == m) return s == t ? 1 : 0;

            int[][] dp = new int[n+1][];

            for (int i = 0; i < n+1; i++)
                dp[i] = new int[m+1];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m && j <= i; j++)
                    if (dp[i][j + 1] != 0 || dp[i][j] != 0 || i == 0 || j == 0)
                        dp[i + 1][j + 1] = dp[i][j + 1] + (s[i] != t[j] ? 0 : Math.Max(1, dp[i][j]));

            //ShowTools.ShowMatrix(dp);

            return dp[n][m];

        }

        int res;
        // Time Limit Exceeded 
        // 意料之中，只要不是
        public int RecursionSolution(string s, string t)
        {
            res = 0;
            RecursionHelp(s, t, 0, 0);
            return res;
        }

        private void RecursionHelp(string s,string t,int i,int j)
        {
            if (j == t.Length)
            {
                res++;
                return;
            }
            if (i == s.Length) return;
            if (s[i] != t[j])
            {
                RecursionHelp(s, t, i + 1, j);
            }
            else
            {
                RecursionHelp(s, t, i + 1, j + 1);
                RecursionHelp(s, t, i + 1, j);
            }

        }

    }
}
