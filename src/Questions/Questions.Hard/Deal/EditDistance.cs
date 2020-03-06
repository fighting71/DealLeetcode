using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/6/2020 11:04:35 AM
    /// @source : https://leetcode.com/problems/edit-distance/
    /// @des : 
    /// </summary>
    public class EditDistance
    {

        /**
         * 
         * Runtime: 68 ms, faster than 98.82% of C# online submissions for Edit Distance.
         * Memory Usage: 26 MB, less than 14.29% of C# online submissions for Edit Distance.
         * 
         * From recursion to dp 
         * 
         */
        public int DpSolution(string word1, string word2)
        {

            int m = word1.Length, n = word2.Length;

            if (m == 0) return n;
            if (n == 0) return m;

            int[][] dp = new int[m + 1][];
            for (int i = 0; i < m + 1; i++)
                dp[i] = new int[n + 1];

            for (int i = 1; i < m + 1; i++)
                dp[i][0] = i;

            for (int i = 1; i < n + 1; i++)
                dp[0][i] = i;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    dp[i + 1][j + 1] = dp[i][j + 1] + 1;// add
                    dp[i + 1][j + 1] = Math.Min(dp[i + 1][j + 1], dp[i][j] + word1[i] == word2[j] ? 0 : 1);//  replace or equal
                    dp[i + 1][j + 1] = Math.Min(dp[i + 1][j + 1], dp[i + 1][j] + 1);// remove
                }

            return dp[m][n];
        }

        // time limit
        // 递归 》》 暴力破解法 ~
        public int Recursion(string word1, string word2)
        {
            return Helper(word1, word2, 0, 0, 0);
        }

        private int Helper(string s,string s2,int i,int j,int count)
        {
            if (i == s.Length) return count + s2.Length - j;
            if (j == s2.Length) return count + s.Length - i;

            var old = count;

            count = Helper(s, s2, i, j + 1, old + 1);// add

            count = Math.Min(count, Helper(s, s2, i + 1, j + 1, old + s[i] == s2[j] ? 0 : 1));// replace or equal

            count = Math.Min(count, Helper(s, s2, i + 1, j, old + 1));// remove

            return count;

        }

        // bug
        public int Try(string word1, string word2)
        {

            int m = word1.Length, n = word2.Length, same = 0;

            if (m == n)
            {
                for (int i = 0; i < m; i++)
                {
                    if (word1[i] == word2[i]) same++;
                }
                return m - same;
            }

            if (m > n)
            {
                for (int i = 0; i <= m - n; i++)
                {
                    var count = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (word1[i + j] == word2[j]) count++;
                    }
                    same = Math.Max(same, count);
                }
                return m - same;
            }

            for (int i = 0; i <= n - m; i++)
            {
                var count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (word1[j] == word2[i + j]) count++;
                }
                same = Math.Max(same, count);
            }

            return n - same;

        }

    }
}
