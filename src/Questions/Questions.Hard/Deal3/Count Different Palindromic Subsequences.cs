using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 5:04:00 PM
    /// @source : https://leetcode.com/problems/count-different-palindromic-subsequences/
    /// @des : 给定一个字符串S，找出S中不同的非空回文子序列的数量，并以10^9 + 7求模返回该数字。
    /// </summary>
    public class Count_Different_Palindromic_Subsequences
    {

        public const int mod = 1000_000_007;

        // The length of S will be in the range [1, 1000].
        // Each character S[i] will be in the set {'a', 'b', 'c', 'd'}.

        class Item
        {
            public int Same { get; set; }

        }

        // Runtime: 428 ms, faster than 45.45% of C# online submissions for Count Different Palindromic Subsequences.
        // Memory Usage: 75.6 MB, less than 9.09% of C# online submissions for Count Different Palindromic Subsequences.
        // 泪目( Ĭ ^ Ĭ ).
        public int Try4(string S)
        {
            int len = S.Length;

            int[][][] dp = new int[len][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[len][];
            }

            for (int i = 0; i < len; i++)
            {
                var arr = new int[4];
                arr[S[i] - 'a'] = 1;
                dp[i][i] = arr;
            }

            var emptyArr = new int[4];

            for (int wid = 1; wid < len; wid++)
            {
                for (int l = 0; l < len - wid; l++)
                {
                    var r = l + wid;
                    int lKey = S[l] - 'a', rKey = S[r] - 'a';
                    var inner = dp[l + 1][r - 1] ?? emptyArr;

                    int[] arr = new int[4];
                    if (lKey != rKey)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == lKey || i == rKey) continue;
                            arr[i] = inner[i];
                        }
                        arr[rKey] = 1;
                        arr[lKey] = 1;
                        for (int i = l + 1; i < r; i++)
                        {
                            if(S[i] -'a' == rKey)
                            {
                                arr[rKey] = dp[i][r][rKey];
                                break;
                            }
                        }

                        for (int i = r - 1; i > l; i--)
                        {
                            if (S[i] - 'a' == lKey)
                            {
                                arr[lKey] = dp[l][i][lKey];
                                break;
                            }
                        }
                    }
                    else
                    {
                        int sum = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == lKey) continue;
                            arr[i] = inner[i];
                            sum = (sum + arr[i]) % mod;
                        }
                        arr[lKey] = (inner[lKey] + 2 + sum) % mod;
                    }
                    dp[l][r] = arr;
                }
            }

            var emp = dp[0][len - 1];
            int res = emp[0];
            for (int i = 1; i < emp.Length; i++)
            {
                res = (res + emp[i]) % mod;
            }

            return res;

        }
        public int Try3(string S)
        {
            int len = S.Length;
            List<int>[] arr = new List<int>[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new List<int>();
            }
            for (int i = 0; i < len; i++)
            {
                var c = S[i];
                arr[c - 'a'].Add(i);
            }
            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            int res = 0;
            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                res += Help(i, i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var c = (char)('a' + i);

                var list = arr[i];

                var s = c + "" + c;

                for (int j = 1; j < list.Count; j++)
                {
                    res += Help(list[j - 1], list[j]);
                }
            }

            // todo: res 中存在着重复的项，如何去重？==>

            return res;

            int Help(int l, int r)
            {
                if (dp[l][r] > 0) return dp[l][r];

                int count = 1;
                if (l == 0 || r == S.Length) return count;
                for (int i = 0; i < arr.Length; i++)
                {
                    var list = arr[i];

                    if (list.Count == 0 || l <= list[0] || r >= list[list.Count - 1]) continue;
                    var c = (char)('a' + i);
                    count += Help(list.Where(u => u < l).Max(), list.Where(u => u > r).Min());
                    count %= mod;
                }
                dp[l][r] = count;
                return count;

            }
        }

        // slow
        public int Try2(string S)
        {
            List<int>[] arr = new List<int>[4];

            ISet<string> set = new HashSet<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new List<int>();
            }

            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                arr[c - 'a'].Add(i);
            }

            Dictionary<(int l, int r), ISet<string>> cache = new Dictionary<(int l, int r), ISet<string>>();
            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                ISet<string> itemSet = Help(i, i);
                foreach (var item in itemSet)
                {
                    set.Add(item + c + item);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var c = (char)('a' + i);

                var list = arr[i];

                for (int j = 1; j < list.Count; j++)
                {
                    ISet<string> itemSet = Help(list[j - 1], list[j]);
                    foreach (var item in itemSet)
                    {
                        set.Add(item + c + c + item);
                    }
                }
            }

            //ShowTools.Show(set.OrderBy(u => u));

            return set.Count % mod;

            ISet<string> Help(int l, int r)
            {
                var key = (l, r);

                if (cache.TryGetValue(key, out var prevList))
                {
                    return prevList;
                }

                ISet<string> set = new HashSet<string>() { string.Empty };
                if (l == 0 || r == S.Length) return set;

                for (int i = 0; i < arr.Length; i++)
                {
                    var list = arr[i];

                    if (list.Count == 0 || l <= list[0] || r >= list[list.Count - 1]) continue;
                    var c = (char)('a' + i);
                    ISet<string> set1 = Help(list.Where(u => u < l).Max(), list.Where(u => u > r).Min());

                    // 此处遍历添加比较耗时...
                    foreach (var item in set1)
                    {
                        set.Add(item + c);
                    }
                }

                cache[key] = set;

                return set;

            }

        }

        public int Try(string S)
        {
            List<int>[] arr = new List<int>[4];

            ISet<string> set = new HashSet<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new List<int>();
            }

            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                arr[c - 'a'].Add(i);
            }

            for (int i = 0; i < S.Length; i++)
            {
                Help(S[i].ToString(), i, i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var c = (char)('a' + i);

                var list = arr[i];

                var s = c + "" + c;

                for (int j = 1; j < list.Count; j++)
                {
                    Help(s, list[j - 1], list[j]);
                }
            }

            return set.Count % mod;

            void Help(string build, int l, int r)
            {
                set.Add(build);
                if (l == 0 || r == S.Length) return;

                for (int i = 0; i < arr.Length; i++)
                {
                    var list = arr[i];

                    if (list.Count == 0 || l <= list[0] || r >= list[list.Count - 1]) continue;
                    var c = (char)('a' + i);
                    Help(c + build + c, list.Where(u => u < l).Max(), list.Where(u => u > r).Min());
                }

            }

        }
        public int Simple(string S)
        {
            ISet<string> set = new HashSet<string>();

            Help(0, string.Empty);

            //ShowTools.Show(set.OrderBy(u=>u));

            return set.Count % mod;

            void Help(int i, string builder)
            {
                if (i == S.Length)
                {
                    if (builder.Length > 0 && IsPalindromic(builder))
                    {
                        set.Add(builder);
                    }
                    return;
                }

                Help(i + 1, builder + S[i]);
                Help(i + 1, builder);
            }

            bool IsPalindromic(string s)
            {
                int l = 0, r = s.Length - 1;
                while (r > l)
                {
                    if (s[l++] != s[r--]) return false;
                }
                return true;
            }

        }


    }
}
