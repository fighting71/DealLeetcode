using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/8/2021 4:52:36 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3665/
    /// @des : 
    ///     给定一个字符串{此字符串只由'a'和'b'字母构成}
    ///     在每一步中，你可以从此字符串中删除一个可构造回文数的子序列
    ///     target:
    ///         最少需要几步，可以将字符串删完
    ///         
    ///     no 动态规划!!!! ===>
    ///             Hide Hint #1  
    ///         Use the fact that string contains only 2 characters.
    ///             Hide Hint #2  
    ///         Are subsequences composed of only one type of letter always palindrome strings ?
    ///         
    ///     看完提示才发现是我想多了，只由(a/b)构成的字符串，不管长啥样，最多也就两步搞定(第一步删a,第二步删b....) 恶心到了。
    /// 
    /// </summary>
    public class Remove_Palindromic_Subsequences
    {

        // 0 <= s.length <= 1000
        // s only consists of letters 'a' and 'b'

        // Your runtime beats 81.40 % of csharp submissions.
        public int Try(string s)
        {

            if (s.Length < 2) return s.Length;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return 2;
                }
            }

            return 1;
        }

        public int Think(string s)
        {
            int len = s.Length;
            if (len < 2) return len;

            // 获取子序列中最大回文数的长度
            int[][] dp = new int[len][];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                dp[i][i] = 1;
            }

            for (int wid = 1; wid < len; wid++)
            {
                for (int start = 0; start < len - wid; start++)
                {
                    int end = start + wid;
                    if(s[start] == s[end])
                    {
                        dp[start][end] = 2 + dp[start + 1][end - 1];
                    }
                    else
                    {
                        dp[start][end] = 1 + Math.Max(dp[start][end - 1], dp[start + 1][end]);
                    }
                }
            }

            return 0;
        }
    }
}
