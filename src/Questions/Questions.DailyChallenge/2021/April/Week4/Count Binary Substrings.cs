using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/23/2021 4:49:15 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3718/
    /// @des : 
    /// </summary>
    public class Count_Binary_Substrings
    {

        // s.length will be between 1 and 50,000.
        // s will only consist of "0" or "1" characters.

        // Runtime: 148 ms
        // Memory Usage: 32.5 MB
        public int Try3(string s)
        {

            int res = 0, len = s.Length, prev = 0, curr = 1;

            var currC = s[0];

            for (int i = 1; i < len; i++)
            {
                if(currC == s[i])
                {
                    curr++;
                }
                else
                {
                    currC = s[i];
                    prev = curr;
                    curr = 1;
                }
                if (prev >= curr) res++;
            }

            return res;
        }
        public int Try2(string s)
        {

            int res = 0, len = s.Length;

            bool[][] dp = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new bool[len];
            }

            for (int i = 1; i < len; i++)
            {
                if (s[i] != s[i - 1])
                {
                    dp[i - 1][i] = true;
                    res++;
                }
            }

            for (int count = 4; count < s.Length; count += 2)
            {
                for (int start = 0; start <= s.Length - count; start++)
                {
                    var end = start + count - 1;

                    if (s[start] != s[end] && s[start] == s[start + 1] && dp[start + 1][end - 1])
                    {
                        dp[start][end] = true;
                        res++;
                    }

                }
            }

            return res;

        }
        // time limit
        public int Simple(string s)
        {
            int len = s.Length, res = 0;
            for (int i = 0; i < len; i++)
            {
                var curr = s[i];
                int count = 1, otherCount = 0;

                for (int j = i + 1; j < len; j++)
                {
                    if (s[j] == curr)
                    {
                        if (otherCount > 0) break;
                        count++;
                    }
                    else
                    {
                        otherCount++;
                        if (otherCount == count)
                        {
                            res++;
                            break;
                        }
                    }
                }
            }

            return res;
        }

        // bug: 此解跳过了内容重复的部分，但题意未跳过...
        public int Try(string s)
        {

            List<int> oneIndexList = new List<int>();
            List<int> zeroIndexList = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    oneIndexList.Add(i);
                }
                else
                {
                    zeroIndexList.Add(i);
                }
            }

            int res = 0, len = s.Length;

            for (int i = oneIndexList.Count - 1; i >= 0; i--)
            {
                var index = oneIndexList[i];

                var oneCount = i + 1;
                var maxZeroCount = len - index - 1 - (oneIndexList.Count - i - 1);

                if (maxZeroCount >= oneCount)
                {
                    res += oneCount;
                    break;
                }

            }

            for (int i = zeroIndexList.Count - 1; i >= 0; i--)
            {
                var index = zeroIndexList[i];

                var zeroCount = i + 1;
                var maxOneCount = len - index - 1 - (zeroIndexList.Count - i - 1);

                if (maxOneCount >= zeroCount)
                {
                    res += zeroCount;
                    break;
                }

            }

            return res;
        }

    }
}
