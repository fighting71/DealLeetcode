using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Command.Extension;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/21/2021 4:06:39 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3750/
    /// @des : 
    /// </summary>
    public class Find_and_Replace_Pattern
    {

        // Constraints:
        //1 <= pattern.length <= 20
        //1 <= words.length <= 50
        //words[i].length == pattern.length
        //pattern and words[i] are lowercase English letters.

        // 表达式版，不过更加耗时！
        public IList<string> Try3(string[] words, string pattern)
        {

            int len = pattern.Length;

            if (len == 1) return words;
            Expression<Func<string, bool>> func = u => true;

            int[] prevArr = new int[len];
            int[] flag = new int[26];

            for (int i = 0; i < len; i++)
            {
                var c = pattern[i];
                ref int prev = ref flag[c - 'a'];
                // 表达式内不能使用i
                // 因为i会出现栈逃逸（存在委托占用此值变量），当循环结束时，i=len 永远会越界
                int index = i;
                if (prev != 0)
                {
                    int e = prev;
                    // 此处不能使用prev,因为表达式内不能使用ref变量
                    func = func.AndAlso(u => u[index] == u[e - 1]);
                    prevArr[i] = prev;
                }
                else
                {
                    func = func.AndAlso(u => u.Take(index).All(c => c != u[index]));
                }
                prev = i + 1;
            }

            Func<string, bool> func1 = func.Compile();

            return words.Where(u => func1(u)).ToArray();
        }
        // Runtime: 244 ms
        // Memory Usage: 32.1 MB
        // 差不多.
        public IList<string> Try2(string[] words, string pattern)
        {

            int len = pattern.Length;

            if (len == 1) return words;

            int[] flag = new int[26];
            int[] prevArr = new int[len];

            for (int i = 0; i < len; i++)
            {
                var c = pattern[i];
                ref int prev = ref flag[c - 'a'];

                if (prev != 0)
                {
                    prevArr[i] = prev;
                }
                prev = i + 1;
            }

            IList<string> res = new List<string>();

            foreach (var word in words)
            {
                bool[] exists = new bool[26];
                bool match = true;
                for (int i = 0; i < len; i++)
                {
                    var c = word[i];
                    bool e = exists[c - 'a'];
                    int prev = prevArr[i];
                    if (e != (prev != 0))
                    {
                        match = false;
                        break;
                    }
                    if (prev != 0 && word[prev - 1] != c)
                    {
                        match = false;
                        break;
                    }
                    exists[c - 'a'] = true;
                }
                if (match) res.Add(word);
            }

            return res;
        }

        // Runtime: 404 ms
        // Memory Usage: 32 MB
        // slow
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {

            int len = pattern.Length;

            if (len == 1) return words;

            bool[] isNewArr = new bool[len];

            int[] prevSame = new int[len];

            Dictionary<char, int> indexDic = new Dictionary<char, int>();

            for (int i = 0; i < len; i++)
            {
                var c = pattern[i];

                if (indexDic.TryGetValue(c, out var index))
                {
                    prevSame[i] = index;
                }
                else
                {
                    isNewArr[i] = true;
                }
                indexDic[c] = i;
            }

            IList<string> res = new List<string>();

            ISet<char> set = new HashSet<char>();
            foreach (var word in words)
            {
                bool success = true;
                set.Clear();

                for (int i = 0; i < len; i++)
                {
                    var c = word[i];
                    if (isNewArr[i])
                    {
                        if (set.Contains(c))
                        {
                            success = false;
                            break;
                        }
                        set.Add(c);
                    }
                    else
                    {
                        if (c != word[prevSame[i]])
                        {
                            success = false;
                            break;
                        }
                    }
                }
                if (success) res.Add(word);
            }

            return res;


        }

    }
}
