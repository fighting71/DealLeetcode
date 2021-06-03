using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/1/2021 4:25:28 PM
    /// @source : https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string/
    /// @des : 
    /// 
    ///     定义一个函数 CountSingle(s)，它返回s上唯一字符的数量，例如，如果s = "LEETCODE"，那么"L"， "T"，"C"，"O"，"D"是唯一字符，因为它们只在s中出现一次，因此 CountSingle(s) = 5
    ///     
    ///     在这基础上，给定一个字符串 s, 需要返回 CountSingle(t) 的和，其中t是s的子字符串
    /// 
    ///     因为答案可能非常大，所以以10 ^ 9 + 7取模返回答案。
    /// 
    /// </summary>
    [Optimize("slow")]
    public class Count_Unique_Characters_of_All_Substrings_of_a_Given_String
    {

        /*
         * Constraints:
         * 0 <= s.length <= 10^4
         * s contain upper-case English letters only.
         */

        const int mod = 1000_000_007;

        class Brev
        {
            public int Key { get; set; }
            public int Count { get; set; }
        }

        // 差别不是很大
        public int Optimize(string s)
        {

            int len = s.Length;

            if (len == 0) return 0;

            int maxDiffCount = s.GroupBy(u => u).Count();

            int res = s.Length;

            Brev prev = new Brev { Count = 1, Key = s[0] - 'A' };
            int prevCount = 1;
            List<Brev> list = new List<Brev>() { prev };
            for (int j = 1; j < s.Length; j++)
            {
                var key = s[j] - 'A';

                if(prev.Count > 1 && prev.Key == key)
                {
                    prev.Count++;
                    res = (res + prevCount) % mod;
                    continue;
                }

                int[] exists = new int[26];
                exists[key] = 1;
                int matchCount = 1;
                int diffCount = 1;

                prevCount = 0;

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    var item = list[i];
                    int curr = 0;
                    ref int existsCount = ref exists[item.Key];

                    if (existsCount == 0)
                    {
                        diffCount++;
                        if (item.Count == 1)
                        {
                            matchCount++;
                        }
                        else
                        {
                            curr++;
                        }
                    }
                    else if(existsCount == 1)
                    {
                        matchCount--;
                        if (matchCount == 0 && diffCount == maxDiffCount) break;
                    }
                    curr = (curr + matchCount * item.Count) % mod;
                    prevCount = (prevCount + curr) % mod;
                    res = (res + curr) % mod;
                    existsCount += item.Count;
                }
                if (prev.Key == key)
                {
                    prev.Count++;
                }
                else
                {
                    prev = new Brev { Key = key, Count = 1 };
                    list.Add(prev);
                }
            }
            return res;

        }

        // Runtime: 884 ms, faster than 14.29% of C# online submissions for Count Unique Characters of All Substrings of a Given String.
        // Memory Usage: 33.1 MB, less than 14.29% of C# online submissions for Count Unique Characters of All Substrings of a Given String.
        public int Try4(string s)
        {
            int len = s.Length;

            if (len == 0) return 0;

            List<Brev> list = new List<Brev>();

            int res = 0;

            Brev prev = null;
            foreach (var c in s)
            {
                var key = c - 'A';
                if (prev == null)
                {
                    prev = new Brev { Key = key, Count = 1 };
                    res += 1;
                    list.Add(prev);
                    continue;
                }

                int[] exists = new int[26];
                exists[key] = 1;
                int matchCount = 1;
                int diffCount = 1;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    var item = list[i];

                    ref int existsCount = ref exists[item.Key];

                    if (existsCount > 1)
                    {
                        long l = (matchCount * (long)item.Count) % mod;
                        res = (int)((res + l) % mod);
                    }
                    else if (existsCount == 0)
                    {
                        diffCount++;
                        if (item.Count == 1)
                        {
                            matchCount++;
                            existsCount = 1;
                            res = (res + matchCount) % mod;
                        }
                        else
                        {
                            long l = (matchCount * (long)item.Count) % mod;
                            existsCount = item.Count;
                            res = (int)((res + 1 + l) % mod);
                        }
                    }
                    else
                    {
                        existsCount = 2;
                        matchCount--;
                        if (matchCount == 0 && diffCount == 26) break;
                        long l = (matchCount * (long)item.Count) % mod;
                        res = (int)((res + l) % mod);
                    }

                }

                res++;
                if (prev.Key == key)
                {
                    prev.Count++;
                }
                else
                {
                    prev = new Brev { Key = key, Count = 1 };
                    list.Add(prev);
                }


            }

            return res;
        }

        // 712 ms ... 
        public int Try3(string s)
        {
            int len = s.Length;
            Item[] dp = new Item[len];
            int res = len;

            bool[] t = new bool[26];
            int maxCount = 0;

            for (int i = 0; i < len; i++)
            {
                var flag = new int[26];
                var curr = s[i] - 'A';
                if(!t[curr])
                {
                    maxCount++;
                    t[curr] = true;
                }
                flag[curr] = 1;
                dp[i] = new Item
                {
                    Exists = flag,
                    SingleCount = 1,
                    RepetitionCount = 1
                };
            }

            for (int count = 1; count < len; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    var currDp = dp[i];
                    if (currDp.Skip)
                    {
                        continue;
                    }
                    var curr = s[i + count] - 'A';

                    ref int exist = ref currDp.Exists[curr];

                    if (exist == 0)
                    {
                        exist = 1;
                        currDp.SingleCount++;
                        currDp.RepetitionCount++;
                    }
                    else if (exist == 1)
                    {
                        exist = 2;
                        currDp.SingleCount--;
                        if (currDp.SingleCount == 0 && currDp.RepetitionCount == maxCount)
                        {
                            currDp.Skip = true;
                        }
                    }

                    res = (res + currDp.SingleCount) % mod;
                }
            }

            return res;
        }
        // 496 ms  Time Limit
        public int Try2(string s)
        {
            const int mod = 1000_000_007;
            int len = s.Length;
            Item[] dp = new Item[len];
            int res = len;
            for (int i = 0; i < len; i++)
            {
                var flag = new int[26];
                flag[s[i] - 'A'] = 1;
                dp[i] = new Item
                {
                    Exists = flag,
                    SingleCount = 1,
                    RepetitionCount = 1
                };
            }

            for (int count = 1; count < len; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    var currDp = dp[i];
                    if (currDp.Skip)
                    {
                        continue;
                    }
                    var curr = s[i + count] - 'A';

                    ref int exist = ref currDp.Exists[curr];

                    if (exist == 0)
                    {
                        exist = 1;
                        currDp.SingleCount++;
                        currDp.RepetitionCount++;
                    }
                    else if (exist == 1)
                    {
                        exist = 2;
                        currDp.SingleCount--;
                        if(currDp.SingleCount == 0 && currDp.RepetitionCount == 26)
                        {
                            currDp.Skip = true;
                        }
                    }

                    res = (res + currDp.SingleCount) % mod;
                }
            }

            return res;
        }
        // 992 ms  Time Limit
        public int Try(string s)
        {
            const int mod = 1000_000_007;
            int len = s.Length;
            Item[] dp = new Item[len];
            int res = len;
            for (int i = 0; i < len; i++)
            {
                var flag = new int[26];
                flag[s[i] - 'A'] = 1;
                dp[i] = new Item
                {
                    Exists = flag,
                    SingleCount = 1,
                    RepetitionCount = 1
                };
            }

            for (int count = 1; count < len; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    var arr = dp[i];
                    if (arr.SingleCount == 0 && arr.RepetitionCount == 26)
                    {
                        res = (res + arr.SingleCount) % mod;
                        continue;
                    }
                    var curr = s[i + count] - 'A';

                    ref int exist = ref arr.Exists[curr];

                    if (exist == 0)
                    {
                        exist = 1;
                        arr.SingleCount++;
                        arr.RepetitionCount++;
                    }
                    else if (exist == 1)
                    {
                        exist = 2;
                        arr.SingleCount--;
                    }

                    res = (res + arr.SingleCount) % mod;
                }
            }

            return res;
        }

        // Time Limit
        public int Simple(string s)
        {
            const int mod = 1000_000_007;
            int len = s.Length;
            Item[] dp = new Item[len];
            int res = len;
            for (int i = 0; i < len; i++)
            {
                var flag = new int[26];
                flag[s[i] - 'A'] = 1;
                dp[i] = new Item
                {
                    Exists = flag,
                    SingleCount = 1
                };
            }

            for (int count = 1; count < len; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    var arr = dp[i];

                    var curr = s[i + count] - 'A';

                    ref int exist = ref arr.Exists[curr];

                    if (exist == 0)
                    {
                        exist = 1;
                        arr.SingleCount++;
                    }
                    else if(exist == 1)
                    {
                        exist = 2;
                        arr.SingleCount--;
                    }

                    res = (res + arr.SingleCount) % mod;
                }
            }

            return res;
        }

        class Item
        {
            public int[] Exists { get; set; }
            public int SingleCount { get; set; }
            public int RepetitionCount { get; set; }
            public bool Skip { get; set; }
        }

    }
}
