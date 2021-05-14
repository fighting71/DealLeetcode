using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/14/2021 3:24:40 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/598/week-1-may-1st-may-7th/3728/
    /// @des : 
    ///     设计一种特殊的词典，用一些单词通过前缀和后缀搜索其中的单词。
    ///     实现WordFilter类:
    ///     WordFilter(string[] words)使用字典中的单词初始化对象。
    ///     f(string prefix, string suffix)返回单词在字典中的索引，该索引包含前缀prefix和后缀suffix。如果有效索引不止一个，则返回其中最大的索引。如果字典中没有这样的单词，则返回-1。
    /// </summary>
    [Optimize(FlagConst.Slow, FlagConst.Complex)]
    public class Prefix_and_Suffix_Search
    {

        // Constraints:
        //1 <= words.length <= 15000
        //1 <= words[i].length <= 10
        //1 <= prefix.length, suffix.length <= 10
        //words[i], prefix and suffix consist of lower-case English letters only.
        //At most 15000 calls will be made to the function f.

        public interface IWork
        {
            int F(string prefix, string suffix);
        }

        public abstract class Base
        {
            public Base(string[] words) { }
        }

        // Runtime: 1144 ms
        // Memory Usage: 58.4 MB

        // Your runtime beats 35.64 %
        public class Try : Base, IWork
        {
            private readonly string[] words;
            public Try(string[] words) : base(words)
            {
                this.words = words;
                dic = new Dictionary<string, int>();

                for (int i = words.Length - 1; i >= 0; i--)
                {
                    var curr = words[i];

                    if (dic.ContainsKey(curr)) continue;

                    dic[curr] = i;

                    for (int l = 1; l < curr.Length - 1; l++)
                    {
                        for (int r = l + 1; r < curr.Length; r++)
                        {
                            var key = curr.AsSpan(0, l).ToString() + "*" + curr.AsSpan(r).ToString();

                            if (!dic.ContainsKey(key))
                                dic[key] = i;
                        }
                    }

                }

            }
            Dictionary<string, int> dic;

            Dictionary<string, int> resDic = new Dictionary<string, int>();

            public int F(string prefix, string suffix)
            {

                var key = prefix + "*" + suffix;

                int res = -1, v;

                if (resDic.TryGetValue(key, out v)) return v;

                if (dic.TryGetValue(prefix + suffix, out v)) res = Math.Max(res, v);
                if (dic.TryGetValue(key, out v)) res = Math.Max(res, v);

                // 注释后： Your runtime beats 39.45 % 差别不大...
                //int minLen = Math.Min(prefix.Length, suffix.Length);
                //for (int i = 0; i < minLen; i++) // 中间重合
                //{
                //    if (prefix[prefix.Length - 1 - i] != suffix[i]) break;
                //    if (dic.TryGetValue(prefix + suffix.AsSpan(i + 1).ToString(), out v)) res = Math.Max(res, v);
                //}

                // 全匹配
                if (prefix.EndsWith(suffix))
                {
                    if (dic.TryGetValue(prefix, out v)) res = Math.Max(res, v);
                }// 全匹配
                else if (suffix.StartsWith(prefix))
                {
                    if (dic.TryGetValue(suffix, out v)) res = Math.Max(res, v);
                }

                // todo:优化 ==> 中间部分匹配
                for (int i = 1; i < prefix.Length; i++)
                {
                    bool same = true;
                    for (int j = 0; j < suffix.Length && i + j < prefix.Length; j++)
                    {
                        if (prefix[i + j] != suffix[j])
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same)
                    {
                        if (dic.TryGetValue(prefix.AsSpan(0, i).ToString() + suffix, out v)) res = Math.Max(res, v);
                    }
                }

                return resDic[prefix + suffix] = res;

            }
        }

        // time limit
        public class WordFilter
        {

            private readonly string[] words;
            public WordFilter(string[] words)
            {
                this.words = words;
            }

            public int F(string prefix, string suffix)
            {
                var maxLen = Math.Max(prefix.Length, suffix.Length);
                for (int i = words.Length - 1; i >= 0; i--)
                {
                    var curr = words[i];

                    if (curr.Length < maxLen) continue;

                    bool match = true;
                    for (int j = 0; j < prefix.Length; j++)
                    {
                        if (prefix[j] != curr[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (!match) continue;

                    for (int j = 0; j < suffix.Length; j++)
                    {
                        if (suffix[suffix.Length - 1 - j] != curr[curr.Length - 1 - j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match) return i;
                }

                return -1;
            }
        }

    }
}
