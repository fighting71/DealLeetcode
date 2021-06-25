using Command.Attr;
using Command.Const;
using Command.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/25/2021 11:25:10 AM
    /// @source : https://leetcode.com/problems/k-similar-strings/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.DFS, FlagConst.Complex)]
    [Optimize("使用其他方式代替字符串去重？")]
    public class K_Similar_Strings
    {

        // Constraints:

        //1 <= s1.length <= 20
        //s2.length == s1.length
        //s1 and s2 contain only lowercase letters from the set {'a', 'b', 'c', 'd', 'e', 'f'}.
        //s2 is an anagram of s1.

        Dictionary<(string,string), int> cache = new Dictionary<(string, string), int>();

        // Runtime: 1016 ms, faster than 10.34% of C# online submissions for K-Similar Strings.
        // Memory Usage: 42.7 MB, less than 13.79% of C# online submissions for K-Similar Strings.
        // slow
        // ... dfs
        public int Try4(string s1, string s2)
        {

            var test = new string(s1.OrderBy(u => u).ToArray());
            var test2 = new string(s2.OrderBy(u => u).ToArray());

            if(test != test2)
            {
                return int.MaxValue;
            }

            if (cache.TryGetValue((s1,s2), out int v)) return v;

            int len = s1.Length;

            bool[] used = new bool[len];

            List<int> list = new List<int>(len);

            int res = 0;

            for (int i = 0; i < len; i++)
            {
                if (s1[i] == s2[i] || used[i]) continue;

                for (int j = 0; j < len; j++)
                {
                    if (used[j]) continue;
                    if(s1[i] == s2[j] && s1[j] == s2[i])
                    {
                        used[i] = used[j] = true;
                        res++;
                        break;
                    }
                }
                if (!used[i]) list.Add(i);
            }

            if (list.Count == 0) return res;

            int min = int.MaxValue;

            string test3, test4;

            for (int prev = 0; prev < list.Count; prev++)
            {
                var i = list[prev];
                for (int next = prev + 1; next < list.Count; next++)
                {
                    var j = list[next];

                    if (s1[i] == s2[j])
                    {
                        var vs = new List<int>(list);
                        vs[prev] = vs[next];
                        vs.RemoveAt(next);

                        string newStr = new string(vs.Select(u => s1[u]).ToArray());

                        string newStr2 = new string(list.Where(u => u != j).Select(u => s2[u]).ToArray());

                        var inner = 1 + Try4(newStr, newStr2);

                        if(inner <min)
                        {
                            test3 = newStr;
                            test4 = newStr2;
                        }

                        min = Math.Min(min, inner);

                    }
                    else if (s1[j] == s2[i])
                    {
                        var vs = new List<int>(list);
                        vs[next] = vs[prev];
                        vs.RemoveAt(prev);

                        string newStr = new string(vs.Select(u => s1[u]).ToArray());

                        string newStr2 = new string(list.Where(u => u != i).Select(u => s2[u]).ToArray());

                        var inner = 1 + Try4(newStr, newStr2);

                        if (inner < min)
                        {
                            test3 = newStr;
                            test4 = newStr2;
                        }

                        min = Math.Min(min, inner);
                    }

                }
            }

            if(s1 == "bedeafedafca" ||
                s1 == "baedfca"
                || s1 == "beaedfca"
                )
            {

            }

            return cache[(s1,s2)] = res + min;
        }

        // slow
        public int Try3(string s1, string s2)
        {

            int len = s1.Length;

            StringBuilder curr = new StringBuilder(), target = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if(s1[i] != s2[i])
                {
                    curr.Append(s1[i]);
                    target.Append(s2[i]);
                }
            }
            if (curr.Length == 0) return 0;

            int res = 0;

            Stack<(string curr,string target)> stack = new Stack<(string curr, string target)>(), next = new Stack<(string curr, string target)>();

            ISet<string> visited = new HashSet<string>() { curr.ToString() };

            stack.Push((curr.ToString(), target.ToString()));

            BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
            {

                string str = curr.curr, str2 = curr.target;

                ReadOnlySpan<char> span = str.AsSpan(), span2 = str2.AsSpan();

                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {

                        bool match = str[i] == str2[j], match2 = str[j] == str2[i];

                        if (!(match || match2)) continue;

                        List<char> list = str.ToList(),list2 = str2.ToList();

                        if(match && match2)
                        {
                            if (list.Count == 2) return true;
                            list.RemoveAt(j);
                            list.RemoveAt(i);
                            list2.RemoveAt(j);
                            list2.RemoveAt(i);
                        }
                        else if (match)
                        {
                            list[i] = list[j];
                            list.RemoveAt(j);
                            list2.RemoveAt(j);
                        }
                        else
                        {

                            list[j] = list[i];
                            list.RemoveAt(i);
                            list2.RemoveAt(i);
                        }

                        var after = new string(list.ToArray());

                        if (visited.Add(after))
                        {
                            next.Push((after, new string(list2.ToArray())));
                        }

                    }
                }
                return false;
            });

            return res;

        }
        public int Try2(string s1, string s2)
        {
            if (s1 == s2) return 0;

            int res = 1;

            Stack<string> stack = new Stack<string>(), next = new Stack<string>();

            ISet<string> visited = new HashSet<string>() { s1 };

            stack.Push(s1);

            BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
            {

                for (int i = 0; i < curr.Length; i++)
                {
                    if (s1[i] == s2[i]) continue;
                    for (int j = i + 1; j < curr.Length; j++)
                    {
                        if (s1[j] != s2[i] || s1[j] == s2[j]) continue;
                        char[] vs = curr.ToCharArray();

                        var t = vs[i];
                        vs[i] = vs[j];
                        vs[j] = t;
                        var after = new string(vs);
                        if (after == s2)
                            return true;
                        if (visited.Add(after))
                        {
                            next.Push(after);
                        }
                    }
                }
                return false;
            });

            return res;

        }

        // time limit
        public int KSimilarity(string s1, string s2)
        {
            if (s1 == s2) return 0;

            int res = 1;

            Stack<string> stack = new Stack<string>(), next = new Stack<string>();

            ISet<string> visited = new HashSet<string>() { s1 };

            stack.Push(s1);

            BfsHelper.Bfs(stack, next, () => { res++; }, (next, curr) =>
            {

                for (int i = 0; i < curr.Length; i++)
                {
                    for (int j = i + 1; j < curr.Length; j++)
                    {
                        char[] vs = curr.ToCharArray();

                        var t = vs[i];
                        vs[i] = vs[j];
                        vs[j] = t;
                        var after = new string(vs);
                        if (after == s2)
                            return true;
                        if (visited.Add(after))
                        {
                            next.Push(after);
                        }
                    }
                }
                return false;
            });

            return res;

        }

    }
}
