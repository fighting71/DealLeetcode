using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2020 2:19:43 PM
    /// @source : https://leetcode.com/problems/substring-with-concatenation-of-all-words/
    /// @des : 
    /// </summary>
    [Obsolete]
    public class FindSubstring
    {

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
