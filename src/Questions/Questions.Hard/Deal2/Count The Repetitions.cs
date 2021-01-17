using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/17/2021 10:40:33 AM
    /// @source : https://leetcode.com/problems/count-the-repetitions/
    /// @des : 
    ///     给定 n个s1 和 n2个s2
    ///     令S1 = n个s1,S2 = n2个s2
    ///     target : S1 = 多少个 S2
    ///     注: abcd = ab (可任意删除)
    ///         abab = 2 * ab 
    /// </summary>
    [Obsolete("对于多出来的部分复用no thinking")]
    public class Count_The_Repetitions
    {


        public int Simple2(string s1, int n1, string s2, int n2)
        {

            ISet<char> set = new HashSet<char>();
            foreach (var c in s2)
            {
                set.Add(c);
            }

            StringBuilder builder = new StringBuilder();

            foreach (var c in s1)
            {
                if (set.Contains(c)) builder.Append(c);
            }

            s1 = builder.ToString();

            int i = 0, j = 0;

            int useS1 = 1, useS2 = 0, res = 0;
            while (true)
            {
                if (useS2 == n2)
                {
                    res++;
                    useS2 = 0;
                }
                if (useS1 > n1) break;
                if (s1[i] == s2[j])
                    j++;
                i++;
                if (i == s1.Length)
                {
                    i = 0;
                    useS1++;
                }
                if (j == s2.Length)
                {
                    j = 0;
                    useS2++;
                }
            }
            return res;
        }

        // time limit
        public int Simple(string s1, int n1, string s2, int n2)
        {
            int i = 0,j = 0;

            int useS1 = 1, useS2 = 0, res = 0;
            while (true)
            {
                if (useS2 == n2)
                {
                    res++;
                    useS2 = 0;
                }
                if (useS1 > n1) break;
                if(s1[i] == s2[j])
                    j++;
                i++;
                if (i == s1.Length)
                {
                    i = 0;
                    useS1++;
                }
                if (j == s2.Length)
                {
                    j = 0;
                    useS2++;
                }
            }
            return res;
        }

        // ("bacaba",3,"abacab",1),
        public int Try2(string s1, int n1, string s2, int n2)
        {

            int cutLen = CutStr(s1);
            n1 *= s1.Length / cutLen;
            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>>();

            for (int i = 0; i < cutLen; i++)
            {
                var c = s1[i];

                if (dic.ContainsKey(c)) dic[c].Add(i);
                else dic[c] = new List<int>() { i };
            }

            cutLen = CutStr(s2);
            n2 *= s2.Length / cutLen;

            int curr = 0, use = 1;
            for (int i = 0; i < cutLen; i++)
            {
                var c = s2[i];
                if (dic.ContainsKey(c))
                {
                    bool flag = false;
                    foreach (var index in dic[c])
                    {
                        if (curr <= index)
                        {
                            curr = index + 1;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        curr = dic[c][0] + 1;
                        use++;
                        if (use * n2 > n1) return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            return n1 / use / n2;

        }

        private int CutStr(string str)
        {
            int len = str.Length;

            for (int wid = 1; wid <= len / 2; wid++)
            {
                if (len % wid != 0) continue;
                bool flag = true;
                for (int i = wid; i < len; i++)
                {
                    if (str[i] != str[i % wid])
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    return wid;
                }
            }
            return len;
        }

        // bug: aaa,4 aaaa,1
        public int Try(string s1, int n1, string s2, int n2)
        {
            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>>();

            for (int i = 0; i < s1.Length; i++)
            {
                var c = s1[i];

                if (dic.ContainsKey(c)) dic[c].Add(i);
                else dic[c] = new List<int>() { i };
            }

            int curr = 0, use = 1;
            foreach (var c in s2)
            {
                if (dic.ContainsKey(c))
                {
                    bool flag = false;
                    foreach (var index in dic[c])
                    {
                        if (curr <= index)
                        {
                            curr = index + 1;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        curr = dic[c][0] + 1;
                        use++;
                        if (use * n2 > n1) return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            return n1 / use / n2;
        }
    }
}
