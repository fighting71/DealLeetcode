using Command.Attr;
using Command.Const;
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
    //[Obsolete("对于多出来的部分复用no thinking")]
    [Obsolete("time limit")]
    [Serie(FlagConst.Complex)]
    public class Count_The_Repetitions
    {

        // Constraints:

        //1 <= s1.length, s2.length <= 100
        //s1 and s2 consist of lowercase English letters.
        //1 <= n1, n2 <= 10^6

        #region other solution

        // source: https://leetcode.com/problems/count-the-repetitions/discuss/95408/Easy-understanding-Java-Solution-with-detailed-explanation-21ms!

        // Try4 使用的方案就是这种，但未到达这种程度...  az 懒得优化了.
        public int getMaxRepetitions(String s1, int n1, String s2, int n2)
        {
            if (!ableToObtain(s1, s2)) return 0; // check if [s1. ∞] obtains s2
            int cnt = 0, k = -1;
            String s = s1;
            StringBuilder remainBuilder; // record `remain string`
            List<String> stringList = new List<string>(); // record all the `remain string`
            List<int> countList = new List<int>(); // record matching count from start to the current remain string 
            stringList.Add(""); // record empty string
            countList.Add(0);
            for (int i = 0; i <= n1; i++)
            {
                remainBuilder = new StringBuilder();
                cnt += getRemain(s, s2, remainBuilder); // get the next remain string, returns the count of matching
                String remain = remainBuilder.ToString();
                if ((k = stringList.IndexOf(remain)) != -1) break; // if there is a loop, break
                stringList.Add(remain); // record the remain string into arraylist 
                countList.Add(cnt);
                s = remain + s1; // append s1 to make a new string
            }
            // here, k is the beginning of the loop
            if (k == -1) return cnt / n2; // if there is no loop
            int countOfLoop = cnt - countList[k], loopLength = stringList.Count - k; // get matching count in the loop, and loop length
            cnt = countList[k];
            n1 -= k;
            cnt += countOfLoop * (n1 / loopLength);
            n1 %= loopLength;
            cnt += countList[k + n1] - countList[k];
            return cnt / n2;
        }

        // check if [s1. ∞] obtains s2
        private bool ableToObtain(String s1, String s2)
        {
            bool[] cnt = new bool[26];
            foreach (char c in s1.ToCharArray()) cnt[c - 'a'] = true;
            foreach (char c in s2.ToCharArray())
            {
                if (!cnt[c - 'a']) return false;
            }
            return true;
        }

        // get remain string after s1 obtains s2, return the matching count
        private int getRemain(String s1, String s2, StringBuilder remain)
        {
            int cnt = 0, lastMatch = -1, p2 = 0;
            for (int p1 = 0; p1 < s1.Length; p1++)
            {
                if (s1[p1] == s2[p2])
                {
                    if (++p2 == s2.Length)
                    {
                        p2 = 0;
                        cnt++;
                        lastMatch = p1;
                    }
                }
            }
            remain.Append(s1.Substring(lastMatch + 1));
            return cnt;
        }
        #endregion

        // time limit
        public int Try4(string s1, int n1, string s2, int n2)
        {

            List<int>[] indexArr = new List<int>[26];

            for (int i = 0; i < indexArr.Length; i++)
            {
                indexArr[i] = new List<int>();
            }

            for (int i = 0; i < s1.Length; i++)
            {
                indexArr[s1[i] - 'a'].Add(i);
            }

            Dictionary<int, int> cache = new Dictionary<int, int>();
            int curr = -1, use = 1, match = 0;
            List<int> list;
            while (true)
            {
                for (int i = 0; i < n2; i++)
                {
                    for (int j = 0; j < s2.Length; j++)
                    {
                        var c = s2[j];
                        list = indexArr[c - 'a'];
                        if (list.Count == 0) return 0;
                        if (curr >= list[list.Count - 1])
                        {
                            if (i == 0 && j == 0)
                            {
                                int remind = n1 % use;
                                int remindMatch = 0;
                                foreach (var item in cache)
                                {
                                    if (item.Key > remind) break;
                                    remindMatch = item.Value;
                                }

                                return remindMatch + (n1 / use) * match;
                            }
                            else if (use == n1)
                            {
                                return match;
                            }
                            curr = list[0];
                            use++;
                            continue;
                        }

                        bool find = false;
                        foreach (var item in list)
                        {
                            if (item > curr)
                            {
                                curr = item;
                                find = true;
                                break;
                            }
                        }
                        if (!find)
                        {
                            return 0;
                        }
                    }
                }
                match++;
                cache[use] = match;
            }

        }

        // bug ： 不能任意改变顺序
        public int Try3(string s1, int n1, string s2, int n2)
        {
            int[] countArr2 = new int[26];

            foreach (var c in s2)
            {
                countArr2[c - 'a']++;
            }

            int[] countArr = new int[26];
            foreach (var c in s1)
            {
                countArr[c - 'a']++;
            }

            var res = int.MaxValue;

            for (int i = 0; i < 26; i++)
            {
                int have = countArr[i], need = countArr2[i];

                if (need == 0) continue;
                if (have == 0) return 0;
                res = Math.Min((have * n1) / (need * n2), res);
            }
            return res;

        }
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
                if (flag)
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
