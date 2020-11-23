using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 5:21:05 PM
    /// @source : https://leetcode.com/problems/implement-strstr/
    /// @des : 
    /// </summary>
    public class Implement_strStr
    {

        // 0 <= haystack.length, needle.length <= 5 * 104
        // haystack and needle consist of only lower-case English characters.

        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;

            int m = needle.Length,n = haystack.Length;

            #region KMP

            #region init

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[26];
            }

            // 影子坐标 ***
            int x = 0;
            // base case
            dp[0][needle[0] - 'a'] = 1;
            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    dp[i][j] = dp[x][j];
                }
                var index = needle[i] - 'a';
                dp[i][index] = i + 1;
                // update 影子
                x = dp[x][index];
            }

            #endregion

            #region find res

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                k = dp[k][haystack[i] - 'a'];
                if (k == m) return i - m + 1;
            }

            return -1;

            #endregion

            #endregion

        }

        #region core span 快于[自己写的]<KMP>...
        //public int OldSolution(string haystack, string needle)
        //{
        //    if (needle.Length == 0)
        //        return 0;

        //    var readOnlySpan = haystack.AsSpan();
        //    var result = true;
        //    ReadOnlySpan<char> onlySpan;

        //    for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        //    {
        //        onlySpan = readOnlySpan.Slice(i, needle.Length);

        //        result = true;

        //        for (var j = 0; j < onlySpan.Length; j++)
        //            if (onlySpan[j] != needle[j])
        //            {
        //                result = false;
        //                break;
        //            }

        //        if (result)
        //            return i;
        //    }

        //    return -1;
        //}
        #endregion

    }
}
