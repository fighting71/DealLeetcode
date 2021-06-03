using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/2/2021 5:08:24 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3765/
    /// @des : 
    /// 
    ///     给定字符串s1、s2和s3，找出s3是否由s1和s2交织而成。
    ///     两个字符串s和t的交错是一种构型，它们被分成非空的子字符串，如下所示:
    ///     S = s1 + s2 +…+ sn
    ///     T = t1 + t2 +…+ tm
    ///     交错是s1 + t1 + s2 + t2 + s3 + t3 +…或者t1 + s1 + t2 + s2 + t3 + s3 +…
    ///     注意:a + b是字符串a和b的连接。
    /// 
    /// </summary>
    [Optimize(FlagConst.Slow)]
    public class Interleaving_String
    {

        // Constraints:

        //0 <= s1.length, s2.length <= 100
        //0 <= s3.length <= 200
        //s1, s2, and s3 consist of lowercase English letters.

        // Follow up: Could you solve it using only O(s2.length) additional memory space?
        public bool Optimize(string s1, string s2, string s3)
        {

            // "aabcc", "dbbca", "aadbbcbcac"

            //abc  abdc    abdc

            return false;
        }

        // Your runtime beats 14.66 %
        // 100 ms 
        // ... 解法问题
        public bool Try2(string s1, string s2, string s3)
        {
            int len = s1.Length, len2 = s2.Length, len3 = s3.Length;

            if (len + len2 != len3) return false;

            bool[][] dp = new bool[len + 1][];
            for (int i = 0; i < len + 1; i++)
            {
                dp[i] = new bool[len2 + 1];
            }

            dp[0][0] = true;

            for (int i = 0; i <= len; i++)
            {
                for (int j = 0; j <= len2; j++)
                {
                    if (i == 0 && j == 0) continue;

                    char c3 = s3[i + j - 1];

                    if (i != 0 && s1[i - 1] == c3)
                    {
                        if (dp[i - 1][j])
                        {
                            dp[i][j] = true;
                            continue;
                        }
                    }
                    if (j != 0 && s2[j - 1] == c3)
                    {
                        if (dp[i][j - 1])
                        {
                            dp[i][j] = true;
                            continue;
                        }
                    }
                }
            }

            return dp[len][len2];

        }

        // Runtime: 96 ms
        // Memory Usage: 23.6 MB
        // Your runtime beats 14.66 %  .... ??? 
        public bool Try(string s1, string s2, string s3)
        {

            int len = s1.Length, len2 = s2.Length, len3 = s3.Length;

            if (len + len2 != len3) return false;

            bool[][] dp = new bool[len + 1][];
            for (int i = 0; i < len + 1; i++)
            {
                dp[i] = new bool[len2 + 1];
            }

            for (int i = 0; i < len; i++)
            {
                if (s1[i] == s3[i])
                {
                    dp[i + 1][0] = true;
                }
                else break;
            }

            for (int i = 0; i < len2; i++)
            {
                if (s2[i] == s3[i])
                {
                    dp[0][i + 1] = true;
                }
                else break;
            }

            dp[0][0] = true;

            for (int i = 1; i <= len; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    char c = s1[i - 1], c2 = s2[j - 1], c3 = s3[i + j - 1];

                    if(c == c3)
                    {
                        if (dp[i - 1][j])
                        {
                            dp[i][j] = true;
                            continue;
                        }
                    }
                    if (c2 == c3)
                    {
                        if (dp[i][j - 1])
                        {
                            dp[i][j] = true;
                            continue;
                        }
                    }
                }
            }

            return dp[len][len2];

        }

        // Your runtime beats 12.07 %
        public bool Simple(string s1, string s2, string s3)
        {

            int len = s1.Length, len2 = s2.Length, len3 = s3.Length;

            if (len + len2 != len3) return false;

            bool?[][] cache = new bool?[len + 1][];
            for (int i = 0; i < len + 1; i++)
            {
                cache[i] = new bool?[len2 + 1];
            }

            return Help(0, 0, 0);

            bool Help(int index, int index2, int index3)
            {
                var hasV = cache[index][index2];

                if (hasV.HasValue) return hasV.Value;

                if (index3 == len3) return true;

                if (index == len)
                {
                    var old = index2;
                    bool res = true;
                    for (; index3 < len3; index3++, index2++)
                    {
                        if (s2[index2] != s3[index3])
                        {
                            res = false;
                            break;
                        }
                    }
                    cache[index][old] = res;
                    return res;
                }
                else if (index2 == len2)
                {
                    var old = index;
                    bool res = true;
                    for (; index3 < len3; index3++, index++)
                    {
                        if (s1[index] != s3[index3])
                        {
                            res = false;
                            break;
                        }
                    }
                    cache[old][index2] = res;
                    return res;
                }
                else
                {
                    char c = s1[index], c2 = s2[index2], c3 = s3[index3];
                    bool res = false;
                    if (c == c2)
                    {
                        if (c == c3)
                        {
                            res = Help(index + 1, index2, index3 + 1) || Help(index, index2 + 1, index3 + 1);
                        }
                    }
                    else if (c == c3)
                    {
                        res = Help(index + 1, index2, index3 + 1);
                    }
                    else if (c2 == c3)
                    {
                        res = Help(index, index2 + 1, index3 + 1);
                    }
                    cache[index][index2] = res;
                    return res;
                }

            }

        }

    }
}
