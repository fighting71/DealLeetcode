using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 2:03:45 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3595/
    /// @des : 给定一个字符串s，找出没有重复字符的最长子串的长度。(子串是连续的)
    /// </summary>
    public class Longest_Substring_Without_Repeating_Characters
    {

        // 0 <= s.length <= 5 * 10^4
        // s consists of English letters, digits, symbols and spaces.

        public int Optimize(string s)
        {
            int count = 0, itemCount = 0, start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                itemCount++;
                for (int j = i - 1; j >= start; j--) // from big to smaller
                {
                    if (s[i] == s[j])
                    {
                        start = j + 1;
                        itemCount = i - j;
                        break;
                    }
                }

                if (itemCount > count) count = itemCount;
            }

            return count;
        }
        public int OldSolution(string s)
        {
            int count = 0, itemCount = 0, start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                itemCount++;
                for (int j = start; j < i; j++)
                {
                    if (s[i] == s[j])
                    {
                        start = j + 1;// *.
                        itemCount = i - j;
                        break;
                    }
                }

                if (itemCount > count) count = itemCount;
            }

            return count;
        }

        // Your runtime beats 19.06 % 
        public int Try(string s)
        {
            int len = s.Length, res = 0;

            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                if (dic.ContainsKey(c)) // 若已存在此字母则更新dic 重新开始 例如 : abcabcbb 当走到 abc->a 时 变更为 bca -> next
                {
                    res = Math.Max(res, dic.Count);

                    int start = dic[c];
                    dic.Remove(c);
                    foreach (var item in dic.Keys.ToArray())
                    {
                        if (dic[item] < start) dic.Remove(item);
                    }
                    dic[c] = i;
                }
                else
                {
                    dic.Add(c, i);
                }
            }

            return Math.Max(res, dic.Count);
        }

        public int Simple(string s)
        {
            int len = s.Length;

            int res = 0;
            for (int i = 0; i < len; i++)
            {
                ISet<char> set = new HashSet<char>();
                for (int j = i; j < len; j++)
                {
                    if (set.Contains(s[j])) break;
                    set.Add(s[j]);
                }
                res = Math.Max(res, set.Count);
            }
            return res;
        }

    }
}
