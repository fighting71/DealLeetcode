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
    public class MinWindow
    {

        // 1 <= s.length, t.length <= 105
        // s and t consist of English letters.

        // Runtime: 100 ms, faster than 75.35% of C# online submissions for Minimum Window Substring.
        // Memory Usage: 27.3 MB, less than 5.14% of C# online submissions for Minimum Window Substring.
        // Dictionary<char, int> 比 int[] 更耗时,不过优化差不多就这样了.
        public string Clear(string s, string t)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach (var c in t)
                if (count.ContainsKey(c)) count[c]++;
                else count[c] = 1;

            IList<int> indexList = new List<int>();

            int start = 0, end = -1,need = t.Length;

            bool flag = true;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (count.ContainsKey(c))
                {
                    if (t.Length == 1) return t;
                    if (flag)
                    {
                        if (count[c] > 0)
                        {
                            if(--need == 0)
                            {
                                end = indexList.Count;
                                flag = false;
                            }
                        }
                        count[c]--;
                    }
                    indexList.Add(i);
                }
            }

            if (end == -1) return string.Empty;
            int prevEnd = end;
            for (int i = 1; i < indexList.Count; i++)
            {
                var c = s[indexList[i - 1]];
                if (++count[c] > 0)
                {
                    var old = prevEnd;
                    for (int j = prevEnd + 1; j < indexList.Count; j++)
                    {
                        var item = s[indexList[j]];
                        count[item]--;
                        if (item == c)
                        {
                            prevEnd = j;
                            break;
                        }
                    }
                    if (prevEnd == old) break;
                    if (indexList[prevEnd] - indexList[i] < indexList[end] - indexList[start])
                    {
                        start = i;
                        end = prevEnd;
                    }
                }
                else if (prevEnd == end)
                    start = i;
                else if (indexList[prevEnd] - indexList[i] < indexList[end] - indexList[start])
                {
                    start = i;
                    end = prevEnd;
                }
            }

            return s.AsSpan(indexList[start], indexList[end] - indexList[start] + 1).ToString();

        }

        // Runtime: 92 ms, faster than 84.75% of C# online submissions for Minimum Window Substring.
        // Memory Usage: 27.4 MB, less than 5.14% of C# online submissions for Minimum Window Substring.
        // omg 真还就弄出来了， nice!
        public string Try2(string s, string t)
        {
            // 存储t的每个字符的数量， 考虑只有字母，maxlen = 26 * 2
            int[] count = new int[26 * 2];

            // 记录t存在哪些字符。
            ISet<char> set = new HashSet<char>();

            foreach (var c in t)
            {
                count[GetNum(c)]++;
                set.Add(c);
            }

            // 记录s中符合t中的字符的所有下标,因为除了这些下标外，其他元素没有比较意义...只是为了占位
            IList<int> indexList = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i])) indexList.Add(i);
            }

            if (indexList.Count < t.Length) return string.Empty;

            // 记录距离最短的start-end
            int start = 0, end = -1;

            { // 首先先找一次
                count[GetNum(s[indexList[start]])]--;
                if (t.Length == 1) return t;
                var need = t.Length;
                for (int i = 1; i < indexList.Count; i++)
                {
                    var num = GetNum(s[indexList[i]]);

                    if (count[num] > 0) need--;

                    count[num]--; // 匹配一个减一个
                    if(need == 1)// 已符合所有需要直接退出
                    {
                        end = i;
                        break;
                    }
                }

            }

            // 没找到
            if (end == -1) return string.Empty;

            // 记录上一次结束的点
            int prevEnd = end;
            // 变化start=>找最短的距离
            for (int i = 1; i < indexList.Count; i++)
            {
                var c = s[indexList[i - 1]];
                /*
                    把上一个加回来  示例 : s = "abca"  t = "abc"  
                    第一次寻找得到: "abc"  
                    第二次则将s[1](b)做为start,从preEnd+1(s[3](a))开始找a【少个a】,*** 有点类似dp/recursion,复用之前的查询结果。
                    从 prevEnd + 1 开始，==》 prevEnd + 1之前的都找过来，没必要重复寻找...
                 */
                if (++count[GetNum(c)]> 0)
                {
                    var old = prevEnd;
                    for (int j = prevEnd + 1; j < indexList.Count; j++)
                    {
                        var item = s[indexList[j]];
                        count[GetNum(item)]--;
                        if(item == c)
                        {
                            prevEnd = j;
                            break;
                        }
                    }
                    if (prevEnd == old) break;
                    if(indexList[prevEnd] - indexList[i] < indexList[end] - indexList[start])
                    {
                        start = i;
                        end = prevEnd;
                    }
                }
                // 不需要寻找，有多余的  示例 : s = "abaca"  t = "abc"  first:abac  second:bac
                else if (prevEnd == end)
                {
                    start = i;
                }
                // 不需要寻找，但需要比较，因为end不一定为prevEnd
                else
                {
                    if (indexList[prevEnd] - indexList[i] < indexList[end] - indexList[start])
                    {
                        start = i;
                        end = prevEnd;
                    }
                }
            }

            return s.AsSpan(indexList[start], indexList[end] - indexList[start] + 1).ToString();

        }

        // bug
        public string Try(string s, string t)
        {
            int[] count = new int[26 * 2];

            ISet<int> set = new HashSet<int>();

            foreach (var c in t)
            {
                var num = GetNum(c);
                count[num]++;
                set.Add(num);
            }

            int start = -1, end = -1;

            for (int i = 0; i <= s.Length - t.Length; i++)
            {
                int num = GetNum(s[i]);
                if(set.Contains(num))
                {
                    if(start == -1)
                    {
                        count[num]--;
                        if (t.Length == 1) return t;
                        end = GetEnd(s, i + 1, count, t.Length - 1);
                        if (end == -1) return string.Empty;
                        start = i;
                    }
                    else
                    {
                        if (++count[GetNum(s[start])] > 0)
                        {
                            var newEnd = GetEnd(s, end + 1, count, 1);
                            if (newEnd == -1) return s.AsSpan(start,end-start).ToString();
                            if(end - start > newEnd - i)
                            {
                                end = newEnd;
                                start = i;
                            }
                        }
                        else
                        {
                            start = i;
                        }
                    }
                }
            }

            if (start == -1) return string.Empty;

            return s.AsSpan(start, end - start).ToString();
        }

        private int GetEnd(string s,int index,int[] count,int need)
        {
            for (int j = index; j <= s.Length - need; j++)
            {
                var num = GetNum(s[j]);

                if (count[num] > 0)
                {
                    if (--need == 0) return j;
                }
                count[num]--;
            }
            return -1;
        }

        // a -> 0
        // A -> 26
        private int GetNum(char c)
        {
            if (c >= 'a') return c - 'a' + 26;
            return c - 'A';
        }

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