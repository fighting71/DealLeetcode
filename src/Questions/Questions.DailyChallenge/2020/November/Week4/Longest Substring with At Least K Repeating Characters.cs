using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/27/2020 2:01:59 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3544/
    /// @des : 求子串，
    /// </summary>
    [Optimize]
    public class Longest_Substring_with_At_Least_K_Repeating_Characters
    {

        // 1 <= s.length <= 104
        // s consists of only lowercase English letters.
        // 1 <= k <= 105

        // bug : 子串并非任意添加或替换
        public int LongestSubstring(string s, int k)
        {
            int[] count = new int[26];

            foreach (var c in s)
            {
                count[c - 'a']++;
            }

            int sum = 0;
            foreach (var item in count)
            {
                if (item >= k) sum += item;
            }
            return sum;

        }

        // Runtime: 1200 ms
        public int Simple(string s, int k)
        {
            int len = s.Length;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                int[] arr = new int[26];
                int count = 0;
                for (int j = i; j < len; j++)
                {
                    var key = s[j] - 'a';

                    var value = ++arr[key];

                    if (value == 1)
                    {
                        count = 1;
                    }
                    else if (value == count + 1)
                    {
                        count++;
                        foreach (var item in arr)
                        {
                            if (item == 0) continue;
                            if (item < count)
                            {
                                count--;
                                break;
                            }
                        }
                    }
                    if (count >= k)
                    {
                        res = Math.Max(res, j - i + 1);
                    }
                }
            }

            return res;
        }

        private struct DpItem
        {
            public int[] Count { get; set; }
        }

        // Runtime: 332 ms
        // 228 ms, faster than 7.89% of 
        // ... 
        public int Optimize(string s, int k)
        {
            int len = s.Length;
            int res = 0;
            int[] need = new int[26];
            for (int i = 0; i < len; i++)
            {
                int needCount = 0;
                Array.Fill(need, 0);
                for (int j = i; j < len; j++)
                {
                    var key = s[j] - 'a';
                    var value = ++need[key];
                    if (value == 1) needCount += k - 1;
                    else if (value <= k) needCount--;
                    if (needCount == 0) res = Math.Max(res, j - i + 1);
                }
            }

            return res;
        }

        public int Optimize2(string s, int k)
        {
            return default;
        }
    }
}
