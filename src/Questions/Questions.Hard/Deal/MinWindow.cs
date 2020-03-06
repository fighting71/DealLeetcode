using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/6 11:19:25
    /// @source : https://leetcode.com/problems/minimum-window-substring/
    /// @des : 
    /// </summary>
    [Obsolete]
    public class MinWindow
    {
        
        public string Solution(string s, string t)
        {

            if (s.Length < t.Length) return string.Empty;
            
            IDictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var c in t)
            {
                if (dictionary.ContainsKey(c)) dictionary[c]++;
                else dictionary.Add(c, 1);
            }

            IDictionary<char, IList<int>> searchDictionary = new Dictionary<char, IList<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary.ContainsKey(s[i]))
                {
                    if (searchDictionary.ContainsKey(s[i])) searchDictionary[s[i]].Add(i);
                    else searchDictionary.Add(s[i], new List<int>() {i});
                }
            }

            if (dictionary.Count != searchDictionary.Count) return string.Empty;

            List<int> list = new List<int>();
            List<int[]> area = new List<int[]>();

            foreach (var item in searchDictionary)
            {
                if (item.Value.Count < dictionary[item.Key]) return string.Empty;
                if (item.Value.Count == dictionary[item.Key])
                {
                    list.AddRange(item.Value);
                }
                
            }
            
            return string.Empty;
            
        }

        // time limit
        public string Simple(string s, string t)
        {
            // 将t放入 map中
            IDictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var c in t)
            {
                if (dictionary.ContainsKey(c)) dictionary[c]++;
                else dictionary.Add(c, 1);
            }

            int end = int.MaxValue, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary.ContainsKey(s[i]))// 匹配时
                {
                    var clone = new Dictionary<char, int>(dictionary);
                    int j = i;
                    // 开一个循环去适配 map 
                    for (; j < s.Length && clone.Count > 0; j++)
                    {
                        if (j - i >= end - start) break;
                        if (clone.ContainsKey(s[j]))
                        {
                            if (clone[s[j]] == 1) clone.Remove(s[j]);
                            else clone[s[j]]--;
                        }
                    }

                    // 若适配
                    if (clone.Count == 0)
                    {
                        // 比较与上一次适配的长度
                        if (j - i < end - start)
                        {
                            start = i;
                            end = j; 
                        }
                    }
                    // 未出现适配
                    else if (end == int.MaxValue) return string.Empty;
                }
            }

            if (end == int.MaxValue) return string.Empty;
            
            StringBuilder builder = new StringBuilder();

            for (int i = start; i <= end; i++)
            {
                builder.Append(s[i]);
            }

            return builder.ToString();
        }
        
    }
}