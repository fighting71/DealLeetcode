using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 10:25:57 AM
    /// @source : https://leetcode.com/problems/concatenated-words/
    /// @des :  
    ///     给定一个数组，获取数组中的连接词
    ///     连接词定义：可由数组中的其他单词组成(至少2个 其他单词可无限次使用) 例如:  abcab  = ab + c
    /// </summary>
    [Obsolete("time limit exdl tul tul!>_")]
    public class Concatenated_Words
    {

        // 1 <= words.length <= 10^4
        //0 <= words[i].length <= 1000
        //words[i] consists of only lowercase English letters.
        //0 <= sum(words[i].length) <= 6 * 10^5

        #region other solution
        public List<string> findAllConcatenatedWordsInADict(string[] words)
        {
            List<string> result = new List<string>();
            ISet<string> preWords = new HashSet<string>();
            words = words.OrderBy(u => u.Length).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                if (canForm(words[i], preWords))
                {
                    result.Add(words[i]);
                }
                preWords.Add(words[i]);
            }

            return result;
        }

        private static bool canForm(string word, ISet<string> dict)
        {
            if (dict.Count == 0) return false;
            bool[] dp = new bool[word.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= word.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!dp[j]) continue;
                    if (dict.Contains(word.AsSpan(j, i - j).ToString()))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[word.Length];
        }
        #endregion

        public IList<string> Try5(string[] words)
        {
            IList<string> res = new List<string>();

            Dictionary<string, bool> dic = new Dictionary<string, bool>();

            foreach (var item in words)
            {
                dic[item] = true;
            }

            foreach (var str in words)
            {
                for (int i = 1; i < str.Length; i++)
                {
                    string left = str.AsSpan(0, i).ToString();

                    if (!Helper(left)) continue;

                    string right = str.AsSpan(i, str.Length - i).ToString();

                    if (Helper(right))
                    {
                        res.Add(str);
                        break;
                    }

                }
            }

            bool Helper(string str)
            {
                if (dic.ContainsKey(str)) return dic[str];

                for (int i = 1; i < str.Length; i++)
                {
                    string left = str.AsSpan(0, i).ToString();

                    if (!Helper(left)) continue;

                    string right = str.AsSpan(i, str.Length - i).ToString();

                    if(Helper(right))
                    {
                        dic[str] = true;
                        return true;
                    }

                }
                dic[str] = false;
                return false;
            }

            return res;
        }

        //private bool Helper(string str, int len, int i, string[] words)
        //{
        //    if (i == words.Length)
        //    {
        //        dic[str] = false;
        //        return false;
        //    }

        //    if (str.Length == 0) return true;

        //    //if (dic.ContainsKey(str)) return dic[str];

        //    var item = words[i];

        //    if (item.Length != 0 && item.Length != len && item.Length <= str.Length)
        //    {
        //        for (int j = 0, k = 0, start = 0; j < str.Length && k < item.Length;)
        //        {
        //            if(str[j] == item[k])
        //            {
        //                k++;
        //            }
        //            else
        //            {
        //                k = 0;
        //            }
        //            j++;
        //            if(k == item.Length)
        //            {
        //                var prev = str.AsSpan(start, j - k + 1).ToString();
        //                bool flag = Helper(prev, len, i + 1, words);

        //                if (!flag) break;

        //                dic[prev.ToString()] = true;

        //                var next = str.AsSpan(j, str.Length - j).ToString();
        //                bool flag2 = Helper(next, len, i + 1, words);
        //                dic[next.ToString()] = flag2;
        //                if (flag2)
        //                {
        //                    dic[str] = true;
        //                    return true;
        //                }
        //                k = 0;
        //                start = j;
        //            }

        //        }
        //    }
        //    return Helper(str, len, i + 1, words);
        //}

        public IList<string> Try4(string[] words)
        {
            int[][] count = new int[words.Length][];
            int[] summaryCount = new int[26];
            for (int i = 0; i < words.Length; i++)
            {
                var str = words[i];

                var item = count[i] = new int[26];

                foreach (var c in str)
                {
                    var key = c - 'a';
                    summaryCount[key]++;
                    item[key]++;
                }

            }

            string[] sortArr = words.OrderBy(u => u.Length).ToArray();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            IList<string> res = new List<string>();
            for (int i = 0; i < sortArr.Length; i++)
            {
                dic[sortArr[i].Length] = i;
            }

            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;

                bool skip = false;
                var itemCount = count[i];
                for (int j = 0; j < 26; j++)
                {
                    if(itemCount[j] != 0 && summaryCount[j] - itemCount[j] == 0)
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip) continue;

                if (Helper(words[i], 0, words, dic))
                {
                    res.Add(words[i]);
                }
            }

            return res;

        }

        public IList<string> Try3(string[] words)
        {

            string[] sortArr = words.OrderBy(u => u.Length).ToArray();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            IList<string> res = new List<string>();
            for (int i = 0; i < sortArr.Length; i++)
            {
                dic[sortArr[i].Length] = i;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                if (Helper(words[i], 0, words, dic))
                {
                    res.Add(words[i]);
                }
            }

            return res;

        }
        private bool Helper(string str, int index, string[] words, Dictionary<int, int> dic)
        {
            if (index == str.Length) return true;

            var key = str.Length - index;

            if (dic.ContainsKey(key))
            {
                var max = dic[key];
                for (int i = max; i >= 0; i--)
                {
                    var item = words[i];
                    if (str.Length - index < item.Length || str.Length == item.Length) continue;

                    bool flag = true;
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (str[index + j] != item[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (Helper(str, index + item.Length, words, dic)) return true;
                    }
                }
            }

            return false;
        }

        // time limit
        public IList<string> Try2(string[] words)
        {
            Dictionary<char, ISet<string>> dic = new Dictionary<char, ISet<string>>();

            foreach (var item in words)
            {
                if (item.Length == 0) continue;
                var key = item[0];
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(item);
                }
                else
                {
                    dic[key] = new HashSet<string>() { item };
                }
            }

            foreach (var key in dic.Keys.ToArray())
            {
                dic[key] = dic[key].OrderByDescending(u => u.Length).ToHashSet();
            }

            IList<string> res = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                if (Helper(words[i], 0, dic))
                {
                    res.Add(words[i]);
                }
            }

            return res;
        }

        private bool Helper(string str, int index, Dictionary<char, ISet<string>> dic)
        {
            if (index == str.Length) return true;

            if (dic.ContainsKey(str[index]))
                foreach (var item in dic[str[index]])
                {
                    if (item == str) continue;
                    if (str.Length - index < item.Length) continue;

                    bool flag = true;
                    for (int j = 1; j < item.Length; j++)
                    {
                        if (str[index + j] != item[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (Helper(str, index + item.Length, dic)) return true;
                    }
                }
            return false;
        }

        // time limit
        public IList<string> Try(string[] words)
        {
            Dictionary<char, ISet<int>> dic = new Dictionary<char, ISet<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                var key = words[i][0];
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(i);
                }
                else
                {
                    dic[key] = new HashSet<int>() { i };
                }
            }

            IList<string> res = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                if (Helper(words[i], 0, words, i, dic))
                {
                    res.Add(words[i]);
                }
            }

            return res;
        }

        private bool Helper(string str, int index, string[] words, int skip, Dictionary<char, ISet<int>> dic)
        {
            if (index == str.Length) return true;

            if (dic.ContainsKey(str[index]))
                foreach (var i in dic[str[index]])
                {
                    if (i == skip) continue;
                    var item = words[i];
                    if (str.Length - index < item.Length) continue;

                    bool flag = true;
                    for (int j = 1; j < item.Length; j++)
                    {
                        if (str[index + j] != item[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (Helper(str, index + item.Length, words, skip, dic)) return true;
                    }
                }
            return false;
        }

        public IList<string> Simple(string[] words)
        {
            IList<string> res = new List<string>();

            bool[] visited = new bool[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                visited[i] = true;
                if (Helper(words[i], 0, words, visited))
                {
                    res.Add(words[i]);
                }
                visited[i] = false;
            }

            return res;
        }

        private bool Helper(string str, int index, string[] words, bool[] visited)
        {
            if (index == str.Length) return true;
            for (int i = 0; i < words.Length; i++)
            {
                if (visited[i]) continue;
                var item = words[i];
                if (str.Length - index < item.Length) continue;

                bool flag = true;
                for (int j = 0; j < item.Length; j++)
                {
                    if (str[index + j] != item[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    visited[i] = true;
                    if (Helper(str, index + item.Length, words, visited)) return true;
                    visited[i] = false;
                }
            }

            return false;
        }

    }
}
