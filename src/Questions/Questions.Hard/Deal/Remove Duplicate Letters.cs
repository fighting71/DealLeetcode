using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/7/2020 11:17:22 AM
    /// @source : https://leetcode.com/problems/remove-duplicate-letters/
    /// @des : 
    /// </summary>
    [Obsolete]
    public class Remove_Duplicate_Letters
    {

        #region other solution

        /// <summary>
        /// source:https://leetcode.com/problems/remove-duplicate-letters/discuss/76768/A-short-O(n)-recursive-greedy-solution
        /// des: 贪婪算法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string OtherSolution(string s)
        {
            int[] cnt = new int[26];
            int pos = 0; // the position for the smallest s[i]
            for (int i = 0; i < s.Length; i++) cnt[s[i] - 'a']++;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < s[pos]) pos = i;
                if (--cnt[s[i] - 'a'] == 0) break;
            }
            return s.Length == 0 ? "" : s[pos] + OtherSolution(s.Substring(pos + 1).Replace("" + s[pos], ""));
        }

        #endregion

        public string Simple(string s)
        {

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }

            Help(dic, -1, s, new StringBuilder());

            return res;

        }

        string res;

        private void Help(Dictionary<char,int> dic,int i,string s,StringBuilder builder)
        {
            i++;
            if (i == s.Length)
            {
                if (res == null || res.CompareTo(builder.ToString()) > 0)
                    res = builder.ToString();
                return;
            }

            if (res?.CompareTo(builder.ToString()) < 0) return;

            if(dic[s[i]] == 0)
            {
                Help(dic, i, s, builder);
                return;
            }else if (dic[s[i]] > 1)
            {
                dic[s[i]]--;
                Help(dic, i, s, builder);
                dic[s[i]]++;
            }
            builder.Append(s[i]);
            var old = dic[s[i]];
            dic[s[i]] = 0;
            Help(dic, i, s, builder);
            dic[s[i]] = old;
            builder.Remove(builder.Length - 1,1);
        }

        public string Solution(string s)
        {

            int len = s.Length;
            bool[] flag = new bool[len];
            int[] place = new int[26];

            // cbacdcbc
            for (int i = 0; i < len; i++)
            {
                var index = s[i] - 'a';

                if(place[index] == 0)
                {
                    place[index] = i + 1;
                }
                else
                {
                    int start = 0;
                    while (true)
                    {
                        start = Get(place, start, index);
                        if(start== -1)
                        {
                            flag[i] = true;
                            break;
                        }

                        if (start > index)
                        {
                            // cdac
                            //if(place[start])
                        }
                        else
                        {
                            if (place[start] > place[index])
                            {
                                flag[place[index]] = true;
                                place[index] = i;
                            }
                        }

                    }

                }

            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if (!flag[i]) builder.Append(s[i]);
            }

            return builder.ToString();

        }

        private int Get(int[] place,int start,int skip)
        {
            for (int j = start; j < 26; j++)
            {
                if (j == skip) continue;
                if (place[j] != 0)
                {
                    return j;
                }
            }
            return -1;
        }

    }
}
