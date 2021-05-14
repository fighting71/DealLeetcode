using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/13/2021 3:53:59 PM
    /// @source : https://leetcode.com/explore/featured/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3741/
    /// @des : 坐标转换
    /// </summary>
    [Optimize("Slow")]
    public class Ambiguous_Coordinates
    {
        // 4 <= s.length <= 12.
        // s[0] = "(", s[s.length - 1] = ")", and the other elements in s are digits.

        // Runtime: 252 ms
        // Memory Usage: 33.9 MB
        // ...
        public IList<string> Optimize(string s)
        {
            IList<string> res = new List<string>();

            int len = s.Length;

            Dictionary<string, string[]> cache = new Dictionary<string, string[]>();

            for (int mid = 1; mid < len - 2; mid++)
            {
                string[] left = GetMaybe(s.AsSpan(1, mid).ToString());

                if (left.Length == 0) continue;

                string[] right = GetMaybe(s.AsSpan(mid + 1, len - 2 - mid).ToString());

                if (right.Length == 0) continue;

                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        res.Add($"({l}, {r})");
                    }
                }
            }

            return res;

            string[] GetMaybe(string str)
            {
                if (cache.TryGetValue(str, out var maybe))
                    return maybe;

                if (str.Length == 1)
                {
                    return cache[str] = new[] { str };
                }

                bool firstIsZero = str[0] == '0';

                if (str[str.Length - 1] == '0')
                {
                    if(firstIsZero) return cache[str] = Array.Empty<string>();
                    else return cache[str] = new[] { str };
                }

                if (firstIsZero)
                {
                    return cache[str] = new[] { "0." + str.AsSpan(1).ToString() };
                }

                string[] res = cache[str] = new string[str.Length];
                res[0] = str;
                for (int i = 1; i < str.Length; i++)
                {
                    res[i] = str.AsSpan(0, i).ToString() + "." + str.AsSpan(i).ToString();
                }
                return res;
            }

        }

        // Runtime: 252 ms
        // Memory Usage: 33.5 MB
        // slow
        public IList<string> Simple(string s)
        {
            IList<string> res = new List<string>(), leftList = new List<string>(), rigthList = new List<string>();

            int len = s.Length;

            for (int mid = 1; mid < len - 2; mid++)
            {
                ReadOnlySpan<char> left = s.AsSpan(1, mid);

                GetMaybe(left, leftList);

                if (leftList.Count == 0) continue;

                var right = s.AsSpan(mid + 1, len - 2 - mid);

                GetMaybe(right, rigthList);

                if (rigthList.Count == 0) continue;

                foreach (var l in leftList)
                {
                    foreach (var r in rigthList)
                    {
                        res.Add($"({l}, {r})");
                    }
                }
            }

            return res;

            void GetMaybe(ReadOnlySpan<char> str, IList<string> list)
            {
                list.Clear();

                if (str.Length == 1)
                {
                    list.Add(str.ToString());
                    return;
                }

                bool firstIsZero = str[0] == '0';
                if (!firstIsZero)
                {
                    list.Add(str.ToString());
                }

                if (str[str.Length - 1] == '0') return;

                if (firstIsZero)
                {
                    list.Add("0." + str.Slice(1).ToString());
                    return;
                }

                for (int i = 1; i < str.Length; i++)
                {
                    list.Add(str.Slice(0, i).ToString() + "." + str.Slice(i).ToString());
                }

            }

        }

    }
}
