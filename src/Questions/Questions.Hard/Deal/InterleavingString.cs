using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/10/2020 10:49:40 AM
    /// @source : https://leetcode.com/problems/interleaving-string/
    /// @des : 
    /// </summary>
    public class InterleavingString
    {
        /// <summary>
        /// Runtime: 68 ms, faster than 95.65% of C# online submissions for Interleaving String.
        /// Memory Usage: 22.7 MB, less than 100.00% of C# online submissions for Interleaving String.
        /// </summary>
        /// <returns></returns>
        public bool DpSolution(string s1, string s2, string s3)
        {

            if (s1.Length + s2.Length != s3.Length) return false;

            int m = s1.Length, n = s2.Length, l = s3.Length;

            //for (int i = 0; i < l; i++)
            //{
            //    Console.WriteLine($"{(i >= m ? '-' : s1[i])} {(i >= n ? '-' : s2[i])} {s3[i]}");
            //}

            bool[][] dp = new bool[m + 1][];

            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new bool[n + 1];
            }

            dp[0][0] = true;

            for (int i = 0; i < l; i++)
            {
                //bool swaped = false;
                for (int j = 0, k = i - j + 1; j <= i + 1; j++, k = i - j + 1)
                {
                    if (j > m) continue;
                    if (k > n) continue;
                    if (j == 0) dp[j][k] = s2[k - 1] == s3[i] && dp[j][k - 1];
                    else if (k == 0) dp[j][k] = s1[j - 1] == s3[i] && dp[j - 1][k];
                    else
                    {
                        if (s1[j - 1] == s3[i])
                        {
                            dp[j][k] = dp[j - 1][k];
                        }
                        if (dp[j][k]) continue;
                        if (s2[k - 1] == s3[i])
                        {
                            dp[j][k] = dp[j][k - 1];
                        }
                    }
                    //else if (s1[j - 1] == s2[k - 1])
                    //{
                    //    dp[j][k] = s1[j - 1] == s3[i] && (dp[j - 1][k] || dp[j][k - 1]);
                    //}
                    //else if (s1[j - 1] == s3[i])
                    //{
                    //    dp[j][k] = dp[j - 1][k];
                    //}
                    //else if (s2[k - 1] == s3[i])
                    //{
                    //    dp[j][k] = dp[j][k - 1];
                    //}
                    //if (!swaped && dp[j][k]) swaped = true;
                }
                //if (!swaped) return false;
            }

            //ShowTools.ShowMatrix(dp);
            //return true;
            return dp[m][n];

        }

        /// <summary>
        /// Runtime: 2232 ms, faster than 5.22% of C# online submissions for Interleaving String.
        /// Memory Usage: 22.4 MB, less than 100.00% of C# online submissions for Interleaving String.
        /// 
        /// 暴力破解法能通过的都是仁慈的测试案例~
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Simple(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;// length don't match
            return Help(s1, s2, s3, 0, 0, 0);
        }

        private bool Help(string s1, string s2, string s3,int i,int j,int k)
        {

            if (i > s1.Length) return false;
            if (j > s2.Length) return false;
            if (k == s3.Length) return true;

            if(i == s1.Length)// s1 is used up => match s2
            {
                if (s2[j] == s3[k]) return Help(s1, s2, s3, i, j + 1, k + 1);
                return false;
            }
            
            if(j== s2.Length)// Same as above
            {
                if (s1[i] == s3[k]) return Help(s1, s2, s3, i + 1, j, k + 1);
                return false;
            }

            if (s1[i] == s2[j])// s1[i] == s2[j]
            {
                // match s1[i] or s2[j]
                if (s3[k] == s1[i]) return Help(s1, s2, s3, i + 1, j, k + 1) || Help(s1, s2, s3, i, j + 1, k + 1);
                return false;
            }
            
            if (s1[i] == s3[k])
            {
                return Help(s1, s2, s3, i + 1, j, k + 1);
            }
            
            if (s2[j] == s3[k])
            {
                return Help(s1, s2, s3, i, j + 1, k + 1);
            }

            return false;
        }

    }
}
