using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2020 2:19:43 PM
    /// @source : https://leetcode.com/problems/substring-with-concatenation-of-all-words/
    /// @des : 这题确实奇怪，没有容易想到的便捷方案。
    /// </summary>
    public class FindSubstring
    {

        // 1 <= s.length <= 10^4
        // s consists of lower-case English letters.
        // 1 <= words.length <= 5000
        // 1 <= words[i].length <= 30
        // words[i] consists of lower-case English letters.

        // Runtime: 696 ms, faster than 82.30% of C# online submissions for Substring with Concatenation of All Words.
        // Memory Usage: 34.9 MB, less than 8.85% of C# online submissions for Substring with Concatenation of All Words.
        // 嗯？ 实话实说 复杂，还必须考虑数据量
        public IList<int> Optimize2(string s, string[] words)
        {

            IList<int> res = new List<int>();

            int[] arr = new int[26];
            // *** 核心点
            //  a.减少每次都遍历所有words
            //  b.考虑到words存在重复项，避免重复项重复递归...
            Dictionary<string,int>[] canJump = new Dictionary<string,int>[26];
            for (int i = 0; i < 26; i++)
                canJump[i] = new Dictionary<string, int>();
            int need = 0;

            for (int i = 0; i < words.Length; i++)
            {
                var item = words[i];

                var dic = canJump[item[0] - 'a'];

                if (dic.ContainsKey(item)) dic[item]++;
                else dic[item] = 1;

                need += item.Length;
                foreach (var c in item)
                    arr[c - 'a']++;
            }
            for (int i = 0; i <= s.Length - need; i++)
                if (Help(s.AsSpan(i, need), 0, canJump)) res.Add(i);
            return res;
        }

        private bool Help(ReadOnlySpan<char> span, int index, Dictionary<string, int>[] canJump)
        {
            if (span.Length == index) return true;

            var dic = canJump[span[index] - 'a'];

            foreach (var key in dic.Keys.ToArray())// toarray为了修改dic.
            {
                var value = dic[key];
                if (value == 0) continue;
                bool flag = true;
                for (int j = 1; j < key.Length; j++)
                {
                    if (span[index + j] != key[j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    dic[key]--;
                    bool res = Help(span, index + key.Length, canJump);
                    dic[key]++;
                    if (res) return true;
                }
            }

            return false;
        }

        public IList<int> Optimize(string s, string[] words)
        {

            int[] arr = new int[26];
            List<int>[] canJump = new List<int>[26];
            for (int i = 0; i < 26; i++)
            {
                canJump[i] = new List<int>();
            }
            int need = 0;

            for (int i = 0; i < words.Length; i++)
            {
                var item = words[i];
                canJump[item[0] - 'a'].Add(i);
                need += item.Length;
                foreach (var c in item)
                {
                    arr[c - 'a']++;
                }
            }

            IList<int> res = new List<int>();
            bool[] used = new bool[words.Length];
            for (int i = 0; i < s.Length - need; i++)
            {
                ReadOnlySpan<char> span = s.AsSpan(i, need);

                Console.WriteLine("eachI");
                int[] item = new int[26];

                bool flag = true;
                foreach (var c in span)
                {
                    var index = c - 'a';
                    item[index]++;
                    if(item[index] > arr[index])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag && Help(span, 0, words, used, canJump)) res.Add(i);

            }
            return res;
        }

        // 耗时太长.
        private bool Help(ReadOnlySpan<char> span, int index, string[] words, bool[] used, List<int>[] canJump)
        {
            Console.WriteLine("Help");
            if (span.Length == index) return true;

            foreach (var i in canJump[span[index]-'a'])
            {
                if (used[i]) continue;
                bool flag = true;
                for (int j = 1; j < words[i].Length; j++)
                {
                    if (span[index + j] != words[i][j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    used[i] = true;
                    bool res = Help(span, index + words[i].Length, words, used, canJump);
                    used[i] = false;
                    if (res) return true;
                }
            }

            return false;
        }


        // time limit
        public IList<int> Try(string s, string[] words)
        {

            int need = 0;

            foreach (var item in words)
            {
                need += item.Length;
            }

            IList<int> res = new List<int>();
            bool[] used = new bool[words.Length];
            for (int i = 0; i < s.Length - need; i++)
            {
                ReadOnlySpan<char> readOnlySpan = s.AsSpan(i, need);
                if (Help(readOnlySpan, 0, words, used)) res.Add(i);
            }

            return res;
        }

        private bool Help(ReadOnlySpan<char> span,int index,string[] words,bool[] used)
        {
            if (span.Length == index) return true;
            for (int i = 0; i < words.Length; i++)
            {
                if (used[i]) continue;

                bool flag = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if(span[index + j] != words[i][j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    used[i] = true;
                    bool res = Help(span, index + words[i].Length, words, used);
                    used[i] = false;
                    if (res) return true;
                }
            }
            return false;
        }

        // time limit
        public IList<int> Simple(string s, string[] words)
        {

            IList<int> list = new List<int>();

            if (words.Length == 0) return list;

            int len = words[0].Length * words.Length;

            if (s.Length < len) return list;

            var flag = new bool[len];

            for (int i = 0; i <= s.Length - len; i++)
            {
                if (Check(s, i, i + len, words, flag)) list.Add(i);
            }

            return list;

        }
       
        private bool Check(string str,int index,int end,string[] words,bool[] flag)
        {

            if (index == end) return true;

            for (int i = 0; i < words.Length; i++)
            {
                if (flag[i]) continue;

                bool check = true;
                var eachI = index;

                for (int j = 0; j < words[i].Length; j++)
                {
                    if (str[eachI++] != words[i][j])
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    flag[i] = true;
                    if (Check(str, eachI, end, words, flag))
                    {
                        flag[i] = false;
                        return true;
                    }
                    flag[i] = false;
                }

            }

            return false;

        }

        // time limit
        public IList<int> Simple2(string s, string[] words)
        {

            IList<int> list = new List<int>();

            if (words.Length == 0) return list;

            int len = words[0].Length * words.Length;

            if (s.Length < len) return list;

            ISet<string> set = new HashSet<string>();

            GetCombination(new List<string>(words), new StringBuilder(), set);

            bool flag;

            for (int i = 0; i <= s.Length - len; i++)
            {
                var span = s.AsSpan(0, i + len);
                foreach (var item in set)
                {
                    flag = true;
                    for (int j = 0; j < len; j++)
                    {
                        if (item[j] != span[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        list.Add(i);
                        break;
                    }
                }

            }

            return list;

        }

        public void GetCombination(List<string> list,StringBuilder builder,ISet<string> set)
        {

            if (list.Count == 0) set.Add(builder.ToString());

            for (int i = 0; i < list.Count; i++)
            {

                var newList = new List<string>(list);
                newList.RemoveAt(i);

                builder.Append(list[i]);

                GetCombination(newList, builder, set);

                builder.Remove(builder.Length - list[i].Length, list[i].Length);

            }
        }

    }
}
